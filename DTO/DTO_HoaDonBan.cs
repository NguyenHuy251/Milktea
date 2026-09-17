using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonBan
    {
        private int id;
        private int idBanAn;
        private DateTime thoiDiemVao;
        private DateTime? thoiDiemRa;
        private float tongTien;
        private int idNhanVien;
        private string hoTen;
        private bool trangThaiHD;

        public int Id { get => id; set => id = value; }
        public int IdBanAn { get => idBanAn; set => idBanAn = value; }
        public DateTime ThoiDiemVao { get => thoiDiemVao; set => thoiDiemVao = value; }
        public DateTime? ThoiDiemRa { get => thoiDiemRa; set => thoiDiemRa = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public bool TrangThaiHD { get => trangThaiHD; set => trangThaiHD = value; }

        public DTO_HoaDonBan(int id, int idBanAn, DateTime thoiDiemVao, DateTime? thoiDiemRa, float tongTien, int idNhanVien, string hoTen, bool trangThaiHD)
        {
            Id = id;
            IdBanAn = idBanAn;
            ThoiDiemVao = thoiDiemVao;
            ThoiDiemRa = thoiDiemRa;
            TongTien = tongTien;
            IdNhanVien = idNhanVien;
            HoTen = hoTen;
            TrangThaiHD = trangThaiHD;
        }
    }
}
