using BLL;
using DataModel;

namespace DAL

{
    public class DenRepository : IDenRepository
    {
        private IDatabaseHelper _dbHelper;
        public DenRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DenModel GetChiTietDen(int MaDen)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Den_get_by_id",
                     "@MaDen", MaDen);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DenModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(CreateDenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Den_create",
                "@MaLoai", model.MaLoai,
                "@TenDen", model.TenDen,
                "@Anh", model.Anh,
                "@Gia", model.Gia,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@MoTa", model.MoTa);

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
        public bool Update(CreateDenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Den_update",
                "@MaDen", model.MaDen,
                "@MaLoai", model.MaLoai,
                "@TenDen", model.TenDen,
                "@Anh", model.Anh,
                "@Gia", model.Gia,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@MoTa", model.MoTa);

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

        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                // Thực hiện gọi stored procedure để xóa đèn
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Den_delete",
                    "@id", id);

                // Kiểm tra kết quả và lỗi
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                // Nếu không có lỗi, trả về true
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DenModel> Search(int pageIndex, int pageSize, out long total, string ten_den)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Den_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_den", ten_den);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DenModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public bool Create(HoaDonModel model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_create",
        //        "@TenKH", model.TenKH,
        //        "@Diachi", model.Diachi,
        //        "@TrangThai", model.TrangThai,
        //        "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public bool Update(HoaDonModel model)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_update",
        //        "@MaHoaDon", model.MaHoaDon,
        //        "@TenKH", model.TenKH,
        //        "@Diachi", model.Diachi,
        //        "@TrangThai", model.TrangThai,
        //        "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_khach",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@ten_khach", ten_khach,
        //            "@fr_NgayTao", fr_NgayTao,
        //            "@to_NgayTao", to_NgayTao
        //             );
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<ThongKeKhachModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
    
    }
}
