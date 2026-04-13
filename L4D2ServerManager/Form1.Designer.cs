namespace L4D2ServerManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabInstall = new System.Windows.Forms.TabPage();

            this.lblBaseDir = new System.Windows.Forms.Label();
            this.txtBaseDir = new System.Windows.Forms.TextBox();
            this.btnBrowseBaseDir = new System.Windows.Forms.Button();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.lblProfilePort = new System.Windows.Forms.Label();
            this.txtProfilePort = new System.Windows.Forms.TextBox();
            this.btnCreateProfile = new System.Windows.Forms.Button();
            this.lblSelectProfile = new System.Windows.Forms.Label();
            this.cmbProfiles = new System.Windows.Forms.ComboBox();

            this.lblMetaMod = new System.Windows.Forms.Label();
            this.cmbMetaMod = new System.Windows.Forms.ComboBox();
            this.lblSourceMod = new System.Windows.Forms.Label();
            this.cmbSourceMod = new System.Windows.Forms.ComboBox();
            this.lblL4dToolZ = new System.Windows.Forms.Label();
            this.cmbL4dToolZ = new System.Windows.Forms.ComboBox();

            this.btnInstallServer = new System.Windows.Forms.Button();
            this.btnInstallMods = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.pbTab1 = new System.Windows.Forms.ProgressBar();

            this.lblTheme = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.lblWorkshopLinks = new System.Windows.Forms.Label();
            this.txtWorkshopLinks = new System.Windows.Forms.TextBox();
            this.btnInstallMap = new System.Windows.Forms.Button();
            this.btnImportManualMap = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.cmbMaxPlayers = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtSteamGroup = new System.Windows.Forms.TextBox();
            this.btnConfigServer = new System.Windows.Forms.Button();

            this.tabManager = new System.Windows.Forms.TabPage();
            this.lblGameMode = new System.Windows.Forms.Label();
            this.cmbGameMode = new System.Windows.Forms.ComboBox();

            // THÊM: Biến cho chế độ Đột biến
            this.lblMutation = new System.Windows.Forms.Label();
            this.cmbMutation = new System.Windows.Forms.ComboBox();

            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.lblManagerProfile = new System.Windows.Forms.Label();
            this.cmbManagerProfiles = new System.Windows.Forms.ComboBox();
            this.lblStartMap = new System.Windows.Forms.Label();
            this.cmbStartMap = new System.Windows.Forms.ComboBox();
            this.chkConsoleMode = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblInstalledMaps = new System.Windows.Forms.Label();
            this.lstInstalledMaps = new System.Windows.Forms.ListBox();
            this.btnDeleteMap = new System.Windows.Forms.Button();
            this.dgvInstances = new System.Windows.Forms.DataGridView();

            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.lblSearchServer = new System.Windows.Forms.Label();
            this.txtSearchServer = new System.Windows.Forms.TextBox();
            this.dgvBrowser = new System.Windows.Forms.DataGridView();
            this.btnJoinServer = new System.Windows.Forms.Button();
            this.cmbCountryFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnScanBrowser = new System.Windows.Forms.Button();
            this.pbTab3 = new System.Windows.Forms.ProgressBar();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();

            this.rtbConsole = new System.Windows.Forms.RichTextBox();

            this.tabControlMain.SuspendLayout();
            this.tabInstall.SuspendLayout();
            this.tabManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstances)).BeginInit();
            this.tabBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrowser)).BeginInit();
            this.SuspendLayout();

            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabInstall);
            this.tabControlMain.Controls.Add(this.tabManager);
            this.tabControlMain.Controls.Add(this.tabBrowser);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1264, 460);

            this.tabInstall.Controls.Add(this.lblBaseDir); this.tabInstall.Controls.Add(this.txtBaseDir); this.tabInstall.Controls.Add(this.btnBrowseBaseDir);
            this.tabInstall.Controls.Add(this.lblProfileName); this.tabInstall.Controls.Add(this.txtProfileName); this.tabInstall.Controls.Add(this.lblProfilePort);
            this.tabInstall.Controls.Add(this.txtProfilePort); this.tabInstall.Controls.Add(this.btnCreateProfile); this.tabInstall.Controls.Add(this.lblSelectProfile);
            this.tabInstall.Controls.Add(this.cmbProfiles);

            this.tabInstall.Controls.Add(this.lblMetaMod); this.tabInstall.Controls.Add(this.cmbMetaMod);
            this.tabInstall.Controls.Add(this.lblSourceMod); this.tabInstall.Controls.Add(this.cmbSourceMod);
            this.tabInstall.Controls.Add(this.lblL4dToolZ); this.tabInstall.Controls.Add(this.cmbL4dToolZ);

            this.tabInstall.Controls.Add(this.btnInstallServer); this.tabInstall.Controls.Add(this.btnInstallMods); this.tabInstall.Controls.Add(this.btnVerify);
            this.tabInstall.Controls.Add(this.pbTab1);

            this.tabInstall.Controls.Add(this.lblTheme); this.tabInstall.Controls.Add(this.cmbTheme);
            this.tabInstall.Controls.Add(this.lblWorkshopLinks); this.tabInstall.Controls.Add(this.txtWorkshopLinks);
            this.tabInstall.Controls.Add(this.btnInstallMap); this.tabInstall.Controls.Add(this.btnImportManualMap);
            this.tabInstall.Controls.Add(this.lblServerName); this.tabInstall.Controls.Add(this.txtServerName);
            this.tabInstall.Controls.Add(this.lblMaxPlayers); this.tabInstall.Controls.Add(this.cmbMaxPlayers);
            this.tabInstall.Controls.Add(this.lblGroup); this.tabInstall.Controls.Add(this.txtSteamGroup); this.tabInstall.Controls.Add(this.btnConfigServer);
            this.tabInstall.Location = new System.Drawing.Point(4, 24); this.tabInstall.Name = "tabInstall"; this.tabInstall.Size = new System.Drawing.Size(1256, 432); this.tabInstall.Text = "1. Thiết lập Hồ Sơ & Cài Đặt";

            this.lblBaseDir.AutoSize = true; this.lblBaseDir.Location = new System.Drawing.Point(20, 20); this.lblBaseDir.Text = "📁 Thư mục lưu Profile:";
            this.txtBaseDir.Location = new System.Drawing.Point(170, 17); this.txtBaseDir.Size = new System.Drawing.Size(270, 23);
            this.btnBrowseBaseDir.Location = new System.Drawing.Point(450, 15); this.btnBrowseBaseDir.Size = new System.Drawing.Size(75, 27); this.btnBrowseBaseDir.Text = "Chọn..."; this.btnBrowseBaseDir.Click += new System.EventHandler(this.btnBrowseBaseDir_Click);
            this.lblProfileName.AutoSize = true; this.lblProfileName.Location = new System.Drawing.Point(20, 60); this.lblProfileName.Text = "📝 Tên Profile mới:";
            this.txtProfileName.Location = new System.Drawing.Point(170, 57); this.txtProfileName.Size = new System.Drawing.Size(140, 23);
            this.lblProfilePort.AutoSize = true; this.lblProfilePort.Location = new System.Drawing.Point(325, 60); this.lblProfilePort.Text = "Port:";
            this.txtProfilePort.Location = new System.Drawing.Point(365, 57); this.txtProfilePort.Size = new System.Drawing.Size(75, 23); this.txtProfilePort.Text = "27015";
            this.btnCreateProfile.Location = new System.Drawing.Point(450, 55); this.btnCreateProfile.Size = new System.Drawing.Size(110, 27); this.btnCreateProfile.Text = "+ Tạo / Ghi đè"; this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            this.lblSelectProfile.AutoSize = true; this.lblSelectProfile.Location = new System.Drawing.Point(20, 105); this.lblSelectProfile.Text = "📌 CHỌN PROFILE:";
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbProfiles.Location = new System.Drawing.Point(170, 102); this.cmbProfiles.Size = new System.Drawing.Size(390, 23);

            this.lblMetaMod.AutoSize = true; this.lblMetaMod.Location = new System.Drawing.Point(20, 143); this.lblMetaMod.Text = "🔧 Cài đặt MetaMod:";
            this.cmbMetaMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbMetaMod.Location = new System.Drawing.Point(170, 140); this.cmbMetaMod.Size = new System.Drawing.Size(390, 23);

            this.lblSourceMod.AutoSize = true; this.lblSourceMod.Location = new System.Drawing.Point(20, 178); this.lblSourceMod.Text = "🛡 Cài đặt SourceMod:";
            this.cmbSourceMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbSourceMod.Location = new System.Drawing.Point(170, 175); this.cmbSourceMod.Size = new System.Drawing.Size(390, 23);

            this.lblL4dToolZ.AutoSize = true; this.lblL4dToolZ.Location = new System.Drawing.Point(20, 213); this.lblL4dToolZ.Text = "🔓 Cài đặt L4DToolZ:";
            this.cmbL4dToolZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbL4dToolZ.Location = new System.Drawing.Point(170, 210); this.cmbL4dToolZ.Size = new System.Drawing.Size(390, 23);

            this.btnInstallServer.Location = new System.Drawing.Point(170, 260); this.btnInstallServer.Size = new System.Drawing.Size(125, 45); this.btnInstallServer.Text = "⏬ Cài Đặt Server (L4D2 Gốc)"; this.btnInstallServer.Click += new System.EventHandler(this.btnInstallServer_Click);
            this.btnInstallMods.Location = new System.Drawing.Point(300, 260); this.btnInstallMods.Name = "btnInstallMods"; this.btnInstallMods.Size = new System.Drawing.Size(125, 45); this.btnInstallMods.Text = "🧩 Cài Extension (MM, SM, ToolZ)"; this.btnInstallMods.Click += new System.EventHandler(this.btnInstallMods_Click);
            this.btnVerify.Location = new System.Drawing.Point(430, 260); this.btnVerify.Size = new System.Drawing.Size(130, 45); this.btnVerify.Text = "🛠 Verify (Sửa lỗi)"; this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);

            this.pbTab1.Location = new System.Drawing.Point(170, 315); this.pbTab1.Size = new System.Drawing.Size(390, 10); this.pbTab1.Visible = false;

            this.lblTheme.AutoSize = true; this.lblTheme.Location = new System.Drawing.Point(980, 30); this.lblTheme.Text = "🎨 Giao diện:";
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTheme.Location = new System.Drawing.Point(1070, 27); this.cmbTheme.Size = new System.Drawing.Size(150, 23); this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            this.lblWorkshopLinks.AutoSize = true; this.lblWorkshopLinks.Location = new System.Drawing.Point(650, 80); this.lblWorkshopLinks.Text = "🔗 Links Workshop Map:\r\n(Mỗi link 1 dòng)";
            this.txtWorkshopLinks.Location = new System.Drawing.Point(820, 80); this.txtWorkshopLinks.Multiline = true; this.txtWorkshopLinks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; this.txtWorkshopLinks.Size = new System.Drawing.Size(260, 80);
            this.btnInstallMap.Location = new System.Drawing.Point(1100, 80); this.btnInstallMap.Size = new System.Drawing.Size(120, 35); this.btnInstallMap.Text = "⏬ Tải Tự Động"; this.btnInstallMap.Click += new System.EventHandler(this.btnInstallMap_Click);
            this.btnImportManualMap.Location = new System.Drawing.Point(1100, 125); this.btnImportManualMap.Size = new System.Drawing.Size(120, 35); this.btnImportManualMap.Text = "📁 Nhập VPK tay"; this.btnImportManualMap.Click += new System.EventHandler(this.btnImportManualMap_Click);
            this.lblServerName.AutoSize = true; this.lblServerName.Location = new System.Drawing.Point(650, 230); this.lblServerName.Text = "🏷 Tên Host Game:";
            this.txtServerName.Location = new System.Drawing.Point(820, 227); this.txtServerName.Size = new System.Drawing.Size(400, 23); this.txtServerName.Text = "[VN] My L4D2 Server";
            this.lblMaxPlayers.AutoSize = true; this.lblMaxPlayers.Location = new System.Drawing.Point(650, 280); this.lblMaxPlayers.Text = "👥 Max Players:";
            this.cmbMaxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbMaxPlayers.Location = new System.Drawing.Point(820, 277); this.cmbMaxPlayers.Size = new System.Drawing.Size(80, 23);
            this.lblGroup.AutoSize = true; this.lblGroup.Location = new System.Drawing.Point(920, 280); this.lblGroup.Text = "🎮 Group ID:";
            this.txtSteamGroup.Location = new System.Drawing.Point(1000, 277); this.txtSteamGroup.Size = new System.Drawing.Size(220, 23);
            this.btnConfigServer.Location = new System.Drawing.Point(820, 330); this.btnConfigServer.Size = new System.Drawing.Size(400, 35); this.btnConfigServer.Text = "⚙️ Tự động tạo file server.cfg"; this.btnConfigServer.Click += new System.EventHandler(this.btnConfigServer_Click);

            this.tabManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabManager.Controls.Add(this.lblGameMode); this.tabManager.Controls.Add(this.cmbGameMode);

            // THÊM: Kéo các control vào Tab Manager
            this.tabManager.Controls.Add(this.lblMutation); this.tabManager.Controls.Add(this.cmbMutation);

            this.tabManager.Controls.Add(this.lblDifficulty);
            this.tabManager.Controls.Add(this.cmbDifficulty); this.tabManager.Controls.Add(this.btnStop); this.tabManager.Controls.Add(this.btnStart);
            this.tabManager.Controls.Add(this.chkConsoleMode); this.tabManager.Controls.Add(this.lblStartMap); this.tabManager.Controls.Add(this.cmbStartMap);
            this.tabManager.Controls.Add(this.cmbManagerProfiles); this.tabManager.Controls.Add(this.lblManagerProfile); this.tabManager.Controls.Add(this.lblInstalledMaps);
            this.tabManager.Controls.Add(this.lstInstalledMaps); this.tabManager.Controls.Add(this.btnDeleteMap); this.tabManager.Controls.Add(this.dgvInstances);
            this.tabManager.Location = new System.Drawing.Point(4, 24); this.tabManager.Name = "tabManager"; this.tabManager.Size = new System.Drawing.Size(1256, 432); this.tabManager.Text = "2. Quản lý Máy Chủ & Custom Maps";

            this.lblManagerProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblManagerProfile.AutoSize = true; this.lblManagerProfile.Location = new System.Drawing.Point(980, 10); this.lblManagerProfile.Text = "📌 Chọn Profile để Host:";
            this.cmbManagerProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbManagerProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbManagerProfiles.Location = new System.Drawing.Point(980, 30); this.cmbManagerProfiles.Size = new System.Drawing.Size(250, 23); this.cmbManagerProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbManagerProfiles_SelectedIndexChanged);
            this.lblStartMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblStartMap.AutoSize = true; this.lblStartMap.Location = new System.Drawing.Point(980, 65); this.lblStartMap.Text = "🗺 Chọn Map khởi động:";
            this.cmbStartMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbStartMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbStartMap.Location = new System.Drawing.Point(980, 85); this.cmbStartMap.Size = new System.Drawing.Size(250, 23);
            this.lblGameMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblGameMode.AutoSize = true; this.lblGameMode.Location = new System.Drawing.Point(980, 115); this.lblGameMode.Text = "⚔ Chế độ chơi:";
            this.cmbGameMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbGameMode.Location = new System.Drawing.Point(980, 135); this.cmbGameMode.Size = new System.Drawing.Size(120, 23); this.cmbGameMode.SelectedIndexChanged += new System.EventHandler(this.cmbGameMode_SelectedIndexChanged);
            this.lblDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblDifficulty.AutoSize = true; this.lblDifficulty.Location = new System.Drawing.Point(1110, 115); this.lblDifficulty.Text = "🔥 Độ khó:";
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbDifficulty.Location = new System.Drawing.Point(1110, 135); this.cmbDifficulty.Size = new System.Drawing.Size(120, 23);

            // CẬP NHẬT: Thêm tọa độ cho ComboBox Mutation (Ẩn mặc định)
            this.lblMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblMutation.AutoSize = true; this.lblMutation.Location = new System.Drawing.Point(980, 165); this.lblMutation.Text = "🧬 Chọn Đột biến:"; this.lblMutation.Visible = false;
            this.cmbMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbMutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbMutation.Location = new System.Drawing.Point(980, 185); this.cmbMutation.Size = new System.Drawing.Size(250, 23); this.cmbMutation.Visible = false;

            // CẬP NHẬT: Đẩy toàn bộ các nút bên dưới xuống 45-50 pixels để tạo không gian
            this.chkConsoleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.chkConsoleMode.AutoSize = false; this.chkConsoleMode.Location = new System.Drawing.Point(980, 215); this.chkConsoleMode.Size = new System.Drawing.Size(250, 20); this.chkConsoleMode.Text = "💻 Chạy ẩn Console (-console)"; this.chkConsoleMode.Checked = true;
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.btnStart.Location = new System.Drawing.Point(980, 240); this.btnStart.Size = new System.Drawing.Size(250, 35); this.btnStart.Text = "▶ Khởi Động Server"; this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.btnStop.Location = new System.Drawing.Point(980, 280); this.btnStop.Size = new System.Drawing.Size(250, 35); this.btnStop.Text = "⏹ Dừng Server Đang Chọn"; this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.lblInstalledMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblInstalledMaps.AutoSize = true; this.lblInstalledMaps.Location = new System.Drawing.Point(980, 320); this.lblInstalledMaps.Text = "📦 Các Custom Map đã cài:";
            this.lstInstalledMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right))); this.lstInstalledMaps.FormattingEnabled = true; this.lstInstalledMaps.Location = new System.Drawing.Point(980, 340); this.lstInstalledMaps.Size = new System.Drawing.Size(250, 44); this.lstInstalledMaps.DisplayMember = "DisplayName";
            this.btnDeleteMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))); this.btnDeleteMap.Location = new System.Drawing.Point(980, 390); this.btnDeleteMap.Size = new System.Drawing.Size(250, 30); this.btnDeleteMap.Text = "🗑 Xóa Map đang chọn"; this.btnDeleteMap.Click += new System.EventHandler(this.btnDeleteMap_Click);

            this.dgvInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))); this.dgvInstances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvInstances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; this.dgvInstances.Location = new System.Drawing.Point(8, 6); this.dgvInstances.RowHeadersVisible = false; this.dgvInstances.Size = new System.Drawing.Size(950, 420);

            this.tabBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabBrowser.Controls.Add(this.lblSearchServer); this.tabBrowser.Controls.Add(this.txtSearchServer); this.tabBrowser.Controls.Add(this.dgvBrowser);
            this.tabBrowser.Controls.Add(this.btnJoinServer); this.tabBrowser.Controls.Add(this.cmbCountryFilter); this.tabBrowser.Controls.Add(this.lblFilter);
            this.tabBrowser.Controls.Add(this.btnScanBrowser); this.tabBrowser.Controls.Add(this.pbTab3); this.tabBrowser.Controls.Add(this.cmbRegion); this.tabBrowser.Controls.Add(this.lblRegion);
            this.tabBrowser.Location = new System.Drawing.Point(4, 24); this.tabBrowser.Size = new System.Drawing.Size(1256, 432); this.tabBrowser.Text = "3. Global Server Browser";

            this.lblRegion.AutoSize = true; this.lblRegion.Location = new System.Drawing.Point(8, 15); this.lblRegion.Text = "Khu Vực API:";
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbRegion.Location = new System.Drawing.Point(85, 12); this.cmbRegion.Size = new System.Drawing.Size(150, 23);
            this.btnScanBrowser.Location = new System.Drawing.Point(245, 10); this.btnScanBrowser.Size = new System.Drawing.Size(120, 27); this.btnScanBrowser.Text = "🔍 Quét Server"; this.btnScanBrowser.Click += new System.EventHandler(this.btnScanBrowser_Click);
            this.pbTab3.Location = new System.Drawing.Point(375, 20); this.pbTab3.Size = new System.Drawing.Size(80, 8); this.pbTab3.Visible = false;
            this.lblSearchServer.AutoSize = true; this.lblSearchServer.Location = new System.Drawing.Point(480, 15); this.lblSearchServer.Text = "🔎 Tìm Tên Server:";
            this.txtSearchServer.Location = new System.Drawing.Point(600, 12); this.txtSearchServer.Size = new System.Drawing.Size(150, 23); this.txtSearchServer.TextChanged += new System.EventHandler(this.txtSearchServer_TextChanged);
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.lblFilter.AutoSize = true; this.lblFilter.Location = new System.Drawing.Point(780, 15); this.lblFilter.Text = "🎯 Lọc Quốc Gia:";
            this.cmbCountryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.cmbCountryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbCountryFilter.Location = new System.Drawing.Point(880, 12); this.cmbCountryFilter.Size = new System.Drawing.Size(170, 23); this.cmbCountryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCountryFilter_SelectedIndexChanged);
            this.btnJoinServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); this.btnJoinServer.Location = new System.Drawing.Point(1070, 10); this.btnJoinServer.Size = new System.Drawing.Size(130, 27); this.btnJoinServer.Text = "🚀 JOIN SERVER"; this.btnJoinServer.Click += new System.EventHandler(this.btnJoinServer_Click);
            this.dgvBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))); this.dgvBrowser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; this.dgvBrowser.Location = new System.Drawing.Point(8, 45); this.dgvBrowser.RowHeadersVisible = false; this.dgvBrowser.Size = new System.Drawing.Size(1240, 380); this.dgvBrowser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBrowser_ColumnHeaderMouseClick);

            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right))); this.rtbConsole.Font = new System.Drawing.Font("Consolas", 9.5F); this.rtbConsole.Location = new System.Drawing.Point(0, 465); this.rtbConsole.ReadOnly = true; this.rtbConsole.Size = new System.Drawing.Size(1264, 215); this.rtbConsole.Text = "=== L4D2 ULTIMATE MANAGER ===\n";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.ClientSize = new System.Drawing.Size(1264, 681); this.Controls.Add(this.rtbConsole); this.Controls.Add(this.tabControlMain); this.MinimumSize = new System.Drawing.Size(1000, 600); this.Text = "L4D2 Ultimate Manager & Browser";

            this.tabControlMain.ResumeLayout(false); this.tabInstall.ResumeLayout(false); this.tabInstall.PerformLayout(); this.tabManager.ResumeLayout(false); this.tabManager.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvInstances)).EndInit(); this.tabBrowser.ResumeLayout(false); this.tabBrowser.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvBrowser)).EndInit(); this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabInstall;
        private System.Windows.Forms.TabPage tabManager;
        private System.Windows.Forms.TabPage tabBrowser;

        private System.Windows.Forms.Label lblBaseDir;
        private System.Windows.Forms.TextBox txtBaseDir;
        private System.Windows.Forms.Button btnBrowseBaseDir;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label lblProfilePort;
        private System.Windows.Forms.TextBox txtProfilePort;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.Label lblSelectProfile;
        private System.Windows.Forms.ComboBox cmbProfiles;

        private System.Windows.Forms.Label lblMetaMod;
        private System.Windows.Forms.ComboBox cmbMetaMod;
        private System.Windows.Forms.Label lblSourceMod;
        private System.Windows.Forms.ComboBox cmbSourceMod;

        private System.Windows.Forms.Label lblL4dToolZ;
        private System.Windows.Forms.ComboBox cmbL4dToolZ;

        private System.Windows.Forms.Button btnInstallServer;
        private System.Windows.Forms.Button btnInstallMods;
        private System.Windows.Forms.Button btnVerify;

        private System.Windows.Forms.Label lblWorkshopLinks;
        private System.Windows.Forms.TextBox txtWorkshopLinks;
        private System.Windows.Forms.Button btnInstallMap;
        private System.Windows.Forms.Button btnImportManualMap;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblMaxPlayers;
        private System.Windows.Forms.ComboBox cmbMaxPlayers;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtSteamGroup;
        private System.Windows.Forms.Button btnConfigServer;
        private System.Windows.Forms.ProgressBar pbTab1;

        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.ComboBox cmbTheme;

        private System.Windows.Forms.DataGridView dgvInstances;
        private System.Windows.Forms.Label lblManagerProfile;
        private System.Windows.Forms.ComboBox cmbManagerProfiles;
        private System.Windows.Forms.Label lblStartMap;
        private System.Windows.Forms.ComboBox cmbStartMap;
        private System.Windows.Forms.Label lblGameMode;
        private System.Windows.Forms.ComboBox cmbGameMode;

        // THÊM BIẾN
        private System.Windows.Forms.Label lblMutation;
        private System.Windows.Forms.ComboBox cmbMutation;

        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.CheckBox chkConsoleMode;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblInstalledMaps;
        private System.Windows.Forms.ListBox lstInstalledMaps;
        private System.Windows.Forms.Button btnDeleteMap;

        private System.Windows.Forms.Label lblSearchServer;
        private System.Windows.Forms.TextBox txtSearchServer;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.Button btnScanBrowser;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbCountryFilter;
        private System.Windows.Forms.Button btnJoinServer;
        private System.Windows.Forms.DataGridView dgvBrowser;
        private System.Windows.Forms.ProgressBar pbTab3;

        private System.Windows.Forms.RichTextBox rtbConsole;
    }
}