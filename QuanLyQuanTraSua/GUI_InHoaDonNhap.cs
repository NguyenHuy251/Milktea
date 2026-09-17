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
    public partial class GUI_InHoaDonNhap : Form
    {
        private DTO_HoaDonNhap hoaDonNhap;
        private List<DTO_ChiTietHoaDonNhap> danhSachNguyenLieu;
        private DataGridView dgvChiTietNhap;
        private BUS_HoaDonNhap bus_HoaDonNhap = new BUS_HoaDonNhap();
        public GUI_InHoaDonNhap(DTO_HoaDonNhap hoaDonNhap, List<DTO_ChiTietHoaDonNhap> danhSachNguyenLieu, DataGridView dgvChiTietNhap)
        {
            InitializeComponent();
            this.hoaDonNhap = hoaDonNhap;
            this.danhSachNguyenLieu = danhSachNguyenLieu;
            this.dgvChiTietNhap = dgvChiTietNhap;
            LoadData();
        }

        private void LoadData()
        {
            // Thiết lập tiêu đề và ngày giờ
            lblTitle.Text = "HÓA ĐƠN NHẬP";
            lblNgay.Text = $"Ngày: {hoaDonNhap.NgayNhap:dd/MM/yyyy HH:mm:ss}";

            // Thông tin hóa đơn
            lblIdHoaDon.Text = $"ID Hóa Đơn Nhập: {hoaDonNhap.IdHoaDonNhap}";
            lblNhaCungCap.Text = $"Nhà Cung Cấp: {hoaDonNhap.TenNhaCC} (ID: {hoaDonNhap.IdNhaCungCap})";
            lblNhanVien.Text = $"Nhân Viên Nhập: {hoaDonNhap.HoTen} (ID: {hoaDonNhap.IdNhanVien})";

            // Kiểm tra dữ liệu đầu vào
            if (danhSachNguyenLieu == null || danhSachNguyenLieu.Count == 0)
            {
                MessageBox.Show("Danh sách nguyên liệu trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo DataTable để chứa dữ liệu hiển thị
            DataTable dt = new DataTable();
            dt.Columns.Add("TenNguyenLieu", typeof(string));
            dt.Columns.Add("DonViTinh", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(float));
            dt.Columns.Add("ThanhTien", typeof(string));

            // Điền dữ liệu vào DataTable
            for (int i = 0; i < danhSachNguyenLieu.Count; i++)
            {
                var chiTiet = danhSachNguyenLieu[i];
                string tenNguyenLieu = bus_HoaDonNhap.LayTenNguyenLieuTheoId(chiTiet.IdNguyenLieu);
                if (string.IsNullOrEmpty(tenNguyenLieu))
                {
                    tenNguyenLieu = "Không xác định";
                }
                float thanhTien = chiTiet.SoLuong * chiTiet.DonGia;

                dt.Rows.Add(tenNguyenLieu, chiTiet.DonViTinh, chiTiet.SoLuong, chiTiet.DonGia, $"{thanhTien:N0} VND");
            }

            // Gán DataTable vào DataGridView
            dgvNguyenLieu.DataSource = dt;
            dgvNguyenLieu.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvNguyenLieu.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvNguyenLieu.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvNguyenLieu.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            // Tổng tiền
            lblTongTien.Text = $"Tổng Tiền: {hoaDonNhap.TongTien:N0} VND";
        }
        private void GUI_InHoaDonNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Tạo tên file PDF với timestamp để tránh ghi đè
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string pdfFileName = $"HoaDonNhap_{hoaDonNhap.IdHoaDonNhap}_{timestamp}.pdf";

            // In PDF
            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    // Header
                    page.Header()
                        .Background(Colors.Grey.Lighten3)
                        .Padding(10)
                        .Row(row =>
                        {
                            row.ConstantItem(300).Text("HÓA ĐƠN NHẬP")
                                .FontSize(20).Bold().FontColor(Colors.Green.Darken2);
                            row.RelativeItem().AlignRight().Text($"Ngày: {hoaDonNhap.NgayNhap:dd/MM/yyyy HH:mm:ss}")
                                .FontSize(10).Italic();
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(10)
                        .Column(column =>
                        {
                            // Thông tin hóa đơn
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"ID Hóa Đơn Nhập: {hoaDonNhap.IdHoaDonNhap}").Bold();
                                    col.Item().Text($"Nhà Cung Cấp: {hoaDonNhap.TenNhaCC} (ID: {hoaDonNhap.IdNhaCungCap})");
                                });
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"Nhân Viên Nhập: {hoaDonNhap.HoTen} (ID: {hoaDonNhap.IdNhanVien})");
                                });
                            });

                            column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            // Bảng danh sách nguyên liệu
                            column.Item().PaddingTop(10).Text("Danh Sách Nguyên Liệu").Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(2);
                                });

                                // Tiêu đề bảng
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Tên Nguyên Liệu").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Đơn Vị Tính").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Số Lượng").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Đơn Giá").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Thành Tiền").Bold();
                                });

                                // Dữ liệu bảng
                                for (int i = 0; i < danhSachNguyenLieu.Count; i++)
                                {
                                    var chiTiet = danhSachNguyenLieu[i];
                                    string tenNguyenLieu = (string)dgvChiTietNhap.Rows[i].Cells["TenNguyenLieu"].Value;
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(tenNguyenLieu);
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(chiTiet.DonViTinh);
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(chiTiet.SoLuong.ToString());
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text($"{chiTiet.DonGia:N0} VND");
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).AlignRight().Text($"{(chiTiet.SoLuong * chiTiet.DonGia):N0} VND");
                                }
                            });

                            // Tổng tiền
                            column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(5).Text($"Tổng Tiền: {hoaDonNhap.TongTien:N0} VND").Bold();
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.DefaultTextStyle(ts => ts.FontSize(10).FontColor(Colors.Grey.Medium));
                            x.Span("Trang ");
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                            x.Span(" - Cảm ơn nhà cung cấp!");
                        });
                });
            }).GeneratePdf(pdfFileName);

            MessageBox.Show($"In hóa đơn thành công!\nFile PDF: {pdfFileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
