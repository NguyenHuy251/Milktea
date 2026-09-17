using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using QuanLyQuanTraSua.Resources;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyQuanTraSua
{
    public partial class GUI_BaoCaoDoanhThu : Form
    {
        private BUS_BaoCaoDoanhThu busBaoCao = new BUS_BaoCaoDoanhThu();
        private DTO_BaoCaoDoanhThu baoCaoHienTai;
        public GUI_BaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void GUI_BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            btnXoaBaoCao.Enabled = CurrentUser.LoaiTK == 1; // Chỉ admin được xóa

            LoadDanhSachBaoCao();
        }

        private void LoadDanhSachBaoCao()
        {
            dgvBaoCao.Rows.Clear();
            List<DTO_BaoCaoDoanhThu> dsBaoCao = busBaoCao.LayDanhSachBaoCao();
            foreach (var bc in dsBaoCao)
            {
                dgvBaoCao.Rows.Add(
                    bc.Id,
                    bc.TuNgay.ToString("dd/MM/yyyy"),
                    bc.DenNgay.ToString("dd/MM/yyyy"),
                    bc.TongSoHoaDonBan,
                    bc.TongSoHoaDonNhap,
                    bc.TongDoanhThuBan.ToString("N0"),
                    bc.TongChiPhiNhap.ToString("N0"),
                    bc.TongDoanhThu.ToString("N0"),
                    bc.TenNhanVien,
                    bc.NgayTao.ToString("dd/MM/yyyy HH:mm"),
                    bc.GhiChu
                );
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baoCaoHienTai = busBaoCao.ThongKeDoanhThu(dtpTuNgay.Value, dtpDenNgay.Value);
            if (baoCaoHienTai != null)
            {
                dgvBaoCaoHienTai.Rows.Clear();
                dgvBaoCaoHienTai.Rows.Add(
                    baoCaoHienTai.TuNgay.ToString("dd/MM/yyyy"),
                    baoCaoHienTai.DenNgay.ToString("dd/MM/yyyy"),
                    baoCaoHienTai.TongSoHoaDonBan,
                    baoCaoHienTai.TongSoHoaDonNhap,
                    baoCaoHienTai.TongDoanhThuBan.ToString("N0"),
                    baoCaoHienTai.TongChiPhiNhap.ToString("N0"),
                    baoCaoHienTai.TongDoanhThu.ToString("N0")
                );
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemBaoCao_Click(object sender, EventArgs e)
        {
            if (baoCaoHienTai == null)
            {
                MessageBox.Show("Vui lòng thống kê trước khi thêm báo cáo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CurrentUser.IdNhanVien == 0)
            {
                MessageBox.Show("Không thể xác định nhân viên hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baoCaoHienTai.IdNhanVien = CurrentUser.IdNhanVien;
            baoCaoHienTai.GhiChu = txtGhiChu.Text.Trim();

            if (busBaoCao.ThemBaoCao(baoCaoHienTai))
            {
                var danhSachBaoCao = busBaoCao.LayDanhSachBaoCao();
                var baoCaoMoi = danhSachBaoCao.OrderByDescending(bc => bc.NgayTao).FirstOrDefault();
                if (baoCaoMoi != null)
                {
                    GUI_InBaoCaoDoanhThu formPreview = new GUI_InBaoCaoDoanhThu(baoCaoMoi);
                    formPreview.ShowDialog();

                    MessageBox.Show("Thêm báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm báo cáo thành công nhưng không thể tìm thấy báo cáo để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDanhSachBaoCao();
                btnReset_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn báo cáo cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBaoCao = Convert.ToInt32(dgvBaoCao.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa báo cáo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busBaoCao.XoaBaoCao(idBaoCao))
                    {
                        MessageBox.Show("Xóa báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachBaoCao();
                    }
                    else
                    {
                        MessageBox.Show("Xóa báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xóa báo cáo thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            txtGhiChu.Clear();
            dgvBaoCaoHienTai.Rows.Clear();
            baoCaoHienTai = null;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
