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

namespace QuanLyKhoHang.TacVu
{
    public partial class Frm_XuatKho_Modifies : Form
    {
        public Frm_XuatKho_Modifies()
        {
            InitializeComponent();
        }
        BLL_XuatKho bd;
        string err = string.Empty;
        bool daThemPhieuXuat = false;
        private void Frm_XuatKho_Modifies_Load(object sender, EventArgs e)
        {
            daThemPhieuXuat = false;
            bd = new BLL_XuatKho(Cls_Main.path);
            HienThiDuLieuXuatHang();
        }

        private void HienThiDuLieuXuatHang()
        {
            HienThiDuLieuNhaCungCap();
            lblNhanVien.Text = Cls_Main.tenNhanVien;
            DataTable dt = new DataTable();
            dt = bd.LayPhieuXuatLonNhat(ref err);
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaPhieuNhap"].ToString() != "")
            {
                lblMaPhieuXuat.Text = dt.Rows[0]["MaPhieuXuat"].ToString();
            }
            else
            {
                lblMaPhieuXuat.Text = "1";
            }
        }

        private void HienThiDuLieuSanPham(string maNhaCungCap)
        {
            DataTable dtMatHang = new DataTable();
            dtMatHang = bd.LayHang(ref err, maNhaCungCap);
            cboNhaCungCap.ResetText();
            cboTenHang.DataSource = dtMatHang;
            cboTenHang.ValueMember = "MaHang";
            cboTenHang.DisplayMember = "TenHang";
            cboTenHang.SelectedIndex = -1;
            cboTenHang.Text = "-- Chọn mặt hàng --";

        }

        bool statusLoadcboNhaCungCap = false;
        private void HienThiDuLieuNhaCungCap()
        {
            DataTable dtNhaCungCap = new DataTable();
            dtNhaCungCap = bd.LayNhaCungCap(ref err);
            cboNhaCungCap.ResetText();
            cboNhaCungCap.DataSource = dtNhaCungCap;
            cboNhaCungCap.ValueMember = "MaNhaCungCap";
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.SelectedIndex = -1;
            cboNhaCungCap.Text = "-- Chọn nhà cung cấp --";
            statusLoadcboNhaCungCap = true;
        }

        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex >= 0 && statusLoadcboNhaCungCap)
            {
                HienThiDuLieuSanPham(cboNhaCungCap.SelectedValue.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboTenHang.SelectedIndex >= 0)
            {
                {
                    if (!daThemPhieuXuat)
                    {
                        bd.ThemPhieuXuat(ref err, lblMaPhieuXuat.Text, Cls_Main.maNhanVien);
                        daThemPhieuXuat = true;
                    }
                    //kiểm tra thêm vế sl, dongia, donvitinh.
                    if (bd.ThemChiTietPhieuXuat(ref err, lblMaPhieuXuat.Text, cboTenHang.SelectedValue.ToString(), txtSoLuongXuat.Text) >= 1)
                    {
                        MessageBox.Show("Thêm thành công");
                        HienThiDuLieuChiTietPhieuXuat(lblMaPhieuXuat.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("chưa chọn mặt hàng");
            }
        }

        DataTable dtChiTietPhieuXuat;
        private void HienThiDuLieuChiTietPhieuXuat(string maPhieuXuat)
        {
            dtChiTietPhieuXuat = new DataTable();
            dtChiTietPhieuXuat = bd.LayChiTietPhieuXuat(ref err, maPhieuXuat);

            dgvCTPN.DataSource = dtChiTietPhieuXuat.DefaultView;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
