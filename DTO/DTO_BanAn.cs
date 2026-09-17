using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BanAn
    {
        private int idBanAn;
        private string tenBanAn;
        private string trangThai;

        public int IdBanAn { get => idBanAn; set => idBanAn = value; }
        public string TenBanAn { get => tenBanAn; set => tenBanAn = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        public DTO_BanAn() { }
        
        public DTO_BanAn(int id, string ten, string tt)
        {
            this.IdBanAn = id;
            this.TenBanAn = ten;
            this.TrangThai = tt;
        }
        public override string ToString() => TenBanAn; 


    }
}
