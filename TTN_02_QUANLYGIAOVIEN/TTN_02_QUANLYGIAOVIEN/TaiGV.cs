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

       
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
