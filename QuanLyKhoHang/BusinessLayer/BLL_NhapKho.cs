using QuanLyKhoHang.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProThucHienFormDangNhap.BusinessLayer
{
    public class BLL_NhapKho
    {
        MyDatabase db;
        public BLL_NhapKho(string path)
        {
            db = new MyDatabase(path);
        }
        public int ThemPhieuNhap(ref string err, string maPhieuNhap, string maNhanVien)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuNhap",maPhieuNhap),
                new SqlParameter("@MaNhanVien",maNhanVien)
            };
            return db.MyExcuteNonQuery(ref err, "PhieuNhap_Insert", CommandType.StoredProcedure, sqlParameters);
        }

        public int ThemChiTietPhieuNhap(ref string err, string maPhieuNhap, string maHang, string soLuongNhap)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuNhap",maPhieuNhap),
                new SqlParameter("@MaHang",maHang),
                new SqlParameter("@SoLuongNhap",soLuongNhap)
            };
            return db.MyExcuteNonQuery(ref err, "ChiTietPhieuNhap_InsertAndUpdate", CommandType.StoredProcedure, sqlParameters);
        }
        public DataTable LayChiTietPhieuNhap(ref string err, string maPhieuNhap)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuNhap",maPhieuNhap)
            };
            return db.GetDataTable(ref err, "ChiTietPhieuNhap_Select", CommandType.StoredProcedure, sqlParameters);
        }

        public DataTable LayDuLieuPhieuNhap(ref string err, DateTime tuNgay, DateTime denNgay)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@TuNgay",tuNgay),
                new SqlParameter("@DenNgay",denNgay)
            };
            return db.GetDataTable(ref err, "PhieuNhap_Select", CommandType.StoredProcedure, sqlParameters);
        }
    }


}