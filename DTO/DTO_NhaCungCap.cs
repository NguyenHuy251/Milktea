using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhaCungCap
    {
        private int idNhaCC;
        private string tenNhaCC;
        private string diaChi;
        private string soDienThoai;
        private string email;

        public int IdNhaCC { get => idNhaCC; set => idNhaCC = value; }
        public string TenNhaCC { get => tenNhaCC; set => tenNhaCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }

        public DTO_NhaCungCap() { }

        public DTO_NhaCungCap(int id, string ten, string diaChi, string sdt, string email)
        {
            this.IdNhaCC = id;
            this.TenNhaCC = ten;
            this.DiaChi = diaChi;
            this.SoDienThoai = sdt;
            this.Email = email;
        }
    }
}
