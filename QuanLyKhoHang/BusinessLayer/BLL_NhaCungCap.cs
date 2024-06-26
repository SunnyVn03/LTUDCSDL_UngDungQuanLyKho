﻿using QuanLyKhoHang.DataLayer;
using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.BusinessLayer
{
    public class BLL_NhaCungCap
    {
        MyDatabase db;
        public BLL_NhaCungCap(string path)
        {
            db = new MyDatabase(path);
        }
        public DataTable LayDsNhaCungCap(ref string err, string maNhaCungCap)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhaCungCap", maNhaCungCap)
            };
            return db.GetDataTable(ref err, "NhaCungCap_Select", CommandType.StoredProcedure, sqlParameters);

        }

        public int CapNhatNhaCungCap(ref string err, NhaCungCap nhaSX)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@MaNhaCungCap",nhaSX.MaNhaCungCap),
                new SqlParameter("@TenNhaCungCap",nhaSX.TenNhaCungCap),
                new SqlParameter("@DiaChi",nhaSX.DiaChi),
                new SqlParameter("@Email",nhaSX.Email),
                new SqlParameter("@DienThoai",nhaSX.DienThoai)
            };
            return db.MyExcuteNonQuery(ref err, "NhaCungCap_InsertAndUpdate", CommandType.StoredProcedure, sqlParameters);
        }

        public object SinhMaLonNhat(ref string err)
        {
            return db.MyExcuteScalar(ref err, "NhaCungCap_LayMaNhaCungCap", CommandType.StoredProcedure, null);
        }

        internal int XoaNhaCungCapTheoID(ref string err, string maNhaCungCap)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@MaNhaCungCap", maNhaCungCap)
                };
                string er = err;
                db.GetDataTable(ref err, "NhaCungCap_Delete", CommandType.StoredProcedure, sqlParameters);
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
