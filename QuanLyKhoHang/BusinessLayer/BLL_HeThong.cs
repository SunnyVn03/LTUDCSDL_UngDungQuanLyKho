using QuanLyKhoHang.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.BusinessLayer
{
    internal class BLL_HeThong
    {
        MyDatabase db;
        public BLL_HeThong(string path)
        {
            db = new MyDatabase(path);
        }
        //Kiem tra dang nhập
        public DataTable KiemTraDangNhap(ref string err, string taiKhoan, string matKhau)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TaiKhoan",taiKhoan),
                new SqlParameter("@MatKhau",matKhau)
            };
            return db.GetDataTable(ref err, "NhanVien_KiemTraDangNhap", CommandType.StoredProcedure, sqlParameters);
        }
    }
}
