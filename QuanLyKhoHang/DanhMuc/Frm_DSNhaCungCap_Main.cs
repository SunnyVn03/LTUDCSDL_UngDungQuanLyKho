using QuanLyKhoHang.BusinessLayer;
using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang.DanhMuc
{
    public partial class Frm_DSNhaCungCap_Main : Frm_Base
    {
        public Frm_DSNhaCungCap_Main()
        {
            InitializeComponent();
            Cls_Main.DinhDangDatagridView(dgv_NhaCungCap);
        }
        BLL_NhaCungCap bd;
        string err = string.Empty;
        DataTable dtNhaCungCap;

        private void Frm_DSNhaSX_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_NhaCungCap(Cls_Main.path);
            HienThiDuLieuNhaCungCap();
        }
        private void btnNapLai_Click(object sender, EventArgs e)
        {
            HienThiDuLieuNhaCungCap();
        }

        private void HienThiDuLieuNhaCungCap()
        {
            dtNhaCungCap = new DataTable();
            dtNhaCungCap = bd.LayDsNhaCungCap(ref err, "0");
            dgv_NhaCungCap.DataSource = dtNhaCungCap.DefaultView;
            foreach (DataColumn item in dtNhaCungCap.Columns)
            {
                cboThuocTinh.Items.Add(item.ColumnName);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_QuanLyNhaCungCap_Modifies frm = new Frm_QuanLyNhaCungCap_Modifies();
            frm.isAdd = true;
            frm.ShowDialog();
            HienThiDuLieuNhaCungCap();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (dgv_NhaCungCap.SelectedRows.Count != 0)
            {
                Frm_QuanLyNhaCungCap_Modifies frm = new Frm_QuanLyNhaCungCap_Modifies();
                DataGridViewRow row = dgv_NhaCungCap.SelectedRows[0];
                frm.nhaCungCap = new DTO.NhaCungCap();
                frm.nhaCungCap.MaNhaCungCap = row.Cells["colMaNhaCungCap"].Value.ToString();
                frm.nhaCungCap.TenNhaCungCap = row.Cells["colTenNhaCungCap"].Value.ToString();
                frm.nhaCungCap.DiaChi = row.Cells["colDiaChi"].Value.ToString();
                frm.nhaCungCap.DienThoai = row.Cells["colDienThoai"].Value.ToString();
                frm.nhaCungCap.Email = row.Cells["colEmail"].Value.ToString();

                frm.isAdd = false;
                frm.ShowDialog();
                HienThiDuLieuNhaCungCap();
            }
            else
            {
                MessageBox.Show("Chưa chọn hàng hoá");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv_NhaCungCap.SelectedRows.Count != 0)
            {
                if (bd.XoaNhaCungCapTheoID(ref err, int.Parse(dgv_NhaCungCap.SelectedRows[0].Cells["colMaNhaCungCap"].Value.ToString())) != 1)
                {
                    MessageBox.Show(err);
                }
            }
            else
            {
            MessageBox.Show("Chưa chọn nhà cung cấp.");
            }
            HienThiDuLieuNhaCungCap();
        }

        private void timKiem_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtNhaCungCap.DefaultView;
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                switch (cboThuocTinh.Text)
                {
                    case "MaNhaCungCap":
                        try
                            {
                            if(int.Parse(txtTimKiem.Text) > 0)
                            dv.RowFilter = string.Format("{0} >= {1}", cboThuocTinh.Text, txtTimKiem.Text);
                            break;
                        }

                        catch (Exception er)
                        {
                            MessageBox.Show("Chỉ nhập số");
                            break;
                        }
                    default:
                        dv.RowFilter = string.Format("{0} LIKE '%{1}%'", cboThuocTinh.Text, txtTimKiem.Text);
                        break;
                }

            }
            else
            {
                dv.RowFilter = "";
            }
        }
    }
}
