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
    public partial class Frm_XuatKho_Main : Frm_Base
    {
        public Frm_XuatKho_Main()
        {
            InitializeComponent();
        }
        BLL_XuatKho bd;
        DataTable dtPhieuXuat;
        string err = string.Empty;

        private void btnThemPhieuXuat_Click(object sender, EventArgs e)
        {
            Frm_XuatKho_Modifies frm_XuatKho_Modifies = new Frm_XuatKho_Modifies();
            frm_XuatKho_Modifies.StartPosition = FormStartPosition.CenterScreen;
            frm_XuatKho_Modifies.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            deDongTab();
        }

        private void Frm_XuatKho_Main_Load(object sender, EventArgs e)
        {
            Cls_Main.DinhDangDatagridView(dgvDanhSachPhieuXuat);
            bd = new BLL_XuatKho(Cls_Main.path);
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Không được lớn hơn ngày đích");
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value < dtpDenNgay.Value)
            {
                MessageBox.Show("Không được nhỏ hơn ngày bắt đầu");
            }
        }

        private void btnLayDuLieu_Click(object sender, EventArgs e)
        {
            LayDuLieuPhieuXuat(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void LayDuLieuPhieuXuat(DateTime tuNgay, DateTime denNgay)
        {
            dtPhieuXuat = new DataTable();
            dtPhieuXuat = bd.LayDuLieuPhieuXuat(ref err, tuNgay, denNgay);

            dgvDanhSachPhieuXuat.DataSource = dtPhieuXuat.DefaultView;

            LayThuocTinhTrenLuoiToCombo();
        }

        private void LayThuocTinhTrenLuoiToCombo()
        {
            foreach (DataColumn item in dtPhieuXuat.Columns)
            {
                cboThuocTinh.Items.Add(item.ColumnName.ToString());
            }
        }
    }
}
