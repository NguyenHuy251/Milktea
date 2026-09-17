using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanTraSua.Resources
{
    public static class CurrentUser
    {
        private static int idNhanVien;
        private static int loaiTK;

        public static int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public static int LoaiTK { get => loaiTK; set => loaiTK = value; }

        public static void SetUser(DTO_Login login)
        {
            IdNhanVien = login.IdNhanVien;
            LoaiTK = login.LoaiTK;
        }

        public static void ClearUser()
        {
            IdNhanVien = 0;
            LoaiTK = 0;
        }
    }
}
