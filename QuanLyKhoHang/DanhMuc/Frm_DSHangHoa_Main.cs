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
    public partial class Frm_DSHangHoa_Main : Frm_Base
    {
        public Frm_DSHangHoa_Main()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            deDongTab();
        }
    }
}
