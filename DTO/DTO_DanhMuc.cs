using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DanhMuc
    {
        private int idDanhMuc;
        private string tenDanhMuc;

        public int IdDanhMuc { get => idDanhMuc; set => idDanhMuc = value; }
        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }

        public DTO_DanhMuc() { }

        public DTO_DanhMuc(int idDanhMuc, string tenDanhMuc)
        {
            this.idDanhMuc = idDanhMuc;
            this.tenDanhMuc = tenDanhMuc;
        }

    }
}
