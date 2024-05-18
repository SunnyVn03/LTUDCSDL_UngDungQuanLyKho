using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHang.DataLayer;
using System.Windows.Forms;
using System.Data;
using System.IO;

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
        public DataTable LayDSHangHoa(ref string err)
        {
            return _db.GetDataTable(ref err, "HangHoa_Select", CommandType.StoredProcedure, null);
        }
    }
}
