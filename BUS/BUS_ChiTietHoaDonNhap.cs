using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ChiTietHoaDonNhap
    {
        DAL_ChiTietHoaDonNhap dal_chiTiet = new DAL_ChiTietHoaDonNhap();

        public bool ThemChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap chiTiet)
        {
            return dal_chiTiet.ThemChiTietHoaDonNhap(chiTiet);
        }

        public List<DTO_ChiTietHoaDonNhap> LayChiTietHoaDonNhapTheoId(int idHoaDonNhap)
        {
            return dal_chiTiet.LayChiTietHoaDonNhapTheoId(idHoaDonNhap);
        }
    }
}
