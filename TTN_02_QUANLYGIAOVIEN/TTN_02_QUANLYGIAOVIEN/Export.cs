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
            // T?o ??i t??ng m? Explorer
            SaveFileDialog fsave = new SaveFileDialog();
            // Ch? ra ?uôi c?a t?p tin
            fsave.Filter = "(T?t c? các t?p)|*.*|(Các t?p excel)|*.xlsx";
            fsave.ShowDialog();

            if (fsave.FileName != "")
            {
                // T?o Excel App
                Excel.Application app = new Excel.Application();
                // T?o 1 workbook
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = null;
                try
                {
                    // ??c d? li?u
                    sheet = wb.ActiveSheet;
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgv.ColumnCount]].Merge();
                    sheet.Cells[1, 1].Value = Header;
                    sheet.Cells[1, 1].Font.Name = "Times New Roman";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //Sinh tiêu ??
                    for (int i = 1, k = 1; i <= dgv.Columns.Count; i++)
                    {
                                    }
            else
            {
                MessageBox.Show("B?n không ch?n t?p tin nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
