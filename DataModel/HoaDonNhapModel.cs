using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int MaHoaDon { get; set; }
        public int MaNCC { get; set; }
        public string NgayTao { get; set; }
        public string KieuThanhToan { get; set; }
        public int MaTaiKhoan { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }
    public class ChiTietHoaDonNhapModel
    {
        public int Id { get; set; }
        public int MaHoaDon { get; set; }
        public int MaDen { get; set; }
        public int SoLuong { get; set; }
        public string DoViTinh { get; set; }
        public double GiaNhap { get; set; }
        public double TongTien { get; set; }
    }
}
