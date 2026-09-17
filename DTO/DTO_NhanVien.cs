using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private int idNhanVien;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string diaChi;
        private int luong;
        private string chucVu;

        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int Luong { get => luong; set => luong = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }

        public DTO_NhanVien() { }

        public DTO_NhanVien(int id, string ten, DateTime ngaySinh, string gioiTinh, string soDienThoai, string diaChi, int luong, string chucVu)
        {
            this.IdNhanVien = id;
            this.HoTen = ten;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.Luong = luong;
            this.ChucVu = chucVu;
        }

        public override string ToString() => HoTen; // Để hiển thị trong ComboBox
    }
}
