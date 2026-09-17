using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonBan
    {
        private int IdHoaDonBan;
        private int idMonAn;
        private int idDanhMuc;
        private string tenMonAn;
        private string tenDanhMuc;
        private decimal giaTien;
        private int soLuong;
        private float thanhTien;

        public int IdHoaDonBan1 { get => IdHoaDonBan; set => IdHoaDonBan = value; }
        public int IdMonAn { get => idMonAn; set => idMonAn = value; }
        public int IdDanhMuc { get => idDanhMuc; set => idDanhMuc = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }

        public DTO_ChiTietHoaDonBan() { }

        public DTO_ChiTietHoaDonBan(int IdHoaDonBan, string tenMon, string tenDM, decimal gia, int sl, float thanhTien)
        {
            IdHoaDonBan1 = IdHoaDonBan;
            TenMonAn = tenMon;
            TenDanhMuc = tenDM;
            GiaTien = gia;
            SoLuong = sl;
            ThanhTien = thanhTien;
        }
    }
}
