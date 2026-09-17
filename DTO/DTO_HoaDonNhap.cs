using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonNhap
    {
        private int idHoaDonNhap;
        private int idNhaCungCap;
        private string tenNhaCC; 
        private DateTime ngayNhap;
        private float tongTien;
        private int idNhanVien;
        private string hoTen;

        public int IdHoaDonNhap { get => idHoaDonNhap; set => idHoaDonNhap = value; }
        public int IdNhaCungCap { get => idNhaCungCap; set => idNhaCungCap = value; }
        public string TenNhaCC { get => tenNhaCC; set => tenNhaCC = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        public DTO_HoaDonNhap() { }

        public DTO_HoaDonNhap(int id, int idNhaCungCap, string tenNhaCC, DateTime ngayNhap, float tongTien, int idNhanVien, string hoTen)
        {
            this.IdHoaDonNhap = id;
            this.IdNhaCungCap = idNhaCungCap;
            this.TenNhaCC = tenNhaCC;
            this.NgayNhap = ngayNhap;
            this.TongTien = tongTien;
            this.IdNhanVien = idNhanVien;
            this.HoTen = hoTen;
        }
    }
}
