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
    internal class BLL_XuatKho
    {
        MyDatabase db;
        public BLL_XuatKho(string path)
        {
            db = new MyDatabase(path);
        }
        public int ThemPhieuXuat(ref string err, string maPhieuXuat, string maNhanVien)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuXuat",int.Parse(maPhieuXuat)),
                new SqlParameter("@MaNhanVien",int.Parse(maNhanVien))
            };
            return db.MyExcuteNonQuery(ref err, "PhieuXuat_Insert", CommandType.StoredProcedure, sqlParameters);
        }

        public int ThemChiTietPhieuXuat(ref string err, string maPhieuXuat, string maHang, string soLuongXuat)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuXuat",int.Parse(maPhieuXuat)),
                new SqlParameter("@MaHang",int.Parse(maHang)),
                new SqlParameter("@SoLuongXuat",int.Parse(soLuongXuat))
            };
            return db.MyExcuteNonQuery(ref err, "ChiTietPhieuXuat_InsertAndUpdate", CommandType.StoredProcedure, sqlParameters);
        }
        public DataTable LayChiTietPhieuXuat(ref string err, string maPhieuXuat)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuXuat",maPhieuXuat)
            };
            return db.GetDataTable(ref err, "ChiTietPhieuXuat_Select", CommandType.StoredProcedure, sqlParameters);
        }

        public DataTable LayDuLieuPhieuXuat(ref string err, DateTime tuNgay, DateTime denNgay)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay",tuNgay),
                new SqlParameter("@DenNgay",denNgay)
            };
            return db.GetDataTable(ref err, "PhieuXuat_Select", CommandType.StoredProcedure, sqlParameters);
        }
        public DataTable LayDuLieuPhieuXuat(ref string err)
        {
            return db.GetDataTable(ref err, "PhieuXuat_SelectAll", CommandType.StoredProcedure, null);
        }

        public DataTable LayNhaCungCap(ref string err)
        {
            return db.GetDataTable(ref err, "NhaCungCap_SelectToComboBox", CommandType.StoredProcedure, null);
        }
        public DataTable LayHang(ref string err, string maNhaCungCap)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhaCungCap",maNhaCungCap)
            };
            return db.GetDataTable(ref err, "HangHoa_SelectToComboBox", CommandType.StoredProcedure, sqlParameters);
        }

        public DataTable LayPhieuXuatLonNhat(ref string err)
        {
            return db.GetDataTable(ref err, "PhieuXuat_LayMaxID", CommandType.StoredProcedure, null);
        }

        public int XoaCTPXTheoID(ref string err, string maPhieuXuat, string maHang)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@MaPhieuXuat", int.Parse(maPhieuXuat)),
                    new SqlParameter("@MaHang", int.Parse(maHang))
                };
                string er = err;
                db.GetDataTable(ref err, "CTPX_Delete", CommandType.StoredProcedure, sqlParameters);
                if (err != er)
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
