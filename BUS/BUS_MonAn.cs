using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;


namespace BUS
{
    public class BUS_MonAn 
    {
        DAL_MonAn dal_monAn = new DAL_MonAn();
        public DataTable GetMonAn()
        {
            return dal_monAn.GetMonAn();
        }
        public DataTable GetMonAn(string maMonAn)
        {
            return dal_monAn.GetMonAn(maMonAn);
        }

        public List<DTO_MonAn> LayMonAnTheoDanhMuc(string tenDanhMuc)
        {
            DataTable dt = dal_monAn.LayMonAnTheoDanhMuc(tenDanhMuc);
            List<DTO_MonAn> list = new List<DTO_MonAn>();
            foreach (DataRow row in dt.Rows)
            {
                DTO_MonAn mon = new DTO_MonAn(
                    Convert.ToInt32(row["idMonAn"]),
                    row["tenMonAn"].ToString(),
                    row["tenDanhMuc"].ToString(),
                    Convert.ToInt32(row["giaTien"])
                );
                list.Add(mon);
            }
            return list;
        }

        public List<DTO_MonAn> GetMonAnList()
        {
            return dal_monAn.GetMonAnList();
        }

        public bool ThemMonAn(DTO_MonAn monAn)
        {
            return dal_monAn.ThemMonAn(monAn);
        }

        public bool SuaMonAn(DTO_MonAn monAn)
        {
            return dal_monAn.SuaMonAn(monAn);
        }

        public bool XoaMonAn(int idMonAn)
        {
            return dal_monAn.XoaMonAn(idMonAn);
        }

        public List<DTO_MonAn> LayMonAnTheoDanhMucList(string tenDanhMuc)
        {
            return dal_monAn.LayMonAnTheoDanhMucList(tenDanhMuc);
        }
    }
}
