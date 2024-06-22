using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DenModel
    {
        public int MaDen { get; set; }
        public int MaLoai { get; set; }
        public string TenDen { get; set; }
        public string Anh { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
        public List<DenModel> list_json_denlienquan { get; set; }
        public List<ChiTietAnhModel> list_json_chitietanhden { get; set; }
    }

    public class CreateDenModel
    {
        public int MaDen { get; set; }
        public int MaLoai { get; set; }
        public string TenDen { get; set; }
        public string Anh { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }
        public string MoTa { get; set; }
    }
    public class ChiTietAnhModel
    {
        public int MaChiTietAnh { get; set; }
        public int MaDen { get; set; }
        public string Anh { get; set; }
        public int status { get; set; }
    }
}

