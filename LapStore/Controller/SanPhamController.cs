using LapStore;
using LapStore.Model;
using LapStore.Widget.User;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Drawing;


namespace LapStore
{
    class SanPhamController
    {
        public static List<SanPham> GetSanPham(string maDanhMuc = "", int kieuSapXep = 0)
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                // Xây dựng điều kiện WHERE (nếu có mã danh mục)
                string whereClause = string.IsNullOrEmpty(maDanhMuc) ? "" : "WHERE maDm = @maDanhMuc";

                // Xây dựng chuỗi ORDER BY theo kiểu sắp xếp
                string orderBy;
                switch (kieuSapXep)
                {
                    case 1:
                        orderBy = "ORDER BY giaBan ASC"; // Giá tăng dần
                        break;
                    case 2:
                        orderBy = "ORDER BY giaBan DESC"; // Giá giảm dần
                        break;
                    case 3:
                        orderBy = "ORDER BY tenSp ASC"; // Theo chữ cái A-Z
                        break;
                    case 4:
                        orderBy = "ORDER BY created_at DESC"; // Sản phẩm mới nhất
                        break;
                    default:
                        orderBy = "ORDER BY NEWID()"; // Lấy ngẫu nhiên nếu không truyền tham số
                        break;
                }

                // Xây dựng câu lệnh SQL
                string query = $"SELECT * FROM SANPHAM {whereClause} {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maDanhMuc)) // Nếu có mã danh mục, thêm tham số vào câu lệnh
                    {
                        cmd.Parameters.AddWithValue("@maDanhMuc", "%" + maDanhMuc + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPhamList.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                GiaChuaBan = (long)reader["GiaChuaBan"],
                                SoLuong = (int)reader["soLuong"],
                                GiamGia = reader["maGiamGia"].ToString(),
                                NhaCungCap = reader["maNhaCungCap"].ToString(),
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return sanPhamList;
        }

        // Lấy danh sách sản phẩm theo mã danh mục
        public static List<SanPham> getSanPhamByMaDm(string maDm)
        {
            List<SanPham> SanPham = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM SANPHAM WHERE maDm = @maDm";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDm", "%" + maDm + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                GiaChuaBan = (long)reader["GiaChuaBan"],
                                SoLuong = (int)reader["soLuong"],
                                GiamGia = reader["maGiamGia"].ToString(),
                                NhaCungCap = reader["maNhaCungCap"].ToString(),
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return SanPham;
        }


        // Thêm sản phẩm
        public static void AddSanPham(SanPham sanPham)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query =
                    "INSERT INTO SANPHAM(maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong, GiaChuaBan, maGiamGia, maNhaCungCap) " +
                    "VALUES (@maSp, @maDm, @tenSp, @hinhAnh, @moTa, @giaNhap, @giaBan, @soLuong, @GiaChuaBan, @maGiamGia, @maNhaCungCap)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@tenSp", sanPham.TenSp);
                    cmd.Parameters.AddWithValue("@hinhAnh", sanPham.HinhAnh);
                    cmd.Parameters.AddWithValue("@moTa", sanPham.MoTa);
                    cmd.Parameters.AddWithValue("@giaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@giaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@soLuong", sanPham.SoLuong);
                    cmd.Parameters.AddWithValue("@GiaChuaBan", sanPham.GiaChuaBan);
                    cmd.Parameters.AddWithValue("@maGiamGia", sanPham.GiamGia);
                    cmd.Parameters.AddWithValue("@maNhaCungCap", sanPham.NhaCungCap);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật sản phẩm
        public static void UpdateSanPham(SanPham sanPham)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE SANPHAM SET maDm = @maDm, tenSp = @tenSp, hinhAnh = @hinhAnh, moTa = @moTa, " +
                               "giaNhap = @giaNhap, giaBan = @giaBan, soLuong = @soLuong, GiaChuaBan = @GiaChuaBan, maGiamGia = @maGiamGia, maNhaCungCap = @maNhaCungCap WHERE maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@tenSp", sanPham.TenSp);
                    cmd.Parameters.AddWithValue("@hinhAnh", sanPham.HinhAnh);
                    cmd.Parameters.AddWithValue("@moTa", sanPham.MoTa);
                    cmd.Parameters.AddWithValue("@giaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@giaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@soLuong", sanPham.SoLuong);
                    cmd.Parameters.AddWithValue("@GiaChuaBan", sanPham.GiaChuaBan);
                    cmd.Parameters.AddWithValue("@maGiamGia", sanPham.GiamGia);
                    cmd.Parameters.AddWithValue("@maNhaCungCap", sanPham.NhaCungCap);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xóa sản phẩm
        public static void DeleteSanPham(string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM SANPHAM WHERE maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Tìm kiếm sản phẩm
        public static List<SanPham> SearchSanPham(string searchValue, string maDm = "", int kieuSapXep = -1)
        {
            List<SanPham> SanPhams = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                // Danh sách điều kiện WHERE
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(maDm))
                {
                    conditions.Add("maDm = @maDm");
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    conditions.Add(
                        "(maSp LIKE @search OR tenSp LIKE @search OR moTa LIKE @search OR tenSp LIKE @search)");
                }

                // Xây dựng WHERE từ điều kiện
                string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

                // Xây dựng chuỗi ORDER BY theo kiểu sắp xếp
                string orderBy = "";
                switch (kieuSapXep)
                {
                    case 1:
                        orderBy = "ORDER BY giaBan ASC"; // Giá tăng dần
                        break;
                    case 2:
                        orderBy = "ORDER BY giaBan DESC"; // Giá giảm dần
                        break;
                    case 3:
                        orderBy = "ORDER BY tenSp ASC"; // Theo chữ cái A-Z
                        break;
                    case 4:
                        orderBy = "ORDER BY created_at DESC"; // Sản phẩm mới nhất
                        break;
                    default:
                        orderBy = ""; // Không sắp xếp nếu không có kiểu sắp xếp
                        break;
                }

                // Xây dựng câu truy vấn SQL
                string query = $"SELECT * FROM SANPHAM {whereClause} {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maDm))
                    {
                        cmd.Parameters.AddWithValue("@maDm", maDm);
                    }

                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhams.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                GiaChuaBan = (long)reader["GiaChuaBan"],
                                SoLuong = (int)reader["soLuong"],
                                GiamGia = reader["maGiamGia"].ToString(),
                                NhaCungCap = reader["maNhaCungCap"].ToString(),
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return SanPhams;
        }




