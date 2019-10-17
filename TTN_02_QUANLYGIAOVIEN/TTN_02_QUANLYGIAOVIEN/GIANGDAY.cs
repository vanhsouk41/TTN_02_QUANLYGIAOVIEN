using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GIAO_VIEN
{
    class GIANGDAY
    {
        // Phát sửa
        private string hocphan;
        private string monhoc;
        private string khoa;
        private float tai;













        /*public void Update_BBKH(string MaBB, string TenBB, string LoaiBB, DateTime NgayDang, string TapChi, string Soluongtacgia)
        {
            SqlCommand update = conn.CreateCommand();
            update.CommandText = "Update_BBKH";
            update.CommandType = CommandType.StoredProcedure;
            update.Parameters.Add(new SqlParameter("@MaBB", SqlDbType.Char)).Value = MaBB;
            update.Parameters.Add(new SqlParameter("@TenBB", SqlDbType.NVarChar)).Value = TenBB;
            update.Parameters.Add(new SqlParameter("@LoaiBB", SqlDbType.NVarChar)).Value = LoaiBB;
            update.Parameters.Add(new SqlParameter("@NgayDang", SqlDbType.Date)).Value = NgayDang.Date;
            update.Parameters.Add(new SqlParameter("@TapChi", SqlDbType.NVarChar)).Value = TapChi;
            update.Parameters.Add(new SqlParameter("@Soluongtacgia", SqlDbType.Int)).Value = int.Parse(Soluongtacgia);
            sda.SelectCommand = update;
            conn.Open();
            update.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete_BBKH(string MaBB)
        {
            SqlCommand delete = conn.CreateCommand();
            delete.CommandText = "Delete_BBKH";
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.Add(new SqlParameter("@MaBB", SqlDbType.Char)).Value = MaBB;
            conn.Open();
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void search_BBKH(string type, string value)
        {
            SqlCommand search = conn.CreateCommand();
            search.CommandText = "SELECT * FROM Search_BBKH (@type, @value)";
            search.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar)).Value = type;
            search.Parameters.Add(new SqlParameter("@value", SqlDbType.NVarChar)).Value = value;
            sda.SelectCommand = search;
            conn.Open();
            myDataSet = new DataSet();
            sda.Fill(myDataSet);
            conn.Close();
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }
    }*/
}
}
