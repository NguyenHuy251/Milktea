using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dal_hoaDonNhap = new DAL_HoaDonNhap();

        public int ThemHoaDonNhap(DTO_HoaDonNhap hoaDon)
        {
            return dal_hoaDonNhap.ThemHoaDonNhap(hoaDon);
        }
        public List<DTO_HoaDonNhap> LayDanhSachHoaDonNhap(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            return dal_hoaDonNhap.LayDanhSachHoaDonNhap(tuNgay, denNgay, idNhanVien);
        }

        public DTO_HoaDonNhap LayHoaDonNhapTheoId(int id)
        {
            var danhSachHoaDonNhap = dal_hoaDonNhap.LayDanhSachHoaDonNhap(null, null, null);
            return danhSachHoaDonNhap.FirstOrDefault(hd => hd.IdHoaDonNhap == id);
        }

        public string LayTenNguyenLieuTheoId(int idNguyenLieu)
        {
            DAL_KhoNguyenLieu dalKhoNguyenLieu = new DAL_KhoNguyenLieu();
            return dalKhoNguyenLieu.LayTenNguyenLieuTheoId(idNguyenLieu);
        }
    }
}
