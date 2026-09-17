using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using QuanLyQuanTraSua.Resources;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyQuanTraSua
{
    public partial class GUI_NhapNguyenLieu : Form
    {
        BUS_NhaCungCap bus_nhaCungCap = new BUS_NhaCungCap();
        BUS_HoaDonNhap bus_hoaDonNhap = new BUS_HoaDonNhap();
        BUS_ChiTietHoaDonNhap bus_chiTiet = new BUS_ChiTietHoaDonNhap();
        BUS_KhoNguyenLieu bus_khoNguyenLieu = new BUS_KhoNguyenLieu();

        private List<DTO_ChiTietHoaDonNhap> danhSachNguyenLieu = new List<DTO_ChiTietHoaDonNhap>();
        private List<DTO_KhoNguyenLieu> dsNguyenLieuKho; 
        private List<DTO_NhaCungCap> dsNhaCungCap; 

        public GUI_NhapNguyenLieu()
        {
            InitializeComponent();
        }

        private void LoadNhaCungCap()
        {
            dsNhaCungCap = bus_nhaCungCap.LayDanhSachNhaCungCap();
            cbbNhaCungCap.DataSource = null;
            cbbNhaCungCap.Items.Clear();
            cbbNhaCungCap.DataSource = dsNhaCungCap;
            cbbNhaCungCap.DisplayMember = "TenNhaCC";
            cbbNhaCungCap.ValueMember = "IdNhaCC";
            cbbNhaCungCap.SelectedIndex = -1;
        }

        private void LoadTenNguyenLieu()
        {
            dsNguyenLieuKho = bus_khoNguyenLieu.LayDanhSachNguyenLieuKho();
            cbbTenNguyenLieu.DataSource = null;
            cbbTenNguyenLieu.Items.Clear();
            cbbTenNguyenLieu.DataSource = dsNguyenLieuKho;
            cbbTenNguyenLieu.DisplayMember = "TenNguyenLieu";
            cbbTenNguyenLieu.SelectedIndex = -1; 
        }

        private float CapNhatTongTien()
        {
            float tongTien = 0;
            foreach (var chiTiet in danhSachNguyenLieu)
            {
                tongTien += chiTiet.SoLuong * chiTiet.DonGia;
            }
            txtTongTien.Text = tongTien.ToString(); 
            return tongTien;
        }

        private void GUI_NhapNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            LoadTenNguyenLieu();

            dtpNgayNhap.Value = DateTime.Now;
        }

        private void cbbTenNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenNguyenLieu.SelectedIndex != -1 && cbbTenNguyenLieu.SelectedItem is DTO_KhoNguyenLieu selectedNguyenLieu)
            {
                txtDonViTinh.Text = selectedNguyenLieu.DonViTinh;
                txtGhiChu.Text = selectedNguyenLieu.GhiChu;
            }
            else
            {
                txtDonViTinh.Text = string.Empty;
                txtGhiChu.Text = string.Empty;
            }
        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(cbbTenNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn tên nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtDonViTinh.Text.Length > 50)
            {
                MessageBox.Show("Đơn vị tính không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtGhiChu.Text.Length > 255)
            {
                MessageBox.Show("Ghi chú không được dài quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonGia.Text) || !float.TryParse(txtDonGia.Text, out float donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng chi tiết hóa đơn nhập
            DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
            {
                IdNguyenLieu = -1, 
                DonViTinh = txtDonViTinh.Text,
                SoLuong = soLuong,
                DonGia = donGia,
                GhiChu = txtGhiChu.Text,
            };

            // Thêm vào danh sách
            danhSachNguyenLieu.Add(chiTiet);

            // Hiển thị trên DataGridView (tính Thành Tiền động)
            float thanhTien = soLuong * donGia;
            dgvChiTietNhap.Rows.Add(cbbTenNguyenLieu.Text, chiTiet.DonViTinh, chiTiet.SoLuong, chiTiet.DonGia,chiTiet.GhiChu, thanhTien);

            // Cập nhật tổng tiền
            CapNhatTongTien();

            // Xóa các trường nhập liệu
            cbbTenNguyenLieu.SelectedIndex = -1;
            txtDonViTinh.Clear();
            txtGhiChu.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedIndex = dgvChiTietNhap.SelectedRows[0].Index;
            danhSachNguyenLieu.RemoveAt(selectedIndex);
            dgvChiTietNhap.Rows.RemoveAt(selectedIndex);

            // Cập nhật tổng tiền
            CapNhatTongTien();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbNhaCungCap.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (danhSachNguyenLieu.Count == 0)
            {
                MessageBox.Show("Danh sách nguyên liệu trống. Vui lòng thêm ít nhất một nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CurrentUser.IdNhanVien == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên hiện tại. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idNhaCungCap = -1;
            var nhaCungCap = dsNhaCungCap.FirstOrDefault(ncc => ncc.TenNhaCC.Equals(cbbNhaCungCap.Text, StringComparison.OrdinalIgnoreCase));
            if (nhaCungCap != null)
            {
                idNhaCungCap = nhaCungCap.IdNhaCC;
            }
            else
            {
                DTO_NhaCungCap nhaCungCapMoi = new DTO_NhaCungCap
                {
                    TenNhaCC = cbbNhaCungCap.Text,
                    DiaChi = string.Empty,
                    SoDienThoai = string.Empty,
                    Email = string.Empty
                };
                if (bus_nhaCungCap.ThemNhaCungCap(nhaCungCapMoi))
                {
                    dsNhaCungCap = bus_nhaCungCap.LayDanhSachNhaCungCap();
                    var nhaCungCapVuaThem = dsNhaCungCap.FirstOrDefault(ncc => ncc.TenNhaCC.Equals(cbbNhaCungCap.Text, StringComparison.OrdinalIgnoreCase));
                    if (nhaCungCapVuaThem != null)
                    {
                        idNhaCungCap = nhaCungCapVuaThem.IdNhaCC;
                    }
                    else
                    {
                        throw new Exception("Không thể lấy ID của nhà cung cấp vừa thêm.");
                    }
                }
                else
                {
                    throw new Exception("Không thể thêm nhà cung cấp mới.");
                }
            }

            DTO_HoaDonNhap hoaDon = new DTO_HoaDonNhap
            {
                IdNhaCungCap = idNhaCungCap,
                NgayNhap = dtpNgayNhap.Value,
                TongTien = CapNhatTongTien(),
                IdNhanVien = CurrentUser.IdNhanVien
            };

            int idHoaDonNhap = bus_hoaDonNhap.ThemHoaDonNhap(hoaDon);

            bool allSuccess = true;
            foreach (var chiTiet in danhSachNguyenLieu)
            {
                string tenNguyenLieu = (string)dgvChiTietNhap.Rows[danhSachNguyenLieu.IndexOf(chiTiet)].Cells["TenNguyenLieu"].Value;
                int idNguyenLieu = bus_khoNguyenLieu.LayIdNguyenLieuTheoTen(tenNguyenLieu);
                if (idNguyenLieu == -1)
                {
                    idNguyenLieu = bus_khoNguyenLieu.ThemNguyenLieuMoi(tenNguyenLieu, chiTiet.DonViTinh, txtGhiChu.Text);
                }

                chiTiet.IdNguyenLieu = idNguyenLieu;

                chiTiet.IdHoaDonNhap = idHoaDonNhap;
                if (!bus_chiTiet.ThemChiTietHoaDonNhap(chiTiet))
                {
                    allSuccess = false;
                    break;
                }

                if (!bus_khoNguyenLieu.ThemNguyenLieuVaoKho(idNguyenLieu, chiTiet.SoLuong, chiTiet.DonViTinh))
                {
                    allSuccess = false;
                    break;
                }
            }

            if (allSuccess)
            {
                var hoaDonNhap = bus_hoaDonNhap.LayDanhSachHoaDonNhap(null, null, null).FirstOrDefault(hd => hd.IdHoaDonNhap == idHoaDonNhap);
                if (hoaDonNhap == null)
                {
                    MessageBox.Show("Nhập nguyên liệu thành công nhưng không tìm thấy hóa đơn để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                GUI_InHoaDonNhap formPreview = new GUI_InHoaDonNhap(hoaDonNhap, danhSachNguyenLieu, dgvChiTietNhap);
                formPreview.ShowDialog();

                MessageBox.Show("Nhập nguyên liệu thành công! Dữ liệu đã được lưu vào kho và hóa đơn nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                danhSachNguyenLieu.Clear();
                dgvChiTietNhap.Rows.Clear();
                txtTongTien.Text = "0";
                cbbNhaCungCap.SelectedIndex = -1;
                dtpNgayNhap.Value = DateTime.Now;
                LoadNhaCungCap(); 
                LoadTenNguyenLieu();
            }
            else
            {
                MessageBox.Show("Nhập nguyên liệu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
