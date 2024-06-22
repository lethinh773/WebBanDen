using DataModel;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _dbHelper;
        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public UserModel Login(string email, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@email", email,
                     "@matkhau", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_User_create",
                "@LoaiTaiKhoan", model.LoaiTaiKhoan,
                "@TenTaiKhoan", model.TenTaiKhoan,
                "@MatKhau", model.MatKhau,
                "@Email", model.Email,
                "@token", model.token);

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
        public bool Update(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_User_update",
                "@MaTaiKhoan", model.MaTaiKhoan,
                "@LoaiTaiKhoan", model.LoaiTaiKhoan,
                "@TenTaiKhoan", model.TenTaiKhoan,
                "@MatKhau", model.MatKhau,
                "@Email", model.Email,
                "@token", model.token);

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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_User_delete",
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
    }
}
