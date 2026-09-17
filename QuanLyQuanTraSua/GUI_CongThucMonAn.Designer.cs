namespace QuanLyQuanTraSua
{
    partial class GUI_CongThucMonAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_CongThucMonAn));
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cbbNguyenLieu = new System.Windows.Forms.ComboBox();
            this.cbbMonAn = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCongThuc = new System.Windows.Forms.DataGridView();
            this.IdMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNguyenLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguyenLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnResetCTMA = new System.Windows.Forms.Button();
            this.btnViewCTMA = new System.Windows.Forms.Button();
            this.btnSuaCTMA = new System.Windows.Forms.Button();
            this.btnXoaCTMA = new System.Windows.Forms.Button();
            this.btnAddCTMA = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(294, 523);
            this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(265, 22);
            this.txtDonViTinh.TabIndex = 21;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(294, 486);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(265, 22);
            this.txtSoLuong.TabIndex = 20;
            // 
            // cbbNguyenLieu
            // 
            this.cbbNguyenLieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNguyenLieu.Location = new System.Drawing.Point(294, 449);
            this.cbbNguyenLieu.Margin = new System.Windows.Forms.Padding(4);
            this.cbbNguyenLieu.Name = "cbbNguyenLieu";
            this.cbbNguyenLieu.Size = new System.Drawing.Size(265, 24);
            this.cbbNguyenLieu.TabIndex = 19;
            // 
            // cbbMonAn
            // 
            this.cbbMonAn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonAn.Location = new System.Drawing.Point(294, 412);
            this.cbbMonAn.Margin = new System.Windows.Forms.Padding(4);
            this.cbbMonAn.Name = "cbbMonAn";
            this.cbbMonAn.Size = new System.Drawing.Size(265, 24);
            this.cbbMonAn.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 523);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đơn Vị Tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 490);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Số Lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 451);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nguyên Liệu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 418);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Món Ăn:";
            // 
            // dgvCongThuc
            // 
            this.dgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongThuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMonAn,
            this.TenMonAn,
            this.IdNguyenLieu,
            this.TenNguyenLieu,
            this.SoLuong,
            this.DonViTinh});
            this.dgvCongThuc.Location = new System.Drawing.Point(3, 3);
            this.dgvCongThuc.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCongThuc.MultiSelect = false;
            this.dgvCongThuc.Name = "dgvCongThuc";
            this.dgvCongThuc.ReadOnly = true;
            this.dgvCongThuc.RowHeadersWidth = 51;
            this.dgvCongThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongThuc.Size = new System.Drawing.Size(1104, 382);
            this.dgvCongThuc.TabIndex = 13;
            this.dgvCongThuc.SelectionChanged += new System.EventHandler(this.dgvCongThuc_SelectionChanged);
            // 
            // IdMonAn
            // 
            this.IdMonAn.HeaderText = "ID Món Ăn";
            this.IdMonAn.MinimumWidth = 6;
            this.IdMonAn.Name = "IdMonAn";
            this.IdMonAn.ReadOnly = true;
            this.IdMonAn.Width = 90;
            // 
            // TenMonAn
            // 
            this.TenMonAn.HeaderText = "Tên Món Ăn";
            this.TenMonAn.MinimumWidth = 6;
            this.TenMonAn.Name = "TenMonAn";
            this.TenMonAn.ReadOnly = true;
            this.TenMonAn.Width = 185;
            // 
            // IdNguyenLieu
            // 
            this.IdNguyenLieu.HeaderText = "ID Nguyên Liệu";
            this.IdNguyenLieu.MinimumWidth = 6;
            this.IdNguyenLieu.Name = "IdNguyenLieu";
            this.IdNguyenLieu.ReadOnly = true;
            this.IdNguyenLieu.Width = 120;
            // 
            // TenNguyenLieu
            // 
            this.TenNguyenLieu.HeaderText = "Tên Nguyên Liệu";
            this.TenNguyenLieu.MinimumWidth = 6;
            this.TenNguyenLieu.Name = "TenNguyenLieu";
            this.TenNguyenLieu.ReadOnly = true;
            this.TenNguyenLieu.Width = 160;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 110;
            // 
            // DonViTinh
            // 
            this.DonViTinh.HeaderText = "Đơn Vị Tính";
            this.DonViTinh.MinimumWidth = 6;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            this.DonViTinh.Width = 110;
            // 
            // btnResetCTMA
            // 
            this.btnResetCTMA.BackColor = System.Drawing.Color.LightGray;
            this.btnResetCTMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCTMA.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_rotate_left_25;
            this.btnResetCTMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetCTMA.Location = new System.Drawing.Point(905, 449);
            this.btnResetCTMA.Name = "btnResetCTMA";
            this.btnResetCTMA.Size = new System.Drawing.Size(117, 48);
            this.btnResetCTMA.TabIndex = 26;
            this.btnResetCTMA.Text = "Làm mới";
            this.btnResetCTMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetCTMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetCTMA.UseVisualStyleBackColor = false;
            this.btnResetCTMA.Click += new System.EventHandler(this.btnResetCTMA_Click);
            // 
            // btnViewCTMA
            // 
            this.btnViewCTMA.BackColor = System.Drawing.Color.Tomato;
            this.btnViewCTMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCTMA.ForeColor = System.Drawing.Color.White;
            this.btnViewCTMA.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_view_25;
            this.btnViewCTMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewCTMA.Location = new System.Drawing.Point(626, 480);
            this.btnViewCTMA.Name = "btnViewCTMA";
            this.btnViewCTMA.Size = new System.Drawing.Size(106, 47);
            this.btnViewCTMA.TabIndex = 25;
            this.btnViewCTMA.Text = "Xem";
            this.btnViewCTMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewCTMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewCTMA.UseVisualStyleBackColor = false;
            this.btnViewCTMA.Click += new System.EventHandler(this.btnViewCTMA_Click);
            // 
            // btnSuaCTMA
            // 
            this.btnSuaCTMA.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSuaCTMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCTMA.ForeColor = System.Drawing.Color.White;
            this.btnSuaCTMA.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_update_3l0;
            this.btnSuaCTMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaCTMA.Location = new System.Drawing.Point(773, 427);
            this.btnSuaCTMA.Name = "btnSuaCTMA";
            this.btnSuaCTMA.Size = new System.Drawing.Size(106, 47);
            this.btnSuaCTMA.TabIndex = 22;
            this.btnSuaCTMA.Text = "Sửa";
            this.btnSuaCTMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaCTMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaCTMA.UseVisualStyleBackColor = false;
            this.btnSuaCTMA.Click += new System.EventHandler(this.btnSuaCTMA_Click);
            // 
            // btnXoaCTMA
            // 
            this.btnXoaCTMA.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXoaCTMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCTMA.ForeColor = System.Drawing.Color.White;
            this.btnXoaCTMA.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_delete_20;
            this.btnXoaCTMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaCTMA.Location = new System.Drawing.Point(773, 480);
            this.btnXoaCTMA.Name = "btnXoaCTMA";
            this.btnXoaCTMA.Size = new System.Drawing.Size(106, 51);
            this.btnXoaCTMA.TabIndex = 23;
            this.btnXoaCTMA.Text = "Xoá";
            this.btnXoaCTMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCTMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaCTMA.UseVisualStyleBackColor = false;
            this.btnXoaCTMA.Click += new System.EventHandler(this.btnXoaCTMA_Click);
            // 
            // btnAddCTMA
            // 
            this.btnAddCTMA.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddCTMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCTMA.ForeColor = System.Drawing.Color.White;
            this.btnAddCTMA.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_add_25;
            this.btnAddCTMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddCTMA.Location = new System.Drawing.Point(626, 427);
            this.btnAddCTMA.Name = "btnAddCTMA";
            this.btnAddCTMA.Size = new System.Drawing.Size(106, 47);
            this.btnAddCTMA.TabIndex = 24;
            this.btnAddCTMA.Text = "Thêm";
            this.btnAddCTMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCTMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCTMA.UseVisualStyleBackColor = false;
            this.btnAddCTMA.Click += new System.EventHandler(this.btnAddCTMA_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.SkyBlue;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Image = global::QuanLyQuanTraSua.Properties.Resources.icons8_redo_251;
            this.btnQuayLai.Location = new System.Drawing.Point(3, 555);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(139, 38);
            this.btnQuayLai.TabIndex = 27;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // GUI_CongThucMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1112, 594);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnResetCTMA);
            this.Controls.Add(this.btnViewCTMA);
            this.Controls.Add(this.btnSuaCTMA);
            this.Controls.Add(this.btnXoaCTMA);
            this.Controls.Add(this.btnAddCTMA);
            this.Controls.Add(this.txtDonViTinh);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cbbNguyenLieu);
            this.Controls.Add(this.cbbMonAn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCongThuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI_CongThucMonAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công Thức Món Ăn";
            this.Load += new System.EventHandler(this.GUI_CongThucMonAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongThuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cbbNguyenLieu;
        private System.Windows.Forms.ComboBox cbbMonAn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCongThuc;
        private System.Windows.Forms.Button btnResetCTMA;
        private System.Windows.Forms.Button btnViewCTMA;
        private System.Windows.Forms.Button btnSuaCTMA;
        private System.Windows.Forms.Button btnXoaCTMA;
        private System.Windows.Forms.Button btnAddCTMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.Button btnQuayLai;
    }
}