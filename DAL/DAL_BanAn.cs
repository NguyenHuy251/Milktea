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
    public class DAL_BanAn : DBConnect
    {
        DBConnect db = new DBConnect();
        public DataTable GetBanAn()
        {
            string str = "SELECT * FROM Ban";
            DataTable dt = db.GetDataTable(str);
            return dt;
        }

        public List<DTO_BanAn> LayTatCaBan()
        {
            string query = "SELECT id, tenBan, trangThai FROM Ban";
            DataTable dt = db.GetDataTable(query);

            List<DTO_BanAn> list = new List<DTO_BanAn>();
            foreach (DataRow row in dt.Rows)
            {
                DTO_BanAn ban = new DTO_BanAn(
                    Convert.ToInt32(row["id"]),
                    row["tenBan"].ToString(),
                    row["trangThai"].ToString()
                );
                list.Add(ban);
            }
            return list;
        }

        public List<DTO_BanAn> LayDanhSachBan()
        {
            List<DTO_BanAn> dsBan = new List<DTO_BanAn>();
            string query = "SELECT * FROM Ban"; 

            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["tenBan"].ToString();
                string trangThai = row["trangThai"].ToString();

                DTO_BanAn ban = new DTO_BanAn(id, ten, trangThai);
                dsBan.Add(ban);
            }

            return dsBan;
        }

        public List<DTO_BanAn> LayDanhSachBanTheoTrangThai(string trangThai)
        {
            List<DTO_BanAn> dsBan = new List<DTO_BanAn>();
            string query;
            SqlParameter[] parameters;

            if (trangThai == "Tất cả")
            {
                query = "SELECT * FROM Ban";
                parameters = null;
            }
            else
            {
                query = "SELECT * FROM Ban WHERE trangThai LIKE '%' + @trangThai + '%'";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@trangThai", trangThai)
                };
            }

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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["tenBan"].ToString();
                string trangThaiBan = row["trangThai"].ToString();

                DTO_BanAn ban = new DTO_BanAn(id, ten, trangThaiBan);
                dsBan.Add(ban);
            }

            return dsBan;
        }

        public bool ThemBanAn(DTO_BanAn ban)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem tên bàn đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Ban WHERE tenBan = @tenBan";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tenBan", ban.TenBanAn);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Tên bàn đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }

                string query = "INSERT INTO Ban (tenBan, trangThai) VALUES (@tenBan, @trangThai)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenBan", ban.TenBanAn),
                    new SqlParameter("@trangThai", ban.TrangThai)
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

        public bool SuaBanAn(DTO_BanAn ban)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem tên bàn đã tồn tại chưa (trừ bàn hiện tại)
                string checkQuery = "SELECT COUNT(*) FROM Ban WHERE tenBan = @tenBan AND id != @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tenBan", ban.TenBanAn);
                    checkCmd.Parameters.AddWithValue("@id", ban.IdBanAn);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Tên bàn đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }

                string query = "UPDATE Ban SET tenBan = @tenBan, trangThai = @trangThai WHERE id = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenBan", ban.TenBanAn),
                    new SqlParameter("@trangThai", ban.TrangThai),
                    new SqlParameter("@id", ban.IdBanAn)
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

        public bool SuaBanAnKiemTraHoaDon(DTO_BanAn ban)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                // Kiểm tra xem tên bàn đã tồn tại chưa (trừ bàn hiện tại)
                string checkNameQuery = "SELECT COUNT(*) FROM Ban WHERE tenBan = @tenBan AND id != @id";
                using (SqlCommand checkNameCmd = new SqlCommand(checkNameQuery, conn))
                {
                    checkNameCmd.Parameters.AddWithValue("@tenBan", ban.TenBanAn);
                    checkNameCmd.Parameters.AddWithValue("@id", ban.IdBanAn);
                    int count = (int)checkNameCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Tên bàn đã tồn tại. Vui lòng chọn tên khác.");
                    }
                }

                // Kiểm tra xem bàn có hóa đơn chưa thanh toán không
                string checkHoaDonQuery = "SELECT COUNT(*) FROM HoaDonBan WHERE idBanAn = @id AND trangThaiHD = 0";
                using (SqlCommand checkHoaDonCmd = new SqlCommand(checkHoaDonQuery, conn))
                {
                    checkHoaDonCmd.Parameters.AddWithValue("@id", ban.IdBanAn);
                    int count = (int)checkHoaDonCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Bàn đang có hóa đơn chưa thanh toán, không thể đổi trạng thái bàn.");
                    }
                }

                // Nếu không có hóa đơn chưa thanh toán, tiến hành cập nhật
                string query = "UPDATE Ban SET tenBan = @tenBan, trangThai = @trangThai WHERE id = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tenBan", ban.TenBanAn),
                    new SqlParameter("@trangThai", ban.TrangThai),
                    new SqlParameter("@id", ban.IdBanAn)
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

        public bool XoaBanAn(int idBanAn)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                // Kiểm tra xem bàn có hóa đơn liên quan không
                string checkQuery = "SELECT COUNT(*) FROM HoaDonBan WHERE idBanAn = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", idBanAn);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Không thể xóa bàn vì có hóa đơn đang sử dụng bàn này.");
                    }
                }

                string query = "DELETE FROM Ban WHERE id = @id";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", idBanAn)
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
