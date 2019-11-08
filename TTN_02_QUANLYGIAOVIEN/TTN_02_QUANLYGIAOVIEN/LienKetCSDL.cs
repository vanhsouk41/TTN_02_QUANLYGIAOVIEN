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

        // Ph?n m? k?t n?i t?i CSDL
        public static void OpenConnection()
        {
            string sql = @"Server = DESKTOP-2LM6C8U\SQLSERVER; Database = QUAN_LY_GIAO_VIEN; Integrated Security = True;";
            try
            { // M? k?t n?i t?i CSDL
                conn = new SqlConnection(sql);
                conn.Open();
            }
            catch (SqlException Ex)
            {

            }
        }

        // ?�ng v� ng?t k?t n?i v?i CSDL
        public static void DisConnection()
        {
            // ?�ng k?t n?i
            conn.Close();
            // Ng?t k?t n?i
            conn.Dispose();
            conn = null;
        }

        // T?o b?ng ?? l?u CSDL
        public static DataTable getDataTable(string sql)
        {
            // Kh?i t?o 1 SqlCommand ?? tr? t?i d? li?u trong CSDL
            cmd = new SqlCommand(sql, conn);
            // Kh?i t?o 1 SqlDataAdapter ?? l?u d? li?u t? CSDL
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            // T?o 1 DataTable ?? hi?n th? d? li?u
            DataTable table = new DataTable();

            // ?? d? li?u l�n b?ng
            da.Fill(table);

            da.Dispose();
            cmd.Dispose();

            return table;
        }

        // T?o h�m Excute  ?? c� th? thao t�c v?i CSDL
        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            // G?i h�m ExecuteNonQuery ?? c� th? th?c hi?n c�c thao t�c Insert, Delete, Update cho DataBase 
            cmd.ExecuteNonQuery();
        }
    }
}
