using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class HangHoa
    {
        string maHang, tenHang, loaiHang;
        int soLuongTon, maNhaCungCap;
        bool isDelete;
        public string MaHang { get { return maHang; } set { maHang = value; } }
        public string TenHang { get { return tenHang; } set { tenHang = value; } }
        public string LoaiHang { get { return loaiHang; } set { loaiHang = value; } }
        public int SoLuongTon { get { return soLuongTon; } set { soLuongTon = value; } }
        public int MaNhaCungCap { get { return maNhaCungCap; } set { maNhaCungCap = value; } }
        public bool IsDelete { get { return isDelete; } set { isDelete = value; } }
    }
}
