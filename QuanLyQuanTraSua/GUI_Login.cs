using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using QuanLyQuanTraSua.Resources; 



namespace QuanLyQuanTraSua
{
    public partial class GUI_Login : Form
    {
        BUS_Login bus_Login = new BUS_Login();

        public GUI_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUserName.Text;
            string matKhau = txtPassWord.Text;

            DTO_Login taiKhoan = bus_Login.KiemTraDangNhap(tenDangNhap, matKhau);

            if (taiKhoan != null)
            {
                CurrentUser.SetUser(taiKhoan);

                string tenHienThi = taiKhoan.TenHienThi; 
                if (string.IsNullOrEmpty(tenHienThi))
                {
                    tenHienThi = tenDangNhap;
                }
                MessageBox.Show($"Đăng nhập thành công!\nXin chào {tenHienThi}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GUI_GiaoDien f = new GUI_GiaoDien();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }

        }

       

        private void GUI_Login_Load(object sender, EventArgs e)
        {

        }

        private void viewpass_CheckedChanged(object sender, EventArgs e)
        {
            if (viewpass.Checked)
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản lí (admin) để được cấp lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
