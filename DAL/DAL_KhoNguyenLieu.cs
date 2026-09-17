using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KhoNguyenLieu : DBConnect
    {
        public List<DTO_KhoNguyenLieu> LayDanhSachNguyenLieuKho()
        {
            List<DTO_KhoNguyenLieu> dsNguyenLieu = new List<DTO_KhoNguyenLieu>();
            string query = "SELECT * FROM KhoNguyenLieu";

            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["tenNguyenLieu"].ToString();
                float soLuongTon = float.Parse(row["soLuongTon"].ToString());
                string donViTinh = row["donViTinh"] != DBNull.Value ? row["donViTinh"].ToString() : string.Empty;
                string ghiChu = row["ghiChu"] != DBNull.Value ? row["ghiChu"].ToString() : string.Empty;

                DTO_KhoNguyenLieu nguyenLieu = new DTO_KhoNguyenLieu(id, ten, soLuongTon, donViTinh, ghiChu);
                dsNguyenLieu.Add(nguyenLieu);
            }

            return dsNguyenLieu;
        }

        public int ThemNguyenLieuMoi(string tenNguyenLieu, string donViTinh, string ghiChu)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string insertQuery = "INSERT INTO KhoNguyenLieu (tenNguyenLieu, donViTinh, soLuongTon, ghiChu) " +
                                     "OUTPUT INSERTED.id " +
                                     "VALUES (@tenNguyenLieu, @donViTinh, 0, @ghiChu)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@tenNguyenLieu", tenNguyenLieu);
                    insertCmd.Parameters.AddWithValue("@donViTinh", donViTinh ?? (object)DBNull.Value);
                    insertCmd.Parameters.AddWithValue("@ghiChu", ghiChu ?? (object)DBNull.Value);
                    int newId = (int)insertCmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        public int LayIdNguyenLieuTheoTen(string tenNguyenLieu)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string query = "SELECT id FROM KhoNguyenLieu WHERE tenNguyenLieu = @tenNguyenLieu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNguyenLieu", tenNguyenLieu);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public bool ThemNguyenLieuVaoKho(int idNguyenLieu, int soLuong, string donViTinh)
        {
            if (string.IsNullOrEmpty(strCon))
            {
                throw new Exception("Chuỗi kết nối cơ sở dữ liệu không được thiết lập.");
            }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();

                    string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                    using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                    {
                        int tableExists = (int)checkTableCmd.ExecuteScalar();
                        if (tableExists == 0)
                        {
                            throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                        }
                    }

                    string updateQuery = "UPDATE KhoNguyenLieu SET soLuongTon = soLuongTon + @soLuong, donViTinh = @donViTinh WHERE id = @idNguyenLieu";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@soLuong", soLuong);
                        updateCmd.Parameters.AddWithValue("@donViTinh", donViTinh ?? (object)DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@idNguyenLieu", idNguyenLieu);
                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi thêm nguyên liệu vào kho: {ex.Message}", ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        public List<DTO_KhoNguyenLieu> TimKiemNguyenLieuTheoTen(string tenNguyenLieu)
        {
            List<DTO_KhoNguyenLieu> dsNguyenLieu = new List<DTO_KhoNguyenLieu>();

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string query = "SELECT * FROM KhoNguyenLieu WHERE tenNguyenLieu LIKE '%' + @tenNguyenLieu + '%'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenNguyenLieu", tenNguyenLieu);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string ten = reader.GetString(reader.GetOrdinal("tenNguyenLieu"));
                            float soLuongTon = (float)reader.GetDouble(reader.GetOrdinal("soLuongTon"));
                            string donViTinh = reader.IsDBNull(reader.GetOrdinal("donViTinh")) ? string.Empty : reader.GetString(reader.GetOrdinal("donViTinh"));
                            string ghiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? string.Empty : reader.GetString(reader.GetOrdinal("ghiChu"));

                            DTO_KhoNguyenLieu nguyenLieu = new DTO_KhoNguyenLieu(id, ten, soLuongTon, donViTinh, ghiChu);
                            dsNguyenLieu.Add(nguyenLieu);
                        }
                    }
                }
            }

            return dsNguyenLieu;
        }

        public bool CapNhatNguyenLieu(DTO_KhoNguyenLieu nguyenLieu)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string updateQuery = "UPDATE KhoNguyenLieu SET tenNguyenLieu = @tenNguyenLieu, donViTinh = @donViTinh, soLuongTon = @soLuongTon, ghiChu = @ghiChu WHERE id = @id";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@tenNguyenLieu", nguyenLieu.TenNguyenLieu);
                    updateCmd.Parameters.AddWithValue("@donViTinh", nguyenLieu.DonViTinh ?? (object)DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@soLuongTon", nguyenLieu.SoLuongTon);
                    updateCmd.Parameters.AddWithValue("@ghiChu", nguyenLieu.GhiChu ?? (object)DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@id", nguyenLieu.IdKhoNguyenLieu);
                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool XoaNguyenLieu(int idNguyenLieu)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'KhoNguyenLieu'";
                using (SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, conn))
                {
                    int tableExists = (int)checkTableCmd.ExecuteScalar();
                    if (tableExists == 0)
                    {
                        throw new Exception("Bảng KhoNguyenLieu không tồn tại trong cơ sở dữ liệu.");
                    }
                }

                string deleteQuery = "DELETE FROM KhoNguyenLieu WHERE id = @idNguyenLieu";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@idNguyenLieu", idNguyenLieu);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<DTO_CongThucMonAn> LayCongThucMonAn(int idMonAn)
        {
            List<DTO_CongThucMonAn> dsCongThuc = new List<DTO_CongThucMonAn>();
            string query = "SELECT * FROM CongThucMonAn WHERE idMonAn = @idMonAn";

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMonAn", idMonAn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_CongThucMonAn congThuc = new DTO_CongThucMonAn
                            {
                                IdMonAn = reader.GetInt32(reader.GetOrdinal("idMonAn")),
                                IdNguyenLieu = reader.GetInt32(reader.GetOrdinal("idNguyenLieu")),
                                SoLuong = (float)reader.GetDouble(reader.GetOrdinal("soLuong")),
                                DonViTinh = reader.GetString(reader.GetOrdinal("donViTinh"))
                            };
                            dsCongThuc.Add(congThuc);
                        }
                    }
                }
            }

            return dsCongThuc;
        }

        public bool KiemTraSoLuongNguyenLieu(int idNguyenLieu, float soLuongCan)
        {
            string query = "SELECT soLuongTon FROM KhoNguyenLieu WHERE id = @idNguyenLieu";

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idNguyenLieu", idNguyenLieu);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        float soLuongTon = Convert.ToSingle(result);
                        return soLuongTon >= soLuongCan;
                    }
                    return false;
                }
            }
        }

        public bool TruNguyenLieu(int idNguyenLieu, float soLuong)
        {
            string query = "UPDATE KhoNguyenLieu SET soLuongTon = soLuongTon - @soLuong WHERE id = @idNguyenLieu";

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@soLuong", soLuong);
                        cmd.Parameters.AddWithValue("@idNguyenLieu", idNguyenLieu);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi trừ nguyên liệu: {ex.Message}", ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        public string LayTenNguyenLieuTheoId(int idNguyenLieu)
        {
            string tenNguyenLieu = "Không xác định";
            string query = "SELECT tenNguyenLieu FROM KhoNguyenLieu WHERE id = @idNguyenLieu";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idNguyenLieu", idNguyenLieu)
            };

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                if (dt.Rows.Count > 0)
                {
                    tenNguyenLieu = dt.Rows[0]["tenNguyenLieu"].ToString();
                }
            }
            return tenNguyenLieu;
        }
    }
}
