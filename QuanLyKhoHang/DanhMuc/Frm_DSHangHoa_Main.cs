using QuanLyHangHoa.BusinessLayer;
using QuanLyKhoHang.DTO;
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
            HienThiDSHangHoa();
        }

        private void HienThiDSHangHoa()
        {
            try
            {
                dtHangHoa = new DataTable();
                dtHangHoa = bd.LayDSHangHoa(ref err, "0");

                dsHangHoa.DataSource = dtHangHoa.DefaultView;
                foreach (DataColumn item in dtHangHoa.Columns)
                {
                    cboThuocTinh.Items.Add(item.ColumnName);
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                lblErr.Text = err;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_QuanLyHangHoa_Modifies frm = new Frm_QuanLyHangHoa_Modifies();
            frm.isAdd = true;
            frm.ShowDialog();
            HienThiDSHangHoa();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dsHangHoa.SelectedRows.Count != 0)
            {
                Frm_QuanLyHangHoa_Modifies frm = new Frm_QuanLyHangHoa_Modifies();
                DataGridViewRow row = dsHangHoa.SelectedRows[0];
                frm.hangHoa = new DTO.HangHoa();
                frm.hangHoa.MaHang = row.Cells["colMaHang"].Value.ToString();
                frm.hangHoa.TenHang = row.Cells["colTenHang"].Value.ToString();
                frm.hangHoa.LoaiHang = row.Cells["colLoaiHang"].Value.ToString();
                frm.hangHoa.SoLuongTon = int.Parse(row.Cells["colSoLuongTon"].Value.ToString());
                frm.hangHoa.MaNhaCungCap = int.Parse(row.Cells["colMaNhaCungCap"].Value.ToString());
                
                frm.isAdd = false;
                frm.ShowDialog();
                HienThiDSHangHoa();
            }else
            {
                MessageBox.Show("Chưa chọn hàng hoá");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dsHangHoa.SelectedRows.Count != 0)
            {
                if (bd.XoaHangHoaTheoID(ref err, dsHangHoa.SelectedRows[0].Cells["colMaHang"].Value.ToString()) != 1)
                {
                    MessageBox.Show(err);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn hàng hoá.");
            }
            HienThiDSHangHoa();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtHangHoa.DefaultView;
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                switch (cboThuocTinh.Text)
                {
                    case "SoLuongTon":
                        try
                        {
                            if (int.Parse(txtTimKiem.Text) > 0)
                                dv.RowFilter = string.Format("{0} >= {1}", cboThuocTinh.Text, txtTimKiem.Text);
                            break;
                        }

                        catch (Exception er)
                        {
                            MessageBox.Show("Chỉ nhập số");
                            break;
                        }
                    case "MaHang":
                        try
                        {
                            if (int.Parse(txtTimKiem.Text) > 0)
                                dv.RowFilter = string.Format("{0} >= {1}", cboThuocTinh.Text, txtTimKiem.Text);
                            break;
                        }

                        catch (Exception er)
                        {
                            MessageBox.Show("Chỉ nhập số");
                            break;
                        }
                    case "MaNhaCungCap":
                        try
                        {
                            if (int.Parse(txtTimKiem.Text) > 0)
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
