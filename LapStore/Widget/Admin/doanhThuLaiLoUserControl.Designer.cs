﻿namespace LapStore.Widget
{
    partial class doanhThuLaiLoUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(doanhThuLaiLoUserControl));
            this.label8 = new System.Windows.Forms.Label();
            this.loinhuan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.tongban = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tongvon = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_xuat = new Guna.UI2.WinForms.Guna2Button();
            this.TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienVon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoiNhuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.label8.Location = new System.Drawing.Point(50, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(342, 17);
            this.label8.TabIndex = 70;
            this.label8.Text = "Nhập tên/mã khách hàng để kiểm tra doanh thu lãi lỗ";
            // 
            // loinhuan
            // 
            this.loinhuan.AutoSize = true;
            this.loinhuan.BackColor = System.Drawing.Color.Transparent;
            this.loinhuan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loinhuan.ForeColor = System.Drawing.Color.White;
            this.loinhuan.Location = new System.Drawing.Point(786, 451);
            this.loinhuan.Name = "loinhuan";
            this.loinhuan.Size = new System.Drawing.Size(61, 17);
            this.loinhuan.TabIndex = 60;
            this.loinhuan.Text = "2000.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(660, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "TỔNG LỢI NHUẬN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(106)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(210, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 37);
            this.label1.TabIndex = 68;
            this.label1.Text = "Thống kê doanh thu lãi lỗ trên từng đơn hàng";
            // 
            // dgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 35;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TT,
            this.MaHoaDon,
            this.TenKhachHang,
            this.TienVon,
            this.TienBan,
            this.LoiNhuon});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(16, 51);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(865, 381);
            this.dgv.TabIndex = 0;
            this.dgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv.ThemeStyle.HeaderStyle.Height = 35;
            this.dgv.ThemeStyle.ReadOnly = false;
            this.dgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv.ThemeStyle.RowsStyle.Height = 22;
            this.dgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this.dgv;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "BẢNG THỐNG KÊ DOANH THU LỖ LÃI THEO ĐƠN HÀNG";
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderRadius = 25;
            this.guna2GradientPanel1.Controls.Add(this.tongban);
            this.guna2GradientPanel1.Controls.Add(this.label9);
            this.guna2GradientPanel1.Controls.Add(this.tongvon);
            this.guna2GradientPanel1.Controls.Add(this.label5);
            this.guna2GradientPanel1.Controls.Add(this.loinhuan);
            this.guna2GradientPanel1.Controls.Add(this.label3);
            this.guna2GradientPanel1.Controls.Add(this.label4);
            this.guna2GradientPanel1.Controls.Add(this.dgv);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(37, 238);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(897, 490);
            this.guna2GradientPanel1.TabIndex = 69;
            // 
            // tongban
            // 
            this.tongban.AutoSize = true;
            this.tongban.BackColor = System.Drawing.Color.Transparent;
            this.tongban.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongban.ForeColor = System.Drawing.Color.White;
            this.tongban.Location = new System.Drawing.Point(472, 451);
            this.tongban.Name = "tongban";
            this.tongban.Size = new System.Drawing.Size(61, 17);
            this.tongban.TabIndex = 64;
            this.tongban.Text = "2000.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(346, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 63;
            this.label9.Text = "TỔNG TIỀN BÁN:";
            // 
            // tongvon
            // 
            this.tongvon.AutoSize = true;
            this.tongvon.BackColor = System.Drawing.Color.Transparent;
            this.tongvon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongvon.ForeColor = System.Drawing.Color.White;
            this.tongvon.Location = new System.Drawing.Point(101, 451);
            this.tongvon.Name = "tongvon";
            this.tongvon.Size = new System.Drawing.Size(61, 17);
            this.tongvon.TabIndex = 62;
            this.tongvon.Text = "2000.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 61;
            this.label5.Text = "TỔNG VỐN:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.BorderThickness = 0;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(237)))), ((int)(((byte)(235)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(53, 144);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Nhập thông tin tìm kiếm...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(338, 36);
            this.txtSearch.TabIndex = 72;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btn_xuat
            // 
            this.btn_xuat.BorderRadius = 15;
            this.btn_xuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(252)))), ((int)(((byte)(213)))));
            this.btn_xuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.btn_xuat.Location = new System.Drawing.Point(790, 188);
            this.btn_xuat.Name = "btn_xuat";
            this.btn_xuat.Size = new System.Drawing.Size(128, 25);
            this.btn_xuat.TabIndex = 73;
            this.btn_xuat.Text = "Xuất excel";
            this.btn_xuat.Click += new System.EventHandler(this.btn_xuat_Click);
            // 
            // TT
            // 
            this.TT.HeaderText = "TT";
            this.TT.Name = "TT";
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.HeaderText = "Mã Hoá Đơn";
            this.MaHoaDon.Name = "MaHoaDon";
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            // 
            // TienVon
            // 
            this.TienVon.HeaderText = "Tiền Vốn";
            this.TienVon.Name = "TienVon";
            // 
            // TienBan
            // 
            this.TienBan.HeaderText = "Tiền Bán";
            this.TienBan.Name = "TienBan";
            // 
            // LoiNhuon
            // 
            this.LoiNhuon.HeaderText = "Lợi Nhuận";
            this.LoiNhuon.Name = "LoiNhuon";
            // 
            // doanhThuLaiLoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_xuat);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2GradientPanel1);
            this.MaximumSize = new System.Drawing.Size(970, 750);
            this.MinimumSize = new System.Drawing.Size(970, 750);
            this.Name = "doanhThuLaiLoUserControl";
            this.Size = new System.Drawing.Size(970, 750);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label loinhuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label tongban;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label tongvon;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btn_xuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienVon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoiNhuon;
    }
}
