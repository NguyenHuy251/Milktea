using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Account
    {
        private string tenDangNhap;
        private string tenHienThi;
        private string matKhau;
        private int loaiTaiKhoan;
        private int idNhanVien;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }

        public DTO_Account() { }

        public DTO_Account(string tenDangNhap, string tenHienThi, string matKhau, int loaiTaiKhoan, int idNhanVien)
        {
            this.TenDangNhap = tenDangNhap;
            this.TenHienThi = tenHienThi;
            this.MatKhau = matKhau;
            this.LoaiTaiKhoan = loaiTaiKhoan;
            this.IdNhanVien = idNhanVien; 
        }
    }
}
