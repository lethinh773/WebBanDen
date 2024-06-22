using DataModel;

namespace DAL
{
    public class LoaiDenRepository : ILoaiDenRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoaiDenRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiDenModel> GetAllLoaiDen()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_loaiden_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiDenModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoaiDenModel GetLoaiDen(int MaLoai)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_loaiden_get_by_id",
                     "@id", MaLoai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiDenModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(LoaiDenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loaiden_create",
                "@TenLoai", model.TenLoai,
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
        public bool Update(LoaiDenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loaiden_update",
                "@MaLoai", model.MaLoai,
                "@TenLoai", model.TenLoai,
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
                // Thực hiện gọi stored procedure để xóa khách hàng
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_loaiden_delete",
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

        public List<LoaiDenModel> Search(int pageIndex, int pageSize, out long total, string ten_loai)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_loaiden_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_loai", ten_loai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<LoaiDenModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
