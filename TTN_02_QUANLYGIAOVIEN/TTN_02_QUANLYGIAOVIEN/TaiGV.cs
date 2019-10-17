using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GIAO_VIEN
{
    public partial class TaiGV : Form
    {
        public TaiGV()
        {
            InitializeComponent();
            if(Works_calculating.DT==1)
                tai_dao_tao();
            if (Works_calculating.NCKH == 1)
                show_taiNCKH();
        }

       
        public void tai_dao_tao()
        {
            label1.Text = "Tải Giảng dạy";
            label2.Text = "Tải Khảo thí";
            label4.Text = "Hội đồng";
            string query1 = "SELECT MaGV AS 'Mã GV', HoTen AS 'Họ tên',Monhoc AS 'Lớp học phần', Siso AS 'Sĩ số',Loaihinhdaotao AS 'Loại hình Đào tạo', Sotiet AS 'Số tiết', GioChuan as 'Giờ chuẩn'FROM dbo.taiGiangday('Mã giáo viên', @magv,@namhoc)";
            //Works_calculating w_c = new Works_calculating();
            string magv = Works_calculating.magvTT;
            string namhoc =Works_calculating.namhocTT;
            
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql = connection.CreateCommand();
                sql.CommandText = query1;
                sql.Parameters.Add(new SqlParameter("@magv", SqlDbType.NVarChar)).Value = magv;
                sql.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                sda.SelectCommand = sql;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            dataGridView1.DataSource = myDataSet.Tables[0];
            dataGridView1.AutoResizeColumns();

            string query2 = "select *  from dbo.Func_GV_Khaothi (@magv,@namhoc) ";
            //Works_calculating w_c = new Works_calculating();
            string magv2 = Works_calculating.magvTT;
            string namhoc2 = Works_calculating.namhocTT;

            SqlDataAdapter sda2 = new SqlDataAdapter();
            DataSet myDataSet2 = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql2 = connection.CreateCommand();
                sql2.CommandText = query2;
                sql2.Parameters.Add(new SqlParameter("@magv", SqlDbType.NVarChar)).Value = magv;
                sql2.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                sda2.SelectCommand = sql2;
                myDataSet2 = new DataSet();
                sda2.Fill(myDataSet2);
                connection.Close();
            }
            dataGridView2.DataSource = myDataSet2.Tables[0];
            dataGridView2.AutoResizeColumns();

            string query3 = "select *  from dbo.Func_GV_HoiDong (@magv,@namhoc) ";
            //Works_calculating w_c = new Works_calculating();
            string magv3 = Works_calculating.magvTT;
            string namhoc3 = Works_calculating.namhocTT;

            SqlDataAdapter sda3 = new SqlDataAdapter();
            DataSet myDataSet3 = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql3 = connection.CreateCommand();
                sql3.CommandText = query3;
                sql3.Parameters.Add(new SqlParameter("@magv", SqlDbType.NVarChar)).Value = magv;
                sql3.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                sda3.SelectCommand = sql3;
                myDataSet3 = new DataSet();
                sda3.Fill(myDataSet3);
                connection.Close();
            }
            dataGridView3.DataSource = myDataSet3.Tables[0];
            dataGridView3.AutoResizeColumns();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
