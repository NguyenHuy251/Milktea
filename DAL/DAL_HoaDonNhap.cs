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
    public class DAL_HoaDonNhap : DBConnect
    {
        public int ThemHoaDonNhap(DTO_HoaDonNhap hoaDon)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();

                string query = "INSERT INTO HoaDonNhap (idNhaCungCap, ngayNhap, tongTien, idNhanVien) " +
                               "OUTPUT INSERTED.id " +
                               "VALUES (@idNhaCungCap, @ngayNhap, @tongTien, @idNhanVien)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@idNhaCungCap", hoaDon.IdNhaCungCap),
                    new SqlParameter("@ngayNhap", hoaDon.NgayNhap),
                    new SqlParameter("@tongTien", hoaDon.TongTien),
                    new SqlParameter("@idNhanVien", hoaDon.IdNhanVien)
                };

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    int idHoaDonNhap = (int)cmd.ExecuteScalar();
                    return idHoaDonNhap;
                }
            }
        }

        public List<DTO_HoaDonNhap> LayDanhSachHoaDonNhap(DateTime? tuNgay, DateTime? denNgay, int? idNhanVien)
        {
            List<DTO_HoaDonNhap> danhSachHoaDonNhap = new List<DTO_HoaDonNhap>();
            string query = @"SELECT 
                                hdn.id,
                                hdn.idNhaCungCap,
                                ncc.tenNhaCungCap,
                                hdn.ngayNhap,
                                hdn.tongTien,
                                hdn.idNhanVien,
                                nv.hoTen
                            FROM HoaDonNhap hdn
                            LEFT JOIN NhaCungCap ncc ON hdn.idNhaCungCap = ncc.id
                            LEFT JOIN NhanVien nv ON hdn.idNhanVien = nv.id
                            WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (tuNgay.HasValue && denNgay.HasValue)
            {
                query += " AND CAST(hdn.ngayNhap AS DATE) BETWEEN @tuNgay AND @denNgay";
                parameters.Add(new SqlParameter("@tuNgay", tuNgay.Value.Date));
                parameters.Add(new SqlParameter("@denNgay", denNgay.Value.Date));
            }

            if (idNhanVien.HasValue)
            {
                query += " AND hdn.idNhanVien = @idNhanVien";
                parameters.Add(new SqlParameter("@idNhanVien", idNhanVien.Value));
            }

            DataTable dt = ExecuteQuery(query, parameters.ToArray());

            foreach (DataRow row in dt.Rows)
            {
                DTO_HoaDonNhap hoaDon = new DTO_HoaDonNhap
                {
                    IdHoaDonNhap = Convert.ToInt32(row["id"]),
                    IdNhaCungCap = Convert.ToInt32(row["idNhaCungCap"]),
                    TenNhaCC = row["tenNhaCungCap"].ToString(),
                    NgayNhap = Convert.ToDateTime(row["ngayNhap"]),
                    TongTien = Convert.ToSingle(row["tongTien"]),
                    IdNhanVien = Convert.ToInt32(row["idNhanVien"]),
                    HoTen = row["hoTen"].ToString()
                };
                danhSachHoaDonNhap.Add(hoaDon);
            }

            return danhSachHoaDonNhap;
        }
    }
}
