using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThanhToan
    {
        private int idBan;
        private float giamGia;
        private int idNhanVien;

        public int IdBan { get => idBan; set => idBan = value; }
        public float GiamGia { get => giamGia; set => giamGia = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }

        public DTO_ThanhToan(int idBan, float giamGia, int idNhanVien)
        {
            IdBan = idBan;
            GiamGia = giamGia;
            IdNhanVien = idNhanVien;
        }
    }
}

