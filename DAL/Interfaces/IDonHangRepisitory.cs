using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface IDonHangRepository
    {
        //get danh sách hóa đơn chưa xác nhận
        List<DonHangModel> getDS_DH_chuaXN();

        //get danh sách hóa đơn đã xác nhận
        List<DonHangModel> getDS_DH_daXN();

        //duyệt đơn
        bool DuyetDon(int id);

        //hủy đơn
        bool HuyDon(int id);

        //get chi tiết đơn hàng
        List<ChiTietDonHangBan> getChiTiet(int id);

        DonHangModel getDonHang(int id);
    }
}

