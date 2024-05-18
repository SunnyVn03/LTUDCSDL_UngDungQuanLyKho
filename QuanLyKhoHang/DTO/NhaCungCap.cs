using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class NhaCungCap
    {
        string maNhaCungCap, tenNhaCungCap, diaChi, email, dienThoai;
        bool isDelete;
        public string MaNhaCungCap { get { return maNhaCungCap; } set { maNhaCungCap = value; } }
        public string TenNhaCungCap { get { return tenNhaCungCap; } set { tenNhaCungCap = value; } }
        public string DiaChi { get { return diaChi; } set { diaChi = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string DienThoai { get { return dienThoai; } set { dienThoai = value; } }
        public bool IsDelete { get { return isDelete; } set { isDelete = value; } }
    }
}
