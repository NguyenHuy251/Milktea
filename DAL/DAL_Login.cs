using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Login : DBConnect
    {
        public DTO_Login KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string query = "SELECT * FROM TaiKhoan WHERE tenDangNhap = @user AND matKhau = @pass";
            SqlParameter[] parameters = {
            new SqlParameter("@user", tenDangNhap),
            new SqlParameter("@pass", matKhau)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new DTO_Login(
                    Convert.ToInt32(r["idNhanVien"]),
                    r["tenDangNhap"].ToString(),
                    r["matKhau"].ToString(),
                    r["tenHienThi"].ToString(),
                    Convert.ToInt32(r["loaiTaiKhoan"])
                );
            }

            return null;
        }


    }
}
