using ProThucHienFormDangNhap;
using QuanLyHangHoa.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyKhoHang.DanhMuc
{
    public partial class Frm_DSHangHoa_Main : Frm_Base
    {
        public Frm_DSHangHoa_Main()
        {
            InitializeComponent();
        }

        BLL_HangHoa bd;
        DataTable dtHangHoa;
        string err = string.Empty;

        private void btnthoat_Click(object sender, EventArgs e)
        {
            deDongTab();
        }

        private void Frm_DSHangHoa_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_HangHoa(Cls_Main.path);
            HienThiDSKhachHang();

        }

        private void HienThiDSKhachHang()
        {
            try
            {
                dtHangHoa = new DataTable();
                dtHangHoa = bd.LayDSHangHoa(ref err);

                dsHangHoa.DataSource = dtHangHoa.DefaultView;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                lblErr.Text = err;
            }

        }
    }
}
