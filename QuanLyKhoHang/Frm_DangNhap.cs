using ProThucHienFormDangNhap;
using QuanLyKhoHang.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKhoHang
{
    public partial class Frm_DangNhap : Form
    {
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        BLL_HeThong db;
        string err = string.Empty;
        DataTable dtNhanVien;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {
            db = new BLL_HeThong(Cls_Main.path);
            txt_Username.Text = "admin";
            txt_Password.Text = "123456";
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Username.Text))
            {
                if (!string.IsNullOrEmpty(txt_Password.Text))
                {
                    if (KiemTraDangNhap(txt_Username.Text, txt_Password.Text))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thong tin tai khoan khong dung");
                    }
                }
                else
                {
                    MessageBox.Show("Chua nhap Mat khau");
                }
            }
            else
            {
                MessageBox.Show("Chua nhap tai khoan");
            }

        }

        private bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            dtNhanVien = new DataTable();
            dtNhanVien = db.KiemTraDangNhap(ref err, taiKhoan, matKhau);
            if (dtNhanVien.Rows.Count > 0)
            {
                if (dtNhanVien.Rows[0]["Code"].ToString().Equals("1"))
                {
                    Cls_Main.tenNhanVien = dtNhanVien.Rows[0]["TenNhanVien"].ToString();

                    Cls_Main.maNhanVien = dtNhanVien.Rows[0]["MaNhanVien"].ToString();
                    return true;
                }
            }
            return false;
        }
    }
}
