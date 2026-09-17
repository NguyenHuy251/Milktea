using BUS;
using DTO;
using QuanLyQuanTraSua.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class GUI_CongThucMonAn : Form
    {
        private BUS_CongThucMonAn bus_CongThucMonAn = new BUS_CongThucMonAn();
        private DataTable dtMonAn;
        private DataTable dtNguyenLieu;
        public GUI_CongThucMonAn()
        {
            InitializeComponent();
        }

        private void PhanQuyen()
        {
            btnAddCTMA.Enabled = (CurrentUser.LoaiTK == 1);
            btnSuaCTMA.Enabled = (CurrentUser.LoaiTK == 1);
            btnXoaCTMA.Enabled = (CurrentUser.LoaiTK == 1);
            btnResetCTMA.Enabled = (CurrentUser.LoaiTK == 1);
            txtSoLuong.ReadOnly = (CurrentUser.LoaiTK != 1);
            txtDonViTinh.ReadOnly = (CurrentUser.LoaiTK != 1);
            cbbMonAn.Enabled = true; 
            cbbNguyenLieu.Enabled = (CurrentUser.LoaiTK == 1);
        }

        private void LoadMonAn()
        {
            dtMonAn = bus_CongThucMonAn.LayDanhSachMonAn();
            cbbMonAn.DataSource = null;
            cbbMonAn.Items.Clear();
            cbbMonAn.DataSource = dtMonAn;
            cbbMonAn.DisplayMember = "tenMonAn";
            cbbMonAn.ValueMember = "id";
            cbbMonAn.SelectedIndex = -1;
        }

        private void LoadNguyenLieu()
        {
            dtNguyenLieu = bus_CongThucMonAn.LayDanhSachNguyenLieu();
            cbbNguyenLieu.DataSource = null;
            cbbNguyenLieu.Items.Clear();
            cbbNguyenLieu.DataSource = dtNguyenLieu;
            cbbNguyenLieu.DisplayMember = "tenNguyenLieu";
            cbbNguyenLieu.ValueMember = "id";
            cbbNguyenLieu.SelectedIndex = -1;
        }

        private void LoadDanhSachCongThuc(int idMonAn)
        {
            var dsCongThuc = bus_CongThucMonAn.LayDanhSachCongThucMonAn(idMonAn);
            dgvCongThuc.Rows.Clear();
            foreach (var congThuc in dsCongThuc)
            {
                string tenNguyenLieu = dtNguyenLieu.AsEnumerable()
                    .FirstOrDefault(row => row.Field<int>("id") == congThuc.IdNguyenLieu)?
                    .Field<string>("tenNguyenLieu") ?? "Không xác định";
                dgvCongThuc.Rows.Add(congThuc.IdMonAn, congThuc.TenMonAn, congThuc.IdNguyenLieu, tenNguyenLieu, congThuc.SoLuong, congThuc.DonViTinh);
            }
        }

        private void ResetForm()
        {
            cbbMonAn.SelectedIndex = -1;
            cbbNguyenLieu.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonViTinh.Clear();
            dgvCongThuc.Rows.Clear();
        }

        private void GUI_CongThucMonAn_Load(object sender, EventArgs e)
        {
            LoadMonAn();
            LoadNguyenLieu();
            PhanQuyen();
        }

        private void dgvCongThuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count > 0)
            {
                var row = dgvCongThuc.SelectedRows[0];
                cbbNguyenLieu.Text = row.Cells["TenNguyenLieu"].Value?.ToString() ?? string.Empty;
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? string.Empty;
                txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btnAddCTMA_Click(object sender, EventArgs e)
        {
            if (cbbMonAn.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbNguyenLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !float.TryParse(txtSoLuong.Text, out float soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDonViTinh.Text.Length > 50)
            {
                MessageBox.Show("Đơn vị tính không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_CongThucMonAn congThuc = new DTO_CongThucMonAn
            {
                IdMonAn = Convert.ToInt32(cbbMonAn.SelectedValue),
                IdNguyenLieu = Convert.ToInt32(cbbNguyenLieu.SelectedValue),
                SoLuong = soLuong,
                DonViTinh = txtDonViTinh.Text
            };

            if (bus_CongThucMonAn.ThemCongThucMonAn(congThuc))
            {
                MessageBox.Show("Thêm công thức thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachCongThuc(congThuc.IdMonAn);
                txtSoLuong.Clear();
                txtDonViTinh.Clear();
                cbbNguyenLieu.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Thêm công thức thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaCTMA_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công thức để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !float.TryParse(txtSoLuong.Text, out float soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDonViTinh.Text.Length > 50)
            {
                MessageBox.Show("Đơn vị tính không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idMonAn = Convert.ToInt32(dgvCongThuc.SelectedRows[0].Cells["IdMonAn"].Value);
            int idNguyenLieu = Convert.ToInt32(dgvCongThuc.SelectedRows[0].Cells["IdNguyenLieu"].Value);

            DTO_CongThucMonAn congThuc = new DTO_CongThucMonAn
            {
                IdMonAn = idMonAn,
                IdNguyenLieu = idNguyenLieu,
                SoLuong = soLuong,
                DonViTinh = txtDonViTinh.Text
            };

            if (bus_CongThucMonAn.SuaCongThucMonAn(congThuc))
            {
                MessageBox.Show("Sửa công thức thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachCongThuc(idMonAn);
                txtSoLuong.Clear();
                txtDonViTinh.Clear();
                cbbNguyenLieu.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Sửa công thức thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCTMA_Click(object sender, EventArgs e)
        {
            if (cbbMonAn.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một món ăn để xem công thức.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idMonAn;
            if (int.TryParse(cbbMonAn.SelectedValue.ToString(), out idMonAn))
            {
                var dsCongThuc = bus_CongThucMonAn.LayDanhSachCongThucMonAn(idMonAn);
                if (dsCongThuc == null || dsCongThuc.Count == 0)
                {
                    MessageBox.Show("Món ăn này chưa có công thức.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCongThuc.Rows.Clear();
                }
                else
                {
                    LoadDanhSachCongThuc(idMonAn);
                }
            }
        }

        private void btnXoaCTMA_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công thức để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa công thức này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int idMonAn = Convert.ToInt32(dgvCongThuc.SelectedRows[0].Cells["IdMonAn"].Value);
                int idNguyenLieu = Convert.ToInt32(dgvCongThuc.SelectedRows[0].Cells["IdNguyenLieu"].Value);

                if (bus_CongThucMonAn.XoaCongThucMonAn(idMonAn, idNguyenLieu))
                {
                    MessageBox.Show("Xóa công thức thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachCongThuc(idMonAn);
                    txtSoLuong.Clear();
                    txtDonViTinh.Clear();
                    cbbNguyenLieu.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Xóa công thức thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetCTMA_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
