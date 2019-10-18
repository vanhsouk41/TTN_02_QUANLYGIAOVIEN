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
        
        // T?o h�m Excute  ?? c� th? thao t�c v?i CSDL
        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            // G?i h�m ExecuteNonQuery ?? c� th? th?c hi?n c�c thao t�c Insert, Delete, Update cho DataBase 
            cmd.ExecuteNonQuery();
        }
    }
}
