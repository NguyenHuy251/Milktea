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
using System.Data.SqlClient;

namespace QuanLyQuanTraSua
{
    public partial class GUI_Admin : Form
    {
        BUS_Account bus_acc = new BUS_Account();
        BUS_MonAn bus_MonAn = new BUS_MonAn();
        BUS_DanhMuc bus_danhMuc = new BUS_DanhMuc();
        BUS_BanAn bus_banAn = new BUS_BanAn();
        BUS_ChiTietHoaDonBan bus_HoaDon = new BUS_ChiTietHoaDonBan();
        BUS_NhanVien bus_NhanVien = new BUS_NhanVien();
        BUS_NhaCungCap bus_nhaCC = new BUS_NhaCungCap();
        BUS_HoaDonNhap bus_HoaDonNhap = new BUS_HoaDonNhap(); 

        public GUI_Admin()
        {
            InitializeComponent();
        }
        private void GUI_Admin_Load(object sender, EventArgs e)
        {
            loadTK();
            loadDanhMuc();
            loadBanAn();
            LoadDanhSachNhanVien();
            loadDTPK();
            HienThiDanhSachMonAn();
            LoadDanhSachDanhMuc();
            HienThiDanhSachNhanVien();
            HienThiDanhSachNhaCungCap();
        }

