using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhoNguyenLieu
    {
        DAL_KhoNguyenLieu dal_khoNguyenLieu = new DAL_KhoNguyenLieu();

        public List<DTO_KhoNguyenLieu> LayDanhSachNguyenLieuKho()
        {
            return dal_khoNguyenLieu.LayDanhSachNguyenLieuKho();
        }

        public int ThemNguyenLieuMoi(string tenNguyenLieu, string donViTinh, string ghiChu)
        {
            return dal_khoNguyenLieu.ThemNguyenLieuMoi(tenNguyenLieu, donViTinh, ghiChu);
        }

        public int LayIdNguyenLieuTheoTen(string tenNguyenLieu)
        {
            return dal_khoNguyenLieu.LayIdNguyenLieuTheoTen(tenNguyenLieu);
        }

        public bool ThemNguyenLieuVaoKho(int idNguyenLieu, int soLuong, string donViTinh)
        {
            return dal_khoNguyenLieu.ThemNguyenLieuVaoKho(idNguyenLieu, soLuong, donViTinh);
        }

        public List<DTO_KhoNguyenLieu> TimKiemNguyenLieuTheoTen(string tenNguyenLieu)
        {
            return dal_khoNguyenLieu.TimKiemNguyenLieuTheoTen(tenNguyenLieu);
        }

        public bool CapNhatNguyenLieu(DTO_KhoNguyenLieu nguyenLieu)
        {
            return dal_khoNguyenLieu.CapNhatNguyenLieu(nguyenLieu);
        }

        public bool XoaNguyenLieu(int idNguyenLieu)
        {
            return dal_khoNguyenLieu.XoaNguyenLieu(idNguyenLieu);
        }

        public List<DTO_CongThucMonAn> LayCongThucMonAn(int idMonAn)
        {
            return dal_khoNguyenLieu.LayCongThucMonAn(idMonAn);
        }

        public bool KiemTraSoLuongNguyenLieu(int idNguyenLieu, float soLuongCan)
        {
            return dal_khoNguyenLieu.KiemTraSoLuongNguyenLieu(idNguyenLieu, soLuongCan);
        }

        public bool TruNguyenLieu(int idNguyenLieu, float soLuong)
        {
            return dal_khoNguyenLieu.TruNguyenLieu(idNguyenLieu, soLuong);
        }
    }
}
