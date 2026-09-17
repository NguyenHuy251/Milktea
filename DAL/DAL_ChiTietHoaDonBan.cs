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
    public class DAL_ChiTietHoaDonBan : DBConnect
    {
        DBConnect db = new DBConnect();
        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDonTheoBan(int idBan)
        {
            List<DTO_ChiTietHoaDonBan> list = new List<DTO_ChiTietHoaDonBan>();

            string query = @"
                SELECT 
                    cthd.idHoaDonBan,
                    cthd.idMonAn,
                    ma.idDanhMuc,
                    ma.tenMonAn,
                    dm.tenDanhMuc,
                    ma.giaTien,
                    cthd.soLuong,
                    (cthd.soLuong * ma.giaTien) AS ThanhTien
                FROM HoaDonBan hd
                JOIN ChiTietHoaDonBan cthd ON hd.id = cthd.idHoaDonBan
                JOIN MonAn ma ON cthd.idMonAn = ma.id
                JOIN DanhMucMonAn dm ON ma.idDanhMuc = dm.id
                WHERE hd.idBanAn = @idBan AND hd.trangThaiHD = 0";

            SqlParameter[] parameters = {
                new SqlParameter("@idBan", idBan)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        DTO_ChiTietHoaDonBan ct = new DTO_ChiTietHoaDonBan
                        {
                            IdHoaDonBan1 = Convert.ToInt32(row["idHoaDonBan"]),
                            IdMonAn = Convert.ToInt32(row["idMonAn"]),
                            IdDanhMuc = Convert.ToInt32(row["idDanhMuc"]),
                            TenMonAn = row["tenMonAn"].ToString(),
                            TenDanhMuc = row["tenDanhMuc"].ToString(),
                            GiaTien = Convert.ToDecimal(row["giaTien"]),
                            SoLuong = Convert.ToInt32(row["soLuong"]),
                            ThanhTien = Convert.ToSingle(row["ThanhTien"])
                        };
                        list.Add(ct);
                    }
                }
            }

            return list;
        }

        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDonTheoIdHoaDon(int idHoaDonBan)
        {
            List<DTO_ChiTietHoaDonBan> chiTietList = new List<DTO_ChiTietHoaDonBan>();

            string query = @"
                SELECT 
                    cthd.idHoaDonBan,
                    ma.tenMonAn,
                    dm.tenDanhMuc,
                    ma.giaTien,
                    cthd.soLuong,
                    (cthd.soLuong * ma.giaTien) AS ThanhTien
                FROM ChiTietHoaDonBan cthd
                JOIN MonAn ma ON cthd.idMonAn = ma.id
                JOIN DanhMucMonAn dm ON ma.idDanhMuc = dm.id
                WHERE cthd.idHoaDonBan = @idHoaDonBan";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idHoaDonBan", idHoaDonBan)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                        {
                            IdHoaDonBan1 = Convert.ToInt32(row["idHoaDonBan"]),
                            TenMonAn = row["tenMonAn"].ToString(),
                            TenDanhMuc = row["tenDanhMuc"].ToString(),
                            GiaTien = Convert.ToDecimal(row["giaTien"]),
                            SoLuong = Convert.ToInt32(row["soLuong"]),
                            ThanhTien = (float)Convert.ToDecimal(row["ThanhTien"])
                        };
                        chiTietList.Add(chiTiet);
                    }
                }
            }

            return chiTietList;
        }

        public bool KiemTraMonAnTonTai(int idBan, int idMonAn)
        {
            string query = "SELECT COUNT(*) " +
                          "FROM HoaDonBan hd " +
                          "JOIN ChiTietHoaDonBan cthd ON hd.id = cthd.idHoaDonBan " +
                          "WHERE hd.idBanAn = @idBan AND cthd.idMonAn = @idMonAn";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idBan", idBan),
                new SqlParameter("@idMonAn", idMonAn)
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

            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public bool CapNhatSoLuongMonAn(int idHoaDonBan, int idMonAn, int soLuongMoi)
        {
            string query = "sp_CapNhatSoLuongMonAn";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idHoaDonBan", idHoaDonBan),
                new SqlParameter("@idMonAn", idMonAn),
                new SqlParameter("@soLuongMoi", soLuongMoi)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int rowsAffected = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            return rowsAffected > 0;
                        }
                    }
                    return false;
                }
            }
        }

        public bool XoaMonAnKhoiHoaDon(int idHoaDonBan, int idMonAn)
        {
            string query = "sp_XoaMonAnKhoiHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idHoaDonBan", idHoaDonBan),
                new SqlParameter("@idMonAn", idMonAn)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int rowsAffected = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            return rowsAffected > 0;
                        }
                    }
                    return false;
                }
            }
        }

        public float ThanhToanHoaDon(int idBan, float giamGia, int idNhanVien)
        {
            string query = "sp_ThanhToanHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idBan", idBan),
                new SqlParameter("@giamGia", giamGia),
                new SqlParameter("@idNhanVien", idNhanVien)
            };

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
            }

            if (dt.Rows.Count > 0)
            {
                return Convert.ToSingle(dt.Rows[0]["TongTienSauGiamGia"]);
            }
            return 0;
        }

        public bool ChuyenBan(int idBanNguon, int idBanDich)
        {
            string query = "sp_ChuyenBan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idBanNguon", idBanNguon),
                new SqlParameter("@idBanDich", idBanDich),
                new SqlParameter("@result", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    cmd.ExecuteNonQuery();

                    // Lấy kết quả từ tham số output
                    return Convert.ToBoolean(cmd.Parameters["@result"].Value);
                }
            }
        }

        public List<DTO_HoaDonBan> LayDanhSachHoaDon(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            string query = "sp_LayDanhSachHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tuNgay", (object)tuNgay ?? DBNull.Value),
                new SqlParameter("@denNgay", (object)denNgay ?? DBNull.Value),
                new SqlParameter("@idNhanVien", (object)idNhanVien ?? DBNull.Value)
            };

            List<DTO_HoaDonBan> list = new List<DTO_HoaDonBan>();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
               DTO_HoaDonBan hoaDon = new DTO_HoaDonBan(
                   row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : 0,
                   row["idBanAn"] != DBNull.Value ? Convert.ToInt32(row["idBanAn"]) : 0,
                   row["thoiDiemVao"] != DBNull.Value ? Convert.ToDateTime(row["thoiDiemVao"]) : DateTime.MinValue,
                   row["thoiDiemRa"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["thoiDiemRa"]) : null,
                   row["TongTien"] != DBNull.Value ? Convert.ToSingle(row["TongTien"]) : 0.0f,
                   row["idNhanVien"] != DBNull.Value ? Convert.ToInt32(row["idNhanVien"]) : 0,
                   row["hoTen"] != DBNull.Value ? row["hoTen"].ToString() : "Không xác định",
                   row["trangThaiHD"] != DBNull.Value && Convert.ToBoolean(row["trangThaiHD"])
               );
               list.Add(hoaDon);
            }

            return list;
        }

        

        public List<DTO_ChiTietHoaDonBan> ThongKeMonAnBanDuoc(DateTime? tuNgay, DateTime? denNgay)
        {
            List<DTO_ChiTietHoaDonBan> danhSachMonAn = new List<DTO_ChiTietHoaDonBan>();

            string query = "sp_ThongKeMonAnBanDuocTheoThoiGian";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tuNgay", (object)tuNgay ?? DBNull.Value),
                new SqlParameter("@denNgay", (object)denNgay ?? DBNull.Value)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        DTO_ChiTietHoaDonBan monAn = new DTO_ChiTietHoaDonBan
                        {
                            IdMonAn = Convert.ToInt32(row["IdMonAn"]),
                            TenMonAn = row["TenMonAn"].ToString(),
                            TenDanhMuc = row["TenDanhMuc"].ToString(),
                            SoLuong = Convert.ToInt32(row["TongSoLuong"]),
                            ThanhTien = Convert.ToSingle(row["TongDoanhThu"])
                        };
                        danhSachMonAn.Add(monAn);
                    }
                }
            }

            return danhSachMonAn;
        }
    }
}
