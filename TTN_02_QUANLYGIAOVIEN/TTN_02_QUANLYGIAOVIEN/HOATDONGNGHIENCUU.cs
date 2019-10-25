
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_GIAO_VIEN
{
    class HOATDONGNGHIENCUU
    {
        public string connString = @"Data Source =DESKTOP-2LM6C8U\SQLSERVER; Initial Catalog = QUAN_LY_GIAO_VIEN; Integrated Security = True";
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet myDataSet = new DataSet();
        public DataTable myDisplayDataTable = new DataTable();

        public HOATDONGNGHIENCUU()
        {
            conn = new SqlConnection(connString);
        }
        public void lylichkhoahoc(string type1, string type2, string value2)
        {
            SqlCommand NCKH = conn.CreateCommand();
            NCKH.CommandText = "SELECT * FROM hoatdongNCKH(@type1, @type2, @value2)";
            NCKH.Parameters.Add(new SqlParameter("@type1", SqlDbType.NVarChar)).Value = type1;
            NCKH.Parameters.Add(new SqlParameter("@type2", SqlDbType.NVarChar)).Value = type2;
            NCKH.Parameters.Add(new SqlParameter("@value2", SqlDbType.NVarChar)).Value = value2;
            sda.SelectCommand = NCKH;

            conn.Open();
            myDataSet = new DataSet();
            sda.Fill(myDataSet);
            conn.Close();
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }

        public void tainghiencuukhoahoc(string type1, string type, string value, string namhoc)
        {
            SqlCommand taiNCKH = conn.CreateCommand();
            if (type1 == "Bài báo khoa h?c")
            {
                taiNCKH.CommandText = "SELECT * FROM taiNCKH_BBKH(@type, @value, @namhoc)";
                taiNCKH.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar)).Value = type;
                taiNCKH.Parameters.Add(new SqlParameter("@value", SqlDbType.NVarChar)).Value = value;
                taiNCKH.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
            }
            else if (type1 == "?? tài nghiên c?u")
            {
                taiNCKH.CommandText = "SELECT * FROM taiNCKH_DTNC(@type, @value, @namhoc)";
                taiNCKH.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar)).Value = type;
                taiNCKH.Parameters.Add(new SqlParameter("@value", SqlDbType.NVarChar)).Value = value;
                taiNCKH.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
            }
                
            else if (type1 == "Sách")
            {
                taiNCKH.CommandText = "SELECT * FROM taiNCKH_SACH(@type, @value, @namhoc)";
                taiNCKH.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar)).Value = type;
                taiNCKH.Parameters.Add(new SqlParameter("@value", SqlDbType.NVarChar)).Value = value;
                taiNCKH.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
            }
            sda.SelectCommand = taiNCKH;
            conn.Open();
            myDataSet = new DataSet();
            sda.Fill(myDataSet);
            conn.Close();
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }
        public void load_BBKH()
        {
            SqlCommand load = conn.CreateCommand();
            load.CommandText = "SELECT * FROM BAIBAOKHOAHOC";
            sda.SelectCommand = load;
            conn.Open();
            myDataSet = new DataSet();
            sda.Fill(myDataSet);
            conn.Close();
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }
        public string AutoGenerateMaBBKH()
        {
            conn.Open();
            SqlCommand autoMaBB = conn.CreateCommand();
            autoMaBB.CommandText = "SELECT TOP 1 MaBB FROM BAIBAOKHOAHOC ORDER BY MaBB DESC";
            sda.SelectCommand = autoMaBB;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            string MaBB = dt.Rows[0][0].ToString();
            MaBB.TrimEnd(' ');
            string name = MaBB.Substring(0, 2);
            int num = Convert.ToInt16(MaBB.Substring(2, MaBB.Length - 2));
            num++;
            string result;
            if (num < 10) result = name + "0" + num.ToString();
            else result = name + num.ToString();
            return result;
        }
        public void Insert_BBKH(string MaBB, string TenBB, string LoaiBB, DateTime NgayDang, string TapChi, string Soluongtacgia)
        {
            SqlCommand insert = conn.CreateCommand();
            insert.CommandText = "Insert_BBKH";
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.Add(new SqlParameter("@MaBB", SqlDbType.Char)).Value = MaBB;
            insert.Parameters.Add(new SqlParameter("@TenBB", SqlDbType.NVarChar)).Value = TenBB;
            insert.Parameters.Add(new SqlParameter("@LoaiBB", SqlDbType.NVarChar)).Value = LoaiBB;
            insert.Parameters.Add(new SqlParameter("@NgayDang", SqlDbType.Date)).Value = NgayDang.Date;
            insert.Parameters.Add(new SqlParameter("@TapChi", SqlDbType.NVarChar)).Value = TapChi;
            insert.Parameters.Add(new SqlParameter("@Soluongtacgia", SqlDbType.Int)).Value = int.Parse(Soluongtacgia);
            sda.SelectCommand = insert;
            conn.Open();
            insert.ExecuteNonQuery();
            conn.Close();
        }
        public void Update_BBKH (string MaBB, string TenBB, string LoaiBB, DateTime NgayDang, string TapChi, string Soluongtacgia)
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
        public void Delete_BBKH (string MaBB)
        {
            SqlCommand delete = conn.CreateCommand();
            delete.CommandText = "Delete_BBKH";
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.Add(new SqlParameter("@MaBB", SqlDbType.Char)).Value = MaBB;
            conn.Open();
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void search_BBKH (string type, string value)
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




    }
}
