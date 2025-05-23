﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Widget;

namespace LapStore.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_pass.UseSystemPasswordChar = true;
            txt_checkPass.UseSystemPasswordChar = true;
            txt_passDK.UseSystemPasswordChar = true;
            txt_email.Text = "admin@gmail.com";
            txt_pass.Text = "123456";

        }

        private async void btn_dangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_email.Text) || string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string role = UserController.Login(txt_email.Text, txt_pass.Text);

            if (role == "USER")
            {
                // loading1.Visible = true;
                await Task.Delay(1000);
                userHome userForm = new userHome();
                userForm.Show();
                QuangCao QuangCao = new QuangCao();
                QuangCao.Show();
                this.Hide();
            }
            else if (role == "ADMIN")
            {
                // loading1.Visible = true;
                await Task.Delay(1000);
                adminHome adminForm = new adminHome();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", "Xác nhận",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát toàn bộ ứng dụng
            }
        }

        private void btn_sangDK_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = true;
            //panelLogin.Visible = false;
            panelRegister.BringToFront();
        }

        private void btn_sangDN_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelLogin.BringToFront();
            panelRegister.Visible = false;

        }

        private void btn_dangKi_Click(object sender, EventArgs e)
        {
        
            string hoTen = txt_tenDK.Text.Trim();
            string email = txt_emailDK.Text.Trim();
            string pass = txt_passDK.Text.Trim();

            // Kiểm tra thông tin nhập vào
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Database.KiemTraEmail(email))
            {
                return; // Nếu email không hợp lệ thì không tiếp tục
            }

            if (!Database.KiemTraMatKhau(pass))
            {
                return; // Nếu mật khẩu không hợp lệ thì không tiếp tục
            }

            // Nếu hợp lệ, tiến hành đăng ký
            bool success = UserController.Register(hoTen, email, pass);

            if (success)
            {
                DialogResult result = MessageBox.Show("Đăng kí thành công! Vui lòng đăng nhập.", "Xác nhận",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    panelLogin.Visible = true;
                    panelLogin.BringToFront();
                    panelRegister.Visible = false;
                    txt_email.Text = email;
                    txt_pass.Text = pass;
                    txt_emailDK.Text = null;
                    txt_checkPass.Text = null;
                    txt_passDK.Text = null;
                    txt_tenDK.Text = null;
                }
               
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Email có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xemPassDN_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái UseSystemPasswordChar
            txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;
        }

        private void btn_xemPassDK_Click(object sender, EventArgs e)
        {
            txt_passDK.UseSystemPasswordChar = !txt_passDK.UseSystemPasswordChar;
        }

        private void btn_xemCheck_Click(object sender, EventArgs e)
        {
            txt_checkPass.UseSystemPasswordChar = !txt_checkPass.UseSystemPasswordChar;
        }
    }
}

