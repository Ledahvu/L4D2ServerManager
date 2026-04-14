namespace L4D2ServerManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
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
            this.lblMutation = new System.Windows.Forms.Label();
            this.cmbMutation = new System.Windows.Forms.ComboBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkConsoleMode = new System.Windows.Forms.CheckBox();
            this.lblStartMap = new System.Windows.Forms.Label();
            this.cmbStartMap = new System.Windows.Forms.ComboBox();
            this.cmbManagerProfiles = new System.Windows.Forms.ComboBox();
            this.lblManagerProfile = new System.Windows.Forms.Label();
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
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabInstall);
            this.tabControlMain.Controls.Add(this.tabManager);
            this.tabControlMain.Controls.Add(this.tabBrowser);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1445, 491);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabInstall
            // 
            this.tabInstall.Controls.Add(this.lblBaseDir);
            this.tabInstall.Controls.Add(this.txtBaseDir);
            this.tabInstall.Controls.Add(this.btnBrowseBaseDir);
            this.tabInstall.Controls.Add(this.lblProfileName);
            this.tabInstall.Controls.Add(this.txtProfileName);
            this.tabInstall.Controls.Add(this.lblProfilePort);
            this.tabInstall.Controls.Add(this.txtProfilePort);
            this.tabInstall.Controls.Add(this.btnCreateProfile);
            this.tabInstall.Controls.Add(this.lblSelectProfile);
            this.tabInstall.Controls.Add(this.cmbProfiles);
            this.tabInstall.Controls.Add(this.lblMetaMod);
            this.tabInstall.Controls.Add(this.cmbMetaMod);
            this.tabInstall.Controls.Add(this.lblSourceMod);
            this.tabInstall.Controls.Add(this.cmbSourceMod);
            this.tabInstall.Controls.Add(this.lblL4dToolZ);
            this.tabInstall.Controls.Add(this.cmbL4dToolZ);
            this.tabInstall.Controls.Add(this.lblLanguage);
            this.tabInstall.Controls.Add(this.cmbLanguage);
            this.tabInstall.Controls.Add(this.btnInstallServer);
            this.tabInstall.Controls.Add(this.btnInstallMods);
            this.tabInstall.Controls.Add(this.btnVerify);
            this.tabInstall.Controls.Add(this.pbTab1);
            this.tabInstall.Controls.Add(this.lblTheme);
            this.tabInstall.Controls.Add(this.cmbTheme);
            this.tabInstall.Controls.Add(this.lblWorkshopLinks);
            this.tabInstall.Controls.Add(this.txtWorkshopLinks);
            this.tabInstall.Controls.Add(this.btnInstallMap);
            this.tabInstall.Controls.Add(this.btnImportManualMap);
            this.tabInstall.Controls.Add(this.lblServerName);
            this.tabInstall.Controls.Add(this.txtServerName);
            this.tabInstall.Controls.Add(this.lblMaxPlayers);
            this.tabInstall.Controls.Add(this.cmbMaxPlayers);
            this.tabInstall.Controls.Add(this.lblGroup);
            this.tabInstall.Controls.Add(this.txtSteamGroup);
            this.tabInstall.Controls.Add(this.btnConfigServer);
            this.tabInstall.Location = new System.Drawing.Point(4, 25);
            this.tabInstall.Name = "tabInstall";
            this.tabInstall.Size = new System.Drawing.Size(1437, 462);
            this.tabInstall.TabIndex = 0;
            this.tabInstall.Text = "1. Thiết lập Hồ Sơ & Cài Đặt";
            // 
            // lblBaseDir
            // 
            this.lblBaseDir.AutoSize = true;
            this.lblBaseDir.Location = new System.Drawing.Point(23, 21);
            this.lblBaseDir.Name = "lblBaseDir";
            this.lblBaseDir.Size = new System.Drawing.Size(137, 16);
            this.lblBaseDir.TabIndex = 0;
            this.lblBaseDir.Text = "📁 Thư mục lưu Profile:";
            // 
            // txtBaseDir
            // 
            this.txtBaseDir.Location = new System.Drawing.Point(194, 18);
            this.txtBaseDir.Name = "txtBaseDir";
            this.txtBaseDir.Size = new System.Drawing.Size(308, 22);
            this.txtBaseDir.TabIndex = 1;
            // 
            // btnBrowseBaseDir
            // 
            this.btnBrowseBaseDir.Location = new System.Drawing.Point(514, 16);
            this.btnBrowseBaseDir.Name = "btnBrowseBaseDir";
            this.btnBrowseBaseDir.Size = new System.Drawing.Size(86, 29);
            this.btnBrowseBaseDir.TabIndex = 2;
            this.btnBrowseBaseDir.Text = "Chọn...";
            this.btnBrowseBaseDir.Click += new System.EventHandler(this.btnBrowseBaseDir_Click);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Location = new System.Drawing.Point(23, 64);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(115, 16);
            this.lblProfileName.TabIndex = 3;
            this.lblProfileName.Text = "📝 Tên Profile mới:";
            // 
            // txtProfileName
            // 
            this.txtProfileName.Location = new System.Drawing.Point(194, 61);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(159, 22);
            this.txtProfileName.TabIndex = 4;
            // 
            // lblProfilePort
            // 
            this.lblProfilePort.AutoSize = true;
            this.lblProfilePort.Location = new System.Drawing.Point(371, 64);
            this.lblProfilePort.Name = "lblProfilePort";
            this.lblProfilePort.Size = new System.Drawing.Size(34, 16);
            this.lblProfilePort.TabIndex = 5;
            this.lblProfilePort.Text = "Port:";
            // 
            // txtProfilePort
            // 
            this.txtProfilePort.Location = new System.Drawing.Point(417, 61);
            this.txtProfilePort.Name = "txtProfilePort";
            this.txtProfilePort.Size = new System.Drawing.Size(85, 22);
            this.txtProfilePort.TabIndex = 6;
            this.txtProfilePort.Text = "27015";
            // 
            // btnCreateProfile
            // 
            this.btnCreateProfile.Location = new System.Drawing.Point(514, 59);
            this.btnCreateProfile.Name = "btnCreateProfile";
            this.btnCreateProfile.Size = new System.Drawing.Size(126, 29);
            this.btnCreateProfile.TabIndex = 7;
            this.btnCreateProfile.Text = "+ Tạo / Ghi đè";
            this.btnCreateProfile.Click += new System.EventHandler(this.btnCreateProfile_Click);
            // 
            // lblSelectProfile
            // 
            this.lblSelectProfile.AutoSize = true;
            this.lblSelectProfile.Location = new System.Drawing.Point(23, 112);
            this.lblSelectProfile.Name = "lblSelectProfile";
            this.lblSelectProfile.Size = new System.Drawing.Size(123, 16);
            this.lblSelectProfile.TabIndex = 8;
            this.lblSelectProfile.Text = "📌 CHỌN PROFILE:";
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfiles.Location = new System.Drawing.Point(194, 109);
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(445, 24);
            this.cmbProfiles.TabIndex = 9;
            // 
            // lblMetaMod
            // 
            this.lblMetaMod.AutoSize = true;
            this.lblMetaMod.Location = new System.Drawing.Point(23, 153);
            this.lblMetaMod.Name = "lblMetaMod";
            this.lblMetaMod.Size = new System.Drawing.Size(127, 16);
            this.lblMetaMod.TabIndex = 10;
            this.lblMetaMod.Text = "🔧 Cài đặt MetaMod:";
            // 
            // cmbMetaMod
            // 
            this.cmbMetaMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetaMod.Location = new System.Drawing.Point(194, 149);
            this.cmbMetaMod.Name = "cmbMetaMod";
            this.cmbMetaMod.Size = new System.Drawing.Size(445, 24);
            this.cmbMetaMod.TabIndex = 11;
            // 
            // lblSourceMod
            // 
            this.lblSourceMod.AutoSize = true;
            this.lblSourceMod.Location = new System.Drawing.Point(23, 190);
            this.lblSourceMod.Name = "lblSourceMod";
            this.lblSourceMod.Size = new System.Drawing.Size(140, 16);
            this.lblSourceMod.TabIndex = 12;
            this.lblSourceMod.Text = "🛡 Cài đặt SourceMod:";
            // 
            // cmbSourceMod
            // 
            this.cmbSourceMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceMod.Location = new System.Drawing.Point(194, 187);
            this.cmbSourceMod.Name = "cmbSourceMod";
            this.cmbSourceMod.Size = new System.Drawing.Size(445, 24);
            this.cmbSourceMod.TabIndex = 13;
            // 
            // lblL4dToolZ
            // 
            this.lblL4dToolZ.AutoSize = true;
            this.lblL4dToolZ.Location = new System.Drawing.Point(23, 227);
            this.lblL4dToolZ.Name = "lblL4dToolZ";
            this.lblL4dToolZ.Size = new System.Drawing.Size(130, 16);
            this.lblL4dToolZ.TabIndex = 14;
            this.lblL4dToolZ.Text = "🔓 Cài đặt L4DToolZ:";
            // 
            // cmbL4dToolZ
            // 
            this.cmbL4dToolZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbL4dToolZ.Location = new System.Drawing.Point(194, 224);
            this.cmbL4dToolZ.Name = "cmbL4dToolZ";
            this.cmbL4dToolZ.Size = new System.Drawing.Size(445, 24);
            this.cmbL4dToolZ.TabIndex = 15;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(846, 32);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(86, 16);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Text = "🌐 Language:";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.Location = new System.Drawing.Point(937, 29);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(148, 24);
            this.cmbLanguage.TabIndex = 17;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // btnInstallServer
            // 
            this.btnInstallServer.Location = new System.Drawing.Point(194, 277);
            this.btnInstallServer.Name = "btnInstallServer";
            this.btnInstallServer.Size = new System.Drawing.Size(143, 48);
            this.btnInstallServer.TabIndex = 18;
            this.btnInstallServer.Text = "⏬ Cài Đặt Server (L4D2 Gốc)";
            this.btnInstallServer.Click += new System.EventHandler(this.btnInstallServer_Click);
            // 
            // btnInstallMods
            // 
            this.btnInstallMods.Location = new System.Drawing.Point(343, 277);
            this.btnInstallMods.Name = "btnInstallMods";
            this.btnInstallMods.Size = new System.Drawing.Size(143, 48);
            this.btnInstallMods.TabIndex = 19;
            this.btnInstallMods.Text = "🧩 Cài Extension (MM, SM, ToolZ)";
            this.btnInstallMods.Click += new System.EventHandler(this.btnInstallMods_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(491, 277);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(149, 48);
            this.btnVerify.TabIndex = 20;
            this.btnVerify.Text = "🛠 Verify (Sửa lỗi)";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // pbTab1
            // 
            this.pbTab1.Location = new System.Drawing.Point(194, 336);
            this.pbTab1.Name = "pbTab1";
            this.pbTab1.Size = new System.Drawing.Size(446, 11);
            this.pbTab1.TabIndex = 21;
            this.pbTab1.Visible = false;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(1120, 32);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(83, 16);
            this.lblTheme.TabIndex = 22;
            this.lblTheme.Text = "🎨 Giao diện:";
            // 
            // cmbTheme
            // 
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.Location = new System.Drawing.Point(1223, 29);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(171, 24);
            this.cmbTheme.TabIndex = 23;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);
            // 
            // lblWorkshopLinks
            // 
            this.lblWorkshopLinks.AutoSize = true;
            this.lblWorkshopLinks.Location = new System.Drawing.Point(743, 85);
            this.lblWorkshopLinks.Name = "lblWorkshopLinks";
            this.lblWorkshopLinks.Size = new System.Drawing.Size(151, 32);
            this.lblWorkshopLinks.TabIndex = 24;
            this.lblWorkshopLinks.Text = "🔗 Links Workshop Map:\r\n(Mỗi link 1 dòng)";
            // 
            // txtWorkshopLinks
            // 
            this.txtWorkshopLinks.Location = new System.Drawing.Point(937, 85);
            this.txtWorkshopLinks.Multiline = true;
            this.txtWorkshopLinks.Name = "txtWorkshopLinks";
            this.txtWorkshopLinks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWorkshopLinks.Size = new System.Drawing.Size(297, 85);
            this.txtWorkshopLinks.TabIndex = 25;
            // 
            // btnInstallMap
            // 
            this.btnInstallMap.Location = new System.Drawing.Point(1257, 85);
            this.btnInstallMap.Name = "btnInstallMap";
            this.btnInstallMap.Size = new System.Drawing.Size(137, 37);
            this.btnInstallMap.TabIndex = 26;
            this.btnInstallMap.Text = "⏬ Tải Tự Động";
            this.btnInstallMap.Click += new System.EventHandler(this.btnInstallMap_Click);
            // 
            // btnImportManualMap
            // 
            this.btnImportManualMap.Location = new System.Drawing.Point(1257, 133);
            this.btnImportManualMap.Name = "btnImportManualMap";
            this.btnImportManualMap.Size = new System.Drawing.Size(137, 37);
            this.btnImportManualMap.TabIndex = 27;
            this.btnImportManualMap.Text = "📁 Nhập VPK tay";
            this.btnImportManualMap.Click += new System.EventHandler(this.btnImportManualMap_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(743, 245);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(120, 16);
            this.lblServerName.TabIndex = 28;
            this.lblServerName.Text = "🏷 Tên Host Game:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(937, 242);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(457, 22);
            this.txtServerName.TabIndex = 29;
            this.txtServerName.Text = "[VN] My L4D2 Server";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(743, 299);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(99, 16);
            this.lblMaxPlayers.TabIndex = 30;
            this.lblMaxPlayers.Text = "👥 Max Players:";
            // 
            // cmbMaxPlayers
            // 
            this.cmbMaxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxPlayers.Location = new System.Drawing.Point(937, 295);
            this.cmbMaxPlayers.Name = "cmbMaxPlayers";
            this.cmbMaxPlayers.Size = new System.Drawing.Size(91, 24);
            this.cmbMaxPlayers.TabIndex = 31;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(1051, 299);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(78, 16);
            this.lblGroup.TabIndex = 32;
            this.lblGroup.Text = "🎮 Group ID:";
            // 
            // txtSteamGroup
            // 
            this.txtSteamGroup.Location = new System.Drawing.Point(1143, 295);
            this.txtSteamGroup.Name = "txtSteamGroup";
            this.txtSteamGroup.Size = new System.Drawing.Size(251, 22);
            this.txtSteamGroup.TabIndex = 33;
            // 
            // btnConfigServer
            // 
            this.btnConfigServer.Location = new System.Drawing.Point(937, 352);
            this.btnConfigServer.Name = "btnConfigServer";
            this.btnConfigServer.Size = new System.Drawing.Size(457, 37);
            this.btnConfigServer.TabIndex = 34;
            this.btnConfigServer.Text = "⚙️ Tự động tạo file server.cfg";
            this.btnConfigServer.Click += new System.EventHandler(this.btnConfigServer_Click);
            // 
            // tabManager
            // 
            this.tabManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabManager.Controls.Add(this.lblGameMode);
            this.tabManager.Controls.Add(this.cmbGameMode);
            this.tabManager.Controls.Add(this.lblMutation);
            this.tabManager.Controls.Add(this.cmbMutation);
            this.tabManager.Controls.Add(this.lblDifficulty);
            this.tabManager.Controls.Add(this.cmbDifficulty);
            this.tabManager.Controls.Add(this.btnStop);
            this.tabManager.Controls.Add(this.btnStart);
            this.tabManager.Controls.Add(this.chkConsoleMode);
            this.tabManager.Controls.Add(this.lblStartMap);
            this.tabManager.Controls.Add(this.cmbStartMap);
            this.tabManager.Controls.Add(this.cmbManagerProfiles);
            this.tabManager.Controls.Add(this.lblManagerProfile);
            this.tabManager.Controls.Add(this.lblInstalledMaps);
            this.tabManager.Controls.Add(this.lstInstalledMaps);
            this.tabManager.Controls.Add(this.btnDeleteMap);
            this.tabManager.Controls.Add(this.dgvInstances);
            this.tabManager.Location = new System.Drawing.Point(4, 25);
            this.tabManager.Name = "tabManager";
            this.tabManager.Size = new System.Drawing.Size(1437, 462);
            this.tabManager.TabIndex = 1;
            this.tabManager.Text = "2. Quản lý Máy Chủ & Custom Maps";
            // 
            // lblGameMode
            // 
            this.lblGameMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGameMode.AutoSize = true;
            this.lblGameMode.Location = new System.Drawing.Point(1120, 123);
            this.lblGameMode.Name = "lblGameMode";
            this.lblGameMode.Size = new System.Drawing.Size(96, 16);
            this.lblGameMode.TabIndex = 0;
            this.lblGameMode.Text = "⚔ Chế độ chơi:";
            // 
            // cmbGameMode
            // 
            this.cmbGameMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameMode.Location = new System.Drawing.Point(1120, 144);
            this.cmbGameMode.Name = "cmbGameMode";
            this.cmbGameMode.Size = new System.Drawing.Size(137, 24);
            this.cmbGameMode.TabIndex = 1;
            this.cmbGameMode.SelectedIndexChanged += new System.EventHandler(this.cmbGameMode_SelectedIndexChanged);
            // 
            // lblMutation
            // 
            this.lblMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMutation.AutoSize = true;
            this.lblMutation.Location = new System.Drawing.Point(1120, 176);
            this.lblMutation.Name = "lblMutation";
            this.lblMutation.Size = new System.Drawing.Size(108, 16);
            this.lblMutation.TabIndex = 2;
            this.lblMutation.Text = "🧬 Chọn Đột biến:";
            this.lblMutation.Visible = false;
            // 
            // cmbMutation
            // 
            this.cmbMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMutation.Location = new System.Drawing.Point(1120, 197);
            this.cmbMutation.Name = "cmbMutation";
            this.cmbMutation.Size = new System.Drawing.Size(285, 24);
            this.cmbMutation.TabIndex = 3;
            this.cmbMutation.Visible = false;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(1269, 123);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(67, 16);
            this.lblDifficulty.TabIndex = 4;
            this.lblDifficulty.Text = "🔥 Độ khó:";
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Location = new System.Drawing.Point(1269, 144);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(137, 24);
            this.cmbDifficulty.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(1120, 299);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(286, 37);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "⏹ Dừng Server Đang Chọn";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1120, 256);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(286, 37);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "▶ Khởi Động Server";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkConsoleMode
            // 
            this.chkConsoleMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConsoleMode.Checked = true;
            this.chkConsoleMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsoleMode.Location = new System.Drawing.Point(1120, 229);
            this.chkConsoleMode.Name = "chkConsoleMode";
            this.chkConsoleMode.Size = new System.Drawing.Size(286, 21);
            this.chkConsoleMode.TabIndex = 8;
            this.chkConsoleMode.Text = "💻 Chạy ẩn Console (-console)";
            // 
            // lblStartMap
            // 
            this.lblStartMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartMap.AutoSize = true;
            this.lblStartMap.Location = new System.Drawing.Point(1120, 69);
            this.lblStartMap.Name = "lblStartMap";
            this.lblStartMap.Size = new System.Drawing.Size(148, 16);
            this.lblStartMap.TabIndex = 9;
            this.lblStartMap.Text = "🗺 Chọn Map khởi động:";
            // 
            // cmbStartMap
            // 
            this.cmbStartMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartMap.Location = new System.Drawing.Point(1120, 91);
            this.cmbStartMap.Name = "cmbStartMap";
            this.cmbStartMap.Size = new System.Drawing.Size(285, 24);
            this.cmbStartMap.TabIndex = 10;
            // 
            // cmbManagerProfiles
            // 
            this.cmbManagerProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbManagerProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManagerProfiles.Location = new System.Drawing.Point(1120, 32);
            this.cmbManagerProfiles.Name = "cmbManagerProfiles";
            this.cmbManagerProfiles.Size = new System.Drawing.Size(285, 24);
            this.cmbManagerProfiles.TabIndex = 11;
            this.cmbManagerProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbManagerProfiles_SelectedIndexChanged);
            // 
            // lblManagerProfile
            // 
            this.lblManagerProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblManagerProfile.AutoSize = true;
            this.lblManagerProfile.Location = new System.Drawing.Point(1120, 11);
            this.lblManagerProfile.Name = "lblManagerProfile";
            this.lblManagerProfile.Size = new System.Drawing.Size(147, 16);
            this.lblManagerProfile.TabIndex = 12;
            this.lblManagerProfile.Text = "📌 Chọn Profile để Host:";
            // 
            // lblInstalledMaps
            // 
            this.lblInstalledMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstalledMaps.AutoSize = true;
            this.lblInstalledMaps.Location = new System.Drawing.Point(1120, 341);
            this.lblInstalledMaps.Name = "lblInstalledMaps";
            this.lblInstalledMaps.Size = new System.Drawing.Size(167, 16);
            this.lblInstalledMaps.TabIndex = 13;
            this.lblInstalledMaps.Text = "📦 Các Custom Map đã cài:";
            // 
            // lstInstalledMaps
            // 
            this.lstInstalledMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInstalledMaps.DisplayMember = "DisplayName";
            this.lstInstalledMaps.FormattingEnabled = true;
            this.lstInstalledMaps.ItemHeight = 16;
            this.lstInstalledMaps.Location = new System.Drawing.Point(1120, 363);
            this.lstInstalledMaps.Name = "lstInstalledMaps";
            this.lstInstalledMaps.Size = new System.Drawing.Size(285, 36);
            this.lstInstalledMaps.TabIndex = 14;
            // 
            // btnDeleteMap
            // 
            this.btnDeleteMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMap.Location = new System.Drawing.Point(1120, 416);
            this.btnDeleteMap.Name = "btnDeleteMap";
            this.btnDeleteMap.Size = new System.Drawing.Size(286, 32);
            this.btnDeleteMap.TabIndex = 15;
            this.btnDeleteMap.Text = "🗑 Xóa Map đang chọn";
            this.btnDeleteMap.Click += new System.EventHandler(this.btnDeleteMap_Click);
            // 
            // dgvInstances
            // 
            this.dgvInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstances.Location = new System.Drawing.Point(9, 6);
            this.dgvInstances.Name = "dgvInstances";
            this.dgvInstances.RowHeadersVisible = false;
            this.dgvInstances.RowHeadersWidth = 51;
            this.dgvInstances.Size = new System.Drawing.Size(1086, 448);
            this.dgvInstances.TabIndex = 16;
            // 
            // tabBrowser
            // 
            this.tabBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabBrowser.Controls.Add(this.lblSearchServer);
            this.tabBrowser.Controls.Add(this.txtSearchServer);
            this.tabBrowser.Controls.Add(this.dgvBrowser);
            this.tabBrowser.Controls.Add(this.btnJoinServer);
            this.tabBrowser.Controls.Add(this.cmbCountryFilter);
            this.tabBrowser.Controls.Add(this.lblFilter);
            this.tabBrowser.Controls.Add(this.btnScanBrowser);
            this.tabBrowser.Controls.Add(this.pbTab3);
            this.tabBrowser.Controls.Add(this.cmbRegion);
            this.tabBrowser.Controls.Add(this.lblRegion);
            this.tabBrowser.Location = new System.Drawing.Point(4, 25);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Size = new System.Drawing.Size(1437, 462);
            this.tabBrowser.TabIndex = 2;
            this.tabBrowser.Text = "3. Global Server Browser";
            // 
            // lblSearchServer
            // 
            this.lblSearchServer.AutoSize = true;
            this.lblSearchServer.Location = new System.Drawing.Point(549, 16);
            this.lblSearchServer.Name = "lblSearchServer";
            this.lblSearchServer.Size = new System.Drawing.Size(118, 16);
            this.lblSearchServer.TabIndex = 0;
            this.lblSearchServer.Text = "🔎 Tìm Tên Server:";
            // 
            // txtSearchServer
            // 
            this.txtSearchServer.Location = new System.Drawing.Point(686, 13);
            this.txtSearchServer.Name = "txtSearchServer";
            this.txtSearchServer.Size = new System.Drawing.Size(171, 22);
            this.txtSearchServer.TabIndex = 1;
            this.txtSearchServer.TextChanged += new System.EventHandler(this.txtSearchServer_TextChanged);
            // 
            // dgvBrowser
            // 
            this.dgvBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBrowser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrowser.Location = new System.Drawing.Point(9, 48);
            this.dgvBrowser.Name = "dgvBrowser";
            this.dgvBrowser.RowHeadersVisible = false;
            this.dgvBrowser.RowHeadersWidth = 51;
            this.dgvBrowser.Size = new System.Drawing.Size(1417, 405);
            this.dgvBrowser.TabIndex = 2;
            this.dgvBrowser.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBrowser_ColumnHeaderMouseClick);
            // 
            // btnJoinServer
            // 
            this.btnJoinServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoinServer.Location = new System.Drawing.Point(1223, 11);
            this.btnJoinServer.Name = "btnJoinServer";
            this.btnJoinServer.Size = new System.Drawing.Size(149, 29);
            this.btnJoinServer.TabIndex = 3;
            this.btnJoinServer.Text = "🚀 JOIN SERVER";
            this.btnJoinServer.Click += new System.EventHandler(this.btnJoinServer_Click);
            // 
            // cmbCountryFilter
            // 
            this.cmbCountryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCountryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountryFilter.Location = new System.Drawing.Point(1006, 13);
            this.cmbCountryFilter.Name = "cmbCountryFilter";
            this.cmbCountryFilter.Size = new System.Drawing.Size(194, 24);
            this.cmbCountryFilter.TabIndex = 4;
            this.cmbCountryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCountryFilter_SelectedIndexChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(891, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(106, 16);
            this.lblFilter.TabIndex = 5;
            this.lblFilter.Text = "🎯 Lọc Quốc Gia:";
            // 
            // btnScanBrowser
            // 
            this.btnScanBrowser.Location = new System.Drawing.Point(280, 11);
            this.btnScanBrowser.Name = "btnScanBrowser";
            this.btnScanBrowser.Size = new System.Drawing.Size(137, 29);
            this.btnScanBrowser.TabIndex = 6;
            this.btnScanBrowser.Text = "🔍 Quét Server";
            this.btnScanBrowser.Click += new System.EventHandler(this.btnScanBrowser_Click);
            // 
            // pbTab3
            // 
            this.pbTab3.Location = new System.Drawing.Point(429, 21);
            this.pbTab3.Name = "pbTab3";
            this.pbTab3.Size = new System.Drawing.Size(91, 9);
            this.pbTab3.TabIndex = 7;
            this.pbTab3.Visible = false;
            // 
            // cmbRegion
            // 
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.Location = new System.Drawing.Point(97, 13);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(171, 24);
            this.cmbRegion.TabIndex = 8;
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(9, 16);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(82, 16);
            this.lblRegion.TabIndex = 9;
            this.lblRegion.Text = "Khu Vực API:";
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbConsole.Location = new System.Drawing.Point(0, 496);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(1444, 229);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "=== L4D2 ULTIMATE MANAGER ===\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 726);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1140, 637);
            this.Name = "Form1";
            this.Text = "L4D2 Ultimate Manager & Browser";
            this.tabControlMain.ResumeLayout(false);
            this.tabInstall.ResumeLayout(false);
            this.tabInstall.PerformLayout();
            this.tabManager.ResumeLayout(false);
            this.tabManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstances)).EndInit();
            this.tabBrowser.ResumeLayout(false);
            this.tabBrowser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrowser)).EndInit();
            this.ResumeLayout(false);

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

        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;

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