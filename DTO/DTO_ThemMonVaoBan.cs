using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThemMonVaoBan
    {
        private int idBan;
        private int idMonAn;
        private int soLuong;

        public int IdBan { get => idBan; set => idBan = value; }
        public int IdMonAn { get => idMonAn; set => idMonAn = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public DTO_ThemMonVaoBan(int idBan, int idMonAn, int soLuong)
        {
            IdBan = idBan;
            IdMonAn = idMonAn;
            SoLuong = soLuong;
        }
    }
}
