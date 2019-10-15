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
    public partial class Works_calculating : Form
    {
        HOATDONGNGHIENCUU HDNC = new HOATDONGNGHIENCUU();
        public static string magvTT;
        public static string namhocTT;
        public static int DT = 0;
        public static int NCKH = 0;
        public Works_calculating()
        {
            InitializeComponent();
            panel1.Visible = false;

            ///----insert 
            ///
            tt_panel2.Visible = false;
            
        }

                private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 trangchu = new Form1();
            trangchu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("B?n th?c s? mu?n thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        ///Phát vi?t
        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.thong_ke_giang_day(@thongketheo, @key,@NamHoc)";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();
            string type1 = comboBox4.Text;
            string type2 = comboBox5.Text;
            string value2 = textBox14.Text;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand HDGD = connection.CreateCommand();
                HDGD.CommandText = query;
                HDGD.Parameters.Add(new SqlParameter("@thongketheo", SqlDbType.NVarChar)).Value = type1;
                HDGD.Parameters.Add(new SqlParameter("@Namhoc", SqlDbType.NChar)).Value = type2;
                HDGD.Parameters.Add(new SqlParameter("@key", SqlDbType.NVarChar)).Value = value2;
                sda.SelectCommand = HDGD;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            dataGridView3.DataSource = myDataSet.Tables[0];
            dataGridView3.AutoResizeColumns();
        }
        // ///Phát vi?t
        private void button8_Click(object sender, EventArgs e)
        {

            string chon = comboBox6.Text;
            panel1.Visible = false;
            if (chon == "Giáo viên")
            {
                string query = "SELECT magv AS 'Mã GV',tengv AS 'H? tên',thuctai AS 'Th?c t?i',taiyeucau AS 'T?i yêu c?u' FROM dbo.tai_giang_day (@Namhoc)";

                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                string type2 = comboBox7.Text;

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@Namhoc", SqlDbType.Char)).Value = type2;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();
            }
            if (chon == "B? môn")
            {
                string query = "EXEC tai_theo_khoa_or_bomon  @chon=N'b? môn',@namhoc=@nh";

                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                string type2 = comboBox7.Text;

                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@nh", SqlDbType.Char)).Value = type2;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();
            }
            if (chon == "Khoa")
            {
                string query = "EXEC tai_theo_khoa_or_bomon  @chon=N'khoa',@namhoc=@nh ";

                string type2 = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();


                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@nh", SqlDbType.Char)).Value = type2;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();
            }
        }
        ///Phát vi?t
        private void dataGridView4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string chon = comboBox6.Text;
            if (chon == "Giáo viên")
            {
                string query = "SELECT MaGV AS 'Mã GV', HoTen AS 'H? tên',Monhoc AS 'L?p h?c ph?n', Siso AS 'S? s?',Loaihinhdaotao AS 'Lo?i hình ?ào t?o', Sotiet AS 'S? ti?t', GioChuan as 'Gi? chu?n'FROM dbo.taiGiangday('Mã giáo viên', @magv,@namhoc)";
                string magv = (dataGridView4.SelectedCells[0].OwningRow.Cells["Mã GV"].Value.ToString());
                string tengv = (dataGridView4.SelectedCells[0].OwningRow.Cells["H? tên"].Value.ToString());
                string namhoc = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                label6.Text = "Mã GV :";
                label7.Text = "H? tên:";
                label8.Text = magv;
                label9.Text = tengv;
                panel1.Visible = true;
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@magv", SqlDbType.NVarChar)).Value = magv;
                    sql.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();

            }
            if (chon == "B? môn")
            {
                string query = "SELECT temp.magv AS 'Mã GV',tengv AS 'H? tên',thuctai AS 'Th?c t?i',taiyeucau AS 'T?i yêu c?u' FROM(SELECT * FROM dbo.tai_giang_day(@namhoc))AS temp JOIN dbo.GV_DV ON GV_DV.MaGV = temp.magv WHERE MaDV = @mabomon";
                string mabm = (dataGridView4.SelectedCells[0].OwningRow.Cells["Mã b? môn"].Value.ToString());
                string tenbm = (dataGridView4.SelectedCells[0].OwningRow.Cells["Tên b? môn"].Value.ToString());
                string namhoc = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                label6.Text = "Mã b? môn :";
                label7.Text = "Tên b? môn:";
                label8.Text = mabm;
                label9.Text = tenbm;
                panel1.Visible = true;
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@mabomon", SqlDbType.NVarChar)).Value = mabm;
                    sql.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();
            }
            if (chon == "Khoa")
            {
                string query = "SELECT temp1.MaGV AS 'Mã GV',tengv AS 'H? tên',thuctai AS 'Th?c t?i',taiyeucau AS 'T?i yêu c?u'  FROM  (SELECT MaGV FROM dbo.GV_DV join(SELECT * FROM dbo.DONVI WHERE MaDVC=@makhoa) AS temp ON temp.MaDV = GV_DV.MaDV) AS temp1 JOIN (SELECT * FROM dbo.tai_giang_day (@namhoc))AS temp2 ON temp2.magv = temp1.MaGV";
                string makhoa = (dataGridView4.SelectedCells[0].OwningRow.Cells["Mã khoa"].Value.ToString());
                string tenbm = (dataGridView4.SelectedCells[0].OwningRow.Cells["Tên khoa"].Value.ToString());
                string namhoc = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                label6.Text = "Mã khoa :";
                label7.Text = "Tên khoa:";
                label8.Text = makhoa;
                label9.Text = tenbm;
                panel1.Visible = true;
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
                {
                    connection.Open();
                    SqlCommand sql = connection.CreateCommand();
                    sql.CommandText = query;
                    sql.Parameters.Add(new SqlParameter("@makhoa", SqlDbType.NVarChar)).Value = makhoa;
                    sql.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.NVarChar)).Value = namhoc;
                    sda.SelectCommand = sql;
                    myDataSet = new DataSet();
                    sda.Fill(myDataSet);
                    connection.Close();
                }
                dataGridView4.DataSource = myDataSet.Tables[0];
                dataGridView4.AutoResizeColumns();
            }
        }
        ///Phát vi?t
        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.button8_Click(sender, e);
        }
        ///Phát vi?t
        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT [_tenkhoa] AS 'Tên khoa', [_tongqs] AS 'T?ng QS',[_sogiaosu] AS 'Giáo s?',[_sophogiaosu] AS 'Phó giáo s?',[_sotiensi] AS 'Ti?n s?',[_sothacsi] AS 'Th?c s?',[_sodaihoc] AS '??i h?c',[_tongCD] AS 'T?ng sô ch?c danh',[_socaocap] AS 'Cao c?p',[_sogiangvienchinh] AS 'Chính', [_sokhoidau] AS 'Kh?i ??u' FROM dbo.thongke_nhan_luc(@ngay)";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();
            DateTime ngay = dateTimePicker1.Value;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand HDGD = connection.CreateCommand();
                HDGD.CommandText = query;
                HDGD.Parameters.Add(new SqlParameter("@ngay", SqlDbType.Date)).Value = ngay;

                sda.SelectCommand = HDGD;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            dataGridView5.DataSource = myDataSet.Tables[0];
            dataGridView5.AutoResizeColumns();
        }

        private void button11_phat_Click(object sender, EventArgs e)
        {
            Export.ExportFile("HO?T ??NG GI?NG D?Y", dataGridView3);
        }

        private void button12_phat_Click(object sender, EventArgs e)
        {
            string chon = comboBox6.Text;
            if (chon == "Giáo viên")
                Export.ExportFile("T?I GIÁO VIÊN", dataGridView4);
            if (chon == "B? môn")
                Export.ExportFile("T?I B? MÔN", dataGridView4);
            if (chon == "Khoa")
                Export.ExportFile("T?I KHOA", dataGridView4);

        }

        private void button13_phat_Click(object sender, EventArgs e)
        {
            Export.ExportFile("TH?NG KÊ NHÂN L?C", dataGridView5);
        }

        /// Th?y vi?t
        /// ph?n th?ng kê kh?o thí
        private void btThongKe_KT_Click(object sender, EventArgs e)
        {
            LienKetCSDL.OpenConnection();

            if (cbBoxNoiDung_KT.Text == "Mã giáo viên")
            {
                dataGridKhaoThi.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_GV_KhaoThi ('" + tbTuKhoa_KT.Text + "', '" + tbNamHoc_KT.Text + "')");

                DataTable sum = new DataTable();
                sum = LienKetCSDL.getDataTable("select SUM (TaiKhaoThi) as tong from dbo.Func_GV_KhaoThi ('" + tbTuKhoa_KT.Text + "', '" + tbNamHoc_KT.Text + "')");
                tbTongTai_KT.Text = sum.Rows[0]["tong"].ToString();
            }
            else
            {
                dataGridKhaoThi.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_KhaoThi_TenGV (N'" + tbTuKhoa_KT.Text + "', '" + tbNamHoc_KT.Text + "')");

                tbTongTai_KT.Text = " ";
            }
        }
        // in ra Excel 
        private void btInExcel_KT_Click(object sender, EventArgs e)
        {
            Export.ExportFile("CÔNG TÁC KH?O THÍ", dataGridKhaoThi);
        }
        /// ph?n th?ng kê h?i ??ng
        private void btThongKe_HD_Click(object sender, EventArgs e)
        {
            LienKetCSDL.OpenConnection();

            if (cbBoxNoiDung_HD.Text == "Mã giáo viên")
            {
                dataGridHoiDong.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_GV_HoiDong ('" + tbTuKhoa_HD.Text + "', '" + tbNamHoc_HD.Text + "')");

                DataTable sum = new DataTable();
                sum = LienKetCSDL.getDataTable("select SUM (TaiHoiDong) as tong from dbo.Func_GV_HoiDong ('" + tbTuKhoa_HD.Text + "', '" + tbNamHoc_HD.Text + "')");
                tbTongTai_HD.Text = sum.Rows[0]["tong"].ToString();
            }
            else
            {
                dataGridHoiDong.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_HoiDong_TenGV (N'" + tbTuKhoa_HD.Text + "', '" + tbNamHoc_HD.Text + "')");

                tbTongTai_HD.Text = " ";
            }
        }
        // in ra Excel 
        private void btInExcel_HD_Click(object sender, EventArgs e)
        {
            Export.ExportFile("THAM GIA CÁC H?I ??NG", dataGridHoiDong);
        }

        /// ph?n h??ng d?n ?? án
        private void btThongKe_DA_Click(object sender, EventArgs e)
        {
            LienKetCSDL.OpenConnection();

            if (cbBoxNoiDung_DA.Text == "Mã giáo viên")
            {
                dataGridDoAn.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_GV_DoAn ('" + tbTuKhoa_DA.Text + "', '" + tbNamHoc_DA.Text + "')");

                DataTable sum = new DataTable();
                sum = LienKetCSDL.getDataTable("select SUM (TaiDoAn) as tong from dbo.Func_GV_DoAn ('" + tbTuKhoa_DA.Text + "', '" + tbNamHoc_DA.Text + "')");
                tbTongTai_DA.Text = sum.Rows[0]["tong"].ToString();
            }

            else if (cbBoxNoiDung_DA.Text == "Tên giáo viên")
            {
                dataGridDoAn.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_DoAn_TenGV (N'" + tbTuKhoa_DA.Text + "', '" + tbNamHoc_DA.Text + "')");

                tbTongTai_DA.Text = " ";
            }
        }
        // in ra Excel 
        private void btInExcel_DA_Click(object sender, EventArgs e)
        {
            Export.ExportFile("H??NG D?N ?? ÁN", dataGridDoAn);
        }

        private void tt_button11_Click(object sender, EventArgs e)
        {
            string query = "";
            string chon = tt_comboBox8_phat.Text;
            if (chon == "B? môn")
            {
                 query = "SELECT magv AS 'Mã GV',tengv AS 'H? tên',ROUND(thuctaidaotao, 2) AS 'Th?c t?i ?ào t?o',ROUND(taiyeucaudaotao, 2) AS 'T?i yêu c?u ?ào t?o',ROUND(phantram_daotao, 0) AS '% ?ào t?o',ROUND(thuctaiNCKH, 2) AS 'Th?c t?i NCKH',ROUND(taiyeucauNCHK, 2) AS 'T?i yêu c?u NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Th?c t?i ',ROUND(taiyeucau, 2) AS 'T?i yêu c?u',ROUND(phantram_tong, 0) AS '% T?ng' FROM tongtai_bomon(@mabm,@namhoc)";

            }
            else
            {
                query = "SELECT magv AS 'Mã GV',tengv AS 'H? tên',ROUND(thuctaidaotao, 2) AS 'Th?c t?i ?ào t?o',ROUND(taiyeucaudaotao, 2) AS 'T?i yêu c?u ?ào t?o',ROUND(phantram_daotao, 0) AS '% ?ào t?o',ROUND(thuctaiNCKH, 2) AS 'Th?c t?i NCKH',ROUND(taiyeucauNCHK, 2) AS 'T?i yêu c?u NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Th?c t?i ',ROUND(taiyeucau, 2) AS 'T?i yêu c?u',ROUND(phantram_tong, 0) AS '% T?ng' FROM tongtai_khoa(@mabm,@namhoc)";

            }
            string ma = tt_comboBox8_tt.Text;
            string namhoc = tt_comboBox10.Text;
           // string query ="SELECT magv AS 'Mã GV',tengv AS 'H? tên',ROUND(thuctaidaotao, 2) AS 'Th?c t?i ?ào t?o',ROUND(taiyeucaudaotao, 2) AS 'T?i yêu c?u ?ào t?o',ROUND(phantram_daotao, 0) AS '% ?ào t?o',ROUND(thuctaiNCKH, 2) AS 'Th?c t?i NCKH',ROUND(taiyeucauNCHK, 2) AS 'T?i yêu c?u NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Th?c t?i ',ROUND(taiyeucau, 2) AS 'T?i yêu c?u',ROUND(phantram_tong, 0) AS '% T?ng' FROM tongtai_bomon(@mabm,@namhoc)";

            string type2 = comboBox7.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();


            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql = connection.CreateCommand();
                sql.CommandText = query;
                sql.Parameters.Add(new SqlParameter("@mabm", SqlDbType.Char)).Value = ma;
                sql.Parameters.Add(new SqlParameter("@namhoc", SqlDbType.Char)).Value = namhoc;
                sda.SelectCommand = sql;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            tt_dataGridView6.DataSource = myDataSet.Tables[0];
            tt_dataGridView6.AutoResizeColumns();
        }
        public static DataSet getData(string query)
        {
            DataTable temp = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(temp);
                connection.Close();

            }

            DataSet dataBomon = new DataSet();
            dataBomon.Tables.Add(temp);
            return dataBomon;

        }

        private void tt_comboBox8_tt_SelectedValueChanged(object sender, EventArgs e)
        {
            string query = " SELECT TenDV FROM dbo.DONVI WHERE MaDV=@mabm";
            string ma = tt_comboBox8_tt.Text;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet myDataSet = new DataSet();


            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlCommand sql = connection.CreateCommand();
                sql.CommandText = query;
                sql.Parameters.Add(new SqlParameter("@mabm", SqlDbType.Char)).Value = ma;
                sda.SelectCommand = sql;
                myDataSet = new DataSet();
                sda.Fill(myDataSet);
                connection.Close();
            }
            tt_comboBox8.DataSource= myDataSet.Tables[0];
            tt_comboBox8.DisplayMember = myDataSet.Tables[0].Columns[0].ToString();
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            string chon = tt_comboBox8_phat.Text;
            tt_panel2.Visible = true;
            if(chon=="B? môn")
            {
                label11_tttt.Text = "Ch?n Mã B? môn:";
                label14_ttttt.Text = "Tên B? môn";
                string query = "SELECT MaDV FROM dbo.DONVI WHERE Capdonvi LIKE N'%B? môn%'";
                tt_comboBox8_tt.DataSource = getData(query).Tables[0];
                tt_comboBox8_tt.DisplayMember = getData(query).Tables[0].Columns[0].ToString();
            }
            else
            {
                label11_tttt.Text = "Ch?n Mã Khoa:";
                label14_ttttt.Text = "Tên Khoa";
                string query = "SELECT MaDV FROM dbo.DONVI WHERE Capdonvi LIKE N'%Khoa%'";
                tt_comboBox8_tt.DataSource = getData(query).Tables[0];
                tt_comboBox8_tt.DisplayMember = getData(query).Tables[0].Columns[0].ToString();
            }
        }

        private void tt_dataGridView6_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ContextMenu cm = new ContextMenu();

                ContextMenu cmHeader = new ContextMenu();
                int currentMouseOverRow = tt_dataGridView6.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverCol = tt_dataGridView6.HitTest(e.X, e.Y).ColumnIndex;
                // MessageBox.Show(currentMouseOverRow.ToString() + currentMouseOverCol.ToString());
                if (currentMouseOverRow >= 0)
                {
                    if (tt_dataGridView6.Rows[currentMouseOverRow].Selected == true)
                    {
                        //cm.MenuItems.Clear();
                        
                            
                            MenuItem itemPlay = new MenuItem();
                            itemPlay.Text = "T?i ?ào t?o";
                            MenuItem itemPlay1 = new MenuItem();
                            itemPlay1.Text = "T?i Nghiên C?u Khoa H?c";
                             itemPlay.Click += Show_taidaotao;
                            itemPlay1.Click += Show_taiNCKH;
                            cm.MenuItems.Add(itemPlay);
                            cm.MenuItems.Add(itemPlay1);
                        cm.Show(tt_dataGridView6, new Point(e.X, e.Y));
                    }
                }
                

            }
        }
        private void Show_taidaotao(object sender, EventArgs e)
        {
            Works_calculating.magvTT = (tt_dataGridView6.SelectedCells[0].OwningRow.Cells["Mã GV"].Value.ToString());
            Works_calculating.namhocTT = tt_comboBox10.Text;
            Works_calculating.DT = 1;
            Works_calculating.NCKH = 0;
            this.Visible = false;
            TaiGV w_c = new TaiGV();
            w_c.ShowDialog();
            this.Visible = true;
        }
        private void Show_taiNCKH(object sender, EventArgs e)
        {
            Works_calculating.magvTT = (tt_dataGridView6.SelectedCells[0].OwningRow.Cells["Mã GV"].Value.ToString());
            Works_calculating.namhocTT = tt_comboBox10.Text;
            Works_calculating.DT = 0;
            Works_calculating.NCKH = 1;
            this.Visible = false;
            TaiGV w_c = new TaiGV();
            w_c.ShowDialog();
            this.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Export.ExportFile("T?NG T?I N?M H?C", tt_dataGridView6);
        }
    }
    
}
