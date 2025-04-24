﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;
using xls = Microsoft.Office.Interop.Excel;

namespace LapStore.Widget
{
    public partial class sanPhamUserControl : System.Windows.Forms.UserControl
    {
        string MADANHMUC = "";
        string imagePath;

        public sanPhamUserControl()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtMaSp.Clear();
            //txtMaDm.Clear();
            txtTenSP.Clear();
            txtMoTa.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            dateCreateAt.Value = DateTime.Now;
            imageSp.Image = null;
            imageSp.BackColor = Color.Red;
        }

        private void LapTop_Load(object sender, EventArgs e)
        {
            cboDanhMuc.Text = MADANHMUC;
            LoadingData(MADANHMUC);
            // dgvSP.DefaultCellStyle.ForeColor = Color.Black;
            // txtMaDm.Enabled = false;
        }

        public void LoadingData(string maDm)
        {
            List<SanPham> SanPhams = SanPhamController.GetSanPham(maDm);
            dgvSP.Rows.Clear();

            foreach (SanPham sp in SanPhams)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80)); // Resize về 50x50
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvSP.Rows.Add(
                    img, // Hình ảnh
                    sp.MaSp, // Mã sản phẩm
                    sp.MaDm, // Mã danh mục
                    sp.TenSp, // Tên sản phẩm
                    sp.MoTa, // Mô tả
                    sp.GiaNhap, // Giá nhập
                    sp.GiaBan, // Giá bán
                    sp.GiaChuaBan, // Giá Chưa bán
                    sp.SoLuong, // Số lượng
                    sp.GiamGia, // Giảm giá
                    sp.NhaCungCap, // Nhà cung cấp
                    sp.CreatedAt // Ngày tạo
                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }

            // Lấy ra danh sách danh mục
            List<DanhMuc> danhMucs = DanhMucController.getAllDanhMucs();
            Dictionary<string, string> danhMucDict = new Dictionary<string, string>();
            foreach (DanhMuc dm in danhMucs)
            {
                danhMucDict.Add(dm.id, dm.tenDanhMuc);
            }

            cboDanhMuc.DataSource = new BindingSource(danhMucDict, null);
            cboDanhMuc.DisplayMember = "Value";
            cboDanhMuc.ValueMember = "Key";
            // lấy ra danh sách nhà cung cấp
            List<NhaCungCap> nhaCungCaps = NhaCungCapController.getAllNhaCungCaps();
            Dictionary<string, string> nhaCungCapDict = new Dictionary<string, string>();
            foreach (NhaCungCap ncc in nhaCungCaps)
            {
                nhaCungCapDict.Add(ncc.id, ncc.tenNhaCungCap);
            }

            cboNcc.DataSource = new BindingSource(nhaCungCapDict, null);
            cboNcc.DisplayMember = "Value";
            cboNcc.ValueMember = "Key";
            // lấy ra danh sách giảm giá
            List<GiamGia> giamGias = GiamGiaController.getAllGiamGias();
            Dictionary<string, string> giamGiaDict = new Dictionary<string, string>();
            foreach (GiamGia gg in giamGias)
            {
                giamGiaDict.Add(gg.id, gg.tenGiamGia);
            }

            cboGiamGia.DataSource = new BindingSource(giamGiaDict, null);
            cboGiamGia.DisplayMember = "Value";
            cboGiamGia.ValueMember = "Key";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // Sử dụng hàm kiểm tra từ lớp Validator
            if (string.IsNullOrWhiteSpace(txtMaSp.Text) ||
              string.IsNullOrWhiteSpace(txtTenSP.Text) ||
              string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
              string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
              string.IsNullOrWhiteSpace(txtGiaChuaBan.Text) ||
              string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
              cboDanhMuc.SelectedValue == null ||
              cboGiamGia.SelectedValue == null ||
              cboNcc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Database.KiemTraMaSp(txtMaSp.Text))
            {
                //MessageBox.Show("Mã sản phẩm không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số
            if (!long.TryParse(txtGiaNhap.Text, out long giaNhap))
            {
                MessageBox.Show("Giá nhập không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!long.TryParse(txtGiaBan.Text, out long giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!long.TryParse(txtGiaChuaBan.Text, out long giaChuaBan))
            {
                MessageBox.Show("Giá chưa bán không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem có ảnh hay không
            imagePath = imageSp.Tag?.ToString() ?? "";

            var sanPham = new SanPham
            {
                MaSp = txtMaSp.Text,
                MaDm = cboDanhMuc.SelectedValue.ToString(),
                TenSp = txtTenSP.Text,
                HinhAnh = imagePath,
                MoTa = txtMoTa.Text,
                GiaNhap = long.Parse(txtGiaNhap.Text),
                GiaBan = long.Parse(txtGiaBan.Text),
                GiaChuaBan = long.Parse(txtGiaChuaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                GiamGia = cboGiamGia.SelectedValue.ToString(),
                NhaCungCap = cboNcc.SelectedValue.ToString(),
                CreatedAt = DateTime.Now,
            };

            // Gọi hàm thêm sản phẩm
            SanPhamController.AddSanPham(sanPham);
            LoadingData(MADANHMUC);
            MessageBox.Show("Thêm sản phẩm thành công!");
            ClearForm();
        }


        private void dgvLapTop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSP.Rows[e.RowIndex];

                // Lấy thông tin từ các ô
                txtMaSp.Text = row.Cells["maSp"].Value?.ToString().Trim();
                cboDanhMuc.Text = row.Cells["maDm"].Value?.ToString().Trim();
                txtTenSP.Text = row.Cells["tenSp"].Value?.ToString().Trim();
                txtMoTa.Text = row.Cells["moTa"].Value?.ToString().Trim();
                txtGiaNhap.Text = row.Cells["giaNhap"].Value?.ToString().Trim();
                txtGiaBan.Text = row.Cells["giaBan"].Value?.ToString().Trim();
                txtGiaChuaBan.Text = row.Cells["giaChuaBan"].Value?.ToString().Trim();
                txtSoLuong.Text = row.Cells["soLuong"].Value?.ToString().Trim();
                dateCreateAt.Value = DateTime.Parse(row.Cells["createAt"].Value?.ToString());
                cboDanhMuc.SelectedItem = row.Cells["maDm"].Value?.ToString().Trim();
                cboNcc.SelectedItem = row.Cells["nhaCungCap"].Value?.ToString().Trim();
                cboGiamGia.SelectedItem = row.Cells["giamGia"].Value?.ToString().Trim();

                // Hiển thị hình ảnh lên PictureBox
                try
                {
                    imagePath = row.Cells["HinhAnh"].Tag?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        using (var bmpTemp = new Bitmap(imagePath))
                        {
                            imageSp.Image = new Bitmap(bmpTemp);
                            imageSp.Tag = imagePath;
                        }

                        imageSp.BackColor = Color.Transparent; // Không có màu nền khi có ảnh
                    }
                    else
                    {
                        imageSp.Image = null;
                        imageSp.BackColor = Color.Red; // Đặt màu nền đỏ khi không có ảnh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị hình ảnh: " + ex.Message);
                    imageSp.Image = null;
                    imageSp.BackColor = Color.Red; // Đặt màu nền đỏ khi xảy ra lỗi
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã sản phẩm từ TextBox
            string maSp = txtMaSp.Text;

            // Kiểm tra mã sản phẩm có rỗng không
            if (string.IsNullOrWhiteSpace(maSp))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để xóa!");
                txtMaSp.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa sản phẩm
                    SanPhamController.DeleteSanPham(maSp);

                    // Tải lại dữ liệu sau khi xóa
                    LoadingData(MADANHMUC);
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa sản phẩm thất bại! Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Sử dụng hàm kiểm tra từ lớp Validator
            if (string.IsNullOrWhiteSpace(txtMaSp.Text) ||
    string.IsNullOrWhiteSpace(txtTenSP.Text) ||
    string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
    string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
    string.IsNullOrWhiteSpace(txtGiaChuaBan.Text) ||
    string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
    cboDanhMuc.SelectedValue == null ||
    cboGiamGia.SelectedValue == null ||
    cboNcc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem mã sản phẩm có bị chỉnh sửa hay không
           

            // Kiểm tra định dạng số
            if (!long.TryParse(txtGiaNhap.Text, out long giaNhap))
            {
                MessageBox.Show("Giá nhập không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!long.TryParse(txtGiaBan.Text, out long giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!long.TryParse(txtGiaChuaBan.Text, out long giaChuaBan))
            {
                MessageBox.Show("Giá chưa bán không hợp lệ. Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem có ảnh hay không
            imagePath = imageSp.Tag?.ToString() ?? "";

            var sanPham = new SanPham
            {
                MaSp = txtMaSp.Text,
                MaDm = cboDanhMuc.SelectedValue.ToString(),
                TenSp = txtTenSP.Text,
                HinhAnh = imagePath,
                MoTa = txtMoTa.Text,
                GiaNhap = long.Parse(txtGiaNhap.Text),
                GiaBan = long.Parse(txtGiaBan.Text),
                GiaChuaBan = long.Parse(txtGiaChuaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                GiamGia = cboGiamGia.SelectedValue.ToString(),
                NhaCungCap = cboNcc.SelectedValue.ToString(),
                CreatedAt = DateTime.Now,
            };
            if (!txtMaSp.ReadOnly && !txtMaSp.Text.Equals(sanPham.MaSp))
            {
                MessageBox.Show("Không được sửa mã sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm cập nhật sản phẩm
            SanPhamController.UpdateSanPham(sanPham);
            LoadingData(MADANHMUC);
            MessageBox.Show("Cập nhật sản phẩm thành công!");
            ClearForm();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string maDm = cboDanhMuc.Text.Trim();

            List<SanPham> SanPhams = SanPhamController.SearchSanPham(keyword, maDm);
            dgvSP.Rows.Clear();

            foreach (SanPham sp in SanPhams)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80)); // Resize về 80x80
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvSP.Rows.Add(
                    img, // Hình ảnh
                    sp.MaSp, // Mã sản phẩm
                    sp.MaDm, // Mã danh mục
                    sp.TenSp, // Tên sản phẩm
                    sp.MoTa, // Mô tả
                    sp.GiaNhap, // Giá nhập
                    sp.GiaBan, // Giá bán
                    sp.GiaChuaBan, // Giá bán thật
                    sp.SoLuong, // Số lượng
                    sp.GiamGia, // Giảm giá
                    sp.NhaCungCap, // Nhà cung cấp
                    sp.CreatedAt // Ngày tạo
                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }
        }

        private void newMaSp_Click(object sender, EventArgs e)
        {
            txtMaSp.Text = SanPhamController.GenerateNewMaSp();
        }

        private void btn_taiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình ảnh";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị hình ảnh lên PictureBox
                    imageSp.Image = new Bitmap(ofd.FileName);
                    imageSp.Tag = ofd.FileName; // Lưu đường dẫn vào Tag
                }
            }
        }

        private void txtGiaChuaBan_TextChanged(object sender, EventArgs e)
        {
            int giaChuaBan;
            long soGiamGia;

            if (int.TryParse(txtGiaChuaBan.Text, out giaChuaBan) &&
                long.TryParse(txtSoGiamGia.Text, out soGiamGia))
            {
                var giaBan = giaChuaBan * (100 - soGiamGia) / 100;
                txtGiaBan.Text = giaBan.ToString();
            }
            else
            {
                txtGiaBan.Text = "0"; // hoặc bạn có thể để trống
            }
        }
        private void cboGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = cboGiamGia.SelectedValue.ToString();
            List<GiamGia> giamGias = GiamGiaController.SearchGiamGias(text);
            foreach (var giamGia in giamGias)
            {
                txtSoGiamGia.Text = giamGia.soGiamGia;
            }
        }

        string filename;
        private void ReadExcel()
        {
            xls.Application excelApp = new xls.Application();
            xls.Workbook workbook = null;
            xls.Worksheet worksheet = null;

            try
            {
                workbook = excelApp.Workbooks.Open(filename);
                worksheet = (xls.Worksheet)workbook.Sheets[1];

                int i = 2;
               
                while (worksheet.Cells[i, 3]?.Value != null)
                //diều kiện ở đyâ sai rồi
                {
                    string hinhAnh = ((xls.Range)worksheet.Cells[i, 2]).Text.ToString().Trim();
                    string maSp = ((xls.Range)worksheet.Cells[i, 3]).Text.ToString().Trim();
                    string maDm = ((xls.Range)worksheet.Cells[i, 4]).Text.ToString().Trim();
                    string tenSp = ((xls.Range)worksheet.Cells[i, 5]).Text.ToString().Trim();
                    string moTa = ((xls.Range)worksheet.Cells[i, 6]).Text.ToString().Trim();
                    long giaNhap = long.Parse(((xls.Range)worksheet.Cells[i, 7]).Text.ToString().Trim());
                    long giaBan = long.Parse(((xls.Range)worksheet.Cells[i, 8]).Text.ToString().Trim());
                    long giaChuaBan = long.Parse(((xls.Range)worksheet.Cells[i, 9]).Text.ToString().Trim());
                    int soLuong = int.Parse(((xls.Range)worksheet.Cells[i, 10]).Text.ToString().Trim());
                    string maGiamGia = ((xls.Range)worksheet.Cells[i, 11]).Text.ToString().Trim();
                    string maNhaCungCap = ((xls.Range)worksheet.Cells[i, 12]).Text.ToString().Trim();  
                    SanPhamController.ThemmoiSanPham(
                        maSp, maDm, tenSp, hinhAnh, moTa,
                        giaNhap, giaBan, giaChuaBan, soLuong,
                        maGiamGia, maNhaCungCap
                    );

                    i++;
                }

                //MessageBox.Show("✅ Nhập sản phẩm từ Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi khi đọc Excel: " + ex.Message);
            }
            finally
            {
                workbook?.Close(false);
                excelApp.Quit();
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opened = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = false
            };

            if (opened.ShowDialog() == DialogResult.OK)
            {
                //txtUploadDienTu.Text = opened.FileName;
                filename = opened.FileName;
                ReadExcel();
            }
            //gọi hàm ở đâu
            LoadingData(MADANHMUC);
        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            var exporter = new SanPhamController.ExcelExporter();
            exporter.ExportSelectedRowsToExcelWithImages(dgvSP);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tukhoa= txtTimKiem.Text.Trim();
            List<SanPham> SanPhams = SanPhamController.SearchSanPham(tukhoa);
            dgvSP.Rows.Clear();

            foreach (SanPham sp in SanPhams)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80)); // Resize về 50x50
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvSP.Rows.Add(
                    img, // Hình ảnh
                    sp.MaSp, // Mã sản phẩm
                    sp.MaDm, // Mã danh mục
                    sp.TenSp, // Tên sản phẩm
                    sp.MoTa, // Mô tả
                    sp.GiaNhap, // Giá nhập
                    sp.GiaBan, // Giá bán
                    sp.GiaChuaBan, // Giá Chưa bán
                    sp.SoLuong, // Số lượng
                    sp.GiamGia, // Giảm giá
                    sp.NhaCungCap, // Nhà cung cấp
                    sp.CreatedAt // Ngày tạo
                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }

        }
    }
}