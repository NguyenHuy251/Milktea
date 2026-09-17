using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nhanVien = new DAL_NhanVien();

        public List<DTO_NhanVien> LayDanhSachNhanVien()
        {
            return dal_nhanVien.LayDanhSachNhanVien();
        }

        public bool ThemNhanVien(DTO_NhanVien nhanVien)
        {
            return dal_nhanVien.ThemNhanVien(nhanVien);
        }

        public bool SuaNhanVien(DTO_NhanVien nhanVien)
        {
            return dal_nhanVien.SuaNhanVien(nhanVien);
        }

        public bool XoaNhanVien(int idNhanVien)
        {
            return dal_nhanVien.XoaNhanVien(idNhanVien);
        }

        public List<DTO_NhanVien> LayDanhSachNhanVienTheoLoc(string hoTen, string gioiTinh, string diaChi, string chucVu)
        {
            return dal_nhanVien.LayDanhSachNhanVienTheoLoc(hoTen, gioiTinh, diaChi, chucVu);
        }
    }
}