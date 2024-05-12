using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class SanPham
    {
        string maSanPham, tenSanPham, maDonViTinh, maLoaiSanPham, maNhaSX;
        int soLuongTon;
        bool isDelete;
        public string MaSanPham { get { return maSanPham; } set { maSanPham = value; } }
        public string TenSanPham { get { return tenSanPham; } set { tenSanPham = value; } }
        public string MaDonViTinh { get { return maDonViTinh; } set { maDonViTinh = value; } }
        public string MaLoaiSanPham { get { return maLoaiSanPham; } set { maLoaiSanPham = value; } }
        public string MaNhaSX { get { return maNhaSX; } set { maNhaSX = value; } }
        public int SoLuongTon { get { return soLuongTon; } set { soLuongTon = value; } }
        public bool IsDelete { get { return isDelete; } set { isDelete = value; } }
    }
}
