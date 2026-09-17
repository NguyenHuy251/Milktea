namespace QuanLyQuanTraSua
{
    partial class GUI_KhoNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_KhoNguyenLieu));
            this.dgvKhoNL = new System.Windows.Forms.DataGridView();
            this.IDNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnResetNL = new System.Windows.Forms.Button();
            this.btnTimNL = new System.Windows.Forms.Button();
            this.btnSuaNL = new System.Windows.Forms.Button();
            this.btnXoaNL = new System.Windows.Forms.Button();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.txtIDNguyenLieu = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.cbbTenNL = new System.Windows.Forms.ComboBox();
            this.label999 = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoNL)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel27.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhoNL
            // 
            this.dgvKhoNL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoNL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNL,
            this.TenNL,
            this.DVTinh,
            this.SLTon,
            this.GhiChu});
            this.dgvKhoNL.Location = new System.Drawing.Point(0, 1);
            this.dgvKhoNL.MultiSelect = false;
            this.dgvKhoNL.Name = "dgvKhoNL";
            this.dgvKhoNL.ReadOnly = true;
            this.dgvKhoNL.RowHeadersWidth = 51;
            this.dgvKhoNL.RowTemplate.Height = 24;
            this.dgvKhoNL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoNL.Size = new System.Drawing.Size(667, 533);
            this.dgvKhoNL.TabIndex = 0;
            this.dgvKhoNL.SelectionChanged += new System.EventHandler(this.dgvKhoNL_SelectionChanged);
            // 
            // IDNL
            // 
            this.IDNL.HeaderText = "ID";
            this.IDNL.MinimumWidth = 6;
            this.IDNL.Name = "IDNL";
            this.IDNL.ReadOnly = true;
            this.IDNL.Width = 30;
            // 
            // TenNL
            // 
            this.TenNL.HeaderText = "Tên Nguyên Liệu";
            this.TenNL.MinimumWidth = 6;
            this.TenNL.Name = "TenNL";
            this.TenNL.ReadOnly = true;
            this.TenNL.Width = 135;
            // 
            // DVTinh
            // 
            this.DVTinh.HeaderText = "Đơn Vị Tính";
            this.DVTinh.MinimumWidth = 6;
            this.DVTinh.Name = "DVTinh";
            this.DVTinh.ReadOnly = true;
            this.DVTinh.Width = 80;
            // 
            // SLTon
            // 
            this.SLTon.HeaderText = "Số Lượng Tồn";
            this.SLTon.MinimumWidth = 6;
            this.SLTon.Name = "SLTon";
            this.SLTon.ReadOnly = true;
            this.SLTon.Width = 90;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 125;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnResetNL);
            this.panel13.Controls.Add(this.btnTimNL);
            this.panel13.Controls.Add(this.btnSuaNL);
            this.panel13.Controls.Add(this.btnXoaNL);
            this.panel13.Controls.Add(this.panel20);
            this.panel13.Controls.Add(this.panel21);
            this.panel13.Controls.Add(this.panel24);
            this.panel13.Controls.Add(this.panel28);
            this.panel13.Controls.Add(this.panel27);
            this.panel13.Location = new System.Drawing.Point(673, 12);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(415, 454);
            this.panel13.TabIndex = 6;
            // 
            // btnResetNL
            // 
            this.btnResetNL.BackColor = System.Drawing.Color.LightGray;
            this.btnResetNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetNL.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_rotate_left_25;
            this.btnResetNL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetNL.Location = new System.Drawing.Point(246, 381);
            this.btnResetNL.Name = "btnResetNL";
            this.btnResetNL.Size = new System.Drawing.Size(106, 45);
            this.btnResetNL.TabIndex = 12;
            this.btnResetNL.Text = "Làm mới";
            this.btnResetNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetNL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetNL.UseVisualStyleBackColor = false;
            this.btnResetNL.Click += new System.EventHandler(this.btnResetNL_Click);
            // 
            // btnTimNL
            // 
            this.btnTimNL.BackColor = System.Drawing.Color.Tomato;
            this.btnTimNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimNL.ForeColor = System.Drawing.Color.White;
            this.btnTimNL.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_view_25;
            this.btnTimNL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimNL.Location = new System.Drawing.Point(72, 328);
            this.btnTimNL.Name = "btnTimNL";
            this.btnTimNL.Size = new System.Drawing.Size(106, 47);
            this.btnTimNL.TabIndex = 11;
            this.btnTimNL.Text = "Tìm kiếm";
            this.btnTimNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimNL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimNL.UseVisualStyleBackColor = false;
            this.btnTimNL.Click += new System.EventHandler(this.btnTimNL_Click);
            // 
            // btnSuaNL
            // 
            this.btnSuaNL.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSuaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaNL.ForeColor = System.Drawing.Color.White;
            this.btnSuaNL.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_update_3l0;
            this.btnSuaNL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaNL.Location = new System.Drawing.Point(246, 328);
            this.btnSuaNL.Name = "btnSuaNL";
            this.btnSuaNL.Size = new System.Drawing.Size(106, 47);
            this.btnSuaNL.TabIndex = 8;
            this.btnSuaNL.Text = "Sửa";
            this.btnSuaNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaNL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaNL.UseVisualStyleBackColor = false;
            this.btnSuaNL.Click += new System.EventHandler(this.btnSuaNL_Click);
            // 
            // btnXoaNL
            // 
            this.btnXoaNL.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXoaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNL.ForeColor = System.Drawing.Color.White;
            this.btnXoaNL.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_delete_20;
            this.btnXoaNL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNL.Location = new System.Drawing.Point(72, 381);
            this.btnXoaNL.Name = "btnXoaNL";
            this.btnXoaNL.Size = new System.Drawing.Size(106, 45);
            this.btnXoaNL.TabIndex = 9;
            this.btnXoaNL.Text = "Xoá";
            this.btnXoaNL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaNL.UseVisualStyleBackColor = false;
            this.btnXoaNL.Click += new System.EventHandler(this.btnXoaNL_Click);
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.txtGhiChu);
            this.panel20.Controls.Add(this.label25);
            this.panel20.Location = new System.Drawing.Point(3, 220);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(396, 82);
            this.panel20.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(174, 12);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(217, 58);
            this.txtGhiChu.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(65, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "Ghi chú:";
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.txtSoLuongTon);
            this.panel21.Controls.Add(this.label26);
            this.panel21.Location = new System.Drawing.Point(3, 166);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(393, 48);
            this.panel21.TabIndex = 1;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(174, 12);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(214, 22);
            this.txtSoLuongTon.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(14, 12);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(142, 24);
            this.label26.TabIndex = 0;
            this.label26.Text = "Số lượng tồn:";
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.label27);
            this.panel24.Controls.Add(this.txtDonViTinh);
            this.panel24.Location = new System.Drawing.Point(3, 116);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(393, 48);
            this.panel24.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(34, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(122, 24);
            this.label27.TabIndex = 0;
            this.label27.Text = "Đơn vị tính:";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(174, 11);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(214, 22);
            this.txtDonViTinh.TabIndex = 2;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.txtIDNguyenLieu);
            this.panel28.Controls.Add(this.label29);
            this.panel28.Location = new System.Drawing.Point(3, 12);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(391, 48);
            this.panel28.TabIndex = 1;
            this.panel28.Visible = false;
            // 
            // txtIDNguyenLieu
            // 
            this.txtIDNguyenLieu.Location = new System.Drawing.Point(170, 12);
            this.txtIDNguyenLieu.Name = "txtIDNguyenLieu";
            this.txtIDNguyenLieu.ReadOnly = true;
            this.txtIDNguyenLieu.Size = new System.Drawing.Size(214, 22);
            this.txtIDNguyenLieu.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(122, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(36, 24);
            this.label29.TabIndex = 0;
            this.label29.Text = "ID:";
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.cbbTenNL);
            this.panel27.Controls.Add(this.label999);
            this.panel27.Location = new System.Drawing.Point(3, 62);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(396, 48);
            this.panel27.TabIndex = 1;
            // 
            // cbbTenNL
            // 
            this.cbbTenNL.FormattingEnabled = true;
            this.cbbTenNL.Items.AddRange(new object[] {
            "Nhân viên",
            "Quản lý"});
            this.cbbTenNL.Location = new System.Drawing.Point(174, 10);
            this.cbbTenNL.Name = "cbbTenNL";
            this.cbbTenNL.Size = new System.Drawing.Size(214, 24);
            this.cbbTenNL.TabIndex = 1;
            // 
            // label999
            // 
            this.label999.AutoSize = true;
            this.label999.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label999.Location = new System.Drawing.Point(0, 10);
            this.label999.Name = "label999";
            this.label999.Size = new System.Drawing.Size(168, 24);
            this.label999.TabIndex = 0;
            this.label999.Text = "Tên nguyên liệu:";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_redo_251;
            this.btnQuayLai.Location = new System.Drawing.Point(12, 540);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(122, 38);
            this.btnQuayLai.TabIndex = 7;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // GUI_KhoNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1093, 584);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.dgvKhoNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUI_KhoNguyenLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho Nguyên liệu";
            this.Load += new System.EventHandler(this.GUI_KhoNguyenLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoNL)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhoNL;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnResetNL;
        private System.Windows.Forms.Button btnTimNL;
        private System.Windows.Forms.Button btnSuaNL;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.ComboBox cbbTenNL;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.TextBox txtIDNguyenLieu;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Label label999;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button btnQuayLai;
    }
}