using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;
using LapStore.Widget.User;
using Microsoft.Office.Interop.Excel;

namespace LapStore.Controller
{
    public class DoanhThuLaiLoController
    {
        public static List<ThongKeDoanhThuLaiLo> getAllThongKeDoanhThuLaiLos()
        {
            List<ThongKeDoanhThuLaiLo> ThongKeDoanhThuLaiLos = new List<ThongKeDoanhThuLaiLo>();

            string query = @"
            SELECT
                tk.maDonHang,                
                u.hoTen,                     
                SUM(sp.giaNhap * tk.soLuong) AS TongGiaNhap,
                SUM(tk.doanhThu) AS TongDoanhThu,          
                SUM(tk.loiNhuan) AS TongLoiNhuan           
            FROM
                THONGKE tk
            INNER JOIN
                DONHANG dh ON tk.maDonHang = dh.id 
            INNER JOIN
                USERS u ON dh.maUser = u.id         
            INNER JOIN
                SANPHAM sp ON tk.maSp = sp.maSp     
            GROUP BY
                tk.maDonHang,                 
                u.hoTen                      
            ORDER BY
                tk.maDonHang;                 
        ";
            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThongKeDoanhThuLaiLos.Add(new ThongKeDoanhThuLaiLo
                        {
                            MaHD = reader["maDonHang"].ToString(), // Sửa lại tên cột
                            TenKH = reader["hoTen"].ToString(), // Sửa lại tên cột
                            TienVon = reader.GetInt64(reader.GetOrdinal("TongGiaNhap")),
                            TienBan = reader.GetInt64(reader.GetOrdinal("TongDoanhThu")),
                            LoiNhuan = reader.GetInt64(reader.GetOrdinal("TongLoiNhuan")),
                        });
                    }
                }
            }

            return ThongKeDoanhThuLaiLos;
        }



        public static List<ThongKeDoanhThuLaiLo> searchThongKeDoanhThuLaiLos(string searchTermParam)
        {
            List<ThongKeDoanhThuLaiLo> ThongKeDoanhThuLaiLos = new List<ThongKeDoanhThuLaiLo>();

            string query = @"
            SELECT
                tk.maDonHang,                 -- Mã đơn hàng từ bảng THONGKE
                u.hoTen,                      -- Họ tên người dùng từ bảng USERS
                SUM(sp.giaNhap * tk.soLuong) AS TongGiaNhap, -- Tổng giá nhập (giá nhập * số lượng)
                SUM(tk.doanhThu) AS TongDoanhThu,          -- Tổng doanh thu từ bảng THONGKE
                SUM(tk.loiNhuan) AS TongLoiNhuan           -- Tổng lợi nhuận từ bảng THONGKE
            FROM
                THONGKE tk
            INNER JOIN
                DONHANG dh ON tk.maDonHang = dh.id -- Kết nối THONGKE với DONHANG qua id đơn hàng
            INNER JOIN
                USERS u ON dh.maUser = u.id         -- Kết nối DONHANG với USERS qua id người dùng
            INNER JOIN
                SANPHAM sp ON tk.maSp = sp.maSp     -- Kết nối THONGKE với SANPHAM qua mã sản phẩm
            WHERE
                -- Search term is applied to both maDonHang and hoTen using OR
                tk.maDonHang LIKE @searchTermParam
                OR u.hoTen LIKE @searchTermParam
            GROUP BY
                tk.maDonHang,                 -- Nhóm kết quả theo mã đơn hàng
                u.hoTen                       -- và họ tên người dùng
            ORDER BY
                tk.maDonHang;                 -- Sắp xếp kết quả theo mã đơn hàng
        ";
            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@searchTermParam", "%" + searchTermParam + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        ThongKeDoanhThuLaiLos.Add(new ThongKeDoanhThuLaiLo
                        {
                            MaHD = reader["maDonHang"].ToString(), // Sửa lại tên cột
                            TenKH = reader["hoTen"].ToString(), // Sửa lại tên cột
                            TienVon = reader.GetInt64(reader.GetOrdinal("TongGiaNhap")),
                            TienBan = reader.GetInt64(reader.GetOrdinal("TongDoanhThu")),
                            LoiNhuan = reader.GetInt64(reader.GetOrdinal("TongLoiNhuan")),
                        });
                    }
                }
            }

            return ThongKeDoanhThuLaiLos;
        }


        public static long getTongVon()
        {
            long tongVon = 0;

            string query = @"
    SELECT
        SUM(sp.giaNhap * tk.soLuong) 
    FROM
        THONGKE tk
    INNER JOIN
        SANPHAM sp ON tk.maSp = sp.maSp;
    ";

            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    tongVon = Convert.ToInt64(result);
                }
            }

            return tongVon;
        }

        public static long getTongBan()
        {
            long tongban = 0;

            string query = @"
    SELECT
        SUM(sp.giaBan * tk.soLuong)

    FROM
        THONGKE tk
    INNER JOIN
        SANPHAM sp ON tk.maSp = sp.maSp;
    ";

            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    tongban = Convert.ToInt64(result);
                }
            }

            return tongban;
        }
        public static long getTongLoiNhuan()
        {
            long tongLoiNhuan = 0;

            string query = @"
        SELECT SUM(loiNhuan) AS TongLoiNhuan
        FROM THONGKE
    ";

            using (SqlCommand cmd = new SqlCommand(query, Database.GetConnection()))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    tongLoiNhuan = Convert.ToInt64(result);
                }
            }

            return tongLoiNhuan;
        }


        public class ExcelExporter
        {
            public void ExportSelectedRowsToExcel(DataGridView dgv)
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng để xuất!", "Thông báo");
                    return;
                }

                var excel = new Microsoft.Office.Interop.Excel.Application { Visible = true };
                var sheet = (Worksheet)excel.Workbooks.Add().Sheets[1];
                sheet.Name = "Dữ liệu hoá đơn";

                // Tiêu đề cột
                string[] headers = { "TT", "Mã Hoá Đơn", "Khách Hàng", "Tiền Vốn", "Tiền Bán", "Tiền Lãi" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = sheet.Cells[1, i + 1];
                    cell.Value = headers[i];
                    cell.Font.Bold = true;
                    cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    cell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    cell.Borders.LineStyle = XlLineStyle.xlContinuous;
                }

                // Dữ liệu
                int excelRow = 2;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        sheet.Cells[excelRow, 1] = excelRow - 1; // TT
                        sheet.Cells[excelRow, 2] = row.Cells["MaHoaDon"].Value; // Mã Hoá Đơn
                        sheet.Cells[excelRow, 3] = row.Cells["TenKhachHang"].Value; // Khách Hàng
                        sheet.Cells[excelRow, 4] = row.Cells["TienVon"].Value;   // Tiền Vốn
                        sheet.Cells[excelRow, 5] = row.Cells["TienBan"].Value;   // Tiền Bán
                        sheet.Cells[excelRow, 6] = row.Cells["LoiNhuon"].Value;   // Tiền Lãi
                        excelRow++;
                    }
                }

                sheet.Columns.AutoFit();
            }
        }


    }
}