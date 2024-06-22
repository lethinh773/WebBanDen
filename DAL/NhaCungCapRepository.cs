using DataModel;

namespace DAL
{
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhaCungCapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaCungCapModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ncc_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaCungCapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ncc_create",
                "@TenNCC", model.TenNCC,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
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
        public bool Update(NhaCungCapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ncc_update",
                "@MaNCC", model.MaNCC,
                "@TenNCC", model.TenNCC,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_ncc_delete",
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

        public List<NhaCungCapModel> Search(int pageIndex, int pageSize, out long total, string ten_ncc, string dia_chi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ncc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_ncc", ten_ncc,
                    "@dia_chi", dia_chi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaCungCapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