        public static List<SanPham> SearchSanPham(string tuKhoa)
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
              

                string query = @"
            SELECT * FROM SANPHAM 
            WHERE maSp LIKE @tuKhoa OR tenSp LIKE @tuKhoa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPhamList.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                GiaChuaBan = (long)reader["GiaChuaBan"],
                                SoLuong = (int)reader["soLuong"],
                                GiamGia = reader["maGiamGia"].ToString(),
                                NhaCungCap = reader["maNhaCungCap"].ToString(),
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return sanPhamList;
        }






        // Tạo mã sản phẩm mới tự động
        public static string GenerateNewMaSp()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT maSp FROM SANPHAM";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<int> existingNumbers = new List<int>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSp = reader["maSp"].ToString();
                            string numberPart = new string(maSp.SkipWhile(c => !char.IsDigit(c)).ToArray());

                            if (int.TryParse(numberPart, out int numericPart))
                            {
                                existingNumbers.Add(numericPart);
                            }
                        }
                    }

                    // Sắp xếp danh sách số
                    existingNumbers.Sort();

                    // Tìm số bị thiếu trong dãy
                    int newNumber = 1;
                    for (int i = 0; i < existingNumbers.Count; i++)
                    {
                        if (existingNumbers[i] != newNumber)
                        {
                            break;
                        }

                        newNumber++;
                    }

                    // Trả về mã mới với định dạng SP###
                    return "SP" + newNumber.ToString("D3");
                }
            }
        }


        public class ExcelExporter
        {
            public void ExportSelectedRowsToExcelWithImages(DataGridView dgv)
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Microsoft.Office.Interop.Excel.Application excelApp = null;

                try
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application
                    {
                        Visible = true,
                        DisplayAlerts = false
                    };

                    Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                    worksheet.Name = "Dữ liệu được chọn";

                    // Thêm tiêu đề
                    worksheet.Cells[1, 1] = "STT";
                    FormatHeaderCell(worksheet.Cells[1, 1]);

                    int targetColIndex = 2; // Bắt đầu từ cột 2 trong Excel, bỏ qua cột "Giá Bán"

                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        //if (dgv.Columns[col].HeaderText == "Giá Nhập")
                        //{
                        //    continue; // Bỏ qua cột này
                        //}

                        //if (dgv.Columns[col].HeaderText == "CreateAt")
                        //{
                        //    continue; // Bỏ qua cột này
                        //}
                        worksheet.Cells[1, targetColIndex] = dgv.Columns[col].HeaderText;
                        FormatHeaderCell(worksheet.Cells[1, targetColIndex]);
                        targetColIndex++; // Di chuyển sang cột tiếp theo
                    }

                    int excelRow = 2;

                    foreach (DataGridViewRow dgvRow in dgv.SelectedRows)
                    {
                        worksheet.Cells[excelRow, 1] = excelRow - 1; // Thêm STT

                        targetColIndex = 2; // Reset vị trí cột mỗi lần duyệt dòng mới

                        for (int col = 0; col < dgv.Columns.Count; col++)
                        {
                            //if (dgv.Columns[col].HeaderText == "Giá Nhập"  )
                            //{
                            //    continue; // Bỏ qua cột này
                            //}
                            //if (dgv.Columns[col].HeaderText == "CreateAt")
                            //{
                            //    continue; // Bỏ qua cột này
                            //}
                            var cellValue = dgvRow.Cells[col].Value;

                            if (dgv.Columns[col] is DataGridViewImageColumn && cellValue is Image img)
                            {
                                string tempPath = Path.GetTempFileName();
                                img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);

                                Range cell = worksheet.Cells[excelRow, targetColIndex];

                                // Lấy kích thước ô và điều chỉnh lớn hơn
                                float left = (float)cell.Left;
                                float top = (float)cell.Top;
                                float enlargedWidth = 50; // Kích thước chiều rộng ảnh
                                float enlargedHeight = 50; // Kích thước chiều cao ảnh

                                // Thêm hình ảnh với kích thước phù hợp
                                var picture = worksheet.Shapes.AddPicture(tempPath,
                                    MsoTriState.msoFalse, MsoTriState.msoCTrue,
                                    left, top, enlargedWidth, enlargedHeight);

                                // Điều chỉnh kích thước dòng và cột để phù hợp với ảnh
                                worksheet.Rows[excelRow].RowHeight = enlargedHeight + 20;
                                worksheet.Columns[targetColIndex].ColumnWidth = (float)(enlargedWidth / 7.5);

                                File.Delete(tempPath); // Xóa file tạm
                            }
                            else
                            {
                                worksheet.Cells[excelRow, targetColIndex].Value2 = cellValue?.ToString() ?? "";
                                worksheet.Cells[excelRow, targetColIndex].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; // Căn giữa ngang
                                worksheet.Cells[excelRow, targetColIndex].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;   // Căn giữa dọc
                            }

                            targetColIndex++; // Di chuyển sang cột tiếp theo
                        }

                        excelRow++;
                    }

                    worksheet.Columns.AutoFit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                }
            }

            private void FormatHeaderCell(Range cell)
            {
                cell.Font.Bold = true;
                cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                cell.Borders.LineStyle = XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; // Căn giữa ngang
                cell.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;   // Căn giữa dọc
            }
        }

        public static void ThemmoiSanPham(string maSP, string maDM, string tenSP, string hinhAnh, string moTa,
                                   long giaNhap, long giaBan, long giaChuaBan,
                                   int soLuong, string maGiamGia, string maNhaCungCap)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                {
                    string query =
                         "INSERT INTO SANPHAM(maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong, GiaChuaBan, maGiamGia, maNhaCungCap) " +
                    "VALUES (@maSp, @maDm, @tenSp, @hinhAnh, @moTa, @giaNhap, @giaBan, @soLuong, @GiaChuaBan, @maGiamGia, @maNhaCungCap)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSp", maSP);
                        cmd.Parameters.AddWithValue("@maDm", maDM);
                        cmd.Parameters.AddWithValue("@tenSp", tenSP);
                        cmd.Parameters.AddWithValue("@hinhAnh", hinhAnh);
                        cmd.Parameters.AddWithValue("@moTa", moTa);
                        cmd.Parameters.AddWithValue("@giaNhap", giaNhap);
                        cmd.Parameters.AddWithValue("@giaBan", giaBan);
                        cmd.Parameters.AddWithValue("@giaChuaBan", giaChuaBan);
                        cmd.Parameters.AddWithValue("@soLuong", soLuong);
                        cmd.Parameters.AddWithValue("@maGiamGia", maGiamGia);
                        cmd.Parameters.AddWithValue("@maNhaCungCap", maNhaCungCap);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows == 0)
                        {
                            MessageBox.Show("Không thêm được sản phẩm: " + tenSP);
                            MessageBox.Show("b");
                        }
                        else
                        {
                            Console.WriteLine($" Đã thêm sản phẩm: {tenSP} ({maSP})");
                            MessageBox.Show("a");
                        }
                    }
                }

            }
        }

    }
}