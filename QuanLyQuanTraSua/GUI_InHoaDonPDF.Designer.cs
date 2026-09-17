namespace QuanLyQuanTraSua
{
    partial class GUI_InHoaDonPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_InHoaDonPDF));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHoaDonBan = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBaoCaoDoanhThu = new System.Windows.Forms.DataGridView();
            this.btnExportHoaDonBanPDF = new System.Windows.Forms.Button();
            this.btnExportHoaDonNhapPDF = new System.Windows.Forms.Button();
            this.btnExportBaoCaoDoanhThuPDF = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hóa Đơn Bán";
            // 
            // dgvHoaDonBan
            // 
            this.dgvHoaDonBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonBan.ColumnHeadersHeight = 29;
            this.dgvHoaDonBan.Location = new System.Drawing.Point(12, 26);
            this.dgvHoaDonBan.MultiSelect = false;
            this.dgvHoaDonBan.Name = "dgvHoaDonBan";
            this.dgvHoaDonBan.RowHeadersWidth = 51;
            this.dgvHoaDonBan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonBan.Size = new System.Drawing.Size(1195, 205);
            this.dgvHoaDonBan.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hóa Đơn Nhập";
            // 
            // dgvHoaDonNhap
            // 
            this.dgvHoaDonNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonNhap.ColumnHeadersHeight = 29;
            this.dgvHoaDonNhap.Location = new System.Drawing.Point(12, 268);
            this.dgvHoaDonNhap.MultiSelect = false;
            this.dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            this.dgvHoaDonNhap.RowHeadersWidth = 51;
            this.dgvHoaDonNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonNhap.Size = new System.Drawing.Size(1195, 205);
            this.dgvHoaDonNhap.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Báo Cáo Doanh Thu";
            // 
            // dgvBaoCaoDoanhThu
            // 
            this.dgvBaoCaoDoanhThu.ColumnHeadersHeight = 29;
            this.dgvBaoCaoDoanhThu.Location = new System.Drawing.Point(12, 504);
            this.dgvBaoCaoDoanhThu.MultiSelect = false;
            this.dgvBaoCaoDoanhThu.Name = "dgvBaoCaoDoanhThu";
            this.dgvBaoCaoDoanhThu.RowHeadersWidth = 51;
            this.dgvBaoCaoDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoDoanhThu.Size = new System.Drawing.Size(1195, 205);
            this.dgvBaoCaoDoanhThu.TabIndex = 16;
            // 
            // btnExportHoaDonBanPDF
            // 
            this.btnExportHoaDonBanPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportHoaDonBanPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportHoaDonBanPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportHoaDonBanPDF.Image")));
            this.btnExportHoaDonBanPDF.Location = new System.Drawing.Point(1227, 26);
            this.btnExportHoaDonBanPDF.Name = "btnExportHoaDonBanPDF";
            this.btnExportHoaDonBanPDF.Size = new System.Drawing.Size(136, 58);
            this.btnExportHoaDonBanPDF.TabIndex = 11;
            this.btnExportHoaDonBanPDF.Text = "Xuất PDF";
            this.btnExportHoaDonBanPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportHoaDonBanPDF.Click += new System.EventHandler(this.btnExportHoaDonBanPDF_Click);
            // 
            // btnExportHoaDonNhapPDF
            // 
            this.btnExportHoaDonNhapPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportHoaDonNhapPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportHoaDonNhapPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportHoaDonNhapPDF.Image")));
            this.btnExportHoaDonNhapPDF.Location = new System.Drawing.Point(1227, 268);
            this.btnExportHoaDonNhapPDF.Name = "btnExportHoaDonNhapPDF";
            this.btnExportHoaDonNhapPDF.Size = new System.Drawing.Size(136, 58);
            this.btnExportHoaDonNhapPDF.TabIndex = 14;
            this.btnExportHoaDonNhapPDF.Text = "Xuất PDF";
            this.btnExportHoaDonNhapPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportHoaDonNhapPDF.Click += new System.EventHandler(this.btnExportHoaDonNhapPDF_Click);
            // 
            // btnExportBaoCaoDoanhThuPDF
            // 
            this.btnExportBaoCaoDoanhThuPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportBaoCaoDoanhThuPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportBaoCaoDoanhThuPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportBaoCaoDoanhThuPDF.Image")));
            this.btnExportBaoCaoDoanhThuPDF.Location = new System.Drawing.Point(1227, 504);
            this.btnExportBaoCaoDoanhThuPDF.Name = "btnExportBaoCaoDoanhThuPDF";
            this.btnExportBaoCaoDoanhThuPDF.Size = new System.Drawing.Size(136, 58);
            this.btnExportBaoCaoDoanhThuPDF.TabIndex = 17;
            this.btnExportBaoCaoDoanhThuPDF.Text = "Xuất PDF";
            this.btnExportBaoCaoDoanhThuPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportBaoCaoDoanhThuPDF.Click += new System.EventHandler(this.btnExportBaoCaoDoanhThuPDF_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_redo_251;
            this.btnQuayLai.Location = new System.Drawing.Point(2, 730);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(126, 38);
            this.btnQuayLai.TabIndex = 18;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // GUI_InHoaDonPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1423, 770);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDonBan);
            this.Controls.Add(this.btnExportHoaDonBanPDF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHoaDonNhap);
            this.Controls.Add(this.btnExportHoaDonNhapPDF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvBaoCaoDoanhThu);
            this.Controls.Add(this.btnExportBaoCaoDoanhThuPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUI_InHoaDonPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Hoá Đơn";
            this.Load += new System.EventHandler(this.GUI_InHoaDonPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHoaDonBan;
        private System.Windows.Forms.Button btnExportHoaDonBanPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoaDonNhap;
        private System.Windows.Forms.Button btnExportHoaDonNhapPDF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvBaoCaoDoanhThu;
        private System.Windows.Forms.Button btnExportBaoCaoDoanhThuPDF;
        private System.Windows.Forms.Button btnQuayLai;
    }
}