        #region THỐNG KÊ
        private void HienThiDanhSachHoaDonBan(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            List<DTO_HoaDonBan> danhSachHoaDon = bus_HoaDon.LayDanhSachHoaDon(tuNgay, denNgay, idNhanVien);
            dgvBill.Rows.Clear();

            float tongDoanhThu = 0;
            foreach (var hoaDon in danhSachHoaDon)
            {
                dgvBill.Rows.Add(
                    hoaDon.Id,
                    hoaDon.IdBanAn,
                    hoaDon.ThoiDiemVao,
                    hoaDon.ThoiDiemRa.HasValue ? hoaDon.ThoiDiemRa.Value.ToString() : "Chưa thanh toán",
                    hoaDon.TongTien,
                    hoaDon.IdNhanVien,
                    hoaDon.HoTen,
                    hoaDon.TrangThaiHD ? "Đã thanh toán" : "Chưa thanh toán"
                );
                tongDoanhThu += hoaDon.TongTien;
            }
            txtTongTien.Text = $"{tongDoanhThu:N0} VNĐ";
        }
        private void HienThiDanhSachHoaDonNhap(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            List<DTO_HoaDonNhap> danhSachHoaDonNhap = bus_HoaDonNhap.LayDanhSachHoaDonNhap(tuNgay, denNgay, idNhanVien);
            dgvBill.Rows.Clear();

            float tongChiPhi = 0;
            foreach (var hoaDon in danhSachHoaDonNhap)
            {
                dgvBill.Rows.Add(
                    hoaDon.IdHoaDonNhap,
                    hoaDon.IdNhaCungCap,
                    hoaDon.TenNhaCC,
                    hoaDon.NgayNhap,
                    hoaDon.TongTien,
                    hoaDon.IdNhanVien,
                    hoaDon.HoTen,
                    "Đã nhập"
                );
                tongChiPhi += hoaDon.TongTien;
            }

            txtTongTien.Text = $"{tongChiPhi:N0} VNĐ";
        }
        void loadDTPK()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            if (!rdoTheoHoaDonBan.Checked && !rdoTheoHoaDonNhap.Checked && !rdoTheoMonAn.Checked)
            {
                MessageBox.Show("Vui lòng chọn chế độ thống kê (Theo hóa đơn bán, Theo hóa đơn nhập hoặc Theo món ăn).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!rdoTheoThoiGian.Checked && !rdoTheoNhanVien.Checked && !rdoNVTG.Checked)
            {
                MessageBox.Show("Vui lòng chọn chế độ lọc (Theo thời gian, Theo nhân viên, hoặc Cả nhân viên và thời gian).\n Nếu thống kê món ăn thì chỉ chọn theo thời gian.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime? tuNgay = null;
            DateTime? denNgay = null;
            int? idNhanVien = null;

            if (rdoTheoThoiGian.Checked || rdoNVTG.Checked || rdoTheoMonAn.Checked)
            {
                tuNgay = dtpkFromDate.Value.Date;
                denNgay = dtpkToDate.Value.Date;

                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if ((rdoTheoNhanVien.Checked || rdoNVTG.Checked) && (rdoTheoHoaDonBan.Checked || rdoTheoHoaDonNhap.Checked))
            {
                if (cbbNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để lọc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                idNhanVien = (int)cbbNhanVien.SelectedValue;
            }

            dgvBill.Columns.Clear();

            // Xử lý khi chọn Theo món ăn
            if (rdoTheoMonAn.Checked)
            {
                if (!rdoTheoThoiGian.Checked && !rdoNVTG.Checked)
                {
                    MessageBox.Show("Vui lòng chọn chế độ lọc theo thời gian để thống kê món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvBill.Columns.Add("IdMonAn", "ID Món Ăn");
                dgvBill.Columns.Add("TenMonAn", "Tên Món Ăn");
                dgvBill.Columns.Add("TenDanhMuc", "Danh Mục");
                dgvBill.Columns.Add("TongSoLuong", "Tổng Số Lượng");
                dgvBill.Columns.Add("TongDoanhThu", "Tổng Doanh Thu");
                dgvBill.Columns.Add("TuNgay", "Từ Ngày");
                dgvBill.Columns.Add("DenNgay", "Đến Ngày");

                List<DTO_ChiTietHoaDonBan> danhSachMonAn = bus_HoaDon.ThongKeMonAnBanDuoc(tuNgay, denNgay);
                float tongDoanhThu = 0;

                foreach (var monAn in danhSachMonAn)
                {
                    dgvBill.Rows.Add(
                        monAn.IdMonAn,
                        monAn.TenMonAn,
                        monAn.TenDanhMuc,
                        monAn.SoLuong,
                        monAn.ThanhTien,
                        tuNgay?.ToString("yyyy-MM-dd"),
                        denNgay?.ToString("yyyy-MM-dd")
                    );
                    tongDoanhThu += monAn.ThanhTien;
                }

                txtTongTien.Text = $"{tongDoanhThu:N0} VNĐ";

                dgvBill.Columns["IdMonAn"].Width = 80;
                dgvBill.Columns["TenMonAn"].Width = 150;
                dgvBill.Columns["TenDanhMuc"].Width = 120;
                dgvBill.Columns["TongSoLuong"].Width = 100;
                dgvBill.Columns["TongDoanhThu"].Width = 100;
                dgvBill.Columns["TuNgay"].Width = 100;
                dgvBill.Columns["DenNgay"].Width = 100;
            }
            else if (rdoTheoHoaDonBan.Checked)
            {
                dgvBill.Columns.Add("Id", "ID HĐ Bán");
                dgvBill.Columns.Add("IdBanAn", "ID Bàn");
                dgvBill.Columns.Add("ThoiDiemVao", "Thời Điểm Vào");
                dgvBill.Columns.Add("ThoiDiemRa", "Thời Điểm Ra");
                dgvBill.Columns.Add("TongTien", "Tổng Tiền");
                dgvBill.Columns.Add("IdNhanVien", "ID Nhân Viên");
                dgvBill.Columns.Add("HoTen", "Họ Tên Nhân Viên");
                dgvBill.Columns.Add("TrangThaiHD", "Trạng Thái");
                HienThiDanhSachHoaDonBan(tuNgay, denNgay, idNhanVien);

                dgvBill.Columns["Id"].Width = 80;
                dgvBill.Columns["IdBanAn"].Width = 80;
                dgvBill.Columns["ThoiDiemVao"].Width = 130;
                dgvBill.Columns["ThoiDiemRa"].Width = 130;
                dgvBill.Columns["TongTien"].Width = 90;
                dgvBill.Columns["IdNhanVien"].Width = 70;
                dgvBill.Columns["HoTen"].Width = 120;
                dgvBill.Columns["TrangThaiHD"].Width = 90;
            }
            else if (rdoTheoHoaDonNhap.Checked)
            {
                dgvBill.Columns.Add("IdHoaDonNhap", "ID HĐ Nhập");
                dgvBill.Columns.Add("IdNhaCungCap", "ID Nhà Cung Cấp");
                dgvBill.Columns.Add("TenNhaCC", "Tên Nhà Cung Cấp");
                dgvBill.Columns.Add("NgayNhap", "Ngày Nhập");
                dgvBill.Columns.Add("TongTien", "Tổng Tiền");
                dgvBill.Columns.Add("IdNhanVien", "ID Nhân Viên");
                dgvBill.Columns.Add("HoTen", "Họ Tên Nhân Viên");
                dgvBill.Columns.Add("TrangThai", "Trạng Thái");
                HienThiDanhSachHoaDonNhap(tuNgay, denNgay, idNhanVien);

                dgvBill.Columns["IdHoaDonNhap"].Width = 80;
                dgvBill.Columns["IdNhaCungCap"].Width = 80;
                dgvBill.Columns["TenNhaCC"].Width = 150;
                dgvBill.Columns["NgayNhap"].Width = 130;
                dgvBill.Columns["TongTien"].Width = 90;
                dgvBill.Columns["IdNhanVien"].Width = 70;
                dgvBill.Columns["HoTen"].Width = 120;
                dgvBill.Columns["TrangThai"].Width = 90;
            }
        }
        private void btnResetDT_Click(object sender, EventArgs e)
        {
            dgvBill.Columns.Clear();
            dgvBill.Rows.Clear();

            loadDTPK();

            cbbNhanVien.SelectedIndex = -1;

            rdoTheoThoiGian.Checked = false;
            rdoTheoNhanVien.Checked = false;
            rdoNVTG.Checked = false;
            rdoTheoHoaDonBan.Checked = false;
            rdoTheoHoaDonNhap.Checked = false;
            rdoTheoMonAn.Checked = false;

            txtTongTien.Text = "0";
        }
        #endregion

        #region QL Món Ăn
        private void HienThiDanhSachMonAn()
        {
            List<DTO_MonAn> danhSachMonAn = bus_MonAn.GetMonAnList();
            dgvMonAn.Rows.Clear();

            foreach (var monAn in danhSachMonAn)
            {
                dgvMonAn.Rows.Add(
                    monAn.IdMonAn,
                    monAn.TenMonAn,
                    monAn.DanhMuc,
                    monAn.Gia
                );
            }
        }

        private void XoaFormMonAn()
        {
            txtFoodID.Clear();
            txtNameFood.Clear();
            txtGia.Clear();
            cbbFoodCategory.SelectedIndex = -1;
        }
        private void dgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonAn.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMonAn.SelectedRows[0];
                txtFoodID.Text = row.Cells["IdMonAn"].Value.ToString();
                txtNameFood.Text = row.Cells["TenMonAn"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();

                // Tìm danh mục trong cbbDanhMuc và chọn
                string tenDanhMuc = row.Cells["DanhMuc"].Value.ToString();
                foreach (DTO_DanhMuc item in cbbFoodCategory.Items)
                {
                    if (item.TenDanhMuc == tenDanhMuc)
                    {
                        cbbFoodCategory.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtNameFood.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Tên món ăn và Giá tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbFoodCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtGia.Text, out int giaTien) || giaTien <= 0)
            {
                MessageBox.Show("Giá tiền phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_MonAn monAn = new DTO_MonAn
            {
                TenMonAn = txtNameFood.Text,
                IdDanhMuc = ((DTO_DanhMuc)cbbFoodCategory.SelectedItem).IdDanhMuc,
                Gia = giaTien
            };

            bool result = bus_MonAn.ThemMonAn(monAn);
            if (result)
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachMonAn(); 
                XoaFormMonAn();
            }
            else
            {
                MessageBox.Show("Thêm món ăn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodID.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNameFood.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin Tên món ăn và Giá tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbFoodCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtGia.Text, out int giaTien) || giaTien <= 0)
            {
                MessageBox.Show("Giá tiền phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_MonAn monAn = new DTO_MonAn
            {
                IdMonAn = Convert.ToInt32(txtFoodID.Text),
                TenMonAn = txtNameFood.Text,
                IdDanhMuc = ((DTO_DanhMuc)cbbFoodCategory.SelectedItem).IdDanhMuc,
                Gia = giaTien
            };

            bool result = bus_MonAn.SuaMonAn(monAn);
            if (result)
            {
                MessageBox.Show("Sửa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachMonAn(); 
                XoaFormMonAn(); 
            }
            else
            {
                MessageBox.Show("Sửa món ăn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodID.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            int idMonAn = Convert.ToInt32(txtFoodID.Text);
            bool result = bus_MonAn.XoaMonAn(idMonAn);
            if (result)
            {
                MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachMonAn(); // Cập nhật lại danh sách món ăn
                XoaFormMonAn(); // Xóa form sau khi xóa
            }
            else
            {
                MessageBox.Show("Xóa món ăn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            List<DTO_MonAn> danhSachMonAn;

            // Lọc món ăn theo danh mục được chọn
            string tenDanhMuc = cbbFoodCategory.Text;
            danhSachMonAn = bus_MonAn.LayMonAnTheoDanhMucList(tenDanhMuc);
            
            dgvMonAn.Rows.Clear();

            foreach (var monAn in danhSachMonAn)
            {
                dgvMonAn.Rows.Add(
                    monAn.IdMonAn,
                    monAn.TenMonAn,
                    monAn.DanhMuc,
                    monAn.Gia
                );
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            HienThiDanhSachMonAn();
            XoaFormMonAn(); 

            txtFoodID.Clear();
            txtNameFood.Clear();
            txtGia.Clear();
        }
        #endregion

        #region QL Danh Mục
        private void LoadDanhSachDanhMuc()
        {
                List<DTO_DanhMuc> danhSachDanhMuc = bus_danhMuc.GetDanhMucList();
                cbbFoodCategory.DataSource = null;
                cbbFoodCategory.Items.Clear();
                cbbFoodCategory.DataSource = danhSachDanhMuc;
                cbbFoodCategory.DisplayMember = "TenDanhMuc";
                cbbFoodCategory.ValueMember = "IdDanhMuc";
                //cbbFoodCategory.SelectedIndex = -1; 
        }
        void loadDanhMuc()
        {
            List<DTO_DanhMuc> danhSachDanhMuc = bus_danhMuc.GetDanhMucList();
            dgvCategory.Rows.Clear();

            foreach (var danhMuc in danhSachDanhMuc)
            {
                dgvCategory.Rows.Add(
                    danhMuc.IdDanhMuc,
                    danhMuc.TenDanhMuc
                );
            }

            if (dgvCategory.Columns.Count > 0)
            {
                dgvCategory.Columns[0].HeaderText = "ID Danh Mục";
                dgvCategory.Columns[0].Width = 100;
                dgvCategory.Columns[1].HeaderText = "Tên Danh Mục";
                dgvCategory.Columns[1].Width = 200;
            }
        }

        private void XoaFormDanhMuc()
        {
            txtCategoryID.Clear();
            txtCategory.Clear();
        }


        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCategory.SelectedRows[0];
                txtCategoryID.Text = row.Cells[0].Value.ToString(); 
                txtCategory.Text = row.Cells[1].Value.ToString();   
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Vui lòng điền tên danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_DanhMuc danhMuc = new DTO_DanhMuc
            {
                TenDanhMuc = txtCategory.Text
            };

            bool result = bus_danhMuc.ThemDanhMuc(danhMuc);
            if (result)
            {
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhMuc(); 
                XoaFormDanhMuc(); 
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCatagory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này? Các món ăn thuộc danh mục này có thể bị ảnh hưởng.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            int idDanhMuc = Convert.ToInt32(txtCategoryID.Text);
            bool result = bus_danhMuc.XoaDanhMuc(idDanhMuc);
            if (result)
            {
                MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhMuc();  
                XoaFormDanhMuc();  
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Vui lòng điền tên danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_DanhMuc danhMuc = new DTO_DanhMuc
            {
                IdDanhMuc = Convert.ToInt32(txtCategoryID.Text),
                TenDanhMuc = txtCategory.Text
            };

            bool result = bus_danhMuc.SuaDanhMuc(danhMuc);
            if (result)
            {
                MessageBox.Show("Sửa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhMuc(); 
                XoaFormDanhMuc();  
            }
        }

        private void btnResetCata_Click(object sender, EventArgs e)
        {
            loadDanhMuc();

            txtCategoryID.Clear();
            txtCategory.Clear();
        }
        #endregion

        #region QL Bàn Ăn
        void loadBanAn(string trangThai = "Tất cả")
        {
            List<DTO_BanAn> danhSachBanAn = bus_banAn.LayDanhSachBanTheoTrangThai(trangThai);
            dgvBanAn.Rows.Clear();

            foreach (var ban in danhSachBanAn)
            {
                dgvBanAn.Rows.Add(
                    ban.IdBanAn,
                    ban.TenBanAn,
                    ban.TrangThai
                );
            }
        }

        private void XoaFormBanAn()
        {
            txtTableID.Clear();
            txtTableName.Clear();
            cbbTableStatus.SelectedIndex = 0;
        }

        private void dgvBanAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBanAn.SelectedRows.Count > 0 && dgvBanAn.Rows.Count > 0)
            {
                DataGridViewRow row = dgvBanAn.SelectedRows[0];
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    txtTableID.Text = row.Cells[0].Value.ToString(); 
                    txtTableName.Text = row.Cells[1].Value.ToString(); 
                    cbbTableStatus.SelectedItem = row.Cells[2].Value.ToString();
                }
                else
                {
                    XoaFormBanAn();
                }
            }
        }

        private void btnAddTable_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Vui lòng điền tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbTableStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_BanAn ban = new DTO_BanAn
            {
                TenBanAn = txtTableName.Text,
                TrangThai = cbbTableStatus.SelectedItem.ToString()
            };

            bool result = bus_banAn.ThemBanAn(ban);
            if (result)
            {
                MessageBox.Show("Thêm bàn ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBanAn(); 
                XoaFormBanAn(); 
            }
            else
            {
                MessageBox.Show("Thêm bàn ăn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Vui lòng điền tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbTableStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_BanAn ban = new DTO_BanAn
            {
                IdBanAn = Convert.ToInt32(txtTableID.Text),
                TenBanAn = txtTableName.Text,
                TrangThai = cbbTableStatus.SelectedItem.ToString()
            };

            try
            {
                bool result = bus_banAn.SuaBanAnKiemTraHoaDon(ban);
                if (result)
                {
                    MessageBox.Show("Sửa bàn ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBanAn();
                    XoaFormBanAn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này? Các hóa đơn liên quan đến bàn này có thể bị ảnh hưởng.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            int idBanAn = Convert.ToInt32(txtTableID.Text);
            bool result = bus_banAn.XoaBanAn(idBanAn);
            if (result)
            {
                MessageBox.Show("Xóa bàn ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBanAn(); 
                XoaFormBanAn(); 
            }
            else
            {
                MessageBox.Show("Xóa bàn ăn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            if (cbbTableStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái bàn để lọc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string trangThai = cbbTableStatus.SelectedItem.ToString();
            loadBanAn(trangThai); // Load danh sách bàn ăn theo trạng thái
        }

        private void btnResetBan_Click(object sender, EventArgs e)
        {
            loadBanAn();

            txtTableID.Clear();
            txtTableName.Clear();
        }
        #endregion

        #region QL Tài Khoản
        void loadTK()
        {
            DataTable dt = bus_acc.GetAccountList();
            dgvTaiKhoan.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dgvTaiKhoan.Rows.Add(
                    row["tenDangNhap"].ToString(),
                    row["tenHienThi"].ToString(),
                    row["loaiTaiKhoan"].ToString() == "0" ? "Nhân viên" : "Quản lý",
                    row["idNhanVien"].ToString()
                );
            }
        }
        private void XoaFormTaiKhoan()
        {
            txtUserName.Clear();
            txtIdNhanVien.Clear();
            txtDisplayName.Clear();
            cbbTypeAcc.SelectedIndex = 0;
        }
        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0 && dgvTaiKhoan.Rows.Count > 0)
            {
                DataGridViewRow row = dgvTaiKhoan.SelectedRows[0];
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    txtUserName.Text = row.Cells[0].Value.ToString(); 
                    txtDisplayName.Text = row.Cells[1].Value.ToString(); 
                    cbbTypeAcc.SelectedItem = row.Cells[2].Value.ToString(); 
                    txtIdNhanVien.Text = row.Cells[3].Value.ToString(); 
                }
                else
                {
                    XoaFormTaiKhoan();
                }
            }
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtDisplayName.Text) || string.IsNullOrWhiteSpace(txtIdNhanVien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Tên đăng nhập, Tên hiển thị, ID nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbTypeAcc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtIdNhanVien.Text, out int idNhanVien) || idNhanVien <= 0)
            {
                MessageBox.Show("ID nhân viên phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_Account taiKhoan = new DTO_Account
            {
                TenDangNhap = txtUserName.Text,
                TenHienThi = txtDisplayName.Text,
                MatKhau = "1", 
                LoaiTaiKhoan = cbbTypeAcc.SelectedIndex, 
                IdNhanVien = idNhanVien
            };

            bool result = bus_acc.ThemTaiKhoan(taiKhoan);
            if (result)
            {
                MessageBox.Show("Thêm tài khoản thành công! Mật khẩu mặc định là '1'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTK(); 
                XoaFormTaiKhoan();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDisplayName.Text) || string.IsNullOrWhiteSpace(txtIdNhanVien.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Tên hiển thị, ID nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbTypeAcc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtIdNhanVien.Text, out int idNhanVien) || idNhanVien <= 0)
            {
                MessageBox.Show("ID nhân viên phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_Account taiKhoan = new DTO_Account
            {
                TenDangNhap = txtUserName.Text,
                TenHienThi = txtDisplayName.Text,
                LoaiTaiKhoan = cbbTypeAcc.SelectedIndex, 
                IdNhanVien = idNhanVien
            };

            bool result = bus_acc.SuaTaiKhoan(taiKhoan);
            if (result)
            {
                MessageBox.Show("Sửa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTK();
                XoaFormTaiKhoan();
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            string tenDangNhap = txtUserName.Text;
            bool result = bus_acc.XoaTaiKhoan(tenDangNhap);
            if (result)
            {
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTK(); 
                XoaFormTaiKhoan();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản để reset mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn reset mật khẩu của tài khoản này? Mật khẩu sẽ được đặt lại thành '1'.", "Xác nhận reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            string tenDangNhap = txtUserName.Text;
            bool result = bus_acc.ResetMatKhau(tenDangNhap);
            if (result)
            {
                MessageBox.Show("Reset mật khẩu thành công! Mật khẩu mới là '1'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTK(); // Cập nhật lại danh sách tài khoản
                XoaFormTaiKhoan(); // Xóa form sau khi reset
            }
            else
            {
                MessageBox.Show("Reset mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAcc_Click(object sender, EventArgs e)
        {
            if (cbbTypeAcc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản để lọc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int loaiTaiKhoan = cbbTypeAcc.SelectedIndex; // 0: Nhân viên, 1: Quản lý
            DataTable dt = bus_acc.LayTaiKhoanTheoLoaiTaiKhoan(loaiTaiKhoan);
            dgvTaiKhoan.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dgvTaiKhoan.Rows.Add(
                    row["tenDangNhap"].ToString(),
                    row["tenHienThi"].ToString(),
                    loaiTaiKhoan == 0 ? "Nhân viên" : "Quản lý",
                    row["idNhanVien"].ToString()
                );
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadTK();

            txtUserName.Clear();
            txtDisplayName.Clear();
            txtIdNhanVien.Clear();

        }
        #endregion

        #region QL Nhân Viên
        //QLNhanVien
        private void LoadDanhSachNhanVien()
        {
            List<DTO_NhanVien> danhSachNhanVien = bus_NhanVien.LayDanhSachNhanVien();
            cbbNhanVien.DataSource = null;
            cbbNhanVien.Items.Clear();
            cbbNhanVien.DataSource = danhSachNhanVien;
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "IdNhanVien";
            cbbNhanVien.SelectedIndex = -1;
        }
        private void HienThiDanhSachNhanVien()
        {
            List<DTO_NhanVien> danhSachNhanVien = bus_NhanVien.LayDanhSachNhanVien();
            dgvNhanVien.Rows.Clear();

            foreach (var nv in danhSachNhanVien)
            {
                dgvNhanVien.Rows.Add(
                    nv.IdNhanVien,
                    nv.HoTen,
                    nv.NgaySinh.ToString("yyyy-MM-dd"),
                    nv.GioiTinh,
                    nv.SoDienThoai,
                    nv.DiaChi,
                    nv.Luong,
                    nv.ChucVu
                );
            }
        }
        private void XoaFormNhanVien()
        {
            txtIDNV.Clear();
            txtHoTenNV.Clear();
            txtNgaySinh.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            cbbGioiTinh.SelectedIndex = 0;
            cbbChucVu.SelectedIndex = 0;
        }
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0 && dgvNhanVien.Rows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    txtIDNV.Text = row.Cells[0].Value.ToString(); 
                    txtHoTenNV.Text = row.Cells[1].Value.ToString(); 
                    txtNgaySinh.Text = row.Cells[2].Value.ToString(); 
                    cbbGioiTinh.SelectedItem = row.Cells[3].Value?.ToString() ?? ""; 
                    txtSDT.Text = row.Cells[4].Value?.ToString() ?? ""; 
                    txtDiaChi.Text = row.Cells[5].Value?.ToString() ?? ""; 
                    txtLuong.Text = row.Cells[6].Value?.ToString() ?? "0"; 
                    cbbChucVu.SelectedItem = row.Cells[7].Value?.ToString() ?? "";
                }
                else
                {
                    XoaFormNhanVien();
                }
            }
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtHoTenNV.Text) || string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Họ tên, Ngày sinh, Số điện thoại, Địa chỉ, Lương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(txtNgaySinh.Text, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng yyyy-MM-dd (ví dụ: 2000-01-01).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtLuong.Text, out int luong) || luong < 0)
            {
                MessageBox.Show("Lương phải là số nguyên không âm, Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_NhanVien nhanVien = new DTO_NhanVien
            {
                HoTen = txtHoTenNV.Text,
                NgaySinh = ngaySinh,
                GioiTinh = cbbGioiTinh.SelectedItem?.ToString() ?? "",
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Luong = luong,
                ChucVu = cbbChucVu.SelectedItem?.ToString() ?? ""
            };

            bool result = bus_NhanVien.ThemNhanVien(nhanVien);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhanVien();
                XoaFormNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtIDNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTenNV.Text) || string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Họ tên, Ngày sinh, Số điện thoại, Địa chỉ, Lương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(txtNgaySinh.Text, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng yyyy-MM-dd (ví dụ: 2000-01-01).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtLuong.Text, out int luong) || luong < 0)
            {
                MessageBox.Show("Lương phải là số nguyên không âm, Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_NhanVien nhanVien = new DTO_NhanVien
            {
                IdNhanVien = int.Parse(txtIDNV.Text),
                HoTen = txtHoTenNV.Text,
                NgaySinh = ngaySinh,
                GioiTinh = cbbGioiTinh.SelectedItem?.ToString() ?? "",
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                Luong = luong,
                ChucVu = cbbChucVu.SelectedItem?.ToString() ?? ""
            };

            bool result = bus_NhanVien.SuaNhanVien(nhanVien);
            if (result)
            {
                MessageBox.Show("Sửa nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhanVien();
                XoaFormNhanVien();
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này? Các dữ liệu liên quan (tài khoản, hóa đơn) có thể bị ảnh hưởng.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            int idNhanVien = int.Parse(txtIDNV.Text);
            bool result = bus_NhanVien.XoaNhanVien(idNhanVien);
            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhanVien();
                XoaFormNhanVien();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewNV_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTenNV.Text.Trim().ToString();
            string gioiTinh = cbbGioiTinh.SelectedItem?.ToString() ?? "";
            string chucVu = cbbChucVu.SelectedItem?.ToString() ?? "";
            string diaChi = txtDiaChi.Text.Trim().ToString();

            List<DTO_NhanVien> danhSachNhanVien = bus_NhanVien.LayDanhSachNhanVienTheoLoc(hoTen, gioiTinh, diaChi, chucVu);
            dgvNhanVien.Rows.Clear();

            foreach (var nv in danhSachNhanVien)
            {
                dgvNhanVien.Rows.Add(
                    nv.IdNhanVien,
                    nv.HoTen,
                    nv.NgaySinh.ToString("yyyy-MM-dd"),
                    nv.GioiTinh,
                    nv.SoDienThoai,
                    nv.DiaChi,
                    nv.Luong,
                    nv.ChucVu
                );
            }
        }

        private void btnResetNV_Click(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();

            txtIDNV.Clear();
            txtHoTenNV.Clear();
            txtNgaySinh.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtLuong.Clear();
            cbbGioiTinh.SelectedIndex = -1;
            cbbChucVu.SelectedIndex = -1;
        }
        #endregion

        #region QL Nhà Cung Cấp
        //QLNhaCungCap
        private void HienThiDanhSachNhaCungCap()
        {
            List<DTO_NhaCungCap> danhSachNhaCC = bus_nhaCC.LayDanhSachNhaCungCap();
            dgvNhaCungCap.Rows.Clear();

            foreach (var nhaCC in danhSachNhaCC)
            {
                dgvNhaCungCap.Rows.Add(
                    nhaCC.IdNhaCC,
                    nhaCC.TenNhaCC,
                    nhaCC.DiaChi,
                    nhaCC.SoDienThoai,
                    nhaCC.Email
                );
            }

            
            cbbDiaChi.Items.Clear();
            cbbDiaChi.Items.Add(""); 
            List<string> dsDiaChi = bus_nhaCC.LayDanhSachDiaChi();
            foreach (var diaChi in dsDiaChi)
            {
                cbbDiaChi.Items.Add(diaChi);
            }
            cbbDiaChi.SelectedIndex = 0;
        }
        private void XoaFormNhaCungCap()
        {
            txtIDNhaCC.Clear();
            txtTenNhaCC.Clear();
            cbbDiaChi.SelectedIndex = 0;
            txtSDTNhaCC.Clear();
            txtEmail.Clear();
        }
        private void dgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count > 0 && dgvNhaCungCap.Rows.Count > 0)
            {
                DataGridViewRow row = dgvNhaCungCap.SelectedRows[0];
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    txtIDNhaCC.Text = row.Cells[0].Value.ToString(); 
                    txtTenNhaCC.Text = row.Cells[1].Value.ToString(); 
                    cbbDiaChi.SelectedItem = row.Cells[2].Value?.ToString() ?? "";
                    txtSDTNhaCC.Text = row.Cells[3].Value?.ToString() ?? ""; 
                    txtEmail.Text = row.Cells[4].Value?.ToString() ?? "";
                }
                else
                {
                    XoaFormNhaCungCap();
                }
            }
        }

        private void btnAddNhaCC_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtTenNhaCC.Text) || string.IsNullOrWhiteSpace(txtSDTNhaCC.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Tên nhà cung cấp, Số điện thoại, Email.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_NhaCungCap nhaCC = new DTO_NhaCungCap
            {
                TenNhaCC = txtTenNhaCC.Text,
                DiaChi = cbbDiaChi.SelectedItem?.ToString() ?? "",
                SoDienThoai = txtSDTNhaCC.Text,
                Email = txtEmail.Text
            };

            bool result = bus_nhaCC.ThemNhaCungCap(nhaCC);
            if (result)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhaCungCap();
                XoaFormNhaCungCap();

                // Cập nhật lại danh sách địa chỉ trong cbbDiaChiNhaCC
                cbbDiaChi.Items.Clear();
                cbbDiaChi.Items.Add("");
                List<string> dsDiaChi = bus_nhaCC.LayDanhSachDiaChi();
                foreach (var diaChi in dsDiaChi)
                {
                    cbbDiaChi.Items.Add(diaChi);
                }
                cbbDiaChi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaNhaCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDNhaCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNhaCC.Text) || string.IsNullOrWhiteSpace(txtSDTNhaCC.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin: Tên nhà cung cấp, Số điện thoại, Email.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_NhaCungCap nhaCC = new DTO_NhaCungCap
            {
                IdNhaCC = int.Parse(txtIDNhaCC.Text),
                TenNhaCC = txtTenNhaCC.Text,
                DiaChi = cbbDiaChi.SelectedItem?.ToString() ?? "",
                SoDienThoai = txtSDTNhaCC.Text,
                Email = txtEmail.Text
            };

            bool result = bus_nhaCC.SuaNhaCungCap(nhaCC);
            if (result)
            {
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhaCungCap();
                XoaFormNhaCungCap();

                cbbDiaChi.Items.Clear();
                cbbDiaChi.Items.Add("");
                List<string> dsDiaChi = bus_nhaCC.LayDanhSachDiaChi();
                foreach (var diaChi in dsDiaChi)
                {
                    cbbDiaChi.Items.Add(diaChi);
                }
                cbbDiaChi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Sửa nhà cung cấp thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNhaCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDNhaCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            int idNhaCC = int.Parse(txtIDNhaCC.Text);
            bool result = bus_nhaCC.XoaNhaCungCap(idNhaCC);
            if (result)
            {
                MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhaCungCap();
                XoaFormNhaCungCap();

                // Cập nhật lại danh sách địa chỉ trong cbbDiaChiNhaCC
                cbbDiaChi.Items.Clear();
                cbbDiaChi.Items.Add("");
                List<string> dsDiaChi = bus_nhaCC.LayDanhSachDiaChi();
                foreach (var diaChi in dsDiaChi)
                {
                    cbbDiaChi.Items.Add(diaChi);
                }
                cbbDiaChi.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewNhaCC_Click(object sender, EventArgs e)
        {
            if (cbbDiaChi.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn địa chỉ để lọc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string diaChi = cbbDiaChi.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(diaChi))
            {
                HienThiDanhSachNhaCungCap(); // Nếu địa chỉ trống, hiển thị toàn bộ danh sách
            }
            else
            {
                List<DTO_NhaCungCap> danhSachNhaCC = bus_nhaCC.LayDanhSachNhaCungCapTheoDiaChi(diaChi);
                dgvNhaCungCap.Rows.Clear();

                foreach (var nhaCC in danhSachNhaCC)
                {
                    dgvNhaCungCap.Rows.Add(
                        nhaCC.IdNhaCC,
                        nhaCC.TenNhaCC,
                        nhaCC.DiaChi,
                        nhaCC.SoDienThoai,
                        nhaCC.Email
                    );
                }
            }
        }

        private void btnResetNhaCC_Click(object sender, EventArgs e)
        {
            HienThiDanhSachNhaCungCap();

            txtIDNhaCC.Clear();
            txtTenNhaCC.Clear();
            txtSDTNhaCC.Clear();
            txtEmail.Clear();
            cbbDiaChi.SelectedIndex = -1;

        }
        #endregion

        #region Bao Cáo Doanh Thu
        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            GUI_BaoCaoDoanhThu f = new GUI_BaoCaoDoanhThu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
