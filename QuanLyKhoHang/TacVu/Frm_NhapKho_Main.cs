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
    public partial class Frm_NhapKho_Main : Frm_Base
    {
        public Frm_NhapKho_Main()
        {
            InitializeComponent();
        }
        BLL_NhapKho bd;
        DataTable dtPhieuNhap;
        string err = string.Empty;

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            Frm_NhapKho_Modifies frm_QuanLyNhapHang_Modidies = new Frm_NhapKho_Modifies();
            frm_QuanLyNhapHang_Modidies.StartPosition = FormStartPosition.CenterScreen;
            frm_QuanLyNhapHang_Modidies.ShowDialog();
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            deDongTab();
        }
        private void LayDuLieuPhieuNhap(DateTime tuNgay, DateTime denNgay)
        {
            dtPhieuNhap = new DataTable();
            dtPhieuNhap = bd.LayDuLieuPhieuNhap(ref err, tuNgay, denNgay);

            dgvDanhSachPhieuNhap.DataSource = dtPhieuNhap.DefaultView;

            LayThuocTinhTrenLuoiToCombo();
        }

        private void LayThuocTinhTrenLuoiToCombo()
        {
            foreach (DataColumn item in dtPhieuNhap.Columns)
            {
                cboThuocTinh.Items.Add(item.ColumnName.ToString());
            }
        }

        private void Frm_NhapKho_Main_Load(object sender, EventArgs e)
        {
            Cls_Main.DinhDangDatagridView(dgvDanhSachPhieuNhap);
            bd = new BLL_NhapKho(Cls_Main.path);
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Không được lớn hơn ngày đích");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtPhieuNhap.DefaultView;
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                dv.RowFilter = string.Format("{0} like '%{1}%'", cboThuocTinh.Text, txtSearch.Text);
            }
            else
            {
                dv.RowFilter = "";
            }
        }

        private void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            LayDuLieuPhieuNhap(dtpTuNgay.Value, dtpDenNgay.Value);
        }
    }
}
