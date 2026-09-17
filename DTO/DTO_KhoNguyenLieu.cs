using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhoNguyenLieu
    {
        private int idKhoNguyenLieu;
        private string tenNguyenLieu;
        private float soLuongTon; 
        private string donViTinh;
        private string ghiChu; 

        public int IdKhoNguyenLieu { get => idKhoNguyenLieu; set => idKhoNguyenLieu = value; }
        public string TenNguyenLieu { get => tenNguyenLieu; set => tenNguyenLieu = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public float SoLuongTon { get => soLuongTon; set => soLuongTon = value; }

        public DTO_KhoNguyenLieu() { }

        public DTO_KhoNguyenLieu(int id, string ten, float soLuongTon, string donViTinh, string ghiChu)
        {
            this.IdKhoNguyenLieu = id;
            this.TenNguyenLieu = ten;
            this.SoLuongTon = soLuongTon;
            this.DonViTinh = donViTinh;
            this.GhiChu = ghiChu;
        }

        public override string ToString() => TenNguyenLieu;
    }
}
