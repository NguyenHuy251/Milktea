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
    public class DAL_MonAn : DBConnect
    {   
        DBConnect db = new DBConnect();
        public DataTable GetMonAn()
        {
            string str = "SELECT * FROM MonAn";
            DataTable dt = db.GetDataTable(str);
            return dt;
        }
        public DataTable GetMonAn(string maMonAn)
        {
            string strSelect = "SELECT * FROM MonAn WHERE MaMonAn = @MaMonAn";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMonAn", maMonAn)
            };
            return GetDataTable(strSelect, parameters);
        }

        public DataTable LayMonAnTheoDanhMuc(string tenDanhMuc)
        {
            string query = "SELECT ma.id AS idMonAn, ma.tenMonAn, dm.tenDanhMuc, ma.giaTien " +
                           "FROM MonAn ma JOIN DanhMucMonAn dm ON ma.idDanhMuc = dm.id " +
                           "WHERE dm.tenDanhMuc = @tenDanhMuc";
            SqlParameter[] parameters = {
                new SqlParameter("@tenDanhMuc", tenDanhMuc)
            };
            return GetDataTable(query, parameters);
        }

        public List<DTO_MonAn> GetMonAnList()
        {
            string query = "SELECT ma.id AS idMonAn, ma.tenMonAn, ma.idDanhMuc, dm.tenDanhMuc, ma.giaTien " +
                          "FROM MonAn ma " +
                          "LEFT JOIN DanhMucMonAn dm ON ma.idDanhMuc = dm.id";
            List<DTO_MonAn> list = new List<DTO_MonAn>();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    conn.Close();
            }

            if (dt == null || dt.Rows.Count == 0)
            {
                return list;
            }

            

            foreach (DataRow row in dt.Rows)
            {
               DTO_MonAn monAn = new DTO_MonAn(
                   Convert.ToInt32(row["idMonAn"]),
                   row["tenMonAn"].ToString(),
                   Convert.ToInt32(row["idDanhMuc"]),
                   row["tenDanhMuc"] != DBNull.Value ? row["tenDanhMuc"].ToString() : "Không xác định",
                   Convert.ToInt32(row["giaTien"])
               );
               list.Add(monAn);
            }

            return list;
        }

        
        public bool ThemMonAn(DTO_MonAn monAn)
        {
            string query = "INSERT INTO MonAn (tenMonAn, idDanhMuc, giaTien) VALUES (@tenMonAn, @idDanhMuc, @giaTien)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenMonAn", monAn.TenMonAn),
                new SqlParameter("@idDanhMuc", monAn.IdDanhMuc),
                new SqlParameter("@giaTien", monAn.Gia)
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

        
        public bool SuaMonAn(DTO_MonAn monAn)
        {
            string query = "UPDATE MonAn SET tenMonAn = @tenMonAn, idDanhMuc = @idDanhMuc, giaTien = @giaTien WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenMonAn", monAn.TenMonAn),
                new SqlParameter("@idDanhMuc", monAn.IdDanhMuc),
                new SqlParameter("@giaTien", monAn.Gia),
                new SqlParameter("@id", monAn.IdMonAn)
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

        
        public bool XoaMonAn(int idMonAn)
        {
            string query = "DELETE FROM MonAn WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", idMonAn)
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

        
        public List<DTO_MonAn> LayMonAnTheoDanhMucList(string tenDanhMuc)
        {
            string query = "SELECT ma.id AS idMonAn, ma.tenMonAn, ma.idDanhMuc, dm.tenDanhMuc, ma.giaTien " +
                           "FROM MonAn ma " +
                           "JOIN DanhMucMonAn dm ON ma.idDanhMuc = dm.id " +
                           "WHERE dm.tenDanhMuc LIKE '%' +@tenDanhMuc+ '%'";
            SqlParameter[] parameters = {
                new SqlParameter("@tenDanhMuc", tenDanhMuc)
            };
            List<DTO_MonAn> list = new List<DTO_MonAn>();
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

            foreach (DataRow row in dt.Rows)
            {
                DTO_MonAn monAn = new DTO_MonAn(
                    Convert.ToInt32(row["idMonAn"]),
                    row["tenMonAn"].ToString(),
                    Convert.ToInt32(row["idDanhMuc"]),
                    row["tenDanhMuc"].ToString(),
                    Convert.ToInt32(row["giaTien"])
                );
                list.Add(monAn);
            }

            return list;
        }
    }
}
