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
    public class DAL_DanhMuc : DBConnect
    {
        DBConnect db = new DBConnect();

        public DataTable GetDanhMuc()
        {
            string str = "SELECT * FROM DanhMucMonAn";
            DataTable dt = db.GetDataTable(str);
            return dt;
        }

        public DataTable LayDanhSachDanhMuc()
        {
            string query = "SELECT id, tenDanhMuc FROM DanhMucMonAn";
            return GetDataTable(query);
        }

        public List<DTO_DanhMuc> GetDanhMucList()
        {
            string query = "SELECT id, tenDanhMuc FROM DanhMucMonAn";
            List<DTO_DanhMuc> list = new List<DTO_DanhMuc>();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            if (dt == null || dt.Rows.Count == 0)
            {
                return list;
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row["id"] == DBNull.Value || row["tenDanhMuc"] == DBNull.Value)
                {
                    continue; // Bỏ qua nếu dữ liệu không hợp lệ
                }

                DTO_DanhMuc danhMuc = new DTO_DanhMuc(
                    Convert.ToInt32(row["id"]),
                    row["tenDanhMuc"].ToString()
                );
                list.Add(danhMuc);
            }

            return list;
        }

        public bool ThemDanhMuc(DTO_DanhMuc danhMuc)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem tên danh mục đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM DanhMucMonAn WHERE tenDanhMuc = @tenDanhMuc";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Tên danh mục đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }

                string query = "INSERT INTO DanhMucMonAn (tenDanhMuc) VALUES (@tenDanhMuc)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenDanhMuc", danhMuc.TenDanhMuc)
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

        public bool SuaDanhMuc(DTO_DanhMuc danhMuc)
        {

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem tên danh mục đã tồn tại chưa (trừ danh mục hiện tại)
                string checkQuery = "SELECT COUNT(*) FROM DanhMucMonAn WHERE tenDanhMuc = @tenDanhMuc AND id != @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                    checkCmd.Parameters.AddWithValue("@id", danhMuc.IdDanhMuc);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Tên danh mục đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }

                string query = "UPDATE DanhMucMonAn SET tenDanhMuc = @tenDanhMuc WHERE id = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenDanhMuc", danhMuc.TenDanhMuc),
                    new SqlParameter("@id", danhMuc.IdDanhMuc)
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

        public bool XoaDanhMuc(int idDanhMuc)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem danh mục có món ăn liên quan không
                string checkQuery = "SELECT COUNT(*) FROM MonAn WHERE idDanhMuc = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", idDanhMuc);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Không thể xóa danh mục vì có món ăn đang sử dụng danh mục này.");
                    }
                }

                string query = "DELETE FROM DanhMucMonAn WHERE id = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idDanhMuc)
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
    }
}
