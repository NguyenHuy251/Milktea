namespace QuanLyQuanTraSua
{
    partial class GUI_BaoCaoDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_BaoCaoDoanhThu));
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoHoaDonBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoHoaDonNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDoanhThuBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongChiPhiNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnXoaBaoCao = new System.Windows.Forms.Button();
            this.btnThemBaoCao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TongDoanhThu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongChiPhiNhao1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDoanhThuBan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoHoaDonNhap1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoDonBan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenNgay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TuNgay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBaoCaoHienTai = new System.Windows.Forms.DataGridView();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHienTai)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 18);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tất cả báo cáo doanh thu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-273, 481);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "Ghi chú:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Từ ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Ghi chú:";
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeight = 29;
            this.dgvBaoCao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TuNgay,
            this.DenNgay,
            this.TongSoHoaDonBan,
            this.TongSoHoaDonNhap,
            this.TongDoanhThuBan,
            this.TongChiPhiNhap,
            this.TongDoanhThu,
            this.TenNhanVien,
            this.NgayTao,
            this.GhiChu});
            this.dgvBaoCao.Location = new System.Drawing.Point(16, 23);
            this.dgvBaoCao.MultiSelect = false;
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(1309, 274);
            this.dgvBaoCao.TabIndex = 30;
            // 
            // ID
            // 
            this.ID.FillWeight = 9.061184F;
            this.ID.HeaderText = "ID ";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // TuNgay
            // 
            this.TuNgay.FillWeight = 51.36942F;
            this.TuNgay.HeaderText = "Từ ngày";
            this.TuNgay.MinimumWidth = 6;
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Width = 80;
            // 
            // DenNgay
            // 
            this.DenNgay.FillWeight = 711.23F;
            this.DenNgay.HeaderText = "Đến ngày";
            this.DenNgay.MinimumWidth = 6;
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Width = 80;
            // 
            // TongSoHoaDonBan
            // 
            this.TongSoHoaDonBan.FillWeight = 218.2428F;
            this.TongSoHoaDonBan.HeaderText = "Số HĐ Bán";
            this.TongSoHoaDonBan.MinimumWidth = 6;
            this.TongSoHoaDonBan.Name = "TongSoHoaDonBan";
            this.TongSoHoaDonBan.Width = 80;
            // 
            // TongSoHoaDonNhap
            // 
            this.TongSoHoaDonNhap.FillWeight = 1.682791F;
            this.TongSoHoaDonNhap.HeaderText = "Số HĐ Nhập";
            this.TongSoHoaDonNhap.MinimumWidth = 6;
            this.TongSoHoaDonNhap.Name = "TongSoHoaDonNhap";
            this.TongSoHoaDonNhap.Width = 80;
            // 
            // TongDoanhThuBan
            // 
            this.TongDoanhThuBan.FillWeight = 1.682791F;
            this.TongDoanhThuBan.HeaderText = "Doanh Thu Bán";
            this.TongDoanhThuBan.MinimumWidth = 6;
            this.TongDoanhThuBan.Name = "TongDoanhThuBan";
            this.TongDoanhThuBan.Width = 90;
            // 
            // TongChiPhiNhap
            // 
            this.TongChiPhiNhap.FillWeight = 1.682791F;
            this.TongChiPhiNhap.HeaderText = "Chi Phí Nhập";
            this.TongChiPhiNhap.MinimumWidth = 6;
            this.TongChiPhiNhap.Name = "TongChiPhiNhap";
            this.TongChiPhiNhap.Width = 90;
            // 
            // TongDoanhThu
            // 
            this.TongDoanhThu.FillWeight = 1.682791F;
            this.TongDoanhThu.HeaderText = "Tổng Doanh Thu";
            this.TongDoanhThu.MinimumWidth = 6;
            this.TongDoanhThu.Name = "TongDoanhThu";
            this.TongDoanhThu.Width = 110;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.HeaderText = "Nhân Viên Tạo Báo Cáo";
            this.TenNhanVien.MinimumWidth = 6;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.Width = 135;
            // 
            // NgayTao
            // 
            this.NgayTao.FillWeight = 1.682791F;
            this.NgayTao.HeaderText = "Ngày Tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 80;
            // 
            // GhiChu
            // 
            this.GhiChu.FillWeight = 1.682791F;
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 130;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(78, 484);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 22);
            this.dtpTuNgay.TabIndex = 31;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(343, 484);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 22);
            this.dtpDenNgay.TabIndex = 32;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(598, 484);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(220, 67);
            this.txtGhiChu.TabIndex = 33;
            // 
            // btnXoaBaoCao
            // 
            this.btnXoaBaoCao.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnXoaBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXoaBaoCao.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_delete_view_301;
            this.btnXoaBaoCao.Location = new System.Drawing.Point(928, 551);
            this.btnXoaBaoCao.Name = "btnXoaBaoCao";
            this.btnXoaBaoCao.Size = new System.Drawing.Size(168, 64);
            this.btnXoaBaoCao.TabIndex = 45;
            this.btnXoaBaoCao.Text = "Xoá Báo Cáo";
            this.btnXoaBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaBaoCao.UseVisualStyleBackColor = false;
            this.btnXoaBaoCao.Click += new System.EventHandler(this.btnXoaBaoCao_Click);
            // 
            // btnThemBaoCao
            // 
            this.btnThemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnThemBaoCao.Image = global::QuanLyQuanTraSua.Properties.Resources.addFood2;
            this.btnThemBaoCao.Location = new System.Drawing.Point(1122, 481);
            this.btnThemBaoCao.Name = "btnThemBaoCao";
            this.btnThemBaoCao.Size = new System.Drawing.Size(160, 64);
            this.btnThemBaoCao.TabIndex = 34;
            this.btnThemBaoCao.Text = "Thêm Báo Cáo";
            this.btnThemBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemBaoCao.Click += new System.EventHandler(this.btnThemBaoCao_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_accounting_481;
            this.btnThongKe.Location = new System.Drawing.Point(928, 481);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(168, 64);
            this.btnThongKe.TabIndex = 35;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_rotate_left_251;
            this.btnReset.Location = new System.Drawing.Point(1122, 551);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(160, 64);
            this.btnReset.TabIndex = 36;
            this.btnReset.Text = "Làm mới";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Báo cáo hiện tại:";
            // 
            // TongDoanhThu1
            // 
            this.TongDoanhThu1.HeaderText = "Tổng Doanh Thu";
            this.TongDoanhThu1.MinimumWidth = 6;
            this.TongDoanhThu1.Name = "TongDoanhThu1";
            // 
            // TongChiPhiNhao1
            // 
            this.TongChiPhiNhao1.HeaderText = "Chi Phí Nhập";
            this.TongChiPhiNhao1.MinimumWidth = 6;
            this.TongChiPhiNhao1.Name = "TongChiPhiNhao1";
            // 
            // TongDoanhThuBan1
            // 
            this.TongDoanhThuBan1.HeaderText = "Doanh Thu Bán";
            this.TongDoanhThuBan1.MinimumWidth = 6;
            this.TongDoanhThuBan1.Name = "TongDoanhThuBan1";
            // 
            // TongSoHoaDonNhap1
            // 
            this.TongSoHoaDonNhap1.HeaderText = "Số HĐ Nhập";
            this.TongSoHoaDonNhap1.MinimumWidth = 6;
            this.TongSoHoaDonNhap1.Name = "TongSoHoaDonNhap1";
            // 
            // TongSoDonBan1
            // 
            this.TongSoDonBan1.HeaderText = "Số HĐ Bán ";
            this.TongSoDonBan1.MinimumWidth = 6;
            this.TongSoDonBan1.Name = "TongSoDonBan1";
            // 
            // DenNgay1
            // 
            this.DenNgay1.HeaderText = "Đến ngày";
            this.DenNgay1.MinimumWidth = 6;
            this.DenNgay1.Name = "DenNgay1";
            // 
            // TuNgay1
            // 
            this.TuNgay1.HeaderText = "Từ ngày";
            this.TuNgay1.MinimumWidth = 6;
            this.TuNgay1.Name = "TuNgay1";
            // 
            // dgvBaoCaoHienTai
            // 
            this.dgvBaoCaoHienTai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoHienTai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoHienTai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TuNgay1,
            this.DenNgay1,
            this.TongSoDonBan1,
            this.TongSoHoaDonNhap1,
            this.TongDoanhThuBan1,
            this.TongChiPhiNhao1,
            this.TongDoanhThu1});
            this.dgvBaoCaoHienTai.Location = new System.Drawing.Point(16, 323);
            this.dgvBaoCaoHienTai.Name = "dgvBaoCaoHienTai";
            this.dgvBaoCaoHienTai.RowHeadersWidth = 51;
            this.dgvBaoCaoHienTai.RowTemplate.Height = 24;
            this.dgvBaoCaoHienTai.Size = new System.Drawing.Size(1309, 136);
            this.dgvBaoCaoHienTai.TabIndex = 44;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_redo_251;
            this.btnQuayLai.Location = new System.Drawing.Point(3, 597);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(126, 38);
            this.btnQuayLai.TabIndex = 46;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // GUI_BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1337, 637);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnXoaBaoCao);
            this.Controls.Add(this.dgvBaoCaoHienTai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnThemBaoCao);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI_BaoCaoDoanhThu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Doanh Thu";
            this.Load += new System.EventHandler(this.GUI_BaoCaoDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHienTai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoaBaoCao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoHoaDonBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoHoaDonNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDoanhThuBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongChiPhiNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDoanhThu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongChiPhiNhao1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDoanhThuBan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoHoaDonNhap1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoDonBan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenNgay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TuNgay1;
        private System.Windows.Forms.DataGridView dgvBaoCaoHienTai;
        private System.Windows.Forms.Button btnQuayLai;
    }
}