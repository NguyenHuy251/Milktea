using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyQuanTraSua
{
    public partial class GUI_InHoaDonPDF : Form
    {
        private BUS_ChiTietHoaDonBan bus_ChiTietHoaDonBan = new BUS_ChiTietHoaDonBan();
        private BUS_HoaDonNhap bus_HoaDonNhap = new BUS_HoaDonNhap();
        private BUS_BaoCaoDoanhThu bus_BaoCaoDoanhThu = new BUS_BaoCaoDoanhThu();
        private BUS_ChiTietHoaDonNhap bus_ChiTietHoaDonNhap = new BUS_ChiTietHoaDonNhap();

        public GUI_InHoaDonPDF()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var danhSachHoaDonBan = bus_ChiTietHoaDonBan.LayDanhSachHoaDon(null, null, null);
            dgvHoaDonBan.Columns.Clear();
            dgvHoaDonBan.Columns.Add("Id", "ID Hóa Đơn");
            dgvHoaDonBan.Columns.Add("IdBanAn", "Bàn");
            dgvHoaDonBan.Columns.Add("ThoiDiemVao", "Thời Điểm Vào");
            dgvHoaDonBan.Columns.Add("ThoiDiemRa", "Thời Điểm Ra");
            dgvHoaDonBan.Columns.Add("HoTenNhanVien", "Nhân Viên");
            dgvHoaDonBan.Columns.Add("TongTien", "Tổng Tiền");
            foreach (var hd in danhSachHoaDonBan)
            {
                dgvHoaDonBan.Rows.Add(
                    hd.Id, 
                    hd.IdBanAn, 
                    hd.ThoiDiemVao.ToString("dd/MM/yyyy HH:mm:ss"),
                    hd.ThoiDiemRa?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Chưa ra",
                    hd.HoTen, 
                    $"{hd.TongTien:N0} VND"
                );
            }

            var danhSachHoaDonNhap = bus_HoaDonNhap.LayDanhSachHoaDonNhap(null, null, null);
            dgvHoaDonNhap.Columns.Clear();
            dgvHoaDonNhap.Columns.Add("Id", "ID Hóa Đơn");
            dgvHoaDonNhap.Columns.Add("TenNhaCC", "Nhà Cung Cấp");
            dgvHoaDonNhap.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvHoaDonNhap.Columns.Add("TongTien", "Tổng Tiền");
            dgvHoaDonNhap.Columns.Add("HoTenNhanVien", "Nhân Viên");
            foreach (var hd in danhSachHoaDonNhap)
            {
                dgvHoaDonNhap.Rows.Add(
                    hd.IdHoaDonNhap, 
                    hd.TenNhaCC, 
                    hd.NgayNhap.ToString("dd/MM/yyyy"),
                    $"{hd.TongTien:N0} VND", 
                    hd.HoTen
                );
            }

            var danhSachBaoCao = bus_BaoCaoDoanhThu.LayDanhSachBaoCao();
            dgvBaoCaoDoanhThu.Columns.Clear();
            dgvBaoCaoDoanhThu.Columns.Add("Id", "ID");
            dgvBaoCaoDoanhThu.Columns.Add("TuNgay", "Từ Ngày");
            dgvBaoCaoDoanhThu.Columns.Add("DenNgay", "Đến Ngày");
            dgvBaoCaoDoanhThu.Columns.Add("TongSoHoaDonBan", "Tổng HĐ Bán");
            dgvBaoCaoDoanhThu.Columns.Add("TongSoHoaDonNhap", "Tổng HĐ Nhập");
            dgvBaoCaoDoanhThu.Columns.Add("TongDoanhThuBan", "Tổng Doanh Thu Bán");
            dgvBaoCaoDoanhThu.Columns.Add("TongChiPhiNhap", "Tổng Chi Phí Nhập");
            dgvBaoCaoDoanhThu.Columns.Add("TongDoanhThu", "Tổng Doanh Thu");
            dgvBaoCaoDoanhThu.Columns.Add("TenNhanVien", "Nhân Viên");

            dgvBaoCaoDoanhThu.Columns["Id"].Width = 40;
            dgvBaoCaoDoanhThu.Columns["TuNgay"].Width = 70;
            dgvBaoCaoDoanhThu.Columns["DenNgay"].Width = 70;
            dgvBaoCaoDoanhThu.Columns["TongSoHoaDonBan"].Width = 90;
            dgvBaoCaoDoanhThu.Columns["TongSoHoaDonNhap"].Width = 90;
            dgvBaoCaoDoanhThu.Columns["TongDoanhThuBan"].Width = 130;
            dgvBaoCaoDoanhThu.Columns["TongChiPhiNhap"].Width = 130;
            dgvBaoCaoDoanhThu.Columns["TongDoanhThu"].Width = 130;
            dgvBaoCaoDoanhThu.Columns["TenNhanVien"].Width = 150;

            foreach (var baoCao in danhSachBaoCao)
            {
                dgvBaoCaoDoanhThu.Rows.Add(
                    baoCao.Id,
                    baoCao.TuNgay.ToString("dd/MM/yyyy"),
                    baoCao.DenNgay.ToString("dd/MM/yyyy"),
                    baoCao.TongSoHoaDonBan,
                    baoCao.TongSoHoaDonNhap,
                    $"{baoCao.TongDoanhThuBan:N0} VND",
                    $"{baoCao.TongChiPhiNhap:N0} VND",
                    $"{baoCao.TongDoanhThu:N0} VND",
                    baoCao.TenNhanVien
                );
            }
        }

        private void GUI_InHoaDonPDF_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExportHoaDonBanPDF_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn bán để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvHoaDonBan.SelectedRows[0].Cells["Id"].Value);
            var idBanAn = Convert.ToInt32(dgvHoaDonBan.SelectedRows[0].Cells["IdBanAn"].Value);
            var hoaDonBan = bus_ChiTietHoaDonBan.LayDanhSachHoaDon(null, null, null).FirstOrDefault(hd => hd.Id == id);
            if (hoaDonBan == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn bán để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietList = bus_ChiTietHoaDonBan.LayChiTietHoaDonTheoIdHoaDon(id); 
            if (chiTietList == null || chiTietList.Count == 0)
            {
                MessageBox.Show($"Không có chi tiết hóa đơn để xem trước (ID Hóa Đơn: {id}, ID Bàn: {idBanAn}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            float giamGia = 0;
            float tongTienSauGiamGia = hoaDonBan.TongTien;
            int idNhanVien = hoaDonBan.IdNhanVien;

            GUI_InHoaDonBan formPreview = new GUI_InHoaDonBan(hoaDonBan, chiTietList, tongTienSauGiamGia, giamGia, idNhanVien);
            formPreview.ShowDialog();
        }

        private void btnExportHoaDonNhapPDF_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn nhập để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvHoaDonNhap.SelectedRows[0].Cells["Id"].Value);
            var hoaDonNhap = bus_HoaDonNhap.LayDanhSachHoaDonNhap(null, null, null).FirstOrDefault(hd => hd.IdHoaDonNhap == id);
            if (hoaDonNhap == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nhập để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietList = bus_ChiTietHoaDonNhap.LayChiTietHoaDonNhapTheoId(id);
            if (chiTietList == null || chiTietList.Count == 0)
            {
                MessageBox.Show("Không có chi tiết hóa đơn nhập để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridView dgvTemp = new DataGridView();
            dgvTemp.AllowUserToAddRows = false; // Tắt hàng rỗng tự động
            dgvTemp.Columns.Add("TenNguyenLieu", "Tên Nguyên Liệu");
            foreach (var chiTiet in chiTietList)
            {
                var tenNguyenLieu = bus_HoaDonNhap.LayTenNguyenLieuTheoId(chiTiet.IdNguyenLieu);
                System.Diagnostics.Debug.WriteLine($"Tên nguyên liệu (ID {chiTiet.IdNguyenLieu}): {tenNguyenLieu}");
                if (string.IsNullOrEmpty(tenNguyenLieu))
                {
                    tenNguyenLieu = "Không xác định";
                }
                dgvTemp.Rows.Add(tenNguyenLieu);
            }

            GUI_InHoaDonNhap formPreview = new GUI_InHoaDonNhap(hoaDonNhap, chiTietList, dgvTemp);
            formPreview.ShowDialog();
        }

        private void btnExportBaoCaoDoanhThuPDF_Click(object sender, EventArgs e)
        {
            if (dgvBaoCaoDoanhThu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một báo cáo để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvBaoCaoDoanhThu.SelectedRows[0].Cells["Id"].Value);
            var baoCao = bus_BaoCaoDoanhThu.LayDanhSachBaoCao().Find(bc => bc.Id == id);
            if (baoCao == null)
            {
                MessageBox.Show("Không tìm thấy báo cáo để xem trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GUI_InBaoCaoDoanhThu formPreview = new GUI_InBaoCaoDoanhThu(baoCao);
            formPreview.ShowDialog();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
