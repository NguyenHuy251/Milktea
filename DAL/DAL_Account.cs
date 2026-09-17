using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_Account : DBConnect
    {
        DBConnect db = new DBConnect();

        public DataTable GetAccountList()
        {
            string sql = "SELECT * FROM TaiKhoan";
            DataTable dt = db.GetDataTable(sql);
            return dt;
        }

        public DTO_Account LayTaiKhoanTheoUserName(string userName)
        {
            string query = "SELECT * FROM TaiKhoan WHERE tenDangNhap = @userName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName", userName)
            };

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {                
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                conn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_Account(
                    row["tenDangNhap"].ToString(),
                    row["tenHienThi"].ToString(),
                    row["matKhau"].ToString(),
                    int.Parse(row["loaiTaiKhoan"].ToString()),
                    int.Parse(row["idNhanVien"].ToString())
                );
            }
            return null;
        }

        public bool CapNhatTaiKhoan(DTO_Account taiKhoan)
        {
            string query = "UPDATE TaiKhoan SET tenHienThi = @tenHienThi, matKhau = @matKhau WHERE tenDangNhap = @tenDangNhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenHienThi", taiKhoan.TenHienThi),
                new SqlParameter("@matKhau", taiKhoan.MatKhau),
                new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

        }

        public bool ThemTaiKhoan(DTO_Account taiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "INSERT INTO TaiKhoan (tenDangNhap, tenHienThi, matKhau, loaiTaiKhoan, idNhanVien) " +
                               "VALUES (@tenDangNhap, @tenHienThi, @matKhau, @loaiTaiKhoan, @idNhanVien)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap),
                    new SqlParameter("@tenHienThi", taiKhoan.TenHienThi),
                    new SqlParameter("@matKhau", taiKhoan.MatKhau),
                    new SqlParameter("@loaiTaiKhoan", taiKhoan.LoaiTaiKhoan),
                    new SqlParameter("@idNhanVien", taiKhoan.IdNhanVien)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool SuaTaiKhoan(DTO_Account taiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "UPDATE TaiKhoan SET tenDangNhap = @tenDangNhap, tenHienThi = @tenHienThi, loaiTaiKhoan = @loaiTaiKhoan, idNhanVien = @idNhanVien " +
                               "WHERE idNhanVien = @idNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenHienThi", taiKhoan.TenHienThi),
                    new SqlParameter("@loaiTaiKhoan", taiKhoan.LoaiTaiKhoan),
                    new SqlParameter("@idNhanVien", taiKhoan.IdNhanVien),
                    new SqlParameter("@tenDangNhap", taiKhoan.TenDangNhap)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "DELETE FROM TaiKhoan WHERE tenDangNhap = @tenDangNhap";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenDangNhap", tenDangNhap)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool ResetMatKhau(string tenDangNhap)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "UPDATE TaiKhoan SET matKhau = '1' WHERE tenDangNhap = @tenDangNhap";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenDangNhap", tenDangNhap)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public DataTable LayTaiKhoanTheoLoaiTaiKhoan(int loaiTaiKhoan)
        {
            string query = "SELECT tenDangNhap, tenHienThi, loaiTaiKhoan, idNhanVien FROM TaiKhoan WHERE loaiTaiKhoan = @loaiTaiKhoan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@loaiTaiKhoan", loaiTaiKhoan)
            };

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
        
    }
}

