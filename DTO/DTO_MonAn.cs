using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MonAn 
    {
        private int idMonAn;
        private string tenMonAn;
        private int idDanhMuc;
        private string danhMuc;
        private int gia;

        public int IdMonAn { get => idMonAn; set => idMonAn = value; }

        public string TenMonAn { get => tenMonAn; set => tenMonAn = value; }
        public string DanhMuc { get => danhMuc; set => danhMuc = value; }
        public int Gia { get => gia; set => gia = value; }

        public string DisplayText => $"{TenMonAn} - {Gia}đ";

        public int IdDanhMuc { get => idDanhMuc; set => idDanhMuc = value; }

        public DTO_MonAn() { }

        public DTO_MonAn(int id, string tenMonAn, string danhMuc, int gia)
        {
            this.IdMonAn = id; 
            this.TenMonAn = tenMonAn;
            this.DanhMuc = danhMuc;
            this.Gia = gia;
        }

        public DTO_MonAn(int id, string tenMonAn, int idDanhMuc, string danhMuc, int gia)
        {
            this.IdMonAn = id;
            this.TenMonAn = tenMonAn;
            this.IdDanhMuc = idDanhMuc;
            this.DanhMuc = danhMuc;
            this.Gia = gia;
        }
    }
}
