namespace QuanLyNhanSu.Forms
{
    partial class frmEmployee
    {
        /// <summary>Biến thiết kế.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Giải phóng tài nguyên đang dùng.</summary>
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
        /// Phương thức bắt buộc của trình thiết kế - không sửa bằng tay nội dung
        /// bên trong, hãy dùng cửa sổ Designer của Visual Studio.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader colMa;
            System.Windows.Forms.ColumnHeader colTen;
            System.Windows.Forms.ColumnHeader colGioiTinh;
            System.Windows.Forms.ColumnHeader colNgaySinh;
            System.Windows.Forms.ColumnHeader colDienThoai;
            System.Windows.Forms.ColumnHeader colPhong;
            System.Windows.Forms.ColumnHeader colChucVu;
            System.Windows.Forms.ColumnHeader colLuong;
            System.Windows.Forms.ColumnHeader colTrangThai;
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvToChuc = new System.Windows.Forms.TreeView();
            this.lvNhanVien = new System.Windows.Forms.ListView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.nudPhepNam = new System.Windows.Forms.NumericUpDown();
            this.lblPhepNam = new System.Windows.Forms.Label();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.btnDoiAnh = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVaoLam = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboPhongBanInfo = new System.Windows.Forms.ComboBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboLocPhong = new System.Windows.Forms.ComboBox();
            this.lblLocPhong = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialogAnh = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhepNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvToChuc);
            this.splitContainer1.Panel1MinSize = 180;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvNhanVien);
            this.splitContainer1.Panel2.Controls.Add(this.panelBottom);
            this.splitContainer1.Panel2.Controls.Add(this.panelInfo);
            this.splitContainer1.Panel2.Controls.Add(this.panelHeader);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 700);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvToChuc
            // 
            this.tvToChuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvToChuc.HideSelection = false;
            this.tvToChuc.Location = new System.Drawing.Point(0, 0);
            this.tvToChuc.Name = "tvToChuc";
            this.tvToChuc.Size = new System.Drawing.Size(252, 700);
            this.tvToChuc.TabIndex = 0;
            this.tvToChuc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvToChuc_AfterSelect);
            // 
            // lvNhanVien
            // 
            colMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colGioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colNgaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colDienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colChucVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            colMa.Text = "Mã NV";
            colMa.Width = 95;
            colTen.Text = "Họ và tên";
            colTen.Width = 200;
            colGioiTinh.Text = "Giới tính";
            colGioiTinh.Width = 85;
            colNgaySinh.Text = "Ngày sinh";
            colNgaySinh.Width = 105;
            colDienThoai.Text = "Điện thoại";
            colDienThoai.Width = 115;
            colPhong.Text = "Phòng ban";
            colPhong.Width = 165;
            colChucVu.Text = "Chức vụ";
            colChucVu.Width = 130;
            colLuong.Text = "Lương cơ bản";
            colLuong.Width = 130;
            colTrangThai.Text = "Trạng thái";
            colTrangThai.Width = 110;
            this.lvNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colMa,
            colTen,
            colGioiTinh,
            colNgaySinh,
            colDienThoai,
            colPhong,
            colChucVu,
            colLuong,
            colTrangThai});
            this.lvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNhanVien.FullRowSelect = true;
            this.lvNhanVien.GridLines = true;
            this.lvNhanVien.HideSelection = false;
            this.lvNhanVien.Location = new System.Drawing.Point(0, 334);
            this.lvNhanVien.MultiSelect = false;
            this.lvNhanVien.Name = "lvNhanVien";
            this.lvNhanVien.Size = new System.Drawing.Size(892, 312);
            this.lvNhanVien.TabIndex = 0;
            this.lvNhanVien.UseCompatibleStateImageBehavior = false;
            this.lvNhanVien.View = System.Windows.Forms.View.Details;
            this.lvNhanVien.SelectedIndexChanged += new System.EventHandler(this.lvNhanVien_SelectedIndexChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnLamMoi);
            this.panelBottom.Controls.Add(this.btnHuy);
            this.panelBottom.Controls.Add(this.btnLuu);
            this.panelBottom.Controls.Add(this.btnXoa);
            this.panelBottom.Controls.Add(this.btnSua);
            this.panelBottom.Controls.Add(this.btnThem);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 646);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(892, 54);
            this.panelBottom.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(562, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(452, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 34);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(342, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 34);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(232, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 34);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(122, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 34);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 34);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.cboTrangThai);
            this.panelInfo.Controls.Add(this.lblTrangThai);
            this.panelInfo.Controls.Add(this.nudPhepNam);
            this.panelInfo.Controls.Add(this.lblPhepNam);
            this.panelInfo.Controls.Add(this.btnXoaAnh);
            this.panelInfo.Controls.Add(this.btnDoiAnh);
            this.panelInfo.Controls.Add(this.picAnh);
            this.panelInfo.Controls.Add(this.txtLuong);
            this.panelInfo.Controls.Add(this.lblLuong);
            this.panelInfo.Controls.Add(this.dtpNgayVaoLam);
            this.panelInfo.Controls.Add(this.lblNgayVaoLam);
            this.panelInfo.Controls.Add(this.cboChucVu);
            this.panelInfo.Controls.Add(this.lblChucVu);
            this.panelInfo.Controls.Add(this.cboPhongBanInfo);
            this.panelInfo.Controls.Add(this.lblPhongBan);
            this.panelInfo.Controls.Add(this.txtDiaChi);
            this.panelInfo.Controls.Add(this.lblDiaChi);
            this.panelInfo.Controls.Add(this.txtEmail);
            this.panelInfo.Controls.Add(this.lblEmail);
            this.panelInfo.Controls.Add(this.txtDienThoai);
            this.panelInfo.Controls.Add(this.lblDienThoai);
            this.panelInfo.Controls.Add(this.dtpNgaySinh);
            this.panelInfo.Controls.Add(this.lblNgaySinh);
            this.panelInfo.Controls.Add(this.cboGioiTinh);
            this.panelInfo.Controls.Add(this.lblGioiTinh);
            this.panelInfo.Controls.Add(this.txtHoTen);
            this.panelInfo.Controls.Add(this.lblHoTen);
            this.panelInfo.Controls.Add(this.txtMaNV);
            this.panelInfo.Controls.Add(this.lblMaNV);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 50);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(892, 284);
            this.panelInfo.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(320, 242);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(150, 23);
            this.cboTrangThai.TabIndex = 28;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(230, 246);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(66, 15);
            this.lblTrangThai.TabIndex = 27;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // nudPhepNam
            // 
            this.nudPhepNam.Location = new System.Drawing.Point(115, 243);
            this.nudPhepNam.Maximum = new decimal(new int[] { 30, 0, 0, 0});
            this.nudPhepNam.Name = "nudPhepNam";
            this.nudPhepNam.Size = new System.Drawing.Size(80, 23);
            this.nudPhepNam.TabIndex = 26;
            this.nudPhepNam.Value = new decimal(new int[] { 12, 0, 0, 0});
            // 
            // lblPhepNam
            // 
            this.lblPhepNam.AutoSize = true;
            this.lblPhepNam.Location = new System.Drawing.Point(15, 246);
            this.lblPhepNam.Name = "lblPhepNam";
            this.lblPhepNam.Size = new System.Drawing.Size(88, 15);
            this.lblPhepNam.TabIndex = 25;
            this.lblPhepNam.Text = "Phép năm (ngày):";
            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.Location = new System.Drawing.Point(690, 186);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(130, 30);
            this.btnXoaAnh.TabIndex = 24;
            this.btnXoaAnh.Text = "Xóa ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = true;
            this.btnXoaAnh.Click += new System.EventHandler(this.btnXoaAnh_Click);
            // 
            // btnDoiAnh
            // 
            this.btnDoiAnh.Location = new System.Drawing.Point(690, 152);
            this.btnDoiAnh.Name = "btnDoiAnh";
            this.btnDoiAnh.Size = new System.Drawing.Size(130, 30);
            this.btnDoiAnh.TabIndex = 23;
            this.btnDoiAnh.Text = "Đổi ảnh...";
            this.btnDoiAnh.UseVisualStyleBackColor = true;
            this.btnDoiAnh.Click += new System.EventHandler(this.btnDoiAnh_Click);
            // 
            // picAnh
            // 
            this.picAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(690, 14);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(130, 130);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 22;
            this.picAnh.TabStop = false;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(430, 204);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(200, 23);
            this.txtLuong.TabIndex = 21;
            this.txtLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(330, 208);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(82, 15);
            this.lblLuong.TabIndex = 20;
            this.lblLuong.Text = "Lương cơ bản:";
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(115, 204);
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(190, 23);
            this.dtpNgayVaoLam.TabIndex = 19;
            // 
            // lblNgayVaoLam
            // 
            this.lblNgayVaoLam.AutoSize = true;
            this.lblNgayVaoLam.Location = new System.Drawing.Point(15, 208);
            this.lblNgayVaoLam.Name = "lblNgayVaoLam";
            this.lblNgayVaoLam.Size = new System.Drawing.Size(84, 15);
            this.lblNgayVaoLam.TabIndex = 18;
            this.lblNgayVaoLam.Text = "Ngày vào làm:";
            // 
            // cboChucVu
            // 
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(430, 166);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(200, 23);
            this.cboChucVu.TabIndex = 17;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(330, 170);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(54, 15);
            this.lblChucVu.TabIndex = 16;
            this.lblChucVu.Text = "Chức vụ:";
            // 
            // cboPhongBanInfo
            // 
            this.cboPhongBanInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBanInfo.FormattingEnabled = true;
            this.cboPhongBanInfo.Location = new System.Drawing.Point(115, 166);
            this.cboPhongBanInfo.Name = "cboPhongBanInfo";
            this.cboPhongBanInfo.Size = new System.Drawing.Size(190, 23);
            this.cboPhongBanInfo.TabIndex = 15;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Location = new System.Drawing.Point(15, 170);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(68, 15);
            this.lblPhongBan.TabIndex = 14;
            this.lblPhongBan.Text = "Phòng ban:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(115, 128);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(515, 23);
            this.txtDiaChi.TabIndex = 13;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 132);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(46, 15);
            this.lblDiaChi.TabIndex = 12;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(430, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(330, 94);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(115, 90);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(190, 23);
            this.txtDienThoai.TabIndex = 9;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(15, 94);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(66, 15);
            this.lblDienThoai.TabIndex = 8;
            this.lblDienThoai.Text = "Điện thoại:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(430, 52);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 23);
            this.dtpNgaySinh.TabIndex = 7;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(330, 56);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(62, 15);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(115, 52);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(190, 23);
            this.cboGioiTinh.TabIndex = 5;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 56);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(54, 15);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(430, 14);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 23);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(330, 18);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(61, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ và tên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(115, 14);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(190, 23);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(15, 18);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(79, 15);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã nhân viên:";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnTimKiem);
            this.panelHeader.Controls.Add(this.txtTimKiem);
            this.panelHeader.Controls.Add(this.lblTimKiem);
            this.panelHeader.Controls.Add(this.cboLocPhong);
            this.panelHeader.Controls.Add(this.lblLocPhong);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(892, 50);
            this.panelHeader.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(648, 11);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(420, 13);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(220, 23);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(325, 17);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(85, 15);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm theo tên:";
            // 
            // cboLocPhong
            // 
            this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocPhong.FormattingEnabled = true;
            this.cboLocPhong.Location = new System.Drawing.Point(85, 13);
            this.cboLocPhong.Name = "cboLocPhong";
            this.cboLocPhong.Size = new System.Drawing.Size(220, 23);
            this.cboLocPhong.TabIndex = 1;
            this.cboLocPhong.SelectedIndexChanged += new System.EventHandler(this.cboLocPhong_SelectedIndexChanged);
            // 
            // lblLocPhong
            // 
            this.lblLocPhong.AutoSize = true;
            this.lblLocPhong.Location = new System.Drawing.Point(12, 17);
            this.lblLocPhong.Name = "lblLocPhong";
            this.lblLocPhong.Size = new System.Drawing.Size(68, 15);
            this.lblLocPhong.TabIndex = 0;
            this.lblLocPhong.Text = "Phòng ban:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // openFileDialogAnh
            // 
            this.openFileDialogAnh.Filter = "Tập tin ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tập tin|*.*";
            this.openFileDialogAnh.Title = "Chọn ảnh nhân viên";
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hồ sơ nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhepNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvToChuc;
        private System.Windows.Forms.ListView lvNhanVien;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.ComboBox cboPhongBanInfo;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Label lblNgayVaoLam;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnDoiAnh;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Label lblPhepNam;
        private System.Windows.Forms.NumericUpDown nudPhepNam;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAnh;
    }
}
