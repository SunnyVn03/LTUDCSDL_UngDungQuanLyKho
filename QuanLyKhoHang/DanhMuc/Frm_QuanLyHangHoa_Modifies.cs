using QuanLyHangHoa.BusinessLayer;
using QuanLyKhoHang.BusinessLayer;
using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.DanhMuc
{
    public partial class Frm_QuanLyHangHoa_Modifies : Form
    {
        public Frm_QuanLyHangHoa_Modifies()
        {
            InitializeComponent();
        }
        BLL_HangHoa db;
        public HangHoa hangHoa;
        string err = string.Empty;
        public bool isAdd = true;

        private void Frm_QuanLyHangHoa_Modifies_Load(object sender, EventArgs e)
        {
            db = new BLL_HangHoa(Cls_Main.path);
            if (isAdd)
            {
                txtTenHang.Focus();
            }
            else
            {
                GanHangHoaVaoConTro(hangHoa);
            }
        }

        private void GanHangHoaVaoConTro(HangHoa hangHoa)
        {
            txtMaHang.Text = hangHoa.MaHang;
            txtTenHang.Text = hangHoa.TenHang;
            txtLoaiHang.Text = hangHoa.LoaiHang;
            txtSoLuongTon.Text = hangHoa.SoLuongTon.ToString();
            txtMaNhaCungCap.Text = hangHoa.MaNhaCungCap.ToString();
            txtTenHang.Focus();
        }

        private void ResetControl()
        {
            txtMaHang.ResetText();
            txtTenHang.ResetText();
            txtLoaiHang.ResetText();
            txtSoLuongTon.Clear();
            txtMaNhaCungCap.Clear();
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenHang.Text))
            {
                if (!string.IsNullOrEmpty(txtLoaiHang.Text))
                {
                    if (!string.IsNullOrEmpty(txtSoLuongTon.Text))
                    {
                        if (!string.IsNullOrEmpty(txtMaNhaCungCap.Text))
                        {
                            hangHoa = new HangHoa()
                            {
                                MaHang = txtMaHang.Text,
                                TenHang = txtTenHang.Text,
                                LoaiHang = txtLoaiHang.Text,
                                SoLuongTon = int.Parse(txtSoLuongTon.Text),
                                MaNhaCungCap = int.Parse(txtMaNhaCungCap.Text),
                            };

                            if (db.CapNhatHangHoa(ref err, hangHoa) >= 1)
                            {
                                MessageBox.Show("cập nhật thành công");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("cập nhật không thành công \n" + err);
                            }
                        }
                        else
                        {
                            MessageBox.Show("chưa nhập email");
                        }
                    }
                    else
                    {
                        MessageBox.Show("chưa nhập số điện thoại");
                    }
                }
                else
                {
                    MessageBox.Show("chưa nhập địa chỉ");
                }
            }
            else
            {
                MessageBox.Show("chưa nhập tên nhà cung cấp");
            }
        }
    }
}
