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
    public class BUS_DanhMuc
    {
        DAL_DanhMuc dal_danhMuc = new DAL_DanhMuc();
        public DataTable GetDanhMuc()
        {
            return dal_danhMuc.GetDanhMuc();
        }

        public List<DTO_DanhMuc> LayDanhSachDanhMuc()
        {
            DataTable dt = dal_danhMuc.LayDanhSachDanhMuc();
            List<DTO_DanhMuc> list = new List<DTO_DanhMuc>();
            foreach (DataRow row in dt.Rows)
            {
                DTO_DanhMuc dm = new DTO_DanhMuc(
                    Convert.ToInt32(row["id"]),
                    row["tenDanhMuc"].ToString()
                );
                list.Add(dm);
            }
            return list;
        }

        public List<DTO_DanhMuc> GetDanhMucList()
        {
            return dal_danhMuc.GetDanhMucList();
        }

        public bool ThemDanhMuc(DTO_DanhMuc danhMuc)
        {
            return dal_danhMuc.ThemDanhMuc(danhMuc);
        }

        public bool SuaDanhMuc(DTO_DanhMuc danhMuc)
        {
            return dal_danhMuc.SuaDanhMuc(danhMuc);
        }

        public bool XoaDanhMuc(int idDanhMuc)
        {
            return dal_danhMuc.XoaDanhMuc(idDanhMuc);
        }
    }
}
