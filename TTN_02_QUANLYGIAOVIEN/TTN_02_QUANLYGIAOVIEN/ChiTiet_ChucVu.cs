using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_GIAO_VIEN
{
    public partial class ChiTiet_ChucVu : Form
    {
        public ChiTiet_ChucVu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string magv;
        public void SetMa(string x)
        {
            label2.Text = x;
            magv = x;
        }
        private void ChiTiet_ChucVu_Load(object sender, EventArgs e)
        {
            LienKetCSDL.OpenConnection();

            dataGridHienTai_CV.DataSource = LienKetCSDL.getDataTable("select * from dbo.Func_GV_CV_HienTai ('" + magv + "')");
            dataGridLichSu_CV.DataSource = LienKetCSDL.getDataTable("select * from Func_GV_CV_LichSu ('" + magv + "')");

        }
    }
}
