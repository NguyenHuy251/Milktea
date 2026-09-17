using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_BanAn
    {
        DAL_BanAn dal_banAn = new DAL_BanAn();
        public DataTable GetBanAn()
        {
            return dal_banAn.GetBanAn();
        }

        public List<DTO_BanAn> LayTatCaBan()
        {
            return dal_banAn.LayTatCaBan();
        }

        public List<DTO_BanAn> LayDanhSachBan()
        {
            return dal_banAn.LayDanhSachBan();
        }

        public bool ThemBanAn(DTO_BanAn ban)
        {
            return dal_banAn.ThemBanAn(ban);
        }

        public bool SuaBanAn(DTO_BanAn ban)
        {
            return dal_banAn.SuaBanAn(ban);
        }

        public bool SuaBanAnKiemTraHoaDon(DTO_BanAn ban)
        {
            return dal_banAn.SuaBanAnKiemTraHoaDon(ban);
        }

        public bool XoaBanAn(int idBanAn)
        {
            return dal_banAn.XoaBanAn(idBanAn);
        }

        public List<DTO_BanAn> LayDanhSachBanTheoTrangThai(string trangThai)
        {
            return dal_banAn.LayDanhSachBanTheoTrangThai(trangThai);
        }
    }
}
