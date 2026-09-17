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
    public class DAL_ThemMonVaoBan : DBConnect
    {
        public bool ThemMonVaoBan(DTO_ThemMonVaoBan mon)
        {
            string query = "sp_ThemMonAnVaoBan";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idBan", mon.IdBan),
                new SqlParameter("@idMonAn", mon.IdMonAn),
                new SqlParameter("@soLuong", mon.SoLuong)
            };

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);

                // Thực thi stored procedure và lấy số dòng bị ảnh hưởng
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int rowsAffected = reader.GetInt32(reader.GetOrdinal("RowsAffected"));
                        return rowsAffected > 0; // Trả về true nếu có dòng bị ảnh hưởng
                    }
                }
                return false; // Nếu không có kết quả trả về
            }
        }
    }
}

