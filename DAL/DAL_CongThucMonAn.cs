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
    public class DAL_CongThucMonAn : DBConnect
    {
        // Lấy danh sách công thức món ăn theo idMonAn, bao gồm tên món ăn
        public List<DTO_CongThucMonAn> LayDanhSachCongThucMonAn(int idMonAn)
        {
            List<DTO_CongThucMonAn> dsCongThuc = new List<DTO_CongThucMonAn>();
            string query = @"SELECT ct.idMonAn, ct.idNguyenLieu, ct.soLuong, ct.donViTinh, ma.tenMonAn 
                           FROM CongThucMonAn ct
                           INNER JOIN MonAn ma ON ct.idMonAn = ma.id
                           WHERE ct.idMonAn = @idMonAn";
            SqlParameter[] parameters = { new SqlParameter("@idMonAn", idMonAn) };

            DataTable dt = ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                DTO_CongThucMonAn congThuc = new DTO_CongThucMonAn
                {
                    IdMonAn = Convert.ToInt32(row["idMonAn"]),
                    IdNguyenLieu = Convert.ToInt32(row["idNguyenLieu"]),
                    SoLuong = Convert.ToSingle(row["soLuong"]),
                    DonViTinh = row["donViTinh"].ToString(),
                    TenMonAn = row["tenMonAn"].ToString()
                };
                dsCongThuc.Add(congThuc);
            }

            return dsCongThuc;
        }

        // Thêm công thức món ăn
        public bool ThemCongThucMonAn(DTO_CongThucMonAn congThuc)
        {
            string query = "INSERT INTO CongThucMonAn (idMonAn, idNguyenLieu, soLuong, donViTinh) " +
                          "VALUES (@idMonAn, @idNguyenLieu, @soLuong, @donViTinh)";
            SqlParameter[] parameters = {
                new SqlParameter("@idMonAn", congThuc.IdMonAn),
                new SqlParameter("@idNguyenLieu", congThuc.IdNguyenLieu),
                new SqlParameter("@soLuong", congThuc.SoLuong),
                new SqlParameter("@donViTinh", congThuc.DonViTinh ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Sửa công thức món ăn
        public bool SuaCongThucMonAn(DTO_CongThucMonAn congThuc)
        {
            string query = "UPDATE CongThucMonAn SET soLuong = @soLuong, donViTinh = @donViTinh " +
                          "WHERE idMonAn = @idMonAn AND idNguyenLieu = @idNguyenLieu";
            SqlParameter[] parameters = {
                new SqlParameter("@idMonAn", congThuc.IdMonAn),
                new SqlParameter("@idNguyenLieu", congThuc.IdNguyenLieu),
                new SqlParameter("@soLuong", congThuc.SoLuong),
                new SqlParameter("@donViTinh", congThuc.DonViTinh ?? (object)DBNull.Value)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Xóa công thức món ăn
        public bool XoaCongThucMonAn(int idMonAn, int idNguyenLieu)
        {
            string query = "DELETE FROM CongThucMonAn WHERE idMonAn = @idMonAn AND idNguyenLieu = @idNguyenLieu";
            SqlParameter[] parameters = {
                new SqlParameter("@idMonAn", idMonAn),
                new SqlParameter("@idNguyenLieu", idNguyenLieu)
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Lấy danh sách món ăn
        public DataTable LayDanhSachMonAn()
        {
            string query = "SELECT id, tenMonAn FROM MonAn";
            return GetDataTable(query);
        }

        // Lấy danh sách nguyên liệu
        public DataTable LayDanhSachNguyenLieu()
        {
            string query = "SELECT id, tenNguyenLieu FROM KhoNguyenLieu";
            return GetDataTable(query);
        }
    }
}
