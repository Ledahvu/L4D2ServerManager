using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;

namespace L4D2ServerManager
{
    public partial class Form1 : Form
    {
        readonly string steamApiKey = "D22D6DB0616AF52E8DB856EA82C474C5";

        private readonly ProfileManager profileManager;
        private readonly WorkshopManager wsManager;
        private readonly ServerBrowser serverBrowser;
        private readonly InstanceManager instanceManager;

        private readonly List<BrowserServerInfo> allServers = new List<BrowserServerInfo>();
        private readonly BindingList<BrowserServerInfo> displayBrowserList = new BindingList<BrowserServerInfo>();
        private bool sortAscending = true;
        private bool isUpdatingUI = false;
        private bool isSyncingGridCombo = false;

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true; this.MinimizeBox = true;
            try { int c = 1; DwmSetWindowAttribute(this.Handle, 33, ref c, sizeof(int)); } catch { }

            profileManager = new ProfileManager();
            wsManager = new WorkshopManager();
            serverBrowser = new ServerBrowser(steamApiKey);
            instanceManager = new InstanceManager("");

            if (txtBaseDir != null) txtBaseDir.Text = @"C:\L4D2Ultimate";
            InitializeSystem();

            if (dgvInstances != null) { dgvInstances.DataSource = instanceManager.Instances; dgvInstances.SelectionChanged += dgvInstances_SelectionChanged; }
            if (dgvBrowser != null) dgvBrowser.DataSource = displayBrowserList;

            SetupRegionComboBox();

            if (cmbMaxPlayers != null) { for (int i = 4; i <= 32; i++) cmbMaxPlayers.Items.Add(i); cmbMaxPlayers.SelectedIndex = 0; }

            if (cmbTheme != null)
            {
                cmbTheme.Items.Add("🌙 Midnight Dark"); cmbTheme.Items.Add("☀️ Clean Light");
                cmbTheme.Items.Add("💻 Hacker Matrix"); cmbTheme.SelectedIndex = 0;
            }

            if (cmbMetaMod != null)
            {
                cmbMetaMod.Items.Add(new ComboItem { Text = "Bỏ qua (Không cài)", Value = "" });
                cmbMetaMod.Items.Add(new ComboItem { Text = "MetaMod 1.11 (Ổn định)", Value = "1.11" });
                cmbMetaMod.Items.Add(new ComboItem { Text = "MetaMod 1.12 (Mới nhất)", Value = "1.12" });
                cmbMetaMod.SelectedIndex = 1;
            }

            if (cmbSourceMod != null)
            {
                cmbSourceMod.Items.Add(new ComboItem { Text = "Bỏ qua (Không cài)", Value = "" });
                cmbSourceMod.Items.Add(new ComboItem { Text = "SourceMod 1.11 (Ổn định)", Value = "1.11" });
                cmbSourceMod.Items.Add(new ComboItem { Text = "SourceMod 1.12 (Mới nhất)", Value = "1.12" });
                cmbSourceMod.SelectedIndex = 1;
            }

            if (cmbL4dToolZ != null)
            {
                cmbL4dToolZ.Items.Add(new ComboItem { Text = "Bỏ qua (Không cài)", Value = "" });
                cmbL4dToolZ.Items.Add(new ComboItem { Text = "L4DToolZ v2.4.3 (Nhánh lakwsh)", Value = "https://github.com/lakwsh/l4dtoolz/releases/download/2.4.3/l4dtoolz-18820312043.zip" });
                cmbL4dToolZ.SelectedIndex = 1;
            }

