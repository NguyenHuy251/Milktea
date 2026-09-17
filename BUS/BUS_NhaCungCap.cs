using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dal_nhaCC = new DAL_NhaCungCap();

        public List<DTO_NhaCungCap> LayDanhSachNhaCungCap()
        {
            return dal_nhaCC.LayDanhSachNhaCungCap();
        }

        public bool ThemNhaCungCap(DTO_NhaCungCap nhaCC)
        {
            return dal_nhaCC.ThemNhaCungCap(nhaCC);
        }

        public bool SuaNhaCungCap(DTO_NhaCungCap nhaCC)
        {
            return dal_nhaCC.SuaNhaCungCap(nhaCC);
        }

        public bool XoaNhaCungCap(int idNhaCC)
        {
            return dal_nhaCC.XoaNhaCungCap(idNhaCC);
        }

        public List<DTO_NhaCungCap> LayDanhSachNhaCungCapTheoDiaChi(string diaChi)
        {
            return dal_nhaCC.LayDanhSachNhaCungCapTheoDiaChi(diaChi);
        }

        public List<string> LayDanhSachDiaChi()
        {
            return dal_nhaCC.LayDanhSachDiaChi();
        }
    }
}