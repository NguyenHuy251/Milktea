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

namespace QuanLyQuanTraSua
{
    public partial class GUI_KhoNguyenLieu : Form
    {
        BUS_KhoNguyenLieu bus_khoNguyenLieu = new BUS_KhoNguyenLieu();
        private List<DTO_KhoNguyenLieu> dsNguyenLieuKho;
        public GUI_KhoNguyenLieu()
        {
            InitializeComponent();
        }
        private void PhanQuyen()
        {
            btnSuaNL.Enabled = (CurrentUser.LoaiTK == 1);
            btnXoaNL.Enabled = (CurrentUser.LoaiTK == 1);
            btnResetNL.Enabled = (CurrentUser.LoaiTK == 1);
            txtDonViTinh.ReadOnly = (CurrentUser.LoaiTK != 1);
            txtSoLuongTon.ReadOnly = (CurrentUser.LoaiTK != 1);
            txtGhiChu.ReadOnly = (CurrentUser.LoaiTK != 1);
        }

        private void LoadDanhSachNguyenLieu()
        {
            dsNguyenLieuKho = bus_khoNguyenLieu.LayDanhSachNguyenLieuKho();
            dgvKhoNL.Rows.Clear();
            foreach (var nl in dsNguyenLieuKho)
            {
                dgvKhoNL.Rows.Add(nl.IdKhoNguyenLieu, nl.TenNguyenLieu, nl.DonViTinh, nl.SoLuongTon, nl.GhiChu);
            }
        }

        private void LoadTenNguyenLieu()
        {
            cbbTenNL.DataSource = null;
            cbbTenNL.Items.Clear();
            cbbTenNL.DataSource = dsNguyenLieuKho;
            cbbTenNL.DisplayMember = "TenNguyenLieu";
            cbbTenNL.SelectedIndex = -1;
        }

        private void ResetForm()
        {
            txtIDNguyenLieu.Clear();
            cbbTenNL.SelectedIndex = -1;
            txtDonViTinh.Clear();
            txtSoLuongTon.Clear();
            txtGhiChu.Clear();
            LoadDanhSachNguyenLieu();
        }

        private void GUI_KhoNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachNguyenLieu();
            LoadTenNguyenLieu();
            PhanQuyen();
        }

        private void dgvKhoNL_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhoNL.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhoNL.SelectedRows[0];
                txtIDNguyenLieu.Text = row.Cells[0].Value.ToString();
                cbbTenNL.Text = row.Cells[1].Value.ToString();
                txtDonViTinh.Text = row.Cells[2].Value.ToString();
                txtSoLuongTon.Text = row.Cells[3].Value.ToString();
                txtGhiChu.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnTimNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbTenNL.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dsNguyenLieuTimKiem = bus_khoNguyenLieu.TimKiemNguyenLieuTheoTen(cbbTenNL.Text);
            dgvKhoNL.Rows.Clear();
            foreach (var nl in dsNguyenLieuTimKiem)
            {
                dgvKhoNL.Rows.Add(nl.IdKhoNguyenLieu, nl.TenNguyenLieu, nl.DonViTinh, nl.SoLuongTon, nl.GhiChu);
            }

            if (dsNguyenLieuTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nguyên liệu nào phù hợp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cbbTenNL.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDonViTinh.Text.Length > 50)
            {
                MessageBox.Show("Đơn vị tính không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuongTon.Text) || !int.TryParse(txtSoLuongTon.Text, out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là số không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtGhiChu.Text.Length > 255)
            {
                MessageBox.Show("Ghi chú không được dài quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_KhoNguyenLieu nguyenLieu = new DTO_KhoNguyenLieu
            {
                IdKhoNguyenLieu = int.Parse(txtIDNguyenLieu.Text),
                TenNguyenLieu = cbbTenNL.Text,
                DonViTinh = txtDonViTinh.Text,
                SoLuongTon = soLuongTon,
                GhiChu = txtGhiChu.Text
            };

            if (bus_khoNguyenLieu.CapNhatNguyenLieu(nguyenLieu))
            {
                MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            else
            {
                MessageBox.Show("Cập nhật nguyên liệu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idNguyenLieu = int.Parse(txtIDNguyenLieu.Text);
                if (bus_khoNguyenLieu.XoaNguyenLieu(idNguyenLieu))
                {
                    MessageBox.Show("Xóa nguyên liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Xóa nguyên liệu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetNL_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
