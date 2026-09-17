using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietHoaDonNhap
    {
        private int idChiTietHoaDonNhap;
        private int idHoaDonNhap;
        private int idNguyenLieu;
        private string donViTinh;
        private int soLuong;
        private float donGia;
        private string ghiChu;

        public int IdChiTietHoaDonNhap { get => idChiTietHoaDonNhap; set => idChiTietHoaDonNhap = value; }
        public int IdHoaDonNhap { get => idHoaDonNhap; set => idHoaDonNhap = value; }
        public int IdNguyenLieu { get => idNguyenLieu; set => idNguyenLieu = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public DTO_ChiTietHoaDonNhap() { }

        public DTO_ChiTietHoaDonNhap(int id, int idHoaDonNhap, int idNguyenLieu, string donViTinh, int soLuong, float donGia, string ghiChu)
        {
            this.IdChiTietHoaDonNhap = id;
            this.IdHoaDonNhap = idHoaDonNhap;
            this.IdNguyenLieu = idNguyenLieu;
            this.DonViTinh = donViTinh;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.GhiChu = ghiChu;
        }
    }
}
