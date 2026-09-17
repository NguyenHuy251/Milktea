using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Login
    {
        private int idNhanVien;
        private string tenDangNhap;
        private string matKhau;
        private int loaiTK;
        private string tenHienThi;

        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int LoaiTK { get => loaiTK; set => loaiTK = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }

        public DTO_Login() { }

        public DTO_Login(int idNhanVien,string tenDangNhap, string matKhau, string tenHienThi, int loaiTK)
        {
            IdNhanVien = idNhanVien;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            TenHienThi = tenHienThi;
            LoaiTK = loaiTK;
        }
    }
}
