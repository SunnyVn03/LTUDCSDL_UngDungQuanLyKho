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
        BLL_HangHoa bd1;
        DataTable dtHangHoa;
        string err = string.Empty;
        bool daThemPhieuXuat = false;
        public bool edit = false;
        public string maPX = "";
        private void Frm_XuatKho_Modifies_Load(object sender, EventArgs e)
        {
            daThemPhieuXuat = false;
            bd1 = new BLL_HangHoa(Cls_Main.path);
            bd = new BLL_XuatKho(Cls_Main.path);
            HienThiDuLieuXuatHang();
            HienThiDSHangHoa();
        }

        private void HienThiDSHangHoa()
        {
            try
            {
                dtHangHoa = new DataTable();
                dtHangHoa = bd1.LayDSHangHoa(ref err, "0");

                dsHangHoa.DataSource = dtHangHoa.DefaultView;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                lblErr.Text = err;
            }

        }
        private void HienThiDuLieuXuatHang()
        {
            HienThiDuLieuNhaCungCap();
            lblNhanVien.Text = Cls_Main.tenNhanVien;
            DataTable dt = new DataTable();
            if (edit)
            {
                lblMaPhieuXuat.Text = maPX;
                daThemPhieuXuat = true;
                HienThiDuLieuChiTietPhieuXuat(lblMaPhieuXuat.Text);
            }
            else
            {
                dt = bd.LayPhieuXuatLonNhat(ref err);
                if (dt.Rows.Count > 0 && dt.Rows[0]["MaPhieuXuat"].ToString() != "")
                {
                    lblMaPhieuXuat.Text = dt.Rows[0]["MaPhieuXuat"].ToString();
                }
                else
                {
                    lblMaPhieuXuat.Text = "1";
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
                {
                    string er = err;
                    if (!daThemPhieuXuat)
                    {
                        bd.ThemPhieuXuat(ref err, lblMaPhieuXuat.Text, Cls_Main.maNhanVien);
                        if (er != err)
                        {
                            lblErr.Text = err;
                            er = err;
                        }
                        daThemPhieuXuat = true;
                    }
                    //kiểm tra thêm vế sl, dongia, donvitinh.
                    if (bd.ThemChiTietPhieuXuat(ref err, lblMaPhieuXuat.Text, cboTenHang.SelectedValue.ToString(), txtSoLuongXuat.Text) >= 1)
                    {
                        MessageBox.Show("Thêm thành công");
                        if (er != err)
                        {
                            lblErr.Text = err;
                        }
                        HienThiDuLieuChiTietPhieuXuat(lblMaPhieuXuat.Text);
                        HienThiDSHangHoa();
                    }
                    if (er != err)
                    {
                        lblErr.Text = err;
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

            dgvCTPX.DataSource = dtChiTietPhieuXuat.DefaultView;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCTPX.SelectedRows.Count != 0)
            {
                if (bd.XoaCTPXTheoID(ref err, lblMaPhieuXuat.Text, dgvCTPX.SelectedRows[0].Cells["colMaHang"].Value.ToString()) != 1)
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
            HienThiDSHangHoa();
            HienThiDuLieuChiTietPhieuXuat(lblMaPhieuXuat.Text);
        }
    }
}