            // ==========================================
            // CẬP NHẬT: TÁCH RIÊNG 2 COMBOBOX GAME MODE & MUTATION
            // ==========================================
            if (cmbGameMode != null)
            {
                cmbGameMode.Items.Clear();
                cmbGameMode.Items.Add(new ComboItem { Text = "📌 Chiến dịch (Campaign)", Value = "coop" });
                cmbGameMode.Items.Add(new ComboItem { Text = "📌 Chân thực (Realism)", Value = "realism" });
                cmbGameMode.Items.Add(new ComboItem { Text = "⚔️ Đối kháng (Versus)", Value = "versus" });
                cmbGameMode.Items.Add(new ComboItem { Text = "⚔️ Đ.kháng Chân thực", Value = "realismversus" });
                cmbGameMode.Items.Add(new ComboItem { Text = "🛡️ Sinh tồn (Survival)", Value = "survival" });
                cmbGameMode.Items.Add(new ComboItem { Text = "🛡️ Sinh tồn Đối kháng", Value = "mutation17" });
                cmbGameMode.Items.Add(new ComboItem { Text = "⛽ Thu thập (Scavenge)", Value = "scavenge" });
                cmbGameMode.Items.Add(new ComboItem { Text = "🧬 Đột biến (Mutations) ➡", Value = "mutation_menu" }); // Menu kích hoạt
                cmbGameMode.SelectedIndex = 0;
            }

            if (cmbMutation != null)
            {
                cmbMutation.Items.Clear();
                cmbMutation.Items.Add(new ComboItem { Text = "🩸 Bleed Out", Value = "mutation6" });
                cmbMutation.Items.Add(new ComboItem { Text = "🩸 Bleed Out Versus", Value = "mutation7" });
                cmbMutation.Items.Add(new ComboItem { Text = "🪚 Chainsaw Massacre", Value = "mutation2" });
                cmbMutation.Items.Add(new ComboItem { Text = "🏆 Confogl", Value = "confogl" });
                cmbMutation.Items.Add(new ComboItem { Text = "🏃 Dash", Value = "mutation11" });
                cmbMutation.Items.Add(new ComboItem { Text = "☠️ Death's Door", Value = "mutation14" });
                cmbMutation.Items.Add(new ComboItem { Text = "⛽ Follow the Liter", Value = "mutation8" });
                cmbMutation.Items.Add(new ComboItem { Text = "🍖 Gib Fest", Value = "mutation20" });
                cmbMutation.Items.Add(new ComboItem { Text = "♾️ Hard Eight", Value = "mutation15" });
                cmbMutation.Items.Add(new ComboItem { Text = "🛡️ Iron Man", Value = "mutation21" });
                cmbMutation.Items.Add(new ComboItem { Text = "🧙‍♂️ Last Gnome On Earth", Value = "mutation3" });
                cmbMutation.Items.Add(new ComboItem { Text = "👤 Last Man On Earth", Value = "mutation4" });
                cmbMutation.Items.Add(new ComboItem { Text = "🔫 Lone Gunman", Value = "mutation16" });
                cmbMutation.Items.Add(new ComboItem { Text = "🦍 Taaank!", Value = "mutation19" });
                cmbMutation.Items.Add(new ComboItem { Text = "⭐ VIP Target", Value = "vip_target" });
                cmbMutation.SelectedIndex = 0;
            }

            if (cmbDifficulty != null)
            {
                cmbDifficulty.Items.Clear();
                cmbDifficulty.Items.Add(new ComboItem { Text = "Dễ (Easy)", Value = "Easy" });
                cmbDifficulty.Items.Add(new ComboItem { Text = "Bình thường (Normal)", Value = "Normal" });
                cmbDifficulty.Items.Add(new ComboItem { Text = "Khó (Hard)", Value = "Hard" });
                cmbDifficulty.Items.Add(new ComboItem { Text = "Chuyên gia (Expert)", Value = "Impossible" });
                cmbDifficulty.SelectedIndex = 1;
            }
        }

