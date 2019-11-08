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

        private void Works_calculating_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string type1 = comboBox2.GetItemText(comboBox2.SelectedItem);
            //string type2 = comboBox1.GetItemText(comboBox1.SelectedItem);
            //string value2 = textBox6.Text;

            string type1 = comboBox2.Text;
            string type2 = comboBox1.Text;
            string value2 = textBox6.Text;

            HDNC.lylichkhoahoc(type1, type2, value2);
            dataGridView1.DataSource = HDNC.myDisplayDataTable;
            dataGridView1.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string type = comboBox3.Text;
            string value = textBox10.Text;
            string namhoc = textBox7.Text;
            DataTable dt1, dt2, dt3 = new DataTable();
            HDNC.tainghiencuukhoahoc("Bài báo khoa học", type, value, namhoc);
            dt1 = HDNC.myDisplayDataTable;
            HDNC.tainghiencuukhoahoc("Đề tài nghiên cứu", type, value, namhoc);
            dt2 = HDNC.myDisplayDataTable;
            HDNC.tainghiencuukhoahoc("Sách", type, value, namhoc);
            dt3 = HDNC.myDisplayDataTable;
            dt2.Merge(dt3);
            dt1.Merge(dt2);
            dataGridView2.DataSource = dt1;
            dataGridView2.AutoResizeColumns();
            float tongtai = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                tongtai += float.Parse(dataGridView2.Rows[i].Cells["GioChuan"].Value.ToString());
            }
            textBox12.Text = tongtai.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Export.ExportFile("HOẠT ĐỘNG NGHIÊN CỨU KHOA HỌC", dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Export.ExportFile("TẢI NGHIÊN CỨU KHOA HỌC", dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 trangchu = new Form1();
            trangchu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        ///Phát viết
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
        // ///Phát viết
        private void button8_Click(object sender, EventArgs e)
        {

            string chon = comboBox6.Text;
            panel1.Visible = false;
            if (chon == "Giáo viên")
            {
                string query = "SELECT magv AS 'Mã GV',tengv AS 'Họ tên',thuctai AS 'Thực tải',taiyeucau AS 'Tải yêu cầu' FROM dbo.tai_giang_day (@Namhoc)";

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
            if (chon == "Bộ môn")
            {
                string query = "EXEC tai_theo_khoa_or_bomon  @chon=N'bộ môn',@namhoc=@nh";

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
        ///Phát viết
        private void dataGridView4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string chon = comboBox6.Text;
            if (chon == "Giáo viên")
            {
                string query = "SELECT MaGV AS 'Mã GV', HoTen AS 'Họ tên',Monhoc AS 'Lớp học phần', Siso AS 'Sĩ số',Loaihinhdaotao AS 'Loại hình Đào tạo', Sotiet AS 'Số tiết', GioChuan as 'Giờ chuẩn'FROM dbo.taiGiangday('Mã giáo viên', @magv,@namhoc)";
                string magv = (dataGridView4.SelectedCells[0].OwningRow.Cells["Mã GV"].Value.ToString());
                string tengv = (dataGridView4.SelectedCells[0].OwningRow.Cells["Họ tên"].Value.ToString());
                string namhoc = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                label6.Text = "Mã GV :";
                label7.Text = "Họ tên:";
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
            if (chon == "Bộ môn")
            {
                string query = "SELECT temp.magv AS 'Mã GV',tengv AS 'Họ tên',thuctai AS 'Thực tải',taiyeucau AS 'Tải yêu cầu' FROM(SELECT * FROM dbo.tai_giang_day(@namhoc))AS temp JOIN dbo.GV_DV ON GV_DV.MaGV = temp.magv WHERE MaDV = @mabomon";
                string mabm = (dataGridView4.SelectedCells[0].OwningRow.Cells["Mã bộ môn"].Value.ToString());
                string tenbm = (dataGridView4.SelectedCells[0].OwningRow.Cells["Tên bộ môn"].Value.ToString());
                string namhoc = comboBox7.Text;
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet myDataSet = new DataSet();
                label6.Text = "Mã bộ môn :";
                label7.Text = "Tên bộ môn:";
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
                string query = "SELECT temp1.MaGV AS 'Mã GV',tengv AS 'Họ tên',thuctai AS 'Thực tải',taiyeucau AS 'Tải yêu cầu'  FROM  (SELECT MaGV FROM dbo.GV_DV join(SELECT * FROM dbo.DONVI WHERE MaDVC=@makhoa) AS temp ON temp.MaDV = GV_DV.MaDV) AS temp1 JOIN (SELECT * FROM dbo.tai_giang_day (@namhoc))AS temp2 ON temp2.magv = temp1.MaGV";
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
        ///Phát viết
        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.button8_Click(sender, e);
        }
        ///Phát viết
        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT [_tenkhoa] AS 'Tên khoa', [_tongqs] AS 'Tổng QS',[_sogiaosu] AS 'Giáo sư',[_sophogiaosu] AS 'Phó giáo sư',[_sotiensi] AS 'Tiến sĩ',[_sothacsi] AS 'Thạc sĩ',[_sodaihoc] AS 'Đại học',[_tongCD] AS 'Tống sô chức danh',[_socaocap] AS 'Cao cấp',[_sogiangvienchinh] AS 'Chính', [_sokhoidau] AS 'Khởi đầu' FROM dbo.thongke_nhan_luc(@ngay)";
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
            Export.ExportFile("HOẠT ĐỘNG GIẢNG DẠY", dataGridView3);
        }

        private void button12_phat_Click(object sender, EventArgs e)
        {
            string chon = comboBox6.Text;
            if (chon == "Giáo viên")
                Export.ExportFile("TẢI GIÁO VIÊN", dataGridView4);
            if (chon == "Bộ môn")
                Export.ExportFile("TẢI BỘ MÔN", dataGridView4);
            if (chon == "Khoa")
                Export.ExportFile("TẢI KHOA", dataGridView4);

        }

        private void button13_phat_Click(object sender, EventArgs e)
        {
            Export.ExportFile("THỐNG KÊ NHÂN LỰC", dataGridView5);
        }

        /// Thủy viết
        /// phần thống kê khảo thí
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
            Export.ExportFile("CÔNG TÁC KHẢO THÍ", dataGridKhaoThi);
        }
        /// phần thống kê hội đồng
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
            Export.ExportFile("THAM GIA CÁC HỘI ĐỒNG", dataGridHoiDong);
        }

        /// phần hướng dẫn đồ án
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
            Export.ExportFile("HƯỚNG DẪN ĐỒ ÁN", dataGridDoAn);
        }

        private void tt_button11_Click(object sender, EventArgs e)
        {
            string query = "";
            string chon = tt_comboBox8_phat.Text;
            if (chon == "Bộ môn")
            {
                 query = "SELECT magv AS 'Mã GV',tengv AS 'Họ tên',ROUND(thuctaidaotao, 2) AS 'Thực tải đào tạo',ROUND(taiyeucaudaotao, 2) AS 'Tải yêu cầu đào tạo',ROUND(phantram_daotao, 0) AS '% Đào tạo',ROUND(thuctaiNCKH, 2) AS 'Thực tải NCKH',ROUND(taiyeucauNCHK, 2) AS 'Tải yêu cầu NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Thực tải ',ROUND(taiyeucau, 2) AS 'Tải yêu cầu',ROUND(phantram_tong, 0) AS '% Tổng' FROM tongtai_bomon(@mabm,@namhoc)";

            }
            else
            {
                query = "SELECT magv AS 'Mã GV',tengv AS 'Họ tên',ROUND(thuctaidaotao, 2) AS 'Thực tải đào tạo',ROUND(taiyeucaudaotao, 2) AS 'Tải yêu cầu đào tạo',ROUND(phantram_daotao, 0) AS '% Đào tạo',ROUND(thuctaiNCKH, 2) AS 'Thực tải NCKH',ROUND(taiyeucauNCHK, 2) AS 'Tải yêu cầu NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Thực tải ',ROUND(taiyeucau, 2) AS 'Tải yêu cầu',ROUND(phantram_tong, 0) AS '% Tổng' FROM tongtai_khoa(@mabm,@namhoc)";

            }
            string ma = tt_comboBox8_tt.Text;
            string namhoc = tt_comboBox10.Text;
           // string query ="SELECT magv AS 'Mã GV',tengv AS 'Họ tên',ROUND(thuctaidaotao, 2) AS 'Thực tải đào tạo',ROUND(taiyeucaudaotao, 2) AS 'Tải yêu cầu đào tạo',ROUND(phantram_daotao, 0) AS '% Đào tạo',ROUND(thuctaiNCKH, 2) AS 'Thực tải NCKH',ROUND(taiyeucauNCHK, 2) AS 'Tải yêu cầu NCKH',ROUND(phamtam_NCKH, 0) AS '% NCKH',ROUND(thuctai, 2) AS 'Thực tải ',ROUND(taiyeucau, 2) AS 'Tải yêu cầu',ROUND(phantram_tong, 0) AS '% Tổng' FROM tongtai_bomon(@mabm,@namhoc)";

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
            if(chon=="Bộ môn")
            {
                label11_tttt.Text = "Chọn Mã Bộ môn:";
                label14_ttttt.Text = "Tên Bộ môn";
                string query = "SELECT MaDV FROM dbo.DONVI WHERE Capdonvi LIKE N'%Bộ môn%'";
                tt_comboBox8_tt.DataSource = getData(query).Tables[0];
                tt_comboBox8_tt.DisplayMember = getData(query).Tables[0].Columns[0].ToString();
            }
            else
            {
                label11_tttt.Text = "Chọn Mã Khoa:";
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
                            itemPlay.Text = "Tải đào tạo";
                            MenuItem itemPlay1 = new MenuItem();
                            itemPlay1.Text = "Tải Nghiên Cứu Khoa Học";
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
            Export.ExportFile("TỔNG TẢI NĂM HỌC", tt_dataGridView6);
        }
    }
    
}
