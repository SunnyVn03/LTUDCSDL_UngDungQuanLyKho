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
    public partial class Frm_QuanLyNhaCungCap_Modifies : Form
    {
        public Frm_QuanLyNhaCungCap_Modifies()
        {
            InitializeComponent();
        }
        BLL_NhaCungCap db;
        public NhaCungCap nhaCungCap;
        string err = string.Empty;
        public bool isAdd = true;

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenNhaCungCap.Text))
            {
                if (!string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    if (!string.IsNullOrEmpty(txtDienThoai.Text))
                    {
                        if (!string.IsNullOrEmpty(txtEmail.Text))
                        {
                            nhaCungCap = new NhaCungCap()
                            {
                                MaNhaCungCap = txtMaNhaCungCap.Text,
                                TenNhaCungCap = txtTenNhaCungCap.Text,
                                DiaChi = txtDiaChi.Text,
                                Email = txtEmail.Text,
                                DienThoai = txtDienThoai.Text,
                            };

                            if (db.CapNhatNhaCungCap(ref err, nhaCungCap) >= 1)
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

        private void Frm_QuanLyNhaCungCap_Modifies_Load(object sender, EventArgs e)
        {
            db = new BLL_NhaCungCap(Cls_Main.path);
            if (isAdd)
            {
                txtTenNhaCungCap.Focus();
            }
            else
            {
                GanNhaCungCapVaoConTro(nhaCungCap);
            }
        }

        private void GanNhaCungCapVaoConTro(NhaCungCap nhaCungCap)
        {
            txtMaNhaCungCap.Text = nhaCungCap.MaNhaCungCap;
            txtTenNhaCungCap.Text = nhaCungCap.TenNhaCungCap;
            txtDiaChi.Text = nhaCungCap.DiaChi;
            txtEmail.Text = nhaCungCap.Email;
            txtDienThoai.Text = nhaCungCap.DienThoai.ToString();
            txtTenNhaCungCap.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetControl()
        {
            txtMaNhaCungCap.ResetText();
            txtTenNhaCungCap.ResetText();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
        }
    }
}
