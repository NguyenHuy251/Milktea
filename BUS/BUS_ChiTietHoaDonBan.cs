using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dal = new DAL_ChiTietHoaDonBan();

        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDonTheoBan(int idBan)
        {
            return dal.LayChiTietHoaDonTheoBan(idBan);
        }

        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDonTheoIdHoaDon(int idHoaDonBan)
        {
            return dal.LayChiTietHoaDonTheoIdHoaDon(idHoaDonBan);
        }

        public bool KiemTraMonAnTonTai(int idBan, int idMonAn)
        {
            return dal.KiemTraMonAnTonTai(idBan, idMonAn);
        }

        public bool CapNhatSoLuongMonAn(int idHoaDonBan, int idMonAn, int soLuongMoi)
        {
            return dal.CapNhatSoLuongMonAn(idHoaDonBan, idMonAn, soLuongMoi);
        }

        public bool XoaMonAnKhoiHoaDon(int idHoaDonBan, int idMonAn)
        {
            return dal.XoaMonAnKhoiHoaDon(idHoaDonBan, idMonAn);
        }

        public float ThanhToanHoaDon(int idBan, float giamGia, int idNhanVien)
        {
            return dal.ThanhToanHoaDon(idBan, giamGia, idNhanVien);
        }

        public bool ChuyenBan(int idBanNguon, int idBanDich)
        {
            return dal.ChuyenBan(idBanNguon, idBanDich);
        }

        public List<DTO_HoaDonBan> LayDanhSachHoaDon(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            return dal.LayDanhSachHoaDon(tuNgay, denNgay, idNhanVien);
        }

        public DTO_HoaDonBan LayHoaDonBanTheoId(int idBan)
        {
            var danhSachHoaDon = dal.LayDanhSachHoaDon(null, null, null);
            return danhSachHoaDon.FirstOrDefault(hd => hd.IdBanAn == idBan && hd.TrangThaiHD);
        }

        public List<DTO_ChiTietHoaDonBan> ThongKeMonAnBanDuoc(DateTime? tuNgay, DateTime? denNgay)
        {
            return dal.ThongKeMonAnBanDuoc(tuNgay, denNgay);
        }

    }
}
