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
    public class DAL_NhaCungCap : DBConnect
    {
        DBConnect db = new DBConnect();

        public List<DTO_NhaCungCap> LayDanhSachNhaCungCap()
        {
            List<DTO_NhaCungCap> dsNhaCungCap = new List<DTO_NhaCungCap>();
            string query = "SELECT * FROM NhaCungCap";

            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["tenNhaCungCap"].ToString();
                string diaChi = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : string.Empty;
                string sdt = row["sdt"] != DBNull.Value ? row["sdt"].ToString() : string.Empty;
                string email = row["email"] != DBNull.Value ? row["email"].ToString() : string.Empty;

                DTO_NhaCungCap nhaCC = new DTO_NhaCungCap(id, ten, diaChi, sdt, email);
                dsNhaCungCap.Add(nhaCC);
            }

            return dsNhaCungCap;
        }

        public bool ThemNhaCungCap(DTO_NhaCungCap nhaCC)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhaCungCap'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng NhaCungCap không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string query = "INSERT INTO NhaCungCap (tenNhaCungCap, diaChi, sdt, email) " +
                               "VALUES (@tenNhaCC, @diaChi, @soDienThoai, @email)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenNhaCC", nhaCC.TenNhaCC),
                    new SqlParameter("@diaChi", (object)nhaCC.DiaChi ?? DBNull.Value),
                    new SqlParameter("@soDienThoai", (object)nhaCC.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@email", (object)nhaCC.Email ?? DBNull.Value)
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

        public bool SuaNhaCungCap(DTO_NhaCungCap nhaCC)
        {

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhaCungCap'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng NhaCungCap không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string query = "UPDATE NhaCungCap SET tenNhaCungCap = @tenNhaCC, diaChi = @diaChi, " +
                               "sdt = @soDienThoai, email = @email WHERE id = @idNhaCC";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenNhaCC", nhaCC.TenNhaCC),
                    new SqlParameter("@diaChi", (object)nhaCC.DiaChi ?? DBNull.Value),
                    new SqlParameter("@soDienThoai", (object)nhaCC.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@email", (object)nhaCC.Email ?? DBNull.Value),
                    new SqlParameter("@idNhaCC", nhaCC.IdNhaCC)
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

        public bool XoaNhaCungCap(int idNhaCC)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhaCungCap'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng NhaCungCap không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string query = "DELETE FROM NhaCungCap WHERE id = @idNhaCC";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idNhaCC", idNhaCC)
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

        public List<DTO_NhaCungCap> LayDanhSachNhaCungCapTheoDiaChi(string diaChi)
        {
            List<DTO_NhaCungCap> dsNhaCungCap = new List<DTO_NhaCungCap>();
            string query = "SELECT * FROM NhaCungCap WHERE diaChi = @diaChi";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@diaChi", diaChi)
            };

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhaCungCap'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng NhaCungCap không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["tenNhaCungCap"].ToString();
                string diaChiRow = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : string.Empty;
                string sdt = row["sdt"] != DBNull.Value ? row["sdt"].ToString() : string.Empty;
                string email = row["email"] != DBNull.Value ? row["email"].ToString() : string.Empty;

                DTO_NhaCungCap nhaCC = new DTO_NhaCungCap(id, ten, diaChiRow, sdt, email);
                dsNhaCungCap.Add(nhaCC);
            }

            return dsNhaCungCap;
        }

        public List<string> LayDanhSachDiaChi()
        {
            List<string> dsDiaChi = new List<string>();
            string query = "SELECT DISTINCT diaChi FROM NhaCungCap WHERE diaChi IS NOT NULL";

            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                dsDiaChi.Add(row["diaChi"].ToString());
            }

            return dsDiaChi;
        }
    }
}
