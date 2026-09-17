namespace QuanLyQuanTraSua
{
    partial class GUI_InHoaDonNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_InHoaDonNhap));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblIdHoaDon = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Location = new System.Drawing.Point(16, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÓA ĐƠN NHẬP";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblNgay.Location = new System.Drawing.Point(667, 11);
            this.lblNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(50, 18);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày: ";
            this.lblNgay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIdHoaDon
            // 
            this.lblIdHoaDon.AutoSize = true;
            this.lblIdHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdHoaDon.Location = new System.Drawing.Point(16, 62);
            this.lblIdHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdHoaDon.Name = "lblIdHoaDon";
            this.lblIdHoaDon.Size = new System.Drawing.Size(150, 18);
            this.lblIdHoaDon.TabIndex = 2;
            this.lblIdHoaDon.Text = "ID Hóa Đơn Nhập: ";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(16, 92);
            this.lblNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(100, 16);
            this.lblNhaCungCap.TabIndex = 3;
            this.lblNhaCungCap.Text = "Nhà Cung Cấp: ";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(400, 62);
            this.lblNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(111, 16);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân Viên Nhập: ";
            // 
            // dgvNguyenLieu
            // 
            this.dgvNguyenLieu.AllowUserToAddRows = false;
            this.dgvNguyenLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenLieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguyenLieu.ColumnHeadersHeight = 29;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(16, 135);
            this.dgvNguyenLieu.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.ReadOnly = true;
            this.dgvNguyenLieu.RowHeadersWidth = 51;
            this.dgvNguyenLieu.Size = new System.Drawing.Size(880, 431);
            this.dgvNguyenLieu.TabIndex = 5;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(16, 578);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(93, 18);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "Tổng Tiền: ";
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnInHoaDon.Location = new System.Drawing.Point(0, 603);
            this.btnInHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(912, 49);
            this.btnInHoaDon.TabIndex = 7;
            this.btnInHoaDon.Text = "In Hóa Đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // GUI_InHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 652);
            this.Controls.Add(this.btnInHoaDon);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvNguyenLieu);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.lblIdHoaDon);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_InHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem Trước Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.GUI_InHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblIdHoaDon;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnInHoaDon;
    }
}