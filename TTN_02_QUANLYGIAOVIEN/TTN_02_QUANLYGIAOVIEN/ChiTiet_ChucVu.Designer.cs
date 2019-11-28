namespace QUAN_LY_GIAO_VIEN
{
    partial class ChiTiet_ChucVu
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
            this.lbMaGV_CV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbHienTai_CV = new System.Windows.Forms.Label();
            this.lbLichSu_CV = new System.Windows.Forms.Label();
            this.dataGridHienTai_CV = new System.Windows.Forms.DataGridView();
            this.MaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TG_BatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLichSu_CV = new System.Windows.Forms.DataGridView();
            this._MaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TG_BatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TG_KetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHienTai_CV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLichSu_CV)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMaGV_CV
            // 
            this.lbMaGV_CV.AutoSize = true;
            this.lbMaGV_CV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaGV_CV.Location = new System.Drawing.Point(12, 31);
            this.lbMaGV_CV.Name = "lbMaGV_CV";
            this.lbMaGV_CV.Size = new System.Drawing.Size(132, 24);
            this.lbMaGV_CV.TabIndex = 0;
            this.lbMaGV_CV.Text = "Mã giáo viên:";
            this.lbMaGV_CV.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // lbHienTai_CV
            // 
            this.lbHienTai_CV.AutoSize = true;
            this.lbHienTai_CV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHienTai_CV.Location = new System.Drawing.Point(12, 92);
            this.lbHienTai_CV.Name = "lbHienTai_CV";
            this.lbHienTai_CV.Size = new System.Drawing.Size(74, 22);
            this.lbHienTai_CV.TabIndex = 2;
            this.lbHienTai_CV.Text = "Hiện tại";
            // 
            // lbLichSu_CV
            // 
            this.lbLichSu_CV.AutoSize = true;
            this.lbLichSu_CV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLichSu_CV.Location = new System.Drawing.Point(12, 271);
            this.lbLichSu_CV.Name = "lbLichSu_CV";
            this.lbLichSu_CV.Size = new System.Drawing.Size(70, 22);
            this.lbLichSu_CV.TabIndex = 3;
            this.lbLichSu_CV.Text = "Lịch sử";
            // 
            // dataGridHienTai_CV
            // 
            this.dataGridHienTai_CV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHienTai_CV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHienTai_CV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaGV,
            this.HoTen,
            this.ChucVu,
            this.TG_BatDau,
            this.DonVi});
            this.dataGridHienTai_CV.Location = new System.Drawing.Point(12, 117);
            this.dataGridHienTai_CV.Name = "dataGridHienTai_CV";
            this.dataGridHienTai_CV.Size = new System.Drawing.Size(989, 116);
            this.dataGridHienTai_CV.TabIndex = 4;
            // 
            // MaGV
            // 
            this.MaGV.DataPropertyName = "MaGV";
            this.MaGV.HeaderText = "Mã giáo viên";
            this.MaGV.Name = "MaGV";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.Name = "ChucVu";
            // 
            // TG_BatDau
            // 
            this.TG_BatDau.DataPropertyName = "TG_BatDau";
            this.TG_BatDau.HeaderText = "Thời gian bắt đầu";
            this.TG_BatDau.Name = "TG_BatDau";
            // 
            // DonVi
            // 
            this.DonVi.DataPropertyName = "DonVi";
            this.DonVi.HeaderText = "Đơn vị bổ nhiệm";
            this.DonVi.Name = "DonVi";
            // 
            // dataGridLichSu_CV
            // 
            this.dataGridLichSu_CV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLichSu_CV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLichSu_CV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._MaGV,
            this._HoTen,
            this._ChucVu,
            this._TG_BatDau,
            this._TG_KetThuc,
            this._DonVi});
            this.dataGridLichSu_CV.Location = new System.Drawing.Point(12, 298);
            this.dataGridLichSu_CV.Name = "dataGridLichSu_CV";
            this.dataGridLichSu_CV.Size = new System.Drawing.Size(989, 192);
            this.dataGridLichSu_CV.TabIndex = 5;
            // 
            // _MaGV
            // 
            this._MaGV.DataPropertyName = "MaGV";
            this._MaGV.HeaderText = "Mã giáo viên";
            this._MaGV.Name = "_MaGV";
            // 
            // _HoTen
            // 
            this._HoTen.DataPropertyName = "HoTen";
            this._HoTen.HeaderText = "Họ tên";
            this._HoTen.Name = "_HoTen";
            // 
            // _ChucVu
            // 
            this._ChucVu.DataPropertyName = "ChucVu";
            this._ChucVu.HeaderText = "Chức vụ";
            this._ChucVu.Name = "_ChucVu";
            // 
            // _TG_BatDau
            // 
            this._TG_BatDau.DataPropertyName = "TG_BatDau";
            this._TG_BatDau.HeaderText = "Thời gian bắt đầu";
            this._TG_BatDau.Name = "_TG_BatDau";
            // 
            // _TG_KetThuc
            // 
            this._TG_KetThuc.DataPropertyName = "TG_KetThuc";
            this._TG_KetThuc.HeaderText = "Thời gian kết thúc";
            this._TG_KetThuc.Name = "_TG_KetThuc";
            // 
            // _DonVi
            // 
            this._DonVi.DataPropertyName = "DonVi";
            this._DonVi.HeaderText = "Đơn vị bổ nhiệm";
            this._DonVi.Name = "_DonVi";
            // 
            // ChiTiet_ChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 520);
            this.Controls.Add(this.dataGridLichSu_CV);
            this.Controls.Add(this.dataGridHienTai_CV);
            this.Controls.Add(this.lbLichSu_CV);
            this.Controls.Add(this.lbHienTai_CV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMaGV_CV);
            this.Name = "ChiTiet_ChucVu";
            this.Text = "ChiTiet_ChucVu";
            this.Load += new System.EventHandler(this.ChiTiet_ChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHienTai_CV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLichSu_CV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaGV_CV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbHienTai_CV;
        private System.Windows.Forms.Label lbLichSu_CV;
        private System.Windows.Forms.DataGridView dataGridHienTai_CV;
        private System.Windows.Forms.DataGridView dataGridLichSu_CV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TG_BatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn _MaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TG_BatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TG_KetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _DonVi;
    }
}