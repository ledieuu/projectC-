﻿namespace LapStore.Widget.User
{
    partial class donHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(donHang));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_huy = new Guna.UI2.WinForms.Guna2Button();
            this.btn_xemChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.madh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongthuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_trangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHienThi
            // 
            this.txtHienThi.AutoSize = true;
            this.txtHienThi.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.Location = new System.Drawing.Point(101, -88);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(132, 37);
            this.txtHienThi.TabIndex = 22;
            this.txtHienThi.Text = "Giỏ hàng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(237)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.btn_huy);
            this.panel1.Controls.Add(this.btn_xemChiTiet);
            this.panel1.Controls.Add(this.dgvDonHang);
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbb_trangThai);
            this.panel1.Location = new System.Drawing.Point(108, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 655);
            this.panel1.TabIndex = 21;
            // 
            // btn_huy
            // 
            this.btn_huy.Animated = true;
            this.btn_huy.BorderRadius = 10;
            this.btn_huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_huy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(199)))), ((int)(((byte)(198)))));
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(72)))), ((int)(((byte)(70)))));
            this.btn_huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_huy.Image")));
            this.btn_huy.Location = new System.Drawing.Point(734, 65);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(133, 36);
            this.btn_huy.TabIndex = 30;
            this.btn_huy.Text = "Hủy đơn hàng";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_xemChiTiet
            // 
            this.btn_xemChiTiet.Animated = true;
            this.btn_xemChiTiet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.btn_xemChiTiet.BorderRadius = 10;
            this.btn_xemChiTiet.BorderThickness = 1;
            this.btn_xemChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xemChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xemChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xemChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xemChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(252)))), ((int)(((byte)(213)))));
            this.btn_xemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xemChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            this.btn_xemChiTiet.Location = new System.Drawing.Point(873, 65);
            this.btn_xemChiTiet.Name = "btn_xemChiTiet";
            this.btn_xemChiTiet.Size = new System.Drawing.Size(104, 36);
            this.btn_xemChiTiet.TabIndex = 29;
            this.btn_xemChiTiet.Text = "Xem chi tiết";
            this.btn_xemChiTiet.Click += new System.EventHandler(this.btn_xemChiTiet_Click);
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToOrderColumns = true;
            this.dgvDonHang.AllowUserToResizeColumns = false;
            this.dgvDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDonHang.ColumnHeadersHeight = 30;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madh,
            this.sdt,
            this.diachi,
            this.tongtien,
            this.phuongthuc,
            this.trangthai,
            this.creatat});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonHang.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDonHang.GridColor = System.Drawing.Color.Black;
            this.dgvDonHang.Location = new System.Drawing.Point(13, 155);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersVisible = false;
            this.dgvDonHang.RowTemplate.Height = 80;
            this.dgvDonHang.Size = new System.Drawing.Size(964, 497);
            this.dgvDonHang.TabIndex = 28;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvDonHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvDonHang.ThemeStyle.ReadOnly = true;
            this.dgvDonHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvDonHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.RowsStyle.Height = 80;
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellClick);
            // 
            // madh
            // 
            this.madh.HeaderText = "Mã đơn hàng";
            this.madh.Name = "madh";
            this.madh.ReadOnly = true;
            // 
            // sdt
            // 
            this.sdt.HeaderText = "Số điện thoại";
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // diachi
            // 
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.Name = "diachi";
            this.diachi.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // phuongthuc
            // 
            this.phuongthuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.phuongthuc.HeaderText = "Phương thức thanh toán";
            this.phuongthuc.Name = "phuongthuc";
            this.phuongthuc.ReadOnly = true;
            this.phuongthuc.Width = 161;
            // 
            // trangthai
            // 
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            // 
            // creatat
            // 
            this.creatat.HeaderText = "Creat At";
            this.creatat.Name = "creatat";
            this.creatat.ReadOnly = true;
            // 
            // btnLoc
            // 
            this.btnLoc.Animated = true;
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(232)))), ((int)(((byte)(204)))));
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(174)))), ((int)(((byte)(110)))));
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.Location = new System.Drawing.Point(253, 65);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(104, 36);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Tìm";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(145)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(35, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng thái";
            // 
            // cbb_trangThai
            // 
            this.cbb_trangThai.BackColor = System.Drawing.Color.Transparent;
            this.cbb_trangThai.BorderRadius = 10;
            this.cbb_trangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_trangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_trangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_trangThai.ForeColor = System.Drawing.Color.Black;
            this.cbb_trangThai.ItemHeight = 30;
            this.cbb_trangThai.Location = new System.Drawing.Point(40, 65);
            this.cbb_trangThai.Name = "cbb_trangThai";
            this.cbb_trangThai.Size = new System.Drawing.Size(191, 36);
            this.cbb_trangThai.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(106)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(104, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 37);
            this.label1.TabIndex = 23;
            this.label1.Text = "Đơn hàng của tôi";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this.panel1;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 20;
            this.guna2Elipse2.TargetControl = this.dgvDonHang;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.panel1;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // donHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHienThi);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "donHang";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.donHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_trangThai;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Guna.UI2.WinForms.Guna2Button btn_xemChiTiet;
        private Guna.UI2.WinForms.Guna2Button btn_huy;
        private System.Windows.Forms.DataGridViewTextBoxColumn madh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongthuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatat;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
    }
}
