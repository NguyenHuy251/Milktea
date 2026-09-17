using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_CongThucMonAn
    {
        private DAL_CongThucMonAn dal_CongThucMonAn = new DAL_CongThucMonAn();

        public List<DTO_CongThucMonAn> LayDanhSachCongThucMonAn(int idMonAn)
        {
            return dal_CongThucMonAn.LayDanhSachCongThucMonAn(idMonAn);
        }

        public bool ThemCongThucMonAn(DTO_CongThucMonAn congThuc)
        {
            if (congThuc.SoLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");
            if (string.IsNullOrWhiteSpace(congThuc.DonViTinh))
                throw new Exception("Đơn vị tính không được để trống.");
            if (congThuc.DonViTinh.Length > 50)
                throw new Exception("Đơn vị tính không được dài quá 50 ký tự.");

            return dal_CongThucMonAn.ThemCongThucMonAn(congThuc);
        }

        public bool SuaCongThucMonAn(DTO_CongThucMonAn congThuc)
        {
            if (congThuc.SoLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");
            if (string.IsNullOrWhiteSpace(congThuc.DonViTinh))
                throw new Exception("Đơn vị tính không được để trống.");
            if (congThuc.DonViTinh.Length > 50)
                throw new Exception("Đơn vị tính không được dài quá 50 ký tự.");

            return dal_CongThucMonAn.SuaCongThucMonAn(congThuc);
        }

        public bool XoaCongThucMonAn(int idMonAn, int idNguyenLieu)
        {
            return dal_CongThucMonAn.XoaCongThucMonAn(idMonAn, idNguyenLieu);
        }

        public DataTable LayDanhSachMonAn()
        {
            return dal_CongThucMonAn.LayDanhSachMonAn();
        }

        public DataTable LayDanhSachNguyenLieu()
        {
            return dal_CongThucMonAn.LayDanhSachNguyenLieu();
        }
    }
}
