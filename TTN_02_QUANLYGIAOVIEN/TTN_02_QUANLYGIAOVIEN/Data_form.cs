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
    
    public partial class Data_form : Form
    {
        public static int them = 0;
        public static int sua = 0;
        public static int xoa = 0;
        public Data_form()
        {
            InitializeComponent();
        }

      
        // Xóa
        private void button6_Click(object sender, EventArgs e)
        {
            HOATDONGNGHIENCUU hdnc = new HOATDONGNGHIENCUU();
            string MaBB = textBox5.Text;
            hdnc.Delete_BBKH(MaBB);
            MessageBox.Show("Success!", "Thông báo", MessageBoxButtons.OK);
        }
        // Tìm kiếm bài báo khoa học
       
        ///Phát viết
        private void button12_phat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn lưu kết quả?", "MediaM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                string query = "";
                string malop = textBox14_phat.Text;
                string tenlop = textBox18_phat.Text;
                string siso = textBox17_phat.Text;
                string loaihp = textBox15_phat.Text;
                string ngonngu = textBox19_phat.Text;
                string loaihinhdaotao = textBox16_phat.Text;
                string namhoc = textBox20_phat.Text;
                string hocky = textBox21_phat.Text;
                string mamh = textBox22_phat.Text;
                if (Data_form.them == 1)
                    query = "Insert into LOPHOCPHAN(MaLop, TenLop, SiSo, LoaiHP, NgonNgu, LoaiHinh_DaoTao, NamHoc, HocKy, MaMH) values(@malop, @tenlop, @siso, @loaihp, @ngonngu, @lh_dt, @namhoc, @hocky, @mamh)";
                else if (Data_form.sua == 1)
                    query = " UPDATE dbo.LOPHOCPHAN SET TenLop=@tenlop,SiSo=@siso,LoaiHP=@loaihp,NgonNgu=@ngonngu,LoaiHinh_DaoTao=@lh_dt,NamHoc=@namhoc,HocKy=@hocky,MaMH=@mamh where MaLop=@malop";
                else return;
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                    {
                        connection.Open();

                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText = query;
                        // insert value of Song in database

                        cmd.Parameters.Add("@malop", SqlDbType.Char).Value = malop;
                        // cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = music.Title;
                        cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar).Value = tenlop;
                        cmd.Parameters.Add("@siso", SqlDbType.Int).Value = int.Parse(siso);
                        cmd.Parameters.Add("@loaihp", SqlDbType.NVarChar).Value = loaihp;
                        cmd.Parameters.Add("@ngonngu", SqlDbType.NVarChar).Value = ngonngu;
                        cmd.Parameters.Add("@lh_dt", SqlDbType.NVarChar).Value = loaihinhdaotao;
                        cmd.Parameters.Add("@namhoc", SqlDbType.Char).Value = namhoc;
                        cmd.Parameters.Add("@hocky", SqlDbType.Int).Value = int.Parse(hocky);
                        cmd.Parameters.Add("@mamh", SqlDbType.Char).Value = mamh;
                        cmd.ExecuteNonQuery();


                        connection.Close();
                        load_data_LHP();

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erroorrr");

                }
            }
            else
            {
                //not event
            }
        }
        ///Phát viết
        private void button14_phat_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            Data_form.them = 0;
            Data_form.sua = 1;
            Data_form.xoa = 0;
            textBox14_phat.Enabled = false;
        }
        ///Phát viết
        private void button13_phat_Click(object sender, EventArgs e)
        {
            Data_form.them = 0;
            Data_form.sua = 0;
            Data_form.xoa = 1;
            DialogResult res = MessageBox.Show("Are you sure you want to delete", "MediaM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                string query = "DELETE dbo.LOPHOCPHAN WHERE MaLop=@malop";
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    string malop = textBox14_phat.Text;
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.Add("@malop", SqlDbType.Char).Value = malop;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    load_data_LHP();
                }
            }
            else
            {
                //non event
            }
           // deleteSV.BackColor = Color.DimGray;
            
        }
        /// Phát viết
        private void button11_phat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn hủy?", "MediaM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                string query = "SELECT * FROM  dbo.LOPHOCPHAN";
                DataSet data = new DataSet();

                using (SqlConnection connect = new SqlConnection(ConnectionString.connectionString))
                {
                    connect.Open();
                    SqlDataAdapter apter = new SqlDataAdapter(query, connect);
                    apter.Fill(data);

                    connect.Close();
                }
                lop_hp_datagitview.DataSource = data.Tables[0];
                lop_hp_datagitview.AutoResizeColumns();
                textBox14_phat.Text = "";
                textBox18_phat.Text = "";
                textBox17_phat.Text = "";
                textBox15_phat.Text = "";
                textBox19_phat.Text = "";
                textBox16_phat.Text = "";
                textBox20_phat.Text = "";
                textBox21_phat.Text = "";
                textBox22_phat.Text = "";
                panel2.Enabled = false;
            }
            else
            {
                //not event
            }
        }

        private void button11_LHP_Click(object sender, EventArgs e)
        {
            string hinhthuc = comboBox3_phat.Text;
            string key = textBox9_phat.Text;
            string query = "SELECT * FROM SEARCH_LOPHOCPHAN(@hinhthuc,@key)";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql = connection.CreateCommand();
                sql.CommandText = query;
                sql.Parameters.Add(new SqlParameter("@hinhthuc", SqlDbType.NVarChar)).Value =hinhthuc;
                sql.Parameters.Add(new SqlParameter("@key", SqlDbType.NVarChar)).Value = key;
                sda.SelectCommand = sql;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            lop_hp_datagitview.DataSource = myDataSet.Tables[0];
            lop_hp_datagitview.AutoResizeColumns();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Export.ExportFile("DANH SÁCH LỚP HỌC PHẦN", lop_hp_datagitview);
        }

        private void btThongKe_CV_Click(object sender, EventArgs e)
        {
            LienKetCSDL.OpenConnection();
            dataGridChucVu.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_ThongKe_ChucVu ('" + dateTimePickerCV.Value + "')");

        }

        private void dataGridChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowindex = e.RowIndex;
                DataGridViewRow row = this.dataGridChucVu.Rows[rowindex];

                ChiTiet_ChucVu ChiTiet_CV = new ChiTiet_ChucVu();
                ChiTiet_CV.SetMa(row.Cells[0].Value.ToString());
                ChiTiet_CV.Show();
            }

        }
    }
}
