﻿using DataModel;


namespace DAL
{
    public class HoaDonNhapRepository : IHoaDonNhapRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public HoaDonNhapModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadonnhap_get_by_id",
                     "@MaHoaDon", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadonnhap_create",
                "@MaNCC", model.MaNCC,
                "@NgayTao", model.NgayTao,
                "@KieuThanhToan", model.KieuThanhToan,
                "@MaTaiKhoan", model.MaTaiKhoan,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_nhap_update",
                "@MaHoaDon", model.MaHoaDon,
                "@MaNCC", model.MaNCC,
                "@NgayTao", model.NgayTao,
                "@KieuThanhToan", model.KieuThanhToan,
                "@MaTaiKhoan", model.MaTaiKhoan,
                "@list_json_chitiethoadonnhap", model.list_json_chitiethoadonnhap != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadonnhap) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_khach",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khach", ten_khach,
                    "@fr_NgayTao", fr_NgayTao,
                    "@to_NgayTao", to_NgayTao
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeKhachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
