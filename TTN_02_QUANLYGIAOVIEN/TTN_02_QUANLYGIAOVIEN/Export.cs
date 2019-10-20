using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QUAN_LY_GIAO_VIEN
{
    class Export
    {
        public static void ExportFile(string Header, DataGridView dgv )
        {
            // Tạo đối tượng mở Explorer
            SaveFileDialog fsave = new SaveFileDialog();
            // Chỉ ra đuôi của tệp tin
            fsave.Filter = "(Tất cả các tệp)|*.*|(Các tệp excel)|*.xlsx";
            fsave.ShowDialog();

            if (fsave.FileName != "")
            {
                // Tạo Excel App
                Excel.Application app = new Excel.Application();
                // Tạo 1 workbook
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = null;
                try
                {
                    // Đọc dữ liệu
                    sheet = wb.ActiveSheet;
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgv.ColumnCount]].Merge();
                    sheet.Cells[1, 1].Value = Header;
                    sheet.Cells[1, 1].Font.Name = "Times New Roman";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu đề
                    for (int i = 1, k = 1; i <= dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i - 1].Visible == false) continue;
                        sheet.Cells[2, k] = dgv.Columns[i - 1].HeaderText;
                        sheet.Cells[2, k].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, k].Font.Name = "Times New Roman";
                        sheet.Cells[2, k].Font.Bold = true;
                        sheet.Cells[2, k].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        k++;
                    }
                    // Sinh dữ liệu
                    for (int i = 1; i <= dgv.RowCount - 1; i++)
                    {
                        if (dgv.Columns[0].Visible == false) continue;
                        sheet.Cells[i + 2, 1] = dgv.Rows[i - 1].Cells[0].Value;
                        sheet.Cells[i + 2, 1].Font.Name = "Times New Roman";
                        sheet.Cells[i + 2, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        for (int j = 2, k = 2; j <= dgv.Columns.Count; j++)
                        {
                            if (dgv.Columns[j - 1].Visible == false) continue;
                            sheet.Cells[i + 2, k] = dgv.Rows[i - 1].Cells[j - 1].Value;
                            sheet.Cells[i + 2, k].Font.Name = "Times New Roman";
                            sheet.Cells[i + 2, k].Borders.Weight = Excel.XlBorderWeight.xlThin;
        
                    wb = null;
                }

            }
            else
            {
                MessageBox.Show("Bạn không chọn tệp tin nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
