using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_BaoCaoDoanhThu
    {
        private DAL_BaoCaoDoanhThu dalBaoCao = new DAL_BaoCaoDoanhThu();

        public List<DTO_BaoCaoDoanhThu> LayDanhSachBaoCao()
        {
            return dalBaoCao.LayDanhSachBaoCao();
        }

        public DTO_BaoCaoDoanhThu ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return dalBaoCao.ThongKeDoanhThu(tuNgay, denNgay);
        }

        public bool ThemBaoCao(DTO_BaoCaoDoanhThu baoCao)
        {
            return dalBaoCao.ThemBaoCao(baoCao);
        }

        public bool XoaBaoCao(int idBaoCao)
        {
            return dalBaoCao.XoaBaoCao(idBaoCao);
        }
    }
}
