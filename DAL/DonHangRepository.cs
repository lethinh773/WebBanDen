using BLL;
using DataModel;
using System.Data;

namespace DAL
{
    public class DonHangRepository : IDonHangRepository
    {
        private IDatabaseHelper _dbHelper;

        public DonHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool DuyetDon(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ban_DuyetDon",
                "@id", id);
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

        public List<ChiTietDonHangBan> getChiTiet(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ban_xemChiTietDonHang",
                "@MaDonHang", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //LoaiSPmodels sanPham = new LoaiSPmodels(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());

                List<ChiTietDonHangBan> list = new List<ChiTietDonHangBan>();
                foreach (DataRow row in dt.Rows)
                {

                    ChiTietDonHangBan dh = new ChiTietDonHangBan(row[0].ToString(), int.Parse(row[1].ToString()), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                    list.Add(dh);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DonHangModel getDonHang(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ban_showdonhang",
                     "@MaDonHang", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //LoaiSPmodels sanPham = new LoaiSPmodels(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DonHangModel> getDS_DH_chuaXN()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ban_showdonchuaduyet");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //LoaiSPmodels sanPham = new LoaiSPmodels(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());

                List<DonHangModel> list = new List<DonHangModel>();
                foreach (DataRow row in dt.Rows)
                {

                    DonHangModel dh = new DonHangModel(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                    list.Add(dh);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DonHangModel> getDS_DH_daXN()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ban_showdondaduyet");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                //LoaiSPmodels sanPham = new LoaiSPmodels(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());

                List<DonHangModel> list = new List<DonHangModel>();
                foreach (DataRow row in dt.Rows)
                {

                    DonHangModel dh = new DonHangModel(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                    list.Add(dh);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HuyDon(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ban_huydonhang",
                "@MaDonHang", id);
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
    }
}
