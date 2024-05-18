using QuanLyKhoHang.Properties;

namespace QuanLyKhoHang.DanhMuc
{
    partial class Frm_DSNhaCungCap_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DSNhaCungCap_Main));
            this.dgv_NhaCungCap = new System.Windows.Forms.DataGridView();
            this.colMaNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNapLai = new System.Windows.Forms.ToolStripButton();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.txtTimKiem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.cboThuocTinh = new System.Windows.Forms.ToolStripComboBox();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhaCungCap)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_NhaCungCap
            // 
            this.dgv_NhaCungCap.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_NhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhaCungCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNhaCungCap,
            this.colTenNhaCungCap,
            this.colDiaChi,
            this.colEmail,
            this.colDienThoai});
            this.dgv_NhaCungCap.Location = new System.Drawing.Point(0, 39);
            this.dgv_NhaCungCap.Name = "dgv_NhaCungCap";
            this.dgv_NhaCungCap.ReadOnly = true;
            this.dgv_NhaCungCap.RowHeadersWidth = 51;
            this.dgv_NhaCungCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NhaCungCap.Size = new System.Drawing.Size(1180, 690);
            this.dgv_NhaCungCap.TabIndex = 3;
            // 
            // colMaNhaCungCap
            // 
            this.colMaNhaCungCap.DataPropertyName = "MaNhaCungCap";
            this.colMaNhaCungCap.HeaderText = "Mã nhà cung cấp";
            this.colMaNhaCungCap.MinimumWidth = 6;
            this.colMaNhaCungCap.Name = "colMaNhaCungCap";
            this.colMaNhaCungCap.ReadOnly = true;
            this.colMaNhaCungCap.Width = 125;
            // 
            // colTenNhaCungCap
            // 
            this.colTenNhaCungCap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.colTenNhaCungCap.HeaderText = "Tên nhà cung cấp";
            this.colTenNhaCungCap.MinimumWidth = 6;
            this.colTenNhaCungCap.Name = "colTenNhaCungCap";
            this.colTenNhaCungCap.ReadOnly = true;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDiaChi.DataPropertyName = "DiaChi";
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.MinimumWidth = 6;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 125;
            // 
            // colDienThoai
            // 
            this.colDienThoai.DataPropertyName = "DienThoai";
            this.colDienThoai.HeaderText = "Số điện thoại";
            this.colDienThoai.MinimumWidth = 6;
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.ReadOnly = true;
            this.colDienThoai.Width = 125;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNapLai,
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.toolStripButton1,
            this.txtTimKiem,
            this.toolStripButton4,
            this.cboThuocTinh,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1180, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNapLai
            // 
            this.btnNapLai.AutoSize = false;
            this.btnNapLai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNapLai.Image = ((System.Drawing.Image)(resources.GetObject("btnNapLai.Image")));
            this.btnNapLai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNapLai.Name = "btnNapLai";
            this.btnNapLai.Size = new System.Drawing.Size(100, 25);
            this.btnNapLai.Text = "Nạp lại";
            this.btnNapLai.Click += new System.EventHandler(this.btnNapLai_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = false;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 25);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = false;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 25);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = false;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 25);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(99, 32);
            this.toolStripButton1.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.SystemColors.Control;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 35);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.timKiem_TextChanged);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(100, 32);
            this.toolStripButton4.Text = "Phân loại:";
            // 
            // cboThuocTinh
            // 
            this.cboThuocTinh.Name = "cboThuocTinh";
            this.cboThuocTinh.Size = new System.Drawing.Size(121, 35);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 32);
            this.btnThoat.Text = "Thoát";
            // 
            // Frm_DSNhaCungCap_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.dgv_NhaCungCap);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_DSNhaCungCap_Main";
            this.Text = "Frm_DSNhaSX_Main";
            this.Load += new System.EventHandler(this.Frm_DSNhaSX_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhaCungCap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_NhaCungCap;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripTextBox txtTimKiem;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripButton btnNapLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDienThoai;
        private System.Windows.Forms.ToolStripComboBox cboThuocTinh;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}