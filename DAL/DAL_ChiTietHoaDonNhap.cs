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
    public class DAL_ChiTietHoaDonNhap : DBConnect
    {
        public bool ThemChiTietHoaDonNhap(DTO_ChiTietHoaDonNhap chiTiet)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "INSERT INTO ChiTietHoaDonNhap (idHoaDonNhap, idNguyenLieu, donViTinh, soLuong, donGia) " +
                               "VALUES (@idHoaDonNhap, @idNguyenLieu, @donViTinh, @soLuong, @donGia)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idHoaDonNhap", chiTiet.IdHoaDonNhap),
                    new SqlParameter("@idNguyenLieu", chiTiet.IdNguyenLieu),
                    new SqlParameter("@donViTinh", chiTiet.DonViTinh),
                    new SqlParameter("@soLuong", chiTiet.SoLuong),
                    new SqlParameter("@donGia", chiTiet.DonGia)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<DTO_ChiTietHoaDonNhap> LayChiTietHoaDonNhapTheoId(int idHoaDonNhap)
        {
            List<DTO_ChiTietHoaDonNhap> chiTietList = new List<DTO_ChiTietHoaDonNhap>();

            string query = "SELECT * FROM ChiTietHoaDonNhap WHERE idHoaDonNhap = @idHoaDonNhap";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idHoaDonNhap", idHoaDonNhap)
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
            }

            foreach (DataRow row in dt.Rows)
            {
                DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
                {
                    IdHoaDonNhap = Convert.ToInt32(row["idHoaDonNhap"]),
                    IdNguyenLieu = Convert.ToInt32(row["idNguyenLieu"]),
                    SoLuong = Convert.ToInt32(row["soLuong"]),
                    DonGia = Convert.ToSingle(row["donGia"]),
                    DonViTinh = row["donViTinh"].ToString()
                };
                chiTietList.Add(chiTiet);
            }

            return chiTietList;
        }
    }
}
