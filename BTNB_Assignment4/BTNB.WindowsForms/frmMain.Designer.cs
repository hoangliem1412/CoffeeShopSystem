namespace BTNB.WindowsForms
{
    partial class frmMain
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
            this.DanhSachNhanVienData = new System.Windows.Forms.DataGridView();
            this.TenNhanVienTextBox = new System.Windows.Forms.TextBox();
            this.TenNhanVienLabel = new System.Windows.Forms.Label();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.ThemNhanVienButton = new System.Windows.Forms.Button();
            this.SapXepButton = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoa_PhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrinhDo_ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTietDay_NgayCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhanTrangLowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVienData)).BeginInit();
            this.SuspendLayout();
            // 
            // DanhSachNhanVienData
            // 
            this.DanhSachNhanVienData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DanhSachNhanVienData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.HoTen,
            this.Khoa_PhongBan,
            this.TrinhDo_ChucVu,
            this.PhuCap,
            this.SoTietDay_NgayCong,
            this.TongLuong});
            this.DanhSachNhanVienData.Dock = System.Windows.Forms.DockStyle.Top;
            this.DanhSachNhanVienData.Location = new System.Drawing.Point(0, 0);
            this.DanhSachNhanVienData.Name = "DanhSachNhanVienData";
            this.DanhSachNhanVienData.Size = new System.Drawing.Size(759, 178);
            this.DanhSachNhanVienData.TabIndex = 0;
            // 
            // TenNhanVienTextBox
            // 
            this.TenNhanVienTextBox.Location = new System.Drawing.Point(94, 225);
            this.TenNhanVienTextBox.Name = "TenNhanVienTextBox";
            this.TenNhanVienTextBox.Size = new System.Drawing.Size(130, 20);
            this.TenNhanVienTextBox.TabIndex = 1;
            // 
            // TenNhanVienLabel
            // 
            this.TenNhanVienLabel.AutoSize = true;
            this.TenNhanVienLabel.Location = new System.Drawing.Point(12, 228);
            this.TenNhanVienLabel.Name = "TenNhanVienLabel";
            this.TenNhanVienLabel.Size = new System.Drawing.Size(76, 13);
            this.TenNhanVienLabel.TabIndex = 2;
            this.TenNhanVienLabel.Text = "Tên nhân viên";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(15, 259);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 3;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // ThemNhanVienButton
            // 
            this.ThemNhanVienButton.Location = new System.Drawing.Point(119, 259);
            this.ThemNhanVienButton.Name = "ThemNhanVienButton";
            this.ThemNhanVienButton.Size = new System.Drawing.Size(105, 23);
            this.ThemNhanVienButton.TabIndex = 4;
            this.ThemNhanVienButton.Text = "Thêm nhân viên";
            this.ThemNhanVienButton.UseVisualStyleBackColor = true;
            this.ThemNhanVienButton.Click += new System.EventHandler(this.ThemNhanVienButton_Click);
            // 
            // SapXepButton
            // 
            this.SapXepButton.Location = new System.Drawing.Point(249, 259);
            this.SapXepButton.Name = "SapXepButton";
            this.SapXepButton.Size = new System.Drawing.Size(75, 23);
            this.SapXepButton.TabIndex = 5;
            this.SapXepButton.Text = "Sấp xếp";
            this.SapXepButton.UseVisualStyleBackColor = true;
            this.SapXepButton.Click += new System.EventHandler(this.SapXepButton_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            // 
            // Khoa_PhongBan
            // 
            this.Khoa_PhongBan.DataPropertyName = "Khoa_PhongBan";
            this.Khoa_PhongBan.HeaderText = "Khoa/ PhongBan";
            this.Khoa_PhongBan.Name = "Khoa_PhongBan";
            // 
            // TrinhDo_ChucVu
            // 
            this.TrinhDo_ChucVu.DataPropertyName = "TenTrinhDo_ChucVu";
            this.TrinhDo_ChucVu.HeaderText = "Trình độ/ Chức vụ";
            this.TrinhDo_ChucVu.Name = "TrinhDo_ChucVu";
            // 
            // PhuCap
            // 
            this.PhuCap.DataPropertyName = "PhuCap";
            this.PhuCap.HeaderText = "Phụ cấp";
            this.PhuCap.Name = "PhuCap";
            // 
            // SoTietDay_NgayCong
            // 
            this.SoTietDay_NgayCong.DataPropertyName = "SoTietDay_SoNgayCong";
            this.SoTietDay_NgayCong.HeaderText = "Số tiết dạy/ Ngày công";
            this.SoTietDay_NgayCong.Name = "SoTietDay_NgayCong";
            // 
            // TongLuong
            // 
            this.TongLuong.DataPropertyName = "TongLuong";
            this.TongLuong.HeaderText = "Tổng lương";
            this.TongLuong.Name = "TongLuong";
            // 
            // PhanTrangLowLayoutPanel
            // 
            this.PhanTrangLowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PhanTrangLowLayoutPanel.Location = new System.Drawing.Point(0, 178);
            this.PhanTrangLowLayoutPanel.Name = "PhanTrangLowLayoutPanel";
            this.PhanTrangLowLayoutPanel.Size = new System.Drawing.Size(759, 30);
            this.PhanTrangLowLayoutPanel.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 296);
            this.Controls.Add(this.PhanTrangLowLayoutPanel);
            this.Controls.Add(this.SapXepButton);
            this.Controls.Add(this.ThemNhanVienButton);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.TenNhanVienLabel);
            this.Controls.Add(this.TenNhanVienTextBox);
            this.Controls.Add(this.DanhSachNhanVienData);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVienData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DanhSachNhanVienData;
        private System.Windows.Forms.TextBox TenNhanVienTextBox;
        private System.Windows.Forms.Label TenNhanVienLabel;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.Button ThemNhanVienButton;
        private System.Windows.Forms.Button SapXepButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoa_PhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrinhDo_ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTietDay_NgayCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongLuong;
        private System.Windows.Forms.FlowLayoutPanel PhanTrangLowLayoutPanel;
    }
}

