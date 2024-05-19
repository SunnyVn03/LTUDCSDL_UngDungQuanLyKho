namespace QuanLyKhoHang
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchHàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchNhàSảnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tácVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýXuấtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.CloseButtonOnTabsVisible = true;
            this.tabControl1.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = -1;
            this.tabControl1.Size = new System.Drawing.Size(1184, 730);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Text = "tabControl1";
            this.tabControl1.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabControl1_TabItemClose);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.tácVụToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchHàngHóaToolStripMenuItem,
            this.danhSáchNhàSảnXuấtToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(93, 25);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // danhSáchHàngHóaToolStripMenuItem
            // 
            this.danhSáchHàngHóaToolStripMenuItem.Name = "danhSáchHàngHóaToolStripMenuItem";
            this.danhSáchHàngHóaToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.danhSáchHàngHóaToolStripMenuItem.Text = "Danh sách hàng hóa";
            this.danhSáchHàngHóaToolStripMenuItem.Click += new System.EventHandler(this.danhSáchHàngHóaToolStripMenuItem_Click);
            // 
            // danhSáchNhàSảnXuấtToolStripMenuItem
            // 
            this.danhSáchNhàSảnXuấtToolStripMenuItem.Name = "danhSáchNhàSảnXuấtToolStripMenuItem";
            this.danhSáchNhàSảnXuấtToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.danhSáchNhàSảnXuấtToolStripMenuItem.Text = "Danh sách nhà sản xuất";
            this.danhSáchNhàSảnXuấtToolStripMenuItem.Click += new System.EventHandler(this.danhSáchNhàSảnXuấtToolStripMenuItem_Click);
            // 
            // tácVụToolStripMenuItem
            // 
            this.tácVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhậpHàngToolStripMenuItem,
            this.quảnLýXuấtHàngToolStripMenuItem});
            this.tácVụToolStripMenuItem.Name = "tácVụToolStripMenuItem";
            this.tácVụToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.tácVụToolStripMenuItem.Text = "Tác vụ";
            // 
            // quảnLýNhậpHàngToolStripMenuItem
            // 
            this.quảnLýNhậpHàngToolStripMenuItem.Name = "quảnLýNhậpHàngToolStripMenuItem";
            this.quảnLýNhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.quảnLýNhậpHàngToolStripMenuItem.Text = "Nhập kho";
            this.quảnLýNhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhậpHàngToolStripMenuItem_Click);
            // 
            // quảnLýXuấtHàngToolStripMenuItem
            // 
            this.quảnLýXuấtHàngToolStripMenuItem.Name = "quảnLýXuấtHàngToolStripMenuItem";
            this.quảnLýXuấtHàngToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.quảnLýXuấtHàngToolStripMenuItem.Text = "Xuất kho";
            this.quảnLýXuấtHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýXuấtHàngToolStripMenuItem_Click);
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoTồnKhoToolStripMenuItem});
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(154, 25);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo - Thống kê";
            // 
            // báoCáoTồnKhoToolStripMenuItem
            // 
            this.báoCáoTồnKhoToolStripMenuItem.Name = "báoCáoTồnKhoToolStripMenuItem";
            this.báoCáoTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.báoCáoTồnKhoToolStripMenuItem.Text = "Báo cáo tồn kho";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_Main";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.TabControl tabControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchHàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNhàSảnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tácVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýXuấtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTồnKhoToolStripMenuItem;
    }
}

