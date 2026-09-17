using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanTraSua.Resources;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace QuanLyQuanTraSua
{
    public partial class GUI_xuLyBan : Form
    {
        BUS_BanAn bus_BanAn = new BUS_BanAn();
        BUS_ChiTietHoaDonBan bus_HD = new BUS_ChiTietHoaDonBan();
        BUS_DanhMuc bus_DanhMuc = new BUS_DanhMuc();
        BUS_MonAn bus_MonAn = new BUS_MonAn();
        BUS_ThemMonVaoBan busThemMon = new BUS_ThemMonVaoBan();

        public GUI_xuLyBan()
        {
            InitializeComponent();
        }

        private void LoadBan()
        {
            flpTable.Controls.Clear();
            List<DTO_BanAn> dsBan = bus_BanAn.LayTatCaBan();

            foreach (DTO_BanAn ban in dsBan)
            {
                BanControl ctrl = new BanControl(ban);
                ctrl.Width = 90;
                ctrl.Height = 80;

                ctrl.BanDuocClick += (s, data) =>
                {
                    txtTenBan.Text = data.tenBan;
                    LoadHoaDonTheoBan(data.idBan);
                };

                flpTable.Controls.Add(ctrl);
            }
        }

        private void LoadHoaDonTheoBan(int idBan)
        {
            lvsBill.Items.Clear();
            var listCT = bus_HD.LayChiTietHoaDonTheoBan(idBan);
            float tongTien = 0;

            foreach (var ct in listCT)
            {
                ListViewItem item = new ListViewItem(ct.TenMonAn);
                item.SubItems.Add(ct.TenDanhMuc);
                item.SubItems.Add(ct.GiaTien.ToString("N0"));
                item.SubItems.Add(ct.SoLuong.ToString());
                item.SubItems.Add(ct.ThanhTien.ToString("N0"));
                lvsBill.Items.Add(item);
                tongTien += ct.ThanhTien;
            }
            txtTongTien.Text = tongTien.ToString("N0");

            lvsBill.Refresh();
        }

        void loadDMMA()
        {
            List<DTO_DanhMuc> danhMuc = bus_DanhMuc.LayDanhSachDanhMuc();
            cbbCategory.DataSource = danhMuc;
            cbbCategory.DisplayMember = "TenDanhMuc";
            cbbCategory.ValueMember = "IdDanhMuc";
        }

        private int GetIdBanFromTenBan(string tenBan)
        {
            List<DTO_BanAn> dsBan = bus_BanAn.LayTatCaBan();
            var ban = dsBan.FirstOrDefault(b => b.TenBanAn.Equals(tenBan, StringComparison.OrdinalIgnoreCase));
            return ban != null ? ban.IdBanAn : -1;
        }

        private void LoadDanhSachBanDich()
        {
            List<DTO_BanAn> dsBan = bus_BanAn.LayTatCaBan();
            if (dsBan == null || dsBan.Count == 0)
            {
                MessageBox.Show("Không có bàn nào trong cơ sở dữ liệu. Vui lòng kiểm tra dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbbBanDich.DataSource = dsBan;
            cbbBanDich.DisplayMember = "TenBanAn";
            cbbBanDich.ValueMember = "IdBanAn";
        }

        private void GUI_TableManager_Load(object sender, EventArgs e)
        {
            LoadBan();
            loadDMMA();
            LoadDanhSachBanDich();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenDanhMuc = cbbCategory.Text;
            List<DTO_MonAn> dsMon = bus_MonAn.LayMonAnTheoDanhMuc(tenDanhMuc);
            cbbFood.DataSource = dsMon;
            cbbFood.DisplayMember = "DisplayText";
            cbbFood.ValueMember = "idMonAn";
        }

        private void lvsBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvsBill.SelectedItems.Count == 0) return;

            var selectedItem = lvsBill.SelectedItems[0];
            string tenMonAn = selectedItem.SubItems[0].Text;
            string tenDanhMuc = selectedItem.SubItems[1].Text;
            int soLuong = int.Parse(selectedItem.SubItems[3].Text);

            var danhMucList = bus_DanhMuc.LayDanhSachDanhMuc();
            cbbCategory.DataSource = danhMucList;
            cbbCategory.DisplayMember = "TenDanhMuc";
            cbbCategory.ValueMember = "IdDanhMuc";
            var selectedDanhMuc = danhMucList.FirstOrDefault(dm => dm.TenDanhMuc == tenDanhMuc);
            if (selectedDanhMuc != null)
            {
                cbbCategory.SelectedValue = selectedDanhMuc.IdDanhMuc;
            }

            var monAnList = bus_MonAn.LayMonAnTheoDanhMuc(tenDanhMuc);
            cbbFood.DataSource = monAnList;
            cbbFood.DisplayMember = "DisplayText";
            cbbFood.ValueMember = "idMonAn";
            var selectedMonAn = monAnList.FirstOrDefault(ma => ma.TenMonAn == tenMonAn);
            if (selectedMonAn != null)
            {
                cbbFood.SelectedValue = selectedMonAn.IdMonAn;
            }

            nmFoodCount.Value = soLuong;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text) || cbbFood.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập tên bàn và chọn món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_MonAn selectedFood = cbbFood.SelectedItem as DTO_MonAn;

            int idBan = GetIdBanFromTenBan(txtTenBan.Text);
            if (idBan == -1)
            {
                MessageBox.Show("Tên bàn không hợp lệ. Vui lòng nhập đúng tên bàn (ví dụ: Bàn 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idMonAn = selectedFood.IdMonAn;
            int soLuong = (int)nmFoodCount.Value;

            bool monAnDaTonTai = bus_HD.KiemTraMonAnTonTai(idBan, idMonAn);
            if (!monAnDaTonTai && soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0 khi thêm món ăn mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_ThemMonVaoBan mon = new DTO_ThemMonVaoBan(idBan, idMonAn, soLuong);
            bool kq = busThemMon.ThemMonVaoBan(mon);
            if (kq)
            {
                MessageBox.Show("Thêm món thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDonTheoBan(idBan);
                LoadBan();
            }
            else
            {
                MessageBox.Show("Thêm món thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatSL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lvsBill.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn từ hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBan = GetIdBanFromTenBan(txtTenBan.Text);
            if (idBan == -1)
            {
                MessageBox.Show("Tên bàn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietList = bus_HD.LayChiTietHoaDonTheoBan(idBan);
            var selectedItem = lvsBill.SelectedItems[0];
            string tenMonAn = selectedItem.SubItems[0].Text;
            var chiTiet = chiTietList.FirstOrDefault(ct => ct.TenMonAn == tenMonAn);
            if (chiTiet == null)
            {
                MessageBox.Show("Không tìm thấy món ăn trong hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuongMoi = (int)nmFoodCount.Value;
            if (soLuongMoi <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = bus_HD.CapNhatSoLuongMonAn(chiTiet.IdHoaDonBan1, chiTiet.IdMonAn, soLuongMoi);
            if (result)
            {
                MessageBox.Show("Cập nhật số lượng món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDonTheoBan(idBan);
                LoadBan();
            }
            else
            {
                MessageBox.Show("Cập nhật số lượng thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lvsBill.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn từ hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBan = GetIdBanFromTenBan(txtTenBan.Text);
            if (idBan == -1)
            {
                MessageBox.Show("Tên bàn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietList = bus_HD.LayChiTietHoaDonTheoBan(idBan);
            var selectedItem = lvsBill.SelectedItems[0];
            string tenMonAn = selectedItem.SubItems[0].Text;
            var chiTiet = chiTietList.FirstOrDefault(ct => ct.TenMonAn == tenMonAn);
            if (chiTiet == null)
            {
                MessageBox.Show("Không tìm thấy món ăn trong hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool result = bus_HD.XoaMonAnKhoiHoaDon(chiTiet.IdHoaDonBan1, chiTiet.IdMonAn);
            if (result)
            {
                MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDonTheoBan(idBan);
                LoadBan();
                cbbCategory.SelectedIndex = -1;
                cbbFood.DataSource = null;
                nmFoodCount.Value = 0;
            }
            else
            {
                MessageBox.Show("Xóa món ăn thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBan = GetIdBanFromTenBan(txtTenBan.Text);
            if (idBan == -1)
            {
                MessageBox.Show("Tên bàn không hợp lệ. Vui lòng nhập đúng tên bàn (ví dụ: Bàn 1).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float giamGia = 0;
            if (!string.IsNullOrWhiteSpace(nmDiscount.Text))
            {
                if (!float.TryParse(nmDiscount.Text, out giamGia) || giamGia < 0 || giamGia > 100)
                {
                    MessageBox.Show("Tỷ lệ giảm giá phải là số từ 0 đến 100.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int idNhanVien = CurrentUser.IdNhanVien;
            if (idNhanVien <= 0)
            {
                MessageBox.Show("Không thể xác định nhân viên thực hiện thanh toán. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var chiTietList = bus_HD.LayChiTietHoaDonTheoBan(idBan);
            if (chiTietList == null || chiTietList.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào để thanh toán cho bàn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            float tongTienSauGiamGia = bus_HD.ThanhToanHoaDon(idBan, giamGia, idNhanVien);
            if (tongTienSauGiamGia > 0)
            {
                var hoaDonBanList = bus_HD.LayDanhSachHoaDon(null, null, null);
                var hoaDonBan = hoaDonBanList.OrderByDescending(hd => hd.ThoiDiemRa).FirstOrDefault(hd => hd.IdBanAn == idBan && hd.TrangThaiHD);
                if (hoaDonBan == null)
                {
                    MessageBox.Show("Thanh toán thành công nhưng không tìm thấy hóa đơn để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDonTheoBan(idBan);
                    LoadBan();
                    return;
                }

                GUI_InHoaDonBan formPreview = new GUI_InHoaDonBan(hoaDonBan, chiTietList, tongTienSauGiamGia, giamGia, idNhanVien);
                formPreview.ShowDialog();

                MessageBox.Show($"Thanh toán thành công! Tổng tiền sau giảm giá: {tongTienSauGiamGia:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDonTheoBan(idBan); 
                LoadBan();
            }
            else
            {
                MessageBox.Show("Không có hóa đơn để thanh toán cho bàn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng click chọn bàn nguồn từ danh sách bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbbBanDich.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn đích từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBanNguon = GetIdBanFromTenBan(txtTenBan.Text);
            if (idBanNguon == -1)
            {
                MessageBox.Show("Tên bàn nguồn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idBanDich = (int)cbbBanDich.SelectedValue;

            if (idBanNguon == idBanDich)
            {
                MessageBox.Show("Bàn nguồn và bàn đích không được trùng nhau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            bool result = bus_HD.ChuyenBan(idBanNguon, idBanDich);
            if (result)
            {
                MessageBox.Show($"Chuyển bàn ( gộp bàn ) thành công từ {txtTenBan.Text} sang {cbbBanDich.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBan();
                LoadHoaDonTheoBan(idBanDich); 
                txtTenBan.Text = cbbBanDich.Text; 
            }
            else
            {
                MessageBox.Show("Chuyển bàn thất bại. Không có hóa đơn để chuyển từ bàn nguồn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}