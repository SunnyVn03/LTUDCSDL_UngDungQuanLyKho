using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProThucHienFormDangNhap
{
    public class Cls_Main
    {
        //public static string path = string.Format(@"{0}/Connection.ini", Application.StartupPath);
        public static string path = "Data Source=tsukoyumi;Database=QuanLyKhoHang;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public static string tenNhanVien = string.Empty;
        public static string maNhanVien = string.Empty;

        public static void DinhDangDatagridView(DataGridView dgv)
        {
            dgv.Font = new Font("Arial", 12F, FontStyle.Regular);
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.DarkGray,
            };
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12F, FontStyle.Bold),
            };
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowTemplate.Height = 32;

        }

    }
}
