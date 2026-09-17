using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using QuanLyQuanTraSua.Resources;

namespace QuanLyQuanTraSua
{
    public partial class GUI_GiaoDien : Form
    {

        public GUI_GiaoDien()
        {
            InitializeComponent();
        }

        private void PhanQuyen()
        {
            adminToolStripMenuItem.Enabled = (CurrentUser.LoaiTK == 1);
        }

        private void GUI_GiaoDien_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_Admin f = new GUI_Admin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void GUI_GiaoDien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void thongTinTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_thongTinTK f = new GUI_thongTinTK();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentUser.ClearUser();
            Application.Exit();

            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void bànToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_xuLyBan f = new GUI_xuLyBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void khoNguyênLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_KhoNguyenLieu f = new GUI_KhoNguyenLieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void nhậpNguyênLiệuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI_NhapNguyenLieu f = new GUI_NhapNguyenLieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void côngThứcMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_CongThucMonAn f = new GUI_CongThucMonAn();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_BaoCaoDoanhThu f = new GUI_BaoCaoDoanhThu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void inHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI_InHoaDonPDF f = new GUI_InHoaDonPDF();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
