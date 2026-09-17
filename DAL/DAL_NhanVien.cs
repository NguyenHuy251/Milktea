using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhanVien : DBConnect
    {
        DBConnect db = new DBConnect();

        public List<DTO_NhanVien> LayDanhSachNhanVien()
        {
            List<DTO_NhanVien> dsNhanVien = new List<DTO_NhanVien>();
            string query = "SELECT * FROM NhanVien";

            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["hoTen"].ToString();
                DateTime ngaySinh = row["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(row["ngaySinh"]) : DateTime.MinValue;
                string gioiTinh = row["gioiTinh"] != DBNull.Value ? row["gioiTinh"].ToString() : string.Empty;
                string soDienThoai = row["sdt"] != DBNull.Value ? row["sdt"].ToString() : string.Empty;
                string diaChi = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : string.Empty;
                int luong = row["Luong"] != DBNull.Value ? Convert.ToInt32(row["Luong"]) : 0;
                string chucVu = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : string.Empty;

                DTO_NhanVien nhanVien = new DTO_NhanVien(id, ten, ngaySinh, gioiTinh, soDienThoai, diaChi, luong, chucVu);
                dsNhanVien.Add(nhanVien);
            }

            return dsNhanVien;
        }

        public bool ThemNhanVien(DTO_NhanVien nhanVien)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "INSERT INTO NhanVien (hoTen, ngaySinh, gioiTinh, sdt, diaChi, Luong, ChucVu) " +
                               "VALUES (@hoTen, @ngaySinh, @gioiTinh, @soDienThoai, @diaChi, @luong, @chucVu)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@hoTen", nhanVien.HoTen),
                    new SqlParameter("@ngaySinh", nhanVien.NgaySinh),
                    new SqlParameter("@gioiTinh", (object)nhanVien.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@soDienThoai", (object)nhanVien.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@diaChi", (object)nhanVien.DiaChi ?? DBNull.Value),
                    new SqlParameter("@luong", nhanVien.Luong),
                    new SqlParameter("@chucVu", (object)nhanVien.ChucVu ?? DBNull.Value)
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

        public bool SuaNhanVien(DTO_NhanVien nhanVien)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "UPDATE NhanVien SET hoTen = @hoTen, ngaySinh = @ngaySinh, gioiTinh = @gioiTinh, " +
                               "sdt = @soDienThoai, diaChi = @diaChi, Luong = @luong, ChucVu = @chucVu " +
                               "WHERE id = @idNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@hoTen", nhanVien.HoTen),
                    new SqlParameter("@ngaySinh", nhanVien.NgaySinh),
                    new SqlParameter("@gioiTinh", (object)nhanVien.GioiTinh ?? DBNull.Value),
                    new SqlParameter("@soDienThoai", (object)nhanVien.SoDienThoai ?? DBNull.Value),
                    new SqlParameter("@diaChi", (object)nhanVien.DiaChi ?? DBNull.Value),
                    new SqlParameter("@luong", nhanVien.Luong),
                    new SqlParameter("@chucVu", (object)nhanVien.ChucVu ?? DBNull.Value),
                    new SqlParameter("@idNhanVien", nhanVien.IdNhanVien)
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

        public bool XoaNhanVien(int idNhanVien)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM HoaDonBan WHERE idNhanVien = @idNhanVien";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Không thể xóa nhân viên vì nhân viên này đang có hóa đơn liên quan.");
                    }
                }

                string query = "DELETE FROM NhanVien WHERE id = @idNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idNhanVien", idNhanVien)
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

        public List<DTO_NhanVien> LayDanhSachNhanVienTheoLoc(string hoTen, string gioiTinh,string diaChi, string chucVu)
        {
            List<DTO_NhanVien> dsNhanVien = new List<DTO_NhanVien>();
            string query = "SELECT * FROM NhanVien WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(hoTen))
            {
                query += " AND hoTen LIKE '%' +@hoTen+ '%'";
                parameters.Add(new SqlParameter("@hoTen", hoTen));
            }

            if (!string.IsNullOrEmpty(gioiTinh))
            {
                query += " AND gioiTinh = @gioiTinh";
                parameters.Add(new SqlParameter("@gioiTinh", gioiTinh));
            }

            if (!string.IsNullOrEmpty(diaChi))
            {
                query += " AND diaChi LIKE '%' +@diaChi+ '%'";
                parameters.Add(new SqlParameter("@diaChi", diaChi));
            }

            if (!string.IsNullOrEmpty(chucVu))
            {
                query += " AND ChucVu = @chucVu ";
                parameters.Add(new SqlParameter("@chucVu", chucVu));
            }

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                int id = int.Parse(row["id"].ToString());
                string ten = row["hoTen"].ToString();
                DateTime ngaySinh = row["ngaySinh"] != DBNull.Value ? Convert.ToDateTime(row["ngaySinh"]) : DateTime.MinValue;
                string gioiTinhRow = row["gioiTinh"] != DBNull.Value ? row["gioiTinh"].ToString() : string.Empty;
                string soDienThoai = row["sdt"] != DBNull.Value ? row["sdt"].ToString() : string.Empty;
                string diaChiRow = row["diaChi"] != DBNull.Value ? row["diaChi"].ToString() : string.Empty;
                int luong = row["Luong"] != DBNull.Value ? Convert.ToInt32(row["Luong"]) : 0;
                string chucVuRow = row["ChucVu"] != DBNull.Value ? row["ChucVu"].ToString() : string.Empty;

                DTO_NhanVien nhanVien = new DTO_NhanVien(id, ten, ngaySinh, gioiTinhRow, soDienThoai, diaChiRow, luong, chucVuRow);
                dsNhanVien.Add(nhanVien);
            }

            return dsNhanVien;
        }
    }
}