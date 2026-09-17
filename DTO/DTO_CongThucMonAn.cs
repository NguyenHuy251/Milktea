using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CongThucMonAn
    {
        private int idMonAn;
        private int idNguyenLieu;
        private float soLuong;
        private string donViTinh;
        private string tenMonAn;

        public int IdMonAn { get => idMonAn; set => idMonAn = value; }
        public int IdNguyenLieu { get => idNguyenLieu; set => idNguyenLieu = value; }
        public float SoLuong { get => soLuong; set => soLuong = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }

        public DTO_CongThucMonAn() { }

        public DTO_CongThucMonAn(int idMonAn, int idNguyenLieu, float soLuong, string donViTinh, string tenMonAn)
        {
            IdMonAn = idMonAn;
            IdNguyenLieu = idNguyenLieu;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            TenMonAn = tenMonAn;
        }
    }
}
