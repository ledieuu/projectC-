﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;

namespace LapStore.Widget.Admin
{
    public partial class donHangAdmin : System.Windows.Forms.UserControl
    {
        public donHangAdmin()
        {
            InitializeComponent();
        }

        private void LoadTrangThaiToComboBox()
        {
            cbb_timTheoTT.Items.Clear();
            cbb_trangThai.Items.Clear();
            // Giả sử các trạng thái có thể là:
            var trangThaiList = new List<string>
                {
                    "Chờ thanh toán",
                    "Đang giao",
                    "Giao thành công",
                    "Yêu cầu hủy",
                    "Đã hủy"
                };

            cbb_timTheoTT.Items.AddRange(trangThaiList.ToArray());
            cbb_timTheoTT.SelectedIndex = 0; // Chọn mặc định trạng thái đầu
            cbb_trangThai.Items.AddRange(trangThaiList.ToArray());
            cbb_trangThai.SelectedIndex = 0; // Chọn mặc định trạng thái đầu
        }
        private void LoadDonHangTheoTrangThai(string trangThai)
        {
            var donHangList = DonHangController.GetDonHangTheoTrangThai(trangThai);

            dgvDonHang.Rows.Clear(); // Xóa dữ liệu cũ (nếu bạn không dùng `DataSource`)

            foreach (var dh in donHangList)
            {
                dgvDonHang.Rows.Add(
                    dh.Id,
                    dh.Sdt,
                    dh.DiaChi,
                    dh.TongTien.ToString("N0") + "đ",
                    dh.PhuongThucThanhToan,
                    dh.TrangThai,
                    dh.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void donHangAdmin_Load(object sender, EventArgs e)
        {
            LoadTrangThaiToComboBox();
            LoadDonHangTheoTrangThai(cbb_timTheoTT.Text);
            // dgvDonHang.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {

            string selectedTrangThai = cbb_timTheoTT.Text;
            LoadDonHangTheoTrangThai(selectedTrangThai);
        }


        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDonHang.Rows.Count)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];

                txtMaDh.Text = row.Cells["madh"].Value?.ToString();               // ID
                txtSdt.Text = row.Cells["sdt"].Value?.ToString();              // SĐT
                txtDiaChi.Text = row.Cells["diachi"].Value?.ToString();           // Địa chỉ
                txtTongTien.Text = row.Cells["tongtien"].Value?.ToString();         // Tổng tiền
                txtPhuongThuc.Text = row.Cells["phuongthuc"].Value?.ToString();       // Phương thức
                cbb_trangThai.Text = row.Cells["trangthai"].Value?.ToString();        // Trạng thái
                //  = DateTime.Parse(row.Cells["createat"].Value?.ToString());
                string inputFormat = "dd/MM/yyyy HH:mm";

                dateCreateAt.Value = DateTime.ParseExact(row.Cells["createat"].Value?.ToString(), inputFormat, CultureInfo.InvariantCulture);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDonHang = txtMaDh.Text.Trim();
            string trangThaiMoi = cbb_trangThai.Text.Trim();

            if (string.IsNullOrEmpty(maDonHang))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Nếu trạng thái mới là "Đã hủy", gọi thêm xử lý hoàn tác tồn kho + thống kê
                if (trangThaiMoi == "Đã hủy")
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này không? Thao tác này sẽ hoàn tác lại số lượng tồn kho và xóa thống kê.",
                                                          "Xác nhận hủy",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;

                    // Gọi hàm hoàn tác trước
                    DonHangController.HoanTacDonHangBiHuy(maDonHang);
                }

                // Cập nhật trạng thái đơn hàng
                DonHangController.CapNhatTrangThaiDonHang(maDonHang, trangThaiMoi);

                MessageBox.Show("✅ Cập nhật trạng thái đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi cập nhật thì load lại danh sách theo trạng thái đã lọc
                LoadDonHangTheoTrangThai(cbb_timTheoTT.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
