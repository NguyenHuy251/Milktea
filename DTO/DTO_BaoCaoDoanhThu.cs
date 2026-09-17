using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BaoCaoDoanhThu
    {
        private int id;
        private DateTime tuNgay;
        private DateTime denNgay;
        private int tongSoHoaDonBan;
        private int tongSoHoaDonNhap;
        private double tongDoanhThuBan;
        private double tongChiPhiNhap;
        private double tongDoanhThu;
        private int idNhanVien;
        private string tenNhanVien;
        private DateTime ngayTao;
        private string ghiChu;

        public int Id { get => id; set => id = value; }
        public DateTime TuNgay { get => tuNgay; set => tuNgay = value; }
        public DateTime DenNgay { get => denNgay; set => denNgay = value; }
        public int TongSoHoaDonBan { get => tongSoHoaDonBan; set => tongSoHoaDonBan = value; }
        public int TongSoHoaDonNhap { get => tongSoHoaDonNhap; set => tongSoHoaDonNhap = value; }
        public double TongDoanhThuBan { get => tongDoanhThuBan; set => tongDoanhThuBan = value; }
        public double TongChiPhiNhap { get => tongChiPhiNhap; set => tongChiPhiNhap = value; }
        public double TongDoanhThu { get => tongDoanhThu; set => tongDoanhThu = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public DateTime NgayTao { get => ngayTao; set => ngayTao = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public DTO_BaoCaoDoanhThu() { }

        public DTO_BaoCaoDoanhThu(
            int id,
            DateTime tuNgay,
            DateTime denNgay,
            int tongSoHoaDonBan,
            int tongSoHoaDonNhap,
            double tongDoanhThuBan,
            double tongChiPhiNhap,
            double tongDoanhThu,
            int idNhanVien,
            string tenNhanVien,
            DateTime ngayTao,
            string ghiChu)
        {
            Id = id;
            TuNgay = tuNgay;
            DenNgay = denNgay;
            TongSoHoaDonBan = tongSoHoaDonBan;
            TongSoHoaDonNhap = tongSoHoaDonNhap;
            TongDoanhThuBan = tongDoanhThuBan;
            TongChiPhiNhap = tongChiPhiNhap;
            TongDoanhThu = tongDoanhThu;
            IdNhanVien = idNhanVien;
            TenNhanVien = tenNhanVien;
            NgayTao = ngayTao;
            GhiChu = ghiChu;
        }
    }
}
