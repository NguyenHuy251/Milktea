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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyQuanTraSua
{
    public partial class GUI_InBaoCaoDoanhThu : Form
    {
        private DTO_BaoCaoDoanhThu baoCaoMoi;
        public GUI_InBaoCaoDoanhThu(DTO_BaoCaoDoanhThu baoCaoMoi)
        {
            InitializeComponent();
            this.baoCaoMoi = baoCaoMoi;
            LoadData();
        }

        private void LoadData()
        {
            // Thiết lập tiêu đề và ngày tạo
            lblTitle.Text = "BÁO CÁO DOANH THU";
            lblNgayTao.Text = $"Ngày Tạo: {baoCaoMoi.NgayTao:dd/MM/yyyy HH:mm:ss}";

            // Thông tin báo cáo
            lblIdBaoCao.Text = $"ID Báo Cáo: {baoCaoMoi.Id}";
            lblTuNgay.Text = $"Từ Ngày: {baoCaoMoi.TuNgay:dd/MM/yyyy}";
            lblDenNgay.Text = $"Đến Ngày: {baoCaoMoi.DenNgay:dd/MM/yyyy}";
            lblNhanVien.Text = $"Nhân Viên Tạo: {baoCaoMoi.TenNhanVien} (ID: {baoCaoMoi.IdNhanVien})";
            lblGhiChu.Text = $"Ghi Chú: {baoCaoMoi.GhiChu ?? "Không có"}";

            // Bảng tóm tắt doanh thu
            dgvDoanhThu.Rows.Clear();
            dgvDoanhThu.Rows.Add("Tổng Hóa Đơn Bán", baoCaoMoi.TongSoHoaDonBan);
            dgvDoanhThu.Rows.Add("Tổng Hóa Đơn Nhập", baoCaoMoi.TongSoHoaDonNhap);
            dgvDoanhThu.Rows.Add("Tổng Doanh Thu Bán", $"{baoCaoMoi.TongDoanhThuBan:N0} VND");
            dgvDoanhThu.Rows.Add("Tổng Chi Phí Nhập", $"{baoCaoMoi.TongChiPhiNhap:N0} VND");
            dgvDoanhThu.Rows.Add("Tổng Doanh Thu", $"{baoCaoMoi.TongDoanhThu:N0} VND");
        }

        private void GUI_InBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            // Tạo tên file PDF với timestamp để tránh ghi đè
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string pdfFileName = $"BaoCaoDoanhThu_{baoCaoMoi.Id}_{timestamp}.pdf";

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
                            row.ConstantItem(300).Text("BÁO CÁO DOANH THU")
                                .FontSize(20).Bold().FontColor(Colors.Orange.Darken2);
                            row.RelativeItem().AlignRight().Text($"Ngày Tạo: {baoCaoMoi.NgayTao:dd/MM/yyyy HH:mm:ss}")
                                .FontSize(10).Italic();
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(10)
                        .Column(column =>
                        {
                            // Thông tin báo cáo
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"ID Báo Cáo: {baoCaoMoi.Id}").Bold();
                                    col.Item().Text($"Từ Ngày: {baoCaoMoi.TuNgay:dd/MM/yyyy}");
                                    col.Item().Text($"Đến Ngày: {baoCaoMoi.DenNgay:dd/MM/yyyy}");
                                });
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"Nhân Viên Tạo: {baoCaoMoi.TenNhanVien} (ID: {baoCaoMoi.IdNhanVien})");
                                    col.Item().Text($"Ghi Chú: {baoCaoMoi.GhiChu ?? "Không có"}");
                                });
                            });

                            column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            // Bảng tóm tắt doanh thu
                            column.Item().PaddingTop(10).Text("Tóm Tắt Doanh Thu").Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(2);
                                });

                                // Tiêu đề bảng
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Hạng Mục").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Giá Trị").Bold();
                                });

                                // Dữ liệu bảng
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).Text("Tổng Hóa Đơn Bán");
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).AlignRight().Text(baoCaoMoi.TongSoHoaDonBan.ToString());

                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(5).Text("Tổng Hóa Đơn Nhập");
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(5).AlignRight().Text(baoCaoMoi.TongSoHoaDonNhap.ToString());

                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).Text("Tổng Doanh Thu Bán");
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).AlignRight().Text($"{baoCaoMoi.TongDoanhThuBan:N0} VND");

                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(5).Text("Tổng Chi Phí Nhập");
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(5).AlignRight().Text($"{baoCaoMoi.TongChiPhiNhap:N0} VND");

                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).Text("Tổng Doanh Thu").Bold();
                                table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.White).Padding(5).AlignRight().Text($"{baoCaoMoi.TongDoanhThu:N0} VND").Bold();
                            });
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
                            x.Span(" - Báo cáo nội bộ");
                        });
                });
            }).GeneratePdf(pdfFileName);

            MessageBox.Show($"In báo cáo thành công!\nFile PDF: {pdfFileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
