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
                            k++;
                        }
                    }
                    sheet.Columns.AutoFit();
                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    app.Quit();
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


/*public void Update_BBKH(string MaBB, string TenBB, string LoaiBB, DateTime NgayDang, string TapChi, string Soluongtacgia)
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
public void Delete_BBKH(string MaBB)
{
    SqlCommand delete = conn.CreateCommand();
    delete.CommandText = "Delete_BBKH";
    delete.CommandType = CommandType.StoredProcedure;
    delete.Parameters.Add(new SqlParameter("@MaBB", SqlDbType.Char)).Value = MaBB;
    conn.Open();
    delete.ExecuteNonQuery();
    conn.Close();
}
public void search_BBKH(string type, string value)
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
}*/
