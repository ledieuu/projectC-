using LapStore.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapStore.Controller
{
    internal class DoanhThuNhomHangController
    {
        public static List<ThongKeDanhMuc> getAllThongKeDanhMucs()
        {
            List<ThongKeDanhMuc> ThongKeDanhMucs = new List<ThongKeDanhMuc>();

            string query = @"
            SELECT
                d.id AS DanhMucId,         -- ID của danh mục
                d.tenDanhMuc,             -- Tên danh mục
                SUM(s.soLuong) AS TongSoLuong -- Tổng số lượng sản phẩm trong danh mục này
            FROM
                DANHMUC d                 -- Alias 'd' cho bảng DANHMUC
            JOIN
                SANPHAM s ON d.id = s.maDm -- Kết nối DANHMUC và SANPHAM trên cột id và maDm
            GROUP BY
                d.id, d.tenDanhMuc        -- Gom nhóm kết quả theo ID và tên danh mục
            ORDER BY
                d.id;
        ";
            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThongKeDanhMucs.Add(new ThongKeDanhMuc
                        {
                            DanhMucId = reader["DanhMucId"].ToString(), // Sửa lại tên cột
                            TenDanhMuc = reader["tenDanhMuc"].ToString(), // Sửa lại tên cột
                            TongSoLuong = (int)reader["TongSoLuong"],
                        });
                    }
                }
            }

            return ThongKeDanhMucs;
        }

        public static List<ThongKeDanhMuc> cboThongKeDanhMucs(string text)
        {
            List<ThongKeDanhMuc> ThongKeDanhMucs = new List<ThongKeDanhMuc>();

            string query = @"
            SELECT
                d.id AS DanhMucId,
                d.tenDanhMuc,
                SUM(s.soLuong) AS TongSoLuong
            FROM
                DANHMUC d
            JOIN
                SANPHAM s ON d.id = s.maDm
            WHERE
                d.id = @DanhMucId 
            GROUP BY
                d.id, d.tenDanhMuc
            ORDER BY
                d.id;
            ";
            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@DanhMucId",  text);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThongKeDanhMucs.Add(new ThongKeDanhMuc
                        {
                            DanhMucId = reader["DanhMucId"].ToString(), // Sửa lại tên cột
                            TenDanhMuc = reader["tenDanhMuc"].ToString(), // Sửa lại tên cột
                            TongSoLuong = (int)reader["TongSoLuong"],
                        });
                    }
                }
            }

            return ThongKeDanhMucs;
        }
        public static int getTongSoLuong()
        {
            int tongSoLuong = 0;

            string query = @"
        SELECT SUM(soLuong) AS TongSoLuong
        FROM SANPHAM
    ";

            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    tongSoLuong = Convert.ToInt32(result);
                }
            }

            return tongSoLuong;
        }

        public class ExcelExporter
        {
            //public void ExportSelectedRowsToExcel(DataGridView dgv)
            //{
            //    if (dgv.SelectedRows.Count == 0)
            //    {
            //        MessageBox.Show("Vui lòng chọn ít nhất một dòng để xuất!", "Thông báo");
            //        return;
            //    }

            //    var excel = new Microsoft.Office.Interop.Excel.Application { Visible = true };
            //    var sheet = (Worksheet)excel.Workbooks.Add().Sheets[1];
            //    sheet.Name = "Dữ liệu danh mục";

            //    // Tiêu đề (Không có STT)
            //    string[] headers = { "Mã danh mục", "Tên danh mục", "Số lượng" };
            //    for (int i = 1; i < headers.Length; i++)
            //    {
            //        var cell = sheet.Cells[2, i + 1];
            //        cell.Value = headers[i];
            //        cell.Font.Bold = true;
            //        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            //        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        cell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            //        cell.Borders.LineStyle = XlLineStyle.xlContinuous;
            //    }

            //    // Dữ liệu (Không có cột STT)
            //    int excelRow = 2;
            //    foreach (DataGridViewRow row in dgv.SelectedRows)
            //    {
            //        sheet.Cells[excelRow, 2] = row.Cells["Mã danh mục"].Value;
            //        sheet.Cells[excelRow, 3] = row.Cells["Tên danh mục"].Value;
            //        sheet.Cells[excelRow, 4] = row.Cells["Số lượng"].Value;
            //        excelRow++;
            //    }

            //    sheet.Columns.AutoFit();
            //}
          
                public void ExportSelectedRowsToExcel(DataGridView dgv)
                {
                    if (dgv.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một dòng để xuất!", "Thông báo");
                        return;
                    }

                    var excel = new Microsoft.Office.Interop.Excel.Application { Visible = true };
                    var sheet = (Worksheet)excel.Workbooks.Add().Sheets[1];
                    sheet.Name = "Dữ liệu danh mục";

                    // Chỉ xuất "Tên danh mục" và "Số lượng"
                    string[] headers = { "TT","Mã Danh Mục","Tên danh mục", "Số lượng" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = sheet.Cells[2, i + 1];
                        cell.Value = headers[i];
                        cell.Font.Bold = true;
                        cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        cell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        cell.Borders.LineStyle = XlLineStyle.xlContinuous;
                    }

                    // Dữ liệu
                    int excelRow = 3;
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                    sheet.Cells[excelRow, 1] = row.Cells["TT"].Value;
                    sheet.Cells[excelRow, 2] = row.Cells["madm"].Value;

                    sheet.Cells[excelRow, 3] = row.Cells["tendm"].Value;
                        sheet.Cells[excelRow, 4] = row.Cells["soluong"].Value;
                        excelRow++;
                    }

                    sheet.Columns.AutoFit();
                }
            }

        

    }
}