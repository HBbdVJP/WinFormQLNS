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
            components = new System.ComponentModel.Container();
            colMa = new ColumnHeader();
            colTen = new ColumnHeader();
            colGioiTinh = new ColumnHeader();
            colNgaySinh = new ColumnHeader();
            colDienThoai = new ColumnHeader();
            colPhong = new ColumnHeader();
            colChucVu = new ColumnHeader();
            colLuong = new ColumnHeader();
            colTrangThai = new ColumnHeader();
            splitContainer1 = new SplitContainer();
            tvToChuc = new TreeView();
            lvNhanVien = new ListView();
            panelBottom = new Panel();
            btnLamMoi = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panelInfo = new Panel();
            nudPhepNam = new NumericUpDown();
            lblPhepNam = new Label();
            btnXoaAnh = new Button();
            btnDoiAnh = new Button();
            picAnh = new PictureBox();
            txtLuong = new TextBox();
            lblLuong = new Label();
            dtpNgayVaoLam = new DateTimePicker();
            lblNgayVaoLam = new Label();
            cboChucVu = new ComboBox();
            lblChucVu = new Label();
            cboPhongBanInfo = new ComboBox();
            lblPhongBan = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtDienThoai = new TextBox();
            lblDienThoai = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
            lblGioiTinh = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            panelHeader = new Panel();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            cboLocPhong = new ComboBox();
            lblLocPhong = new Label();
            errorProvider1 = new ErrorProvider(components);
            openFileDialogAnh = new OpenFileDialog();
            cboGioiTinh = new ComboBox();
            btnUpdateNhanVien = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelBottom.SuspendLayout();
            panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhepNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // colMa
            // 
            colMa.Text = "Mã NV";
            colMa.Width = 95;
            // 
            // colTen
            // 
            colTen.Text = "Họ và tên";
            colTen.Width = 200;
            // 
            // colGioiTinh
            // 
            colGioiTinh.Text = "Giới tính";
            colGioiTinh.Width = 85;
            // 
            // colNgaySinh
            // 
            colNgaySinh.Text = "Ngày sinh";
            colNgaySinh.Width = 105;
            // 
            // colDienThoai
            // 
            colDienThoai.Text = "Điện thoại";
            colDienThoai.Width = 115;
            // 
            // colPhong
            // 
            colPhong.Text = "Phòng ban";
            colPhong.Width = 165;
            // 
            // colChucVu
            // 
            colChucVu.Text = "Chức vụ";
            colChucVu.Width = 130;
            // 
            // colLuong
            // 
            colLuong.Text = "Lương cơ bản";
            colLuong.Width = 130;
            // 
            // colTrangThai
            // 
            colTrangThai.Text = "Trạng thái";
            colTrangThai.Width = 110;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvToChuc);
            splitContainer1.Panel1MinSize = 180;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvNhanVien);
            splitContainer1.Panel2.Controls.Add(panelBottom);
            splitContainer1.Panel2.Controls.Add(panelInfo);
            splitContainer1.Panel2.Controls.Add(panelHeader);
            splitContainer1.Size = new Size(1314, 933);
            splitContainer1.SplitterDistance = 287;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // tvToChuc
            // 
            tvToChuc.Dock = DockStyle.Fill;
            tvToChuc.HideSelection = false;
            tvToChuc.Location = new Point(0, 0);
            tvToChuc.Margin = new Padding(3, 4, 3, 4);
            tvToChuc.Name = "tvToChuc";
            tvToChuc.Size = new Size(287, 933);
            tvToChuc.TabIndex = 0;
            // 
            // lvNhanVien
            // 
            lvNhanVien.Columns.AddRange(new ColumnHeader[] { colMa, colTen, colGioiTinh, colNgaySinh, colDienThoai, colPhong, colChucVu, colLuong, colTrangThai });
            lvNhanVien.Dock = DockStyle.Fill;
            lvNhanVien.FullRowSelect = true;
            lvNhanVien.GridLines = true;
            lvNhanVien.Location = new Point(0, 446);
            lvNhanVien.Margin = new Padding(3, 4, 3, 4);
            lvNhanVien.MultiSelect = false;
            lvNhanVien.Name = "lvNhanVien";
            lvNhanVien.Size = new Size(1020, 415);
            lvNhanVien.TabIndex = 0;
            lvNhanVien.UseCompatibleStateImageBehavior = false;
            lvNhanVien.View = View.Details;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnHuy);
            panelBottom.Controls.Add(btnLuu);
            panelBottom.Controls.Add(btnXoa);
            panelBottom.Controls.Add(btnSua);
            panelBottom.Controls.Add(btnThem);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 861);
            panelBottom.Margin = new Padding(3, 4, 3, 4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1020, 72);
            panelBottom.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(642, 13);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(126, 45);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(517, 13);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(114, 45);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(391, 13);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(114, 45);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(265, 13);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(139, 13);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(14, 13);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(btnUpdateNhanVien);
            panelInfo.Controls.Add(nudPhepNam);
            panelInfo.Controls.Add(lblPhepNam);
            panelInfo.Controls.Add(btnXoaAnh);
            panelInfo.Controls.Add(btnDoiAnh);
            panelInfo.Controls.Add(picAnh);
            panelInfo.Controls.Add(txtLuong);
            panelInfo.Controls.Add(lblLuong);
            panelInfo.Controls.Add(dtpNgayVaoLam);
            panelInfo.Controls.Add(lblNgayVaoLam);
            panelInfo.Controls.Add(cboChucVu);
            panelInfo.Controls.Add(lblChucVu);
            panelInfo.Controls.Add(cboPhongBanInfo);
            panelInfo.Controls.Add(lblPhongBan);
            panelInfo.Controls.Add(txtDiaChi);
            panelInfo.Controls.Add(lblDiaChi);
            panelInfo.Controls.Add(txtEmail);
            panelInfo.Controls.Add(lblEmail);
            panelInfo.Controls.Add(txtDienThoai);
            panelInfo.Controls.Add(lblDienThoai);
            panelInfo.Controls.Add(dtpNgaySinh);
            panelInfo.Controls.Add(lblNgaySinh);
            panelInfo.Controls.Add(cboGioiTinh);
            panelInfo.Controls.Add(lblGioiTinh);
            panelInfo.Controls.Add(txtHoTen);
            panelInfo.Controls.Add(lblHoTen);
            panelInfo.Controls.Add(txtMaNV);
            panelInfo.Controls.Add(lblMaNV);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 67);
            panelInfo.Margin = new Padding(3, 4, 3, 4);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(1020, 379);
            panelInfo.TabIndex = 1;
            // 
            // nudPhepNam
            // 
            nudPhepNam.Location = new Point(147, 321);
            nudPhepNam.Margin = new Padding(3, 4, 3, 4);
            nudPhepNam.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudPhepNam.Name = "nudPhepNam";
            nudPhepNam.ReadOnly = true;
            nudPhepNam.Size = new Size(201, 27);
            nudPhepNam.TabIndex = 26;
            nudPhepNam.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblPhepNam
            // 
            lblPhepNam.AutoSize = true;
            lblPhepNam.Location = new Point(17, 323);
            lblPhepNam.Name = "lblPhepNam";
            lblPhepNam.Size = new Size(124, 20);
            lblPhepNam.TabIndex = 25;
            lblPhepNam.Text = "Phép năm (ngày):";
            // 
            // btnXoaAnh
            // 
            btnXoaAnh.Location = new Point(789, 248);
            btnXoaAnh.Margin = new Padding(3, 4, 3, 4);
            btnXoaAnh.Name = "btnXoaAnh";
            btnXoaAnh.Size = new Size(149, 40);
            btnXoaAnh.TabIndex = 24;
            btnXoaAnh.Text = "Xóa ảnh";
            btnXoaAnh.UseVisualStyleBackColor = true;
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.Location = new Point(789, 203);
            btnDoiAnh.Margin = new Padding(3, 4, 3, 4);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(149, 40);
            btnDoiAnh.TabIndex = 23;
            btnDoiAnh.Text = "Đổi ảnh...";
            btnDoiAnh.UseVisualStyleBackColor = true;
            // 
            // picAnh
            // 
            picAnh.BackColor = Color.WhiteSmoke;
            picAnh.BorderStyle = BorderStyle.FixedSingle;
            picAnh.Location = new Point(789, 19);
            picAnh.Margin = new Padding(3, 4, 3, 4);
            picAnh.Name = "picAnh";
            picAnh.Size = new Size(148, 173);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.TabIndex = 22;
            picAnh.TabStop = false;
            // 
            // txtLuong
            // 
            txtLuong.Location = new Point(491, 272);
            txtLuong.Margin = new Padding(3, 4, 3, 4);
            txtLuong.Name = "txtLuong";
            txtLuong.ReadOnly = true;
            txtLuong.Size = new Size(228, 27);
            txtLuong.TabIndex = 21;
            txtLuong.TextAlign = HorizontalAlignment.Right;
            // 
            // lblLuong
            // 
            lblLuong.AutoSize = true;
            lblLuong.Location = new Point(377, 277);
            lblLuong.Name = "lblLuong";
            lblLuong.Size = new Size(103, 20);
            lblLuong.TabIndex = 20;
            lblLuong.Text = "Lương cơ bản:";
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            dtpNgayVaoLam.Enabled = false;
            dtpNgayVaoLam.Format = DateTimePickerFormat.Custom;
            dtpNgayVaoLam.Location = new Point(131, 272);
            dtpNgayVaoLam.Margin = new Padding(3, 4, 3, 4);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(217, 27);
            dtpNgayVaoLam.TabIndex = 19;
            // 
            // lblNgayVaoLam
            // 
            lblNgayVaoLam.AutoSize = true;
            lblNgayVaoLam.Location = new Point(17, 277);
            lblNgayVaoLam.Name = "lblNgayVaoLam";
            lblNgayVaoLam.Size = new Size(104, 20);
            lblNgayVaoLam.TabIndex = 18;
            lblNgayVaoLam.Text = "Ngày vào làm:";
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Enabled = false;
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(491, 221);
            cboChucVu.Margin = new Padding(3, 4, 3, 4);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(228, 28);
            cboChucVu.TabIndex = 17;
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(377, 227);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(64, 20);
            lblChucVu.TabIndex = 16;
            lblChucVu.Text = "Chức vụ:";
            // 
            // cboPhongBanInfo
            // 
            cboPhongBanInfo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhongBanInfo.Enabled = false;
            cboPhongBanInfo.FormattingEnabled = true;
            cboPhongBanInfo.Location = new Point(131, 221);
            cboPhongBanInfo.Margin = new Padding(3, 4, 3, 4);
            cboPhongBanInfo.Name = "cboPhongBanInfo";
            cboPhongBanInfo.Size = new Size(217, 28);
            cboPhongBanInfo.TabIndex = 15;
            // 
            // lblPhongBan
            // 
            lblPhongBan.AutoSize = true;
            lblPhongBan.Location = new Point(17, 227);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Size = new Size(83, 20);
            lblPhongBan.TabIndex = 14;
            lblPhongBan.Text = "Phòng ban:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(131, 171);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.Size = new Size(588, 27);
            txtDiaChi.TabIndex = 13;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(17, 176);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(58, 20);
            lblDiaChi.TabIndex = 12;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(491, 120);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(228, 27);
            txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(377, 125);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(131, 120);
            txtDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.ReadOnly = true;
            txtDienThoai.Size = new Size(217, 27);
            txtDienThoai.TabIndex = 9;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(17, 125);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(81, 20);
            lblDienThoai.TabIndex = 8;
            lblDienThoai.Text = "Điện thoại:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Enabled = false;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(491, 69);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(228, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(377, 75);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(77, 20);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(17, 75);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(68, 20);
            lblGioiTinh.TabIndex = 4;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(491, 19);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(228, 27);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(377, 24);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(76, 20);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên:";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(131, 19);
            txtMaNV.Margin = new Padding(3, 4, 3, 4);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(217, 27);
            txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(17, 24);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(100, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã nhân viên:";
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnTimKiem);
            panelHeader.Controls.Add(txtTimKiem);
            panelHeader.Controls.Add(lblTimKiem);
            panelHeader.Controls.Add(cboLocPhong);
            panelHeader.Controls.Add(lblLocPhong);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1020, 67);
            panelHeader.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(741, 15);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 37);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(480, 17);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(251, 27);
            txtTimKiem.TabIndex = 3;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(371, 23);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(96, 20);
            lblTimKiem.TabIndex = 2;
            lblTimKiem.Text = "Tìm theo tên:";
            // 
            // cboLocPhong
            // 
            cboLocPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocPhong.FormattingEnabled = true;
            cboLocPhong.Location = new Point(97, 17);
            cboLocPhong.Margin = new Padding(3, 4, 3, 4);
            cboLocPhong.Name = "cboLocPhong";
            cboLocPhong.Size = new Size(251, 28);
            cboLocPhong.TabIndex = 1;
            // 
            // lblLocPhong
            // 
            lblLocPhong.AutoSize = true;
            lblLocPhong.Location = new Point(14, 23);
            lblLocPhong.Name = "lblLocPhong";
            lblLocPhong.Size = new Size(83, 20);
            lblLocPhong.TabIndex = 0;
            lblLocPhong.Text = "Phòng ban:";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialogAnh
            // 
            openFileDialogAnh.Filter = "Tập tin ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tập tin|*.*";
            openFileDialogAnh.Title = "Chọn ảnh nhân viên";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Enabled = false;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(131, 69);
            cboGioiTinh.Margin = new Padding(3, 4, 3, 4);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(217, 28);
            cboGioiTinh.TabIndex = 5;
            // 
            // btnUpdateNhanVien
            // 
            btnUpdateNhanVien.Location = new Point(790, 313);
            btnUpdateNhanVien.Name = "btnUpdateNhanVien";
            btnUpdateNhanVien.Size = new Size(148, 40);
            btnUpdateNhanVien.TabIndex = 27;
            btnUpdateNhanVien.Text = "Cập nhật thông tin";
            btnUpdateNhanVien.UseVisualStyleBackColor = true;
            // 
            // frmEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1314, 933);
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hồ sơ nhân viên";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPhepNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAnh).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAnh;
        private ColumnHeader colMa;
        private ColumnHeader colTen;
        private ColumnHeader colGioiTinh;
        private ColumnHeader colNgaySinh;
        private ColumnHeader colDienThoai;
        private ColumnHeader colPhong;
        private ColumnHeader colChucVu;
        private ColumnHeader colLuong;
        private ColumnHeader colTrangThai;
        private ComboBox cboGioiTinh;
        private Button btnUpdateNhanVien;
    }
}