        // ==========================================
        // CẬP NHẬT: SỰ KIỆN ẨN/HIỆN MENU MUTATION
        // ==========================================
        private void cmbGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGameMode.SelectedItem is ComboItem item && lblMutation != null && cmbMutation != null)
            {
                bool isMutation = item.Value == "mutation_menu";
                lblMutation.Visible = isMutation;
                cmbMutation.Visible = isMutation;
            }
        }

        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e) { ApplyTheme(cmbTheme.SelectedIndex); }

        private void ApplyTheme(int themeIndex)
        {
            Color formBg = themeIndex == 1 ? Color.FromArgb(243, 244, 246) : Color.FromArgb(30, 30, 30);
            Color panelBg = themeIndex == 1 ? Color.White : Color.FromArgb(45, 45, 48);
            Color textCol = themeIndex == 1 ? Color.Black : Color.White;
            Color actionBtn = Color.FromArgb(52, 152, 219);

            this.BackColor = formBg; this.ForeColor = textCol;
            foreach (TabPage tab in tabControlMain.TabPages) { tab.BackColor = panelBg; tab.ForeColor = textCol; }
            StyleDataGridView(dgvBrowser, panelBg, textCol, actionBtn, themeIndex == 1);
            StyleDataGridView(dgvInstances, panelBg, textCol, actionBtn, themeIndex == 1);
            StyleControlsRecursively(this, panelBg, textCol, Color.FromArgb(46, 204, 113), Color.IndianRed, actionBtn, themeIndex == 1);

            if (lstInstalledMaps != null) lstInstalledMaps.Invalidate();
        }

        private void StyleControlsRecursively(Control parent, Color panelBg, Color textCol, Color pBtn, Color dBtn, Color aBtn, bool isLight)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Cursor = Cursors.Hand; btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    if (btn.Name.Contains("Start")) btn.BackColor = pBtn;
                    else if (btn.Name.Contains("Stop") || btn.Name.Contains("Delete")) btn.BackColor = dBtn;
                    else if (btn.Name.Contains("InstallMod")) btn.BackColor = Color.FromArgb(155, 89, 182);
                    else btn.BackColor = aBtn;
                    btn.ForeColor = Color.White;
                }
                else if (c is TextBox txt) { txt.BorderStyle = BorderStyle.FixedSingle; txt.BackColor = panelBg; txt.ForeColor = textCol; }
                else if (c is ComboBox cmb) { cmb.FlatStyle = FlatStyle.Flat; cmb.BackColor = panelBg; cmb.ForeColor = textCol; }
                else if (c is ListBox lst) { lst.BorderStyle = BorderStyle.None; lst.BackColor = panelBg; lst.ForeColor = textCol; }
                else if (c is RichTextBox rtb) { rtb.BorderStyle = BorderStyle.None; rtb.BackColor = Color.Black; rtb.ForeColor = Color.Lime; }
                if (c.HasChildren) StyleControlsRecursively(c, panelBg, textCol, pBtn, dBtn, aBtn, isLight);
            }
        }

        private void StyleDataGridView(DataGridView dgv, Color bg, Color fg, Color selectBg, bool isLight) { if (dgv == null) return; dgv.EnableHeadersVisualStyles = false; dgv.BorderStyle = BorderStyle.None; dgv.RowHeadersVisible = false; dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; dgv.MultiSelect = false; dgv.BackgroundColor = bg; dgv.DefaultCellStyle.BackColor = bg; dgv.DefaultCellStyle.ForeColor = fg; dgv.DefaultCellStyle.SelectionBackColor = selectBg; dgv.ColumnHeadersDefaultCellStyle.BackColor = isLight ? Color.FromArgb(243, 244, 246) : Color.FromArgb(17, 24, 39); dgv.ColumnHeadersDefaultCellStyle.ForeColor = isLight ? Color.Black : Color.Gold; }
        private void LogToConsole(string text) { if (rtbConsole.InvokeRequired) { rtbConsole.Invoke(new Action(() => LogToConsole(text))); return; } rtbConsole.AppendText(text + Environment.NewLine); rtbConsole.ScrollToCaret(); }
        private void UpdateProgress(int p, ProgressBar pb) { if (pb.InvokeRequired) { pb.Invoke(new Action(() => UpdateProgress(p, pb))); return; } if (pb.Style == ProgressBarStyle.Marquee) pb.Style = ProgressBarStyle.Blocks; pb.Value = Math.Max(0, Math.Min(100, p)); }
        private void InitializeSystem() { if (txtBaseDir == null) return; profileManager.Initialize(txtBaseDir.Text); wsManager.BaseDirectory = txtBaseDir.Text; wsManager.SetupTools(); RefreshProfileDropdowns(); }
        private void btnBrowseBaseDir_Click(object sender, EventArgs e) { using (FolderBrowserDialog fbd = new FolderBrowserDialog()) { if (fbd.ShowDialog() == DialogResult.OK) { txtBaseDir.Text = fbd.SelectedPath; InitializeSystem(); } } }

        private void RefreshProfileDropdowns()
        {
            isUpdatingUI = true;
            if (cmbProfiles != null) { cmbProfiles.DataSource = new BindingSource(profileManager.Profiles, null); cmbProfiles.DisplayMember = "Name"; }
            if (cmbManagerProfiles != null) { cmbManagerProfiles.DataSource = new BindingSource(profileManager.Profiles, null); cmbManagerProfiles.DisplayMember = "Name"; }
            isUpdatingUI = false; LoadManagerMaps(); instanceManager.SyncWithProfiles(profileManager.Profiles);
        }

        private void LoadManagerMaps()
        {
            if (isUpdatingUI || cmbStartMap == null || lstInstalledMaps == null) return;
            if (!(cmbManagerProfiles.SelectedItem is ServerProfile selectedProfile)) return;

            if (lstInstalledMaps.DrawMode != DrawMode.OwnerDrawVariable)
            {
                lstInstalledMaps.DrawMode = DrawMode.OwnerDrawVariable;
                lstInstalledMaps.MeasureItem += (s, e) => { e.ItemHeight = 45; };
                lstInstalledMaps.DrawItem += (s, e) =>
                {
                    if (e.Index < 0) return;
                    e.DrawBackground();
                    if (((ListBox)s).Items[e.Index] is ListBoxItemWrapper item)
                    {
                        string[] lines = item.DisplayText.Split('\n');
                        using (var brush = new SolidBrush(e.ForeColor))
                        {
                            using (Font boldFont = new Font(e.Font, FontStyle.Bold))
                            {
                                e.Graphics.DrawString(lines[0], boldFont, brush, e.Bounds.Left + 5, e.Bounds.Top + 5);
                            }
                            if (lines.Length > 1)
                            {
                                Color subColor = e.BackColor.R < 128 ? Color.LightGray : Color.DimGray;
                                using (var brush2 = new SolidBrush(subColor))
                                {
                                    e.Graphics.DrawString(lines[1], e.Font, brush2, e.Bounds.Left + 15, e.Bounds.Top + 24);
                                }
                            }
                        }
                    }
                    e.DrawFocusRectangle();
                };
            }

            cmbStartMap.Items.Clear();
            lstInstalledMaps.Items.Clear();
            lstInstalledMaps.DisplayMember = "";

            string[] officialMaps = new string[] { "c1m1_hotel", "c2m1_highway", "c3m1_plankcountry", "c4m1_milltown_a", "c5m1_waterfront", "c8m1_apartment" };
            foreach (string map in officialMaps) cmbStartMap.Items.Add(new MapComboItem { Text = "⭐ Official - " + map, Value = map });

            if (selectedProfile.MapRecords != null)
            {
                foreach (var record in selectedProfile.MapRecords)
                {
                    string wsTitle = string.IsNullOrEmpty(record.DisplayName) ? "Unknown Map" : record.DisplayName;
                    string wsId = (record.WorkshopId != null && record.WorkshopId.StartsWith("MANUAL")) ? "Manual" : record.WorkshopId;
                    string vpkName = string.IsNullOrEmpty(record.VpkFileName) ? "Chưa rõ .vpk" : record.VpkFileName;
                    int bspCount = record.BspNames?.Count ?? 0;

                    string listText = $"🌍 {wsTitle}\n ↳ 📄 ID: {wsId} | File: {vpkName} ({bspCount} map)";
                    lstInstalledMaps.Items.Add(new ListBoxItemWrapper { Record = record, DisplayText = listText });

                    if (record.BspNames != null)
                    {
                        foreach (string bsp in record.BspNames)
                        {
                            cmbStartMap.Items.Add(new MapComboItem
                            {
                                Text = $"🧩 {bsp}  ⬅️  {wsTitle} (ID: {wsId} - {vpkName})",
                                Value = bsp
                            });
                        }
                    }
                }
            }
            if (cmbStartMap.Items.Count > 0) cmbStartMap.SelectedIndex = 0;
        }

        private void cmbManagerProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManagerMaps();
            if (isSyncingGridCombo || dgvInstances == null) return;
            if (cmbManagerProfiles.SelectedItem is ServerProfile profile)
            {
                isSyncingGridCombo = true;
                foreach (DataGridViewRow row in dgvInstances.Rows) if (row.DataBoundItem is ServerInstance inst && inst.Name == profile.Name) { row.Selected = true; break; }
                isSyncingGridCombo = false;
            }
        }

        private void dgvInstances_SelectionChanged(object sender, EventArgs e)
        {
            if (isSyncingGridCombo || cmbManagerProfiles == null) return;
            if (dgvInstances.SelectedRows.Count > 0 && dgvInstances.SelectedRows[0].DataBoundItem is ServerInstance inst)
            {
                isSyncingGridCombo = true;
                for (int i = 0; i < cmbManagerProfiles.Items.Count; i++) if (cmbManagerProfiles.Items[i] is ServerProfile p && p.Name == inst.Name) { cmbManagerProfiles.SelectedIndex = i; break; }
                isSyncingGridCombo = false;
            }
        }

        private void btnCreateProfile_Click(object sender, EventArgs e) { string name = txtProfileName.Text.Trim(); if (string.IsNullOrEmpty(name) || !int.TryParse(txtProfilePort.Text, out int port)) { MessageBox.Show("Lỗi"); return; } profileManager.CreateProfile(name, port, txtBaseDir.Text); RefreshProfileDropdowns(); }

        private async void btnInstallServer_Click(object sender, EventArgs e)
        {
            if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return;
            btnInstallServer.Enabled = false; btnInstallMods.Enabled = false; pbTab1.Visible = true; pbTab1.Value = 0; pbTab1.Style = ProgressBarStyle.Blocks;
            LogToConsole($"\n=== CÀI ĐẶT MÁY CHỦ [{profile.Name}] ===");
            try
            {
                await wsManager.InstallOrVerifyServerAsync(profile.InstallPath, false, LogToConsole, p => UpdateProgress(p, pbTab1));
                LogToConsole("✅ Đã cài đặt xong dữ liệu Server L4D2 gốc!");
            }
            catch (Exception ex) { LogToConsole($"❌ Lỗi: {ex.Message}"); }
            finally { btnInstallServer.Enabled = true; btnInstallMods.Enabled = true; pbTab1.Visible = false; }
        }

        private async void btnInstallMods_Click(object sender, EventArgs e)
        {
            if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return;

            string exePath = Path.Combine(profile.InstallPath, "srcds.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show("Profile này chưa được cài đặt Server!\nVui lòng bấm 'Cài Đặt Server (L4D2)' trước khi cài Extension.", "Lỗi Cài Đặt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnInstallServer.Enabled = false; btnInstallMods.Enabled = false; pbTab1.Visible = true; pbTab1.Value = 0; pbTab1.Style = ProgressBarStyle.Blocks;
            LogToConsole($"\n=== CÀI EXTENSION CHO [{profile.Name}] ===");
            try
            {
                string mmBranch = ((ComboItem)cmbMetaMod.SelectedItem).Value;
                string smBranch = ((ComboItem)cmbSourceMod.SelectedItem).Value;
                string toolzUrl = ((ComboItem)cmbL4dToolZ.SelectedItem).Value;

                if (string.IsNullOrEmpty(mmBranch) && string.IsNullOrEmpty(smBranch) && string.IsNullOrEmpty(toolzUrl))
                {
                    LogToConsole("⚠️ Bạn chưa chọn cài đặt MetaMod, SourceMod hay L4DToolZ nào cả!");
                    return;
                }

                await wsManager.InstallModsAndExtensionsAsync(profile.InstallPath, mmBranch, smBranch, toolzUrl, LogToConsole, p => UpdateProgress(p, pbTab1));
            }
            catch (Exception ex) { LogToConsole($"❌ Lỗi: {ex.Message}"); }
            finally { btnInstallServer.Enabled = true; btnInstallMods.Enabled = true; pbTab1.Visible = false; }
        }

        private async void btnVerify_Click(object sender, EventArgs e) { if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return; btnVerify.Enabled = false; pbTab1.Visible = true; pbTab1.Value = 0; try { await wsManager.InstallOrVerifyServerAsync(profile.InstallPath, true, LogToConsole, p => UpdateProgress(p, pbTab1)); LogToConsole("✅ Verify xong."); } catch { } finally { btnVerify.Enabled = true; pbTab1.Visible = false; } }

        private async void btnInstallMap_Click(object sender, EventArgs e)
        {
            if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return;
            string[] links = txtWorkshopLinks.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (links.Length == 0) return;

            btnInstallMap.Enabled = false; pbTab1.Visible = true; pbTab1.Value = 0;
            try
            {
                foreach (string link in links)
                {
                    string id = wsManager.GetWorkshopId(link);
                    if (id != null)
                    {
                        LogToConsole($"⏬ Bắt đầu xử lý tải Map ID: {id}...");
                        await wsManager.DownloadMapAsync(id, LogToConsole, p => UpdateProgress(p, pbTab1));
                        await wsManager.InstallVpkToProfileAsync(id, profile, profileManager, LogToConsole);
                    }
                }
                LogToConsole("✅ Đã hoàn tất cài đặt toàn bộ Map!");
                LoadManagerMaps();
            }
            catch (Exception ex) { LogToConsole($"❌ Lỗi: {ex.Message}"); }
            finally { btnInstallMap.Enabled = true; pbTab1.Visible = false; }
        }

        private async void btnImportManualMap_Click(object sender, EventArgs e) { if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return; using (OpenFileDialog ofd = new OpenFileDialog { Filter = "VPK Files (*.vpk)|*.vpk" }) { if (ofd.ShowDialog() == DialogResult.OK) { try { await wsManager.InstallManualVpkAsync(ofd.FileName, profile, profileManager, LogToConsole); LoadManagerMaps(); } catch { } } } }
        private void btnConfigServer_Click(object sender, EventArgs e) { if (!(cmbProfiles.SelectedItem is ServerProfile profile)) return; try { string cfgPath = Path.Combine(profile.InstallPath, @"left4dead2\cfg\server.cfg"); Directory.CreateDirectory(Path.GetDirectoryName(cfgPath)); new ServerConfigurator(cfgPath).GenerateConfig(string.IsNullOrWhiteSpace(txtServerName.Text) ? profile.Name : txtServerName.Text, (int)cmbMaxPlayers.SelectedItem, txtSteamGroup.Text); LogToConsole($"✅ Đã tạo file cfg!"); } catch { } }

        private void btnDeleteMap_Click(object sender, EventArgs e)
        {
            if (!(cmbManagerProfiles.SelectedItem is ServerProfile profile)) return;

            if (lstInstalledMaps.SelectedItem is ListBoxItemWrapper wrapper &&
                MessageBox.Show($"Bạn có chắc chắn muốn xóa hệ thống Map này?\n\n{wrapper.DisplayText}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var record = wrapper.Record;
                try
                {
                    if (string.IsNullOrEmpty(record.VpkFileName))
                    {
                        MessageBox.Show("Đây là Map cũ chưa được lưu trữ tên file VPK.\nTool sẽ gỡ Map này khỏi danh sách, nhưng bạn cần tự vào thư mục addons để xóa file .vpk thủ công!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        profile.MapRecords.Remove(record);
                        profileManager.SaveProfiles();
                    }
                    else
                    {
                        profileManager.RemoveSpecificMap(profile, record);
                    }
                    LoadManagerMaps();
                }
                catch (Exception ex) { MessageBox.Show($"Đã xảy ra lỗi khi xóa file: {ex.Message}", "Lỗi Xóa Map", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ==========================================
        // CẬP NHẬT: LOGIC TRUYỀN PARAMETER CHO NÚT START GAME
        // ==========================================
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!(cmbManagerProfiles.SelectedItem is ServerProfile profile) || cmbStartMap.SelectedItem == null) return;
            var currentInst = instanceManager.Instances.FirstOrDefault(i => i.Name == profile.Name);
            if (currentInst != null && currentInst.ProcessId != 0) { MessageBox.Show("Đang chạy rồi!"); return; }

            string exePath = Path.Combine(profile.InstallPath, "srcds.exe");
            if (!File.Exists(exePath)) { MessageBox.Show("Profile này chưa được cài L4D2 Server! Vui lòng sang Tab 1 để Cài đặt."); return; }

            string selectedMap = ((MapComboItem)cmbStartMap.SelectedItem).Value;
            bool useConsole = chkConsoleMode.Checked;
            string difficulty = ((ComboItem)cmbDifficulty.SelectedItem).Value;

            // Xử lý logic gộp chế độ chơi
            string gameMode = ((ComboItem)cmbGameMode.SelectedItem).Value;
            if (gameMode == "mutation_menu")
            {
                gameMode = ((ComboItem)cmbMutation.SelectedItem).Value;
            }

            try { instanceManager.StartInstance(profile.Name, exePath, profile.Port, selectedMap, (int)cmbMaxPlayers.SelectedItem, useConsole, difficulty, gameMode, LogToConsole); } catch (Exception ex) { LogToConsole($"❌ {ex.Message}"); }
        }

        private void btnStop_Click(object sender, EventArgs e) { if (dgvInstances.SelectedRows.Count > 0 && dgvInstances.SelectedRows[0].DataBoundItem is ServerInstance instance) instanceManager.StopInstance(instance.Name); }

        private void SetupRegionComboBox()
        {
            if (cmbRegion == null) return;
            cmbRegion.DisplayMember = "Text";
            cmbRegion.ValueMember = "Value";
            cmbRegion.Items.Clear();

            cmbRegion.Items.Add(new { Text = "🌍 Toàn Cầu (All)", Value = 255 });
            cmbRegion.Items.Add(new { Text = "🇺🇸 Bắc Mỹ (Bờ Đông)", Value = 0 });
            cmbRegion.Items.Add(new { Text = "🇺🇸 Bắc Mỹ (Bờ Tây)", Value = 1 });
            cmbRegion.Items.Add(new { Text = "🌎 Nam Mỹ", Value = 2 });
            cmbRegion.Items.Add(new { Text = "🇪🇺 Châu Âu", Value = 3 });
            cmbRegion.Items.Add(new { Text = "🌏 Châu Á", Value = 4 });
            cmbRegion.Items.Add(new { Text = "🦘 Úc / Châu Đại Dương", Value = 5 });
            cmbRegion.Items.Add(new { Text = "🐪 Trung Đông", Value = 6 });
            cmbRegion.Items.Add(new { Text = "🌍 Châu Phi", Value = 7 });

            cmbRegion.SelectedIndex = 5;
        }

        private string NormalizeCountryName(string countryCodeOrName)
        {
            if (string.IsNullOrEmpty(countryCodeOrName)) return "Không xác định";
            string c = countryCodeOrName.Trim().ToUpper();

            if (c == "US" || c == "USA" || c == "UNITED STATES" || c == "MỸ" || c == "HOA KY") return "Hoa Kỳ";
            if (c == "CN" || c == "CHINA" || c == "TRUNG QUỐC" || c == "TRUNG QUOC") return "Trung Quốc";
            if (c == "VN" || c == "VIETNAM" || c == "VIET NAM" || c == "VIỆT NAM") return "Việt Nam";
            if (c == "TW" || c == "TAIWAN" || c == "ĐÀI LOAN" || c == "DAI LOAN") return "Đài Loan";
            if (c == "KR" || c == "KOREA" || c == "HÀN QUỐC" || c == "SOUTH KOREA" || c == "REPUBLIC OF KOREA") return "Hàn Quốc";
            if (c == "JP" || c == "JAPAN" || c == "NHẬT BẢN") return "Nhật Bản";
            if (c == "SG" || c == "SINGAPORE") return "Singapore";
            if (c == "TH" || c == "THAILAND" || c == "THÁI LAN") return "Thái Lan";
            if (c == "MY" || c == "MALAYSIA") return "Malaysia";
            if (c == "ID" || c == "INDONESIA") return "Indonesia";
            if (c == "PH" || c == "PHILIPPINES") return "Philippines";
            if (c == "HK" || c == "HONG KONG") return "Hồng Kông";
            if (c == "RU" || c == "RUSSIA" || c == "NGA" || c == "RUSSIAN FEDERATION") return "Nga";
            if (c == "IN" || c == "INDIA" || c == "ẤN ĐỘ") return "Ấn Độ";
            if (c == "BR" || c == "BRAZIL") return "Brazil";
            if (c == "GB" || c == "UK" || c == "UNITED KINGDOM" || c == "ANH") return "Vương Quốc Anh";
            if (c == "DE" || c == "GERMANY" || c == "ĐỨC") return "Đức";
            if (c == "FR" || c == "FRANCE" || c == "PHÁP") return "Pháp";

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(countryCodeOrName.ToLower());
        }

        private async void btnScanBrowser_Click(object sender, EventArgs e)
        {
            if (cmbRegion.SelectedItem == null) return;
            allServers.Clear(); displayBrowserList.Clear(); btnScanBrowser.Enabled = false; pbTab3.Visible = true; pbTab3.Style = ProgressBarStyle.Marquee;

            try
            {
                var selectedItem = (dynamic)cmbRegion.SelectedItem;
                int selectedRegionValue = (int)selectedItem.Value;
                ServerRegion region = (ServerRegion)selectedRegionValue;

                bool isScanningAsia = (selectedRegionValue == 4);
                string[] westernFakeCountries = { "Hoa Kỳ", "Nga", "Brazil", "Argentina", "Peru", "Đức", "Pháp", "Vương Quốc Anh", "Canada", "Chile" };

                await serverBrowser.ScanServersAsync(region, s =>
                {
                    if (s.Country != null) s.Country = NormalizeCountryName(s.Country);
                    if (isScanningAsia && s.Country != null && westernFakeCountries.Contains(s.Country)) return;
                    allServers.Add(s);
                }, LogToConsole);

                for (int i = 0; i < allServers.Count; i++) allServers[i].STT = i + 1;

                if (cmbCountryFilter != null)
                {
                    var uc = allServers.Select(s => s.Country).Where(c => !string.IsNullOrEmpty(c)).Distinct().OrderBy(c => c).ToList();
                    uc.Insert(0, "TẤT CẢ");
                    cmbCountryFilter.DataSource = uc;
                }
            }
            catch (Exception ex) { LogToConsole($"❌ Lỗi quét Browser: {ex.Message}"); }
            finally { btnScanBrowser.Enabled = true; pbTab3.Visible = false; }
        }

        private void txtSearchServer_TextChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void cmbCountryFilter_SelectedIndexChanged(object sender, EventArgs e) { ApplyFilter(); }
        private void ApplyFilter() { if (cmbCountryFilter.SelectedItem == null) return; string sc = cmbCountryFilter.SelectedItem.ToString(); string st = txtSearchServer != null ? txtSearchServer.Text.Trim().ToLower() : ""; displayBrowserList.Clear(); foreach (var s in allServers) if ((sc == "TẤT CẢ" || s.Country == sc) && (string.IsNullOrEmpty(st) || (s.Name != null && s.Name.ToLower().Contains(st)))) displayBrowserList.Add(s); }
        private void dgvBrowser_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) { if (displayBrowserList.Count == 0) return; string cn = dgvBrowser.Columns[e.ColumnIndex].DataPropertyName; List<BrowserServerInfo> sl = sortAscending ? displayBrowserList.OrderBy(x => x.GetType().GetProperty(cn).GetValue(x, null)).ToList() : displayBrowserList.OrderByDescending(x => x.GetType().GetProperty(cn).GetValue(x, null)).ToList(); sortAscending = !sortAscending; for (int i = 0; i < sl.Count; i++) sl[i].STT = i + 1; displayBrowserList.Clear(); foreach (var i in sl) displayBrowserList.Add(i); }
        private void btnJoinServer_Click(object sender, EventArgs e) { if (dgvBrowser.SelectedRows.Count > 0 && dgvBrowser.SelectedRows[0].DataBoundItem is BrowserServerInfo ss) Process.Start(new ProcessStartInfo { FileName = $"steam://connect/{ss.Endpoint}", UseShellExecute = true }); }
    }

    public class ComboItem { public string Text { get; set; } public string Value { get; set; } public override string ToString() => Text; }
    public class MapComboItem { public string Text { get; set; } public string Value { get; set; } public override string ToString() => Text; }

    public class ListBoxItemWrapper
    {
        public MapRecord Record { get; set; }
        public string DisplayText { get; set; }
        public override string ToString() => DisplayText;
    }
}