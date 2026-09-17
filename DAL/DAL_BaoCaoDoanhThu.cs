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
    public class DAL_BaoCaoDoanhThu : DBConnect
    {
        public List<DTO_BaoCaoDoanhThu> LayDanhSachBaoCao()
        {
            List<DTO_BaoCaoDoanhThu> dsBaoCao = new List<DTO_BaoCaoDoanhThu>();
            string query = "EXEC sp_LayDanhSachBaoCaoDoanhThu";
            DataTable dt = GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                DTO_BaoCaoDoanhThu baoCao = new DTO_BaoCaoDoanhThu
                {
                    Id = Convert.ToInt32(row["id"]),
                    TuNgay = Convert.ToDateTime(row["tuNgay"]),
                    DenNgay = Convert.ToDateTime(row["denNgay"]),
                    TongSoHoaDonBan = Convert.ToInt32(row["tongSoHoaDonBan"]),
                    TongSoHoaDonNhap = Convert.ToInt32(row["tongSoHoaDonNhap"]),
                    TongDoanhThuBan = Convert.ToDouble(row["tongDoanhThuBan"]),
                    TongChiPhiNhap = Convert.ToDouble(row["tongChiPhiNhap"]),
                    TongDoanhThu = Convert.ToDouble(row["tongDoanhThu"]),
                    IdNhanVien = row["idNhanVien"] != DBNull.Value ? Convert.ToInt32(row["idNhanVien"]) : 0,
                    TenNhanVien = row["tenNhanVien"].ToString(),
                    NgayTao = Convert.ToDateTime(row["ngayTao"]),
                    GhiChu = row["ghiChu"].ToString()
                };
                dsBaoCao.Add(baoCao);
            }

            return dsBaoCao;
        }

        public DTO_BaoCaoDoanhThu ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string query = "EXEC sp_ThongKeDoanhThu @tuNgay, @denNgay";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tuNgay", tuNgay),
                new SqlParameter("@denNgay", denNgay)
            };

            DataTable dt = GetDataTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_BaoCaoDoanhThu
                {
                    TuNgay = Convert.ToDateTime(row["tuNgay"]),
                    DenNgay = Convert.ToDateTime(row["denNgay"]),
                    TongSoHoaDonBan = Convert.ToInt32(row["tongSoHoaDonBan"]),
                    TongSoHoaDonNhap = Convert.ToInt32(row["tongSoHoaDonNhap"]),
                    TongDoanhThuBan = Convert.ToDouble(row["tongDoanhThuBan"]),
                    TongChiPhiNhap = Convert.ToDouble(row["tongChiPhiNhap"]),
                    TongDoanhThu = Convert.ToDouble(row["tongDoanhThu"])
                };
            }

            return null;
        }

        public bool ThemBaoCao(DTO_BaoCaoDoanhThu baoCao)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "EXEC sp_ThemBaoCaoDoanhThu @tuNgay, @denNgay, @tongSoHoaDonBan, @tongSoHoaDonNhap, " +
                               "@tongDoanhThuBan, @tongChiPhiNhap, @tongDoanhThu, @idNhanVien, @ghiChu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@tuNgay", baoCao.TuNgay),
                    new SqlParameter("@denNgay", baoCao.DenNgay),
                    new SqlParameter("@tongSoHoaDonBan", baoCao.TongSoHoaDonBan),
                    new SqlParameter("@tongSoHoaDonNhap", baoCao.TongSoHoaDonNhap),
                    new SqlParameter("@tongDoanhThuBan", baoCao.TongDoanhThuBan),
                    new SqlParameter("@tongChiPhiNhap", baoCao.TongChiPhiNhap),
                    new SqlParameter("@tongDoanhThu", baoCao.TongDoanhThu),
                    new SqlParameter("@idNhanVien", baoCao.IdNhanVien),
                    new SqlParameter("@ghiChu", (object)baoCao.GhiChu ?? DBNull.Value)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Kiểm tra xem có idBaoCaoMoi trả về không
                            return !reader.IsDBNull(reader.GetOrdinal("idBaoCaoMoi"));
                        }
                    }
                }
                return false; // Không có kết quả trả về
            }
        }

        public bool XoaBaoCao(int idBaoCao)
        {

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                string query = "EXEC sp_XoaBaoCaoDoanhThu @idBaoCao";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idBaoCao", idBaoCao)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int rowsAffected = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                            return rowsAffected > 0;
                        }
                    }
                }
                return false; // Không có kết quả trả về
            }
        }
    }
}
