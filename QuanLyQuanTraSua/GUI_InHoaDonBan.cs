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
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyQuanTraSua
{
    public partial class GUI_InHoaDonBan : Form
    {
        private DTO_HoaDonBan hoaDonBan;
        private List<DTO_ChiTietHoaDonBan> chiTietList;
        private float tongTienSauGiamGia;
        private float giamGia;
        private int idNhanVien;
        public GUI_InHoaDonBan(DTO_HoaDonBan hoaDonBan, List<DTO_ChiTietHoaDonBan> chiTietList, float tongTienSauGiamGia, float giamGia, int idNhanVien)
        {
            InitializeComponent();
            this.hoaDonBan = hoaDonBan;
            this.chiTietList = chiTietList;
            this.tongTienSauGiamGia = tongTienSauGiamGia;
            this.giamGia = giamGia;
            this.idNhanVien = idNhanVien;
            LoadData();
        }

        private void LoadData()
        {
            // Thiết lập tiêu đề và ngày giờ
            lblTitle.Text = "HÓA ĐƠN BÁN";
            lblNgay.Text = $"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

            // Thông tin hóa đơn
            lblIdHoaDon.Text = $"ID Hóa Đơn: {hoaDonBan.Id}";
            lblBan.Text = $"Bàn: {hoaDonBan.IdBanAn}";
            lblThoiDiemVao.Text = $"Thời Điểm Vào: {hoaDonBan.ThoiDiemVao:dd/MM/yyyy HH:mm:ss}";
            lblThoiDiemRa.Text = $"Thời Điểm Ra: {(hoaDonBan.ThoiDiemRa.HasValue ? hoaDonBan.ThoiDiemRa.Value.ToString("dd/MM/yyyy HH:mm:ss") : "Chưa ra")}";
            lblNhanVien.Text = $"Nhân Viên: {hoaDonBan.HoTen} (ID: {idNhanVien})";
            lblTrangThai.Text = $"Trạng Thái: {(hoaDonBan.TrangThaiHD ? "Đã thanh toán" : "Chưa thanh toán")}";

            // Bảng danh sách món ăn
            dgvMonAn.DataSource = chiTietList;
            dgvMonAn.Columns["TenMonAn"].HeaderText = "Tên Món";
            dgvMonAn.Columns["TenDanhMuc"].HeaderText = "Danh Mục";
            dgvMonAn.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvMonAn.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvMonAn.Columns["GiaTien"].Visible = false; 
            dgvMonAn.Columns["IdHoaDonBan1"].Visible = false; 

            // Tổng tiền và giảm giá
            lblTongTien.Text = $"Tổng Tiền: {tongTienSauGiamGia:N0} VND";
            lblGiamGia.Text = giamGia > 0 ? $"Giảm Giá: {giamGia:N0}%" : "";
        }

       

        private void GUI_InHoaDonBan_Load(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Tạo tên file PDF với timestamp để tránh ghi đè
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string pdfFileName = $"HoaDonBan_{hoaDonBan.Id}_{timestamp}.pdf";

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
                            row.ConstantItem(300).Text("HÓA ĐƠN BÁN")
                                .FontSize(20).Bold().FontColor(Colors.Blue.Darken2);
                            row.RelativeItem().AlignRight().Text($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
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
                                    col.Item().Text($"ID Hóa Đơn: {hoaDonBan.Id}").Bold();
                                    col.Item().Text($"Bàn: {hoaDonBan.IdBanAn}");
                                });
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"Thời Điểm Vào: {hoaDonBan.ThoiDiemVao:dd/MM/yyyy HH:mm:ss}");
                                    col.Item().Text($"Thời Điểm Ra: {(hoaDonBan.ThoiDiemRa.HasValue ? hoaDonBan.ThoiDiemRa.Value.ToString("dd/MM/yyyy HH:mm:ss") : "Chưa ra")}");
                                });
                            });

                            column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            // Thông tin nhân viên
                            column.Item().Text($"Nhân Viên: {hoaDonBan.HoTen} (ID: {idNhanVien})").Bold();
                            column.Item().Text($"Trạng Thái: {(hoaDonBan.TrangThaiHD ? "Đã thanh toán" : "Chưa thanh toán")}");

                            // Bảng danh sách món ăn
                            column.Item().PaddingTop(10).Text("Danh Sách Món Ăn").Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(2);
                                });

                                // Tiêu đề bảng
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Tên Món").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Danh Mục").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Số Lượng").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Thành Tiền").Bold();
                                });

                                // Dữ liệu bảng
                                for (int i = 0; i < chiTietList.Count; i++)
                                {
                                    var chiTiet = chiTietList[i];
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(chiTiet.TenMonAn);
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(chiTiet.TenDanhMuc);
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).Text(chiTiet.SoLuong.ToString());
                                    table.Cell().Border(1).BorderColor(Colors.Grey.Lighten2).Background(i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4).Padding(5).AlignRight().Text($"{chiTiet.ThanhTien:N0} VND");
                                }
                            });

                            // Tổng tiền và giảm giá
                            column.Item().PaddingTop(10).Background(Colors.Grey.Lighten4).Padding(5).Row(row =>
                            {
                                row.RelativeItem().Text($"Tổng Tiền: {tongTienSauGiamGia:N0} VND").Bold();
                                if (giamGia > 0)
                                    row.ConstantItem(150).AlignRight().Text($"Giảm Giá: {giamGia:N0}%").Bold();
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
                            x.Span(" - Cảm ơn quý khách!");
                        });
                });
            }).GeneratePdf(pdfFileName);

            MessageBox.Show($"In hóa đơn thành công!\nFile PDF: {pdfFileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
