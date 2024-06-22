using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ChiTietDonHangBan
    {
        public string MaDonHang {  get; set; }
        public int MaSanPham { get;set; }
        public string TenSanPham { get;set; }
        public string SoLuong {  get; set; }
        public string DonGia {  get; set; }
        public string Tong { get;set; }

        public ChiTietDonHangBan(string maDonHang, int maSanPham, string tenSanPham, string soLuong, string donGia, string tong)
        {
            MaDonHang = maDonHang;
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            DonGia = donGia;
            Tong = tong;
        }

        public ChiTietDonHangBan()
        {
        }
    }
}
