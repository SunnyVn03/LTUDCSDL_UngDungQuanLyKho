using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHang.DataLayer;
using System.Windows.Forms;
using System.Data;
using System.IO;
using QuanLyKhoHang.DTO;
using System.Data.SqlClient;

namespace QuanLyHangHoa.BusinessLayer
{
    public class BLL_HangHoa
    {
        MyDatabase _db;
        public BLL_HangHoa(string path)
        {
            _db = new MyDatabase(path);
        }

        //phuong thuc lay ds hang hoa
        public DataTable LayDSHangHoa(ref string err, string maHang)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaHang", maHang)
            };
            return _db.GetDataTable(ref err, "HangHoa_Select", CommandType.StoredProcedure, sqlParameters);
        }

        public int CapNhatHangHoa(ref string err, HangHoa hangHoa)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@MaHang",hangHoa.MaHang),
                new SqlParameter("@TenHang",hangHoa.TenHang),
                new SqlParameter("@LoaiHang",hangHoa.LoaiHang),
                new SqlParameter("@SoLuongTon",hangHoa.SoLuongTon),
                new SqlParameter("@MaNhaCungCap",hangHoa.MaNhaCungCap)
            };
            return _db.MyExcuteNonQuery(ref err, "HangHoa_InsertAndUpdate", CommandType.StoredProcedure, sqlParameters);
        }

        internal int XoaHangHoaTheoID(ref string err, string maHang)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@MaHang", maHang)
                };
                _db.GetDataTable(ref err, "HangHoa_Delete", CommandType.StoredProcedure, sqlParameters);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
