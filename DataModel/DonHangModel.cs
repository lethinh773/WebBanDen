using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DonHangModel
    {
        public DonHangModel() { }
        public string MaDonHang { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string NgayTao { get; set; }
        public string TongHD { get; set; }

        public DonHangModel(string maDonHang, string maKhachHang, string tenKhachHang, string soDienThoai, string diaChi, string ngayTao, string tongHD)
        {
            MaDonHang = maDonHang;
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            NgayTao = ngayTao;
            TongHD = tongHD;
        }
    }

}
