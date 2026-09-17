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
    public class BUS_Login
    {
        DAL_Login dal_Login = new DAL_Login();
        public DTO_Login KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return dal_Login.KiemTraDangNhap(tenDangNhap, matKhau);
        }
    }
}
