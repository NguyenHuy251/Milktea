using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanTraSua
{
    public partial class GUI_thongTinTK : Form
    {
        BUS_Account bus_Account = new BUS_Account();

        public GUI_thongTinTK()
        {
            InitializeComponent();
        }

        private void GUI_thongTinTK_Load(object sender, EventArgs e)
        {
            txtDisplayName.Enabled = false;
            txtNewPassWord.Enabled = false;
            txtReEnterPass.Enabled = false;

            rdoAll.Checked = false;
        }

        private void rdoMK_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdoMK.Checked)
            {
                txtNewPassWord.Enabled = true;
                txtReEnterPass.Enabled = true;

                txtDisplayName.Enabled = false;
            }
        }

        private void rdoTHT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTHT.Checked)
            {
                txtDisplayName.Enabled = true;

                txtNewPassWord.Enabled = false;
                txtReEnterPass.Enabled = false;
            }
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
            {
                txtDisplayName.Enabled = true;
                txtNewPassWord.Enabled = true;
                txtReEnterPass.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!rdoMK.Checked && !rdoTHT.Checked && !rdoAll.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại cập nhật (Mật khẩu, Tên hiển thị, hoặc Tất cả).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Vui lòng điền Tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DTO_Account taiKhoan = bus_Account.LayTaiKhoanTheoUserName(txtUserName.Text);
            if (taiKhoan == null)
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (taiKhoan.MatKhau != txtPassWord.Text)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rdoTHT.Checked || rdoAll.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
                {
                    MessageBox.Show("Vui lòng điền Tên hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string newPassWord = txtNewPassWord.Text;
            string reEnterPass = txtReEnterPass.Text;

            if (rdoMK.Checked || rdoAll.Checked)
            {
                if (string.IsNullOrWhiteSpace(newPassWord) || string.IsNullOrWhiteSpace(reEnterPass))
                {
                    MessageBox.Show("Vui lòng nhập Mật khẩu mới và Xác nhận mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPassWord != reEnterPass)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (rdoTHT.Checked || rdoAll.Checked)
            {
                taiKhoan.TenHienThi = txtDisplayName.Text; 
            }

            if (rdoMK.Checked || rdoAll.Checked)
            {
                taiKhoan.MatKhau = newPassWord; 
            }

            
            bool result = bus_Account.CapNhatTaiKhoan(taiKhoan);
            if (result)
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Clear();
                txtDisplayName.Clear();
                txtPassWord.Clear();
                txtNewPassWord.Clear();
                txtReEnterPass.Clear();

                rdoMK.Checked = false;
                rdoTHT.Checked = false;
                rdoAll.Checked = false;
                txtDisplayName.Enabled = false;
                txtNewPassWord.Enabled = false;
                txtReEnterPass.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        
    }
}
