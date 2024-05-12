﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyKhoHang.DanhMuc;

namespace QuanLyKhoHang
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            MoFormDangNhap();
        }

        private void MoFormDangNhap()
        {
            Frm_DangNhap frm_DangNhap = new Frm_DangNhap();
            frm_DangNhap.ShowDialog();
        }

        bool bKTraMotab = false;
        string sTieuDe;
        public Frm_Main frm_Main;

        public delegate void _deDongTab();
        public _deDongTab deDongTab;

        #region Các phương thức mở form
        private bool CheckOpenTab(string name)
        {
            for (int i = 0; i < tabControl1.Tabs.Count; i++)
            {
                if (tabControl1.Tabs[i].Text == name)
                {
                    tabControl1.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void vDongTab()
        {
            foreach (TabItem item in tabControl1.Tabs)
            {
                if (item.IsSelected)
                {
                    tabControl1.Tabs.Remove(item);
                    return;
                }
            }
        }

        private void OpenForm(bool statusOpen, string sTieuDe, Frm_Base frm)
        {
            bKTraMotab = statusOpen;
            this.sTieuDe = sTieuDe;
            if (!CheckOpenTab(sTieuDe))
            {
                TabItem t = tabControl1.CreateTab(sTieuDe);
                t.Name = frm.Name;

                frm.deDongTab = new Frm_Base._deDongTab(vDongTab);
                this.frm_Main = this;

                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;

                t.AttachedControl.Controls.Add(frm);
                frm.Show();

                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
        }
        #endregion

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoFormDangNhap();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void danhSáchHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Danh sách hàng hóa", new Frm_DSHangHoa_Main());
        }
    }
}
