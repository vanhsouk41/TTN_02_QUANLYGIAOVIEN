using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QUAN_LY_GIAO_VIEN
{
    class LienKetCSDL
    {
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;

        public SqlConnection OpenDB()
        {
            conn = new SqlConnection(
                @"Server = (local); 
                Database = QUAN_LY_GIAO_VIEN;
                Integrated Security = True;");
            return conn;
        }

        // Phần mở kết nối tới CSDL
        public static void OpenConnection()
        {
            string sql = @"Server = (local); Database = QUAN_LY_GIAO_VIEN; Integrated Security = True;";
            try
            { // Mở kết nối tới CSDL
                conn = new SqlConnection(sql);
                conn.Open();
            }
            catch (SqlException Ex)
            {

            }
        }

        // Đóng và ngắt kết nối với CSDL
        public static void DisConnection()
        {
            // Đóng kết nối
            conn.Close();
            // Ngắt kết nối
            conn.Dispose();
            conn = null;
        }

        // Tạo bảng để lưu CSDL
        public static DataTable getDataTable(string sql)
        {
            // Khởi tạo 1 SqlCommand để trỏ tới dữ liệu trong CSDL
            cmd = new SqlCommand(sql, conn);
            // Khởi tạo 1 SqlDataAdapter để lưu dữ liệu từ CSDL
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            // Tạo 1 DataTable để hiển thị dữ liệu
            DataTable table = new DataTable();

            // Đổ dữ liệu lên bảng
            da.Fill(table);

            da.Dispose();
            cmd.Dispose();

            return table;
        }

        // Tạo hàm Excute  để có thể thao tác với CSDL
        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            // Gọi hàm ExecuteNonQuery để có thể thực hiện các thao tác Insert, Delete, Update cho DataBase 
            cmd.ExecuteNonQuery();
        }
    }
}
