using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        protected string strCon = "Data Source =.\\SQLEXPRESS01; Initial Catalog = QLyQuanTraSua; Integrated Security = True; Encrypt = False; TrustServerCertificate = True";
        SqlDataAdapter sqlAdap;
        DataTable dt;

        //phi kết nối
        /// <summary>
        /// phương thức 1: phương thức trả về một datatable: dùng để hiển thị dữ liệu lên DataGridView 
        /// và kiểm tra trùng mã
        /// </summary>
        /// <param name="strSelect">Chuỗi string mô tả câu lệnh Select</param>
        /// <returns></returns>             
        public DataTable GetDataTable(string strSelect)
        {
            //B1
            sqlAdap = new SqlDataAdapter(strSelect, strCon);
            dt = new DataTable();
            //B2
            sqlAdap.Fill(dt);
            //B3
            return dt;
        }
        public DataTable GetDataTable(string strSelect, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSelect, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                sqlAdap = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sqlAdap.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// phương thức 2: thực thi câu lệnh sql
        /// </summary>
        /// <param name="strSql">Chuỗi string mô tả các câu lệnh Insert, Update, Delete</param>        
        public void ExecuteSql(string strSql)
        {
            //B1
            sqlAdap = new SqlDataAdapter(strSql, strCon);
            dt = new DataTable();
            //B2
            sqlAdap.Fill(dt);
        }

        protected DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(strCon);
            try
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
            finally
            {
                conn.Close();
            }
            return dt;
        }


        public bool ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu có dòng bị ảnh hưởng
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

