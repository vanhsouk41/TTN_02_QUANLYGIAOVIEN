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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 trangchu = new Form1();
            trangchu.Show();
        }
        
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }


        private void QL_dulieu_selected(object sender, EventArgs e)
        {
            if (QL_dulieu.SelectedIndex == 0)
            {
                HOATDONGNGHIENCUU hdnc = new HOATDONGNGHIENCUU();
                hdnc.load_BBKH();
                dataGridView1.DataSource = hdnc.myDisplayDataTable;
                dataGridView1.AutoResizeColumns();
            }

            ///PHÁT VIẾT
            if (QL_dulieu.SelectedIndex == 1)
            {
                load_data_LHP();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HOATDONGNGHIENCUU hdnc = new HOATDONGNGHIENCUU();
            button3.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox5.Text = hdnc.AutoGenerateMaBBKH();
            textBox5.Enabled = false;
            textBox6.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox6.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox13.Enabled = true;
            textBox12.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox5.ReadOnly = true;
            textBox6.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox13.Enabled = true;
            textBox12.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HOATDONGNGHIENCUU hdnc = new HOATDONGNGHIENCUU();
            string MaBB = textBox5.Text;
            string TenBB = textBox6.Text;
            string LoaiBB = "";
            DateTime NgayDang = dateTimePicker1.Value;
            string TapChi = textBox13.Text;
            string Soluongtacgia = textBox12.Text;

            if (comboBox2.SelectedIndex == 0)
            {
                LoaiBB = "BBKH1";
            }
            if (comboBox2.SelectedIndex == 1)
            {
                LoaiBB = "BBKH2";
            }
            if (comboBox2.SelectedIndex == 2)
            {
                LoaiBB = "BBKH3";
            }
            if (comboBox2.SelectedIndex == 3)
            {
                LoaiBB = "BBKH4";
            }

            if (button3.Enabled == true)
            {
                hdnc.Insert_BBKH(MaBB, TenBB, LoaiBB, NgayDang, TapChi, Soluongtacgia);
                MessageBox.Show("Success!", "Thông báo", MessageBoxButtons.OK);
            }

            if (button5.Enabled == true)
            {

                hdnc.Update_BBKH(MaBB, TenBB, LoaiBB, NgayDang, TapChi, Soluongtacgia);
                MessageBox.Show("Success!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            textBox5.Enabled = true;
            textBox5.ReadOnly = false;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        // Nhấn chọn In excel
        private void button4_Click(object sender, EventArgs e)
        {
            Export.ExportFile("DANH SÁCH BÀI BÁO KHOA HỌC", dataGridView1);
        }
        // Nhấn chọn 1 dòng
        private void row_selected(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells["MaBB"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["TenBB"].Value.ToString();
            comboBox2.DisplayMember = dataGridView1.CurrentRow.Cells["LoaiBB"].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells["TapChi"].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells["Soluongtacgia"].Value.ToString();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox2.Enabled = false;
            textBox13.Enabled = false;
            textBox12.Enabled = false;
            dateTimePicker1.Enabled = false;
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
        private void button9_Click(object sender, EventArgs e)
        {
            string type = comboBox1.Text;
            string value = textBox11.Text;
            HOATDONGNGHIENCUU hdnc = new HOATDONGNGHIENCUU();
            hdnc.search_BBKH(type, value);
            dataGridView1.DataSource = hdnc.myDisplayDataTable;
            dataGridView1.AutoResizeColumns();
        }

        ///Phát viết
        ///

        public void load_data_LHP()
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
            panel2.Enabled = false;
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
        }
        private void lop_hp_datagitview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string malop, tenlop, siso, loiahp, loaihinhdaotao, ngonngu, namhoc, hocy, mamh;
            panel2.Enabled = false;
            string malop = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["MaLop"].Value.ToString());
            string tenlop = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["TenLop"].Value.ToString());
            string siso = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["SiSo"].Value.ToString());
            string loaihp = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["LoaiHP"].Value.ToString());
            string ngonngu = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["NgonNgu"].Value.ToString());
            string loaihinhdaotao = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["LoaiHinh_DaoTao"].Value.ToString());
            string namhoc = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["NamHoc"].Value.ToString());
            string hocky = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["HocKy"].Value.ToString());
            string mamh = (lop_hp_datagitview.SelectedCells[0].OwningRow.Cells["MaMH"].Value.ToString());
            textBox14_phat.Text = malop;
            textBox18_phat.Text = tenlop;
            textBox17_phat.Text = siso;
            textBox15_phat.Text = loaihp;
            textBox19_phat.Text = ngonngu;
            textBox16_phat.Text = loaihinhdaotao;
            textBox20_phat.Text = namhoc;
            textBox21_phat.Text = hocky;
            textBox22_phat.Text = mamh;
            panel2.Enabled = false;

        }
        ///Phát viết
        private void button15_phat_Click(object sender, EventArgs e)
        {
            textBox14_phat.Text = "";
            textBox18_phat.Text = "";
            textBox17_phat.Text = "";
            textBox15_phat.Text = "";
            textBox19_phat.Text = "";
            textBox16_phat.Text = "";
            textBox20_phat.Text = "";
            textBox21_phat.Text = "";
            textBox22_phat.Text = "";
            panel2.Enabled = true;
            Data_form.them = 1;
            Data_form.sua = 0;
            Data_form.xoa = 0;
            panel2.Enabled = true;
        }
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
