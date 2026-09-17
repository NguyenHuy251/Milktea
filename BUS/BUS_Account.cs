using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class BUS_Account
    {
        DAL_Account dal_acc = new DAL_Account();
        public DataTable GetAccountList()
        {
            return dal_acc.GetAccountList();
        }

        public DTO_Account LayTaiKhoanTheoUserName(string userName)
        {
            return dal_acc.LayTaiKhoanTheoUserName(userName);
        }

        public bool CapNhatTaiKhoan(DTO_Account taiKhoan)
        {
            return dal_acc.CapNhatTaiKhoan(taiKhoan);
        }

        public bool ThemTaiKhoan(DTO_Account taiKhoan)
        {
            return dal_acc.ThemTaiKhoan(taiKhoan);
        }

        public bool SuaTaiKhoan(DTO_Account taiKhoan)
        {
            return dal_acc.SuaTaiKhoan(taiKhoan);
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            return dal_acc.XoaTaiKhoan(tenDangNhap);
        }

        public bool ResetMatKhau(string tenDangNhap)
        {
            return dal_acc.ResetMatKhau(tenDangNhap);
        }

        public DataTable LayTaiKhoanTheoLoaiTaiKhoan(int loaiTaiKhoan)
        {
            return dal_acc.LayTaiKhoanTheoLoaiTaiKhoan(loaiTaiKhoan);
        }
    }
}
