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
                // T?o hàm Excute  ?? có th? thao tác v?i CSDL
        public static void Excute(string sql)
        {
            cmd = new SqlCommand(sql, conn);
            // G?i hàm ExecuteNonQuery ?? có th? th?c hi?n các thao tác Insert, Delete, Update cho DataBase 
            cmd.ExecuteNonQuery();
        }
    }
}
