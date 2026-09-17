using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChuyenBan
    {
        private int idBanNguon;
        private int idBanDich;

        public int IdBanNguon { get => idBanNguon; set => idBanNguon = value; }
        public int IdBanDich { get => idBanDich; set => idBanDich = value; }

        public DTO_ChuyenBan(int idBanNguon, int idBanDich)
        {
            IdBanNguon = idBanNguon;
            IdBanDich = idBanDich;
        }
    }
}

