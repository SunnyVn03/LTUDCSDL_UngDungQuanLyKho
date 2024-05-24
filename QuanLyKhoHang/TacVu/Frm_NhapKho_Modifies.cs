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

namespace QuanLyKhoHang.TacVu
{
    public partial class Frm_NhapKho_Modifies : Frm_Base
    {
        public Frm_NhapKho_Modifies()
        {
            InitializeComponent();
        }
        BLL_NhapKho bd;
        string err = string.Empty;
        bool daThemPhieuNhap = false;
        public bool edit = false;
        public string maPN = "";
        private void Frm_QuanLyNhapKho_Load(object sender, EventArgs e)
        {
            daThemPhieuNhap = false;
            bd = new BLL_NhapKho(Cls_Main.path);
            HienThiDuLieuNhapHang();
        }

        private void HienThiDuLieuNhapHang()
        {
            HienThiDuLieuNhaCungCap();
            lblNhanVien.Text = Cls_Main.tenNhanVien;
            DataTable dt = new DataTable();
            if (edit)
            {
                lblMaPhieuNhap.Text = maPN;
                daThemPhieuNhap = true;
                HienThiDuLieuChiTietPhieuNhap(lblMaPhieuNhap.Text);
            }
            else
            {
                dt = bd.LayPhieuNhapLonNhat(ref err);
                if (dt.Rows.Count > 0 && dt.Rows[0]["MaPhieuNhap"].ToString() != "")
                {
                    lblMaPhieuNhap.Text = dt.Rows[0]["MaPhieuNhap"].ToString();
                }
                else
                {
                    lblMaPhieuNhap.Text = "1";
                }
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
                if (!daThemPhieuNhap)
                {
                    bd.ThemPhieuNhap(ref err, lblMaPhieuNhap.Text, Cls_Main.maNhanVien);
                    daThemPhieuNhap = true;
                }
                //kiểm tra thêm vế sl, dongia, donvitinh.
                if (bd.ThemChiTietPhieuNhap(ref err, lblMaPhieuNhap.Text, cboTenHang.SelectedValue.ToString(), txtSoLuongNhap.Text) >= 1)
                {
                    MessageBox.Show("Thêm thành công");
                    HienThiDuLieuChiTietPhieuNhap(lblMaPhieuNhap.Text);
                }
            }
            else
            {
                MessageBox.Show("chua chon san pham");
            }
        }

        DataTable dtChiTietPhieuNhap;
        private void HienThiDuLieuChiTietPhieuNhap(string maPhieuNhap)
        {
            dtChiTietPhieuNhap = new DataTable();
            dtChiTietPhieuNhap = bd.LayChiTietPhieuNhap(ref err, maPhieuNhap);

            dgvCTPN.DataSource = dtChiTietPhieuNhap.DefaultView;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCTPN.SelectedRows.Count != 0)
            {
                if (bd.XoaCTPNTheoID(ref err, lblMaPhieuNhap.Text, dgvCTPN.SelectedRows[0].Cells["colMaHang"].Value.ToString()) != 1)
                {
                    MessageBox.Show(err);
                }
                else
                {
                    MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn hàng hoá.");
            }
            HienThiDuLieuChiTietPhieuNhap(lblMaPhieuNhap.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
