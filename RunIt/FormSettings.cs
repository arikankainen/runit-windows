using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RunIt
{
    public partial class FormSettings : Form
    {
        private Settings settings = new Settings();
        private Color folderNotExist = ColorTranslator.FromHtml("#f7bfbf");
        private Color folderExist = Color.White;
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);

        public FormSettings()
        {
            InitializeComponent();

            foreach (FontFamily font in FontFamily.Families)
            {
                comboFontGroup.Items.Add(font.Name);
                comboFontShortcut.Items.Add(font.Name);
            }
        }

        // ********** Form events **********

        private void FormSettings_Load(object sender, EventArgs e)
        {
            txtShortcutFolder_TextChanged(null, null);
            txtCustom_TextChanged(null, null);

            loadSettings();
            labelVersion.Text = "RunIt v" + Application.ProductVersion + " © 2018 Ari Kankainen";

            tabControl1.SelectedIndex = (Application.OpenForms["Form1"] as Form1).SettingsPage;
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            (Application.OpenForms["Form1"] as Form1).ShowWindow();
            this.Activate();

            if (!Directory.Exists(txtShortcutFolder.Text))
            {
                txtShortcutFolder.BackColor = folderNotExist;
                btnBrowse.PerformClick();
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Application.OpenForms["Form1"] as Form1).SettingsPage = tabControl1.SelectedIndex;
        }

        private void FormSettings_Move(object sender, EventArgs e)
        {
            updatePreview();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                btnResetAppearance.Visible = true;
                btnLoadAppearance.Visible = true;
                btnSaveAppearance.Visible = true;
            }

            else
            {
                btnResetAppearance.Visible = false;
                btnLoadAppearance.Visible = false;
                btnSaveAppearance.Visible = false;
            }
        }

        // ********** Button events **********

        private void btnApply_Click(object sender, EventArgs e)
        {
            saveSettings();
            (Application.OpenForms["Form1"] as Form1).ReloadSettings(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            saveSettings();
            (Application.OpenForms["Form1"] as Form1).ReloadSettings(false);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (Directory.Exists(txtShortcutFolder.Text)) folder.SelectedPath = txtShortcutFolder.Text;
            folder.Description = "Select shortcut folder:";
            folder.ShowNewFolderButton = true;

            DialogResult result = folder.ShowDialog();
            if (folder.SelectedPath != "") txtShortcutFolder.Text = folder.SelectedPath;
        }

        private void btnBrowseCustomProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Programs (*.exe, *.com)|*.exe;*.com|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    txtCustomProgram.Text = dlg.FileName;
                }
            }
        }

        private void btnColorBackground_Click(object sender, EventArgs e)
        {
            string selected = txtColorBackground.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorBackground.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorGroupBackground_Click(object sender, EventArgs e)
        {
            string selected = txtColorGroupBackground.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorGroupBackground.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorShortcutBackground_Click(object sender, EventArgs e)
        {
            string selected = txtColorShortcutBackground.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorShortcutBackground.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorShortcutBackgroundHover_Click(object sender, EventArgs e)
        {
            string selected = txtColorShortcutBackgroundHover.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorShortcutBackgroundHover.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorTooltipBackground_Click(object sender, EventArgs e)
        {
            string selected = txtColorTooltipBackground.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorTooltipBackground.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorGroupFont_Click(object sender, EventArgs e)
        {
            string selected = txtColorGroupFont.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorGroupFont.Text = ColorTranslator.ToHtml(dlg.Color);
        }

        private void btnColorShortcutFont_Click(object sender, EventArgs e)
        {
            string selected = txtColorShortcutFont.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorShortcutFont.Text = ColorTranslator.ToHtml(dlg.Color);
        }


        private void btnColorTooltipFont_Click(object sender, EventArgs e)
        {
            string selected = txtColorTooltipFont.Text;

            Color clr = ColorTranslator.FromHtml(selected);
            ColorDialog dlg = new ColorDialog();
            dlg.Color = clr;
            dlg.FullOpen = true;
            if (dlg.ShowDialog() != DialogResult.Cancel) txtColorTooltipFont.Text = ColorTranslator.ToHtml(dlg.Color);
        }


        private void btnFontGroup_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                comboFontGroup.Text = dlg.Font.FontFamily.Name;
                numericFontGroupSize.Value = (int)dlg.Font.Size;
                checkFontGroupBold.Checked = dlg.Font.Bold;
                checkFontGroupItalic.Checked = dlg.Font.Italic;
            }

            setExampleFonts();
        }

        private void btnFontShortcut_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                comboFontShortcut.Text = dlg.Font.FontFamily.Name;
                numericFontShortcutSize.Value = (int)dlg.Font.Size;
                checkFontShortcutBold.Checked = dlg.Font.Bold;
                checkFontShortcutItalic.Checked = dlg.Font.Italic;
            }

            setExampleFonts();
        }

        private void btnResetAppearance_Click(object sender, EventArgs e)
        {
            txtColorBackground.Text = "#1F1F1F";
            txtColorGroupBackground.Text = "#161616";
            txtColorShortcutBackground.Text = "#333333";
            txtColorShortcutBackgroundHover.Text = "#3F3F3F";
            txtColorTooltipBackground.Text = "#3F3F3F";

            txtColorGroupFont.Text = "#ADADAD";
            txtColorShortcutFont.Text = "#DADADA";
            txtColorTooltipFont.Text = "#DADADA";

            comboFontGroup.Text = "Segoe UI";
            numericFontGroupSize.Value = 12;
            checkFontGroupBold.Checked = false;
            checkFontGroupItalic.Checked = false;

            comboFontShortcut.Text = "Microsoft Sans Serif";
            numericFontShortcutSize.Value = 8;
            checkFontShortcutBold.Checked = false;
            checkFontShortcutItalic.Checked = false;

            numericOuterMargin.Value = 0;

            numericGroupMargin.Value = 10;
            numericGroupLabel.Value = 23;

            numericShortcutMargin.Value = 10;
            numericShortcutLabelHeight.Value = 26;
            numericShortcutBoxSize.Value = 80;
            numericShortcutIconSize.Value = 32;

            numericToolTipMarginTop.Value = 2;
            numericToolTipPaddingWidth.Value = 0;
            numericToolTipPaddingHeight.Value = 0;

            numericHorizontal.Value = 4;

            checkShowShortcutLabels.Checked = true;
            checkShowShortcutTooltips.Checked = false;

            comboGroupTopicAlign.Text = "Left";
            comboShortcutTextAlign.Text = "Middle";

            numericOpacity.Value = 96;
            numericFadeSpeed.Value = 15;
        }

        private void btnSaveAppearance_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "RunIt appearance files (*.runit)|*.runit|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.InitialDirectory = appDir;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(dlg.FileName)) File.Delete(dlg.FileName);
                }

                catch
                {
                    MessageBox.Show("Failed to save.");
                }

                Settings export = new Settings();
                export.CfgFile = dlg.FileName;

                export.OpenSettings();

                if (validColor(txtColorBackground.Text)) export.SetSetting("ColorBackground", txtColorBackground.Text);
                else export.EraseSetting("ColorBackground");

                if (validColor(txtColorGroupBackground.Text)) export.SetSetting("ColorGroupBackground", txtColorGroupBackground.Text);
                else export.EraseSetting("ColorGroupBackground");

                if (validColor(txtColorShortcutBackground.Text)) export.SetSetting("ColorShortcutBackground", txtColorShortcutBackground.Text);
                else export.EraseSetting("ColorShortcutBackground");

                if (validColor(txtColorShortcutBackgroundHover.Text)) export.SetSetting("ColorShortcutBackgroundHover", txtColorShortcutBackgroundHover.Text);
                else export.EraseSetting("ColorShortcutBackgroundHover");

                if (validColor(txtColorTooltipBackground.Text)) export.SetSetting("ColorToolTipBackground", txtColorTooltipBackground.Text);
                else export.EraseSetting("ColorToolTipBackground");


                if (validColor(txtColorGroupFont.Text)) export.SetSetting("ColorGroupFont", txtColorGroupFont.Text);
                else export.EraseSetting("ColorGroupFont");

                if (validColor(txtColorShortcutFont.Text)) export.SetSetting("ColorShortcutFont", txtColorShortcutFont.Text);
                else export.EraseSetting("ColorShortcutFont");

                if (validColor(txtColorTooltipFont.Text)) export.SetSetting("ColorToolTipFont", txtColorTooltipFont.Text);
                else export.EraseSetting("ColorToolTipFont");


                if (validFont(comboFontGroup.Text, (float)numericFontGroupSize.Value, checkFontGroupBold.Checked, checkFontGroupItalic.Checked))
                {
                    export.SetSetting("FontGroup", comboFontGroup.Text);
                    export.SetSetting("FontGroupSize", numericFontGroupSize.Value.ToString());
                    export.SetSetting("FontGroupBold", checkFontGroupBold.Checked.ToString());
                    export.SetSetting("FontGroupItalic", checkFontGroupItalic.Checked.ToString());
                }

                else
                {
                    export.EraseSetting("FontGroup");
                    export.EraseSetting("FontGroupSize");
                    export.EraseSetting("FontGroupBold");
                    export.EraseSetting("FontGroupItalic");
                }


                if (validFont(comboFontShortcut.Text, (float)numericFontShortcutSize.Value, checkFontShortcutBold.Checked, checkFontShortcutItalic.Checked))
                {
                    export.SetSetting("FontShortcut", comboFontShortcut.Text);
                    export.SetSetting("FontShortcutSize", numericFontShortcutSize.Value.ToString());
                    export.SetSetting("FontShortcutBold", checkFontShortcutBold.Checked.ToString());
                    export.SetSetting("FontShortcutItalic", checkFontShortcutItalic.Checked.ToString());
                }

                else
                {
                    export.EraseSetting("FontShortcut");
                    export.EraseSetting("FontShortcutSize");
                    export.EraseSetting("FontShortcutBold");
                    export.EraseSetting("FontShortcutItalic");
                }


                export.SetSetting("OuterMargin", numericOuterMargin.Value.ToString());

                export.SetSetting("GroupMargin", numericGroupMargin.Value.ToString());
                export.SetSetting("GroupLabelHeight", numericGroupLabel.Value.ToString());

                export.SetSetting("ShortcutMargin", numericShortcutMargin.Value.ToString());
                export.SetSetting("ShortcutLabelHeight", numericShortcutLabelHeight.Value.ToString());
                export.SetSetting("ShortcutBoxSize", numericShortcutBoxSize.Value.ToString());
                export.SetSetting("ShortcutIconSize", numericShortcutIconSize.Value.ToString());

                export.SetSetting("ToolTipMarginTop", numericToolTipMarginTop.Value.ToString());
                export.SetSetting("ToolTipPaddingWidth", numericToolTipPaddingWidth.Value.ToString());
                export.SetSetting("ToolTipPaddingHeight", numericToolTipPaddingHeight.Value.ToString());

                export.SetSetting("HorizontalShortcuts", numericHorizontal.Value.ToString());

                export.SetSetting("ShowShortcutLabels", checkShowShortcutLabels.Checked.ToString());
                export.SetSetting("ShowShortcutTooltips", checkShowShortcutTooltips.Checked.ToString());

                export.SetSetting("GroupTopicAlign", comboGroupTopicAlign.Text);
                export.SetSetting("ShortcutTextAlign", comboShortcutTextAlign.Text);

                export.SetSetting("Opacity", (numericOpacity.Value / 100).ToString());
                export.SetSetting("Fade", checkFade.Checked.ToString());
                export.SetSetting("FadeSpeed", numericFadeSpeed.Value.ToString());

                export.WriteSettings();
            }
        }

        private void btnLoadAppearance_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "RunIt appearance files (*.runit)|*.runit|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.InitialDirectory = appDir;
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    string[] test = File.ReadAllLines(dlg.FileName);

                    if (test[0] == "<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                    {
                        Settings import = new Settings();
                        import.CfgFile = dlg.FileName;

                        import.OpenSettings();

                        txtColorBackground.Text = import.GetSetting("ColorBackground", "string", "#1F1F1F");
                        txtColorGroupBackground.Text = import.GetSetting("ColorGroupBackground", "string", "#161616");
                        txtColorShortcutBackground.Text = import.GetSetting("ColorShortcutBackground", "string", "#333333");
                        txtColorShortcutBackgroundHover.Text = import.GetSetting("ColorShortcutBackgroundHover", "string", "#3F3F3F");
                        txtColorTooltipBackground.Text = import.GetSetting("ColorToolTipBackground", "string", "#3F3F3F");

                        txtColorGroupFont.Text = import.GetSetting("ColorGroupFont", "string", "#ADADAD");
                        txtColorShortcutFont.Text = import.GetSetting("ColorShortcutFont", "string", "#DADADA");
                        txtColorTooltipFont.Text = import.GetSetting("ColorShortcutFont", "string", "#DADADA");

                        comboFontGroup.Text = import.GetSetting("FontGroup", "string", "Segoe UI");
                        numericFontGroupSize.Value = import.GetSetting("FontGroupSize", "int", "12");
                        checkFontGroupBold.Checked = import.GetSetting("FontGroupBold", "bool", "false");
                        checkFontGroupItalic.Checked = import.GetSetting("FontGroupItalic", "bool", "false");

                        comboFontShortcut.Text = import.GetSetting("FontShortcut", "string", "Microsoft Sans Serif");
                        numericFontShortcutSize.Value = import.GetSetting("FontShortcutSize", "int", "8");
                        checkFontShortcutBold.Checked = import.GetSetting("FontShortcutBold", "bool", "false");
                        checkFontShortcutItalic.Checked = import.GetSetting("FontShortcutItalic", "bool", "false");

                        numericOuterMargin.Value = import.GetSetting("OuterMargin", "int", "0");

                        numericGroupMargin.Value = import.GetSetting("GroupMargin", "int", "10");
                        numericGroupLabel.Value = import.GetSetting("GroupLabelHeight", "int", "23");

                        numericShortcutMargin.Value = import.GetSetting("ShortcutMargin", "int", "10");
                        numericShortcutLabelHeight.Value = import.GetSetting("ShortcutLabelHeight", "int", "26");
                        numericShortcutBoxSize.Value = import.GetSetting("ShortcutBoxSize", "int", "80");
                        numericShortcutIconSize.Value = import.GetSetting("ShortcutIconSize", "int", "32");

                        numericToolTipMarginTop.Value = import.GetSetting("ToolTipMarginTop", "int", "2");
                        numericToolTipPaddingWidth.Value = import.GetSetting("ToolTipPaddingWidth", "int", "0");
                        numericToolTipPaddingHeight.Value = import.GetSetting("ToolTipPaddingHeight", "int", "0");

                        numericHorizontal.Value = import.GetSetting("HorizontalShortcuts", "int", "4");

                        checkShowShortcutLabels.Checked = import.GetSetting("ShowShortcutLabels", "bool", "true");
                        checkShowShortcutTooltips.Checked = import.GetSetting("ShowShortcutTooltips", "bool", "false");

                        comboGroupTopicAlign.Text = import.GetSetting("GroupTopicAlign", "string", "Left");
                        comboShortcutTextAlign.Text = import.GetSetting("ShortcutTextAlign", "string", "Middle");

                        numericOpacity.Value = trackOpacity.Value = (int)(100 * import.GetSetting("Opacity", "dec", "0,96"));
                        checkFade.Checked = import.GetSetting("Fade", "bool", "true");
                        numericFadeSpeed.Value = trackFadeSpeed.Value = import.GetSetting("FadeSpeed", "int", "15");
                    }

                    else MessageBox.Show("Invalid file.");
                }
            }
        }

        // ********** Changed events **********

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            if (validColor(txtColorBackground.Text)) panelColorBackground.BackColor = ColorTranslator.FromHtml(txtColorBackground.Text);
            else panelColorBackground.BackColor = Color.White;

            if (validColor(txtColorGroupBackground.Text)) panelColorGroupBackground.BackColor = ColorTranslator.FromHtml(txtColorGroupBackground.Text);
            else panelColorGroupBackground.BackColor = Color.White;

            if (validColor(txtColorShortcutBackground.Text)) panelColorShortcutBackground.BackColor = ColorTranslator.FromHtml(txtColorShortcutBackground.Text);
            else panelColorShortcutBackground.BackColor = Color.White;

            if (validColor(txtColorShortcutBackgroundHover.Text)) panelColorShortcutBackgroundHover.BackColor = ColorTranslator.FromHtml(txtColorShortcutBackgroundHover.Text);
            else panelColorShortcutBackgroundHover.BackColor = Color.White;

            if (validColor(txtColorTooltipBackground.Text)) panelColorTooltipBackground.BackColor = ColorTranslator.FromHtml(txtColorTooltipBackground.Text);
            else panelColorTooltipBackground.BackColor = Color.White;

            if (validColor(txtColorGroupFont.Text)) panelColorGroupFont.BackColor = ColorTranslator.FromHtml(txtColorGroupFont.Text);
            else panelColorGroupFont.BackColor = Color.White;

            if (validColor(txtColorShortcutFont.Text)) panelColorShortcutFont.BackColor = ColorTranslator.FromHtml(txtColorShortcutFont.Text);
            else panelColorShortcutFont.BackColor = Color.White;

            if (validColor(txtColorTooltipFont.Text)) panelColorTooltipFont.BackColor = ColorTranslator.FromHtml(txtColorTooltipFont.Text);
            else panelColorTooltipFont.BackColor = Color.White;
        }

        private void font_TextChanged(object sender, EventArgs e)
        {
            setExampleFonts();
        }

        // ********** Key events **********

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void txtHotkey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtHotkey.Text = "";
                label1.Focus();
            }

            else if (e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.LWin && e.KeyCode != Keys.RWin && e.KeyCode != Keys.ControlKey)
            {
                txtHotkey.Text = e.KeyCode.ToString();
                label1.Focus();
            }
        }

        // ********** Methods **********

        private void setExampleFonts()
        {
            if (validFont(comboFontGroup.Text, (float)numericFontGroupSize.Value, checkFontGroupBold.Checked, checkFontGroupItalic.Checked))
            {
                labelExampleGroup.Visible = true;

                FontStyle fontStyle;
                if (checkFontGroupBold.Checked && checkFontGroupItalic.Checked) fontStyle = FontStyle.Bold | FontStyle.Italic;
                else if (checkFontGroupBold.Checked) fontStyle = FontStyle.Bold;
                else if (checkFontGroupItalic.Checked) fontStyle = FontStyle.Italic;
                else fontStyle = FontStyle.Regular;

                labelExampleGroup.Font = new Font(comboFontGroup.Text, (float)numericFontGroupSize.Value, fontStyle);
            }

            else labelExampleGroup.Visible = false;

            if (validFont(comboFontShortcut.Text, (float)numericFontShortcutSize.Value, checkFontShortcutBold.Checked, checkFontShortcutItalic.Checked))
            {
                labelExampleShortcut.Visible = true;

                FontStyle fontStyle;
                if (checkFontShortcutBold.Checked && checkFontShortcutItalic.Checked) fontStyle = FontStyle.Bold | FontStyle.Italic;
                else if (checkFontShortcutBold.Checked) fontStyle = FontStyle.Bold;
                else if (checkFontShortcutItalic.Checked) fontStyle = FontStyle.Italic;
                else fontStyle = FontStyle.Regular;

                labelExampleShortcut.Font = new Font(comboFontShortcut.Text, (float)numericFontShortcutSize.Value, fontStyle);
            }

            else labelExampleShortcut.Visible = false;
        }

        private bool validColor(string inputColor)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(inputColor);
                return true;
            }

            catch
            {
                return false;
            }
        }

        private bool validFont(string name, float size, bool bold, bool italic)
        {
            try
            {
                FontStyle fontStyle;
                if (bold && italic) fontStyle = FontStyle.Bold | FontStyle.Italic;
                else if (bold) fontStyle = FontStyle.Bold;
                else if (italic) fontStyle = FontStyle.Italic;
                else fontStyle = FontStyle.Regular;

                using (Font fontTest = new Font(name, size, fontStyle))
                {
                    if (fontTest.Name == name)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }

            catch
            {
                return false;
            }
        }

        private void Preview_Changed(object sender, EventArgs e)
        {
            updatePreview();
        }

        private void updatePreview()
        {
            Screen screen = Screen.FromControl(this);

            labelCurrentScreenSize.Text = "Current screen size: " + screen.Bounds.Width + " x " + screen.Bounds.Height;

            int numericTopBottomFixed = (int)numericTopBottom.Value;
            int numericLeftRightFixed = (int)numericLeftRight.Value;
            if (numericTopBottomFixed < 20) numericTopBottomFixed = 20;
            if (numericLeftRightFixed < 20) numericLeftRightFixed = 20;

            int height = screen.Bounds.Height;
            int width = screen.Bounds.Width;

            int boxHeight = pictureBox1.ClientRectangle.Height;
            int boxWidth = pictureBox1.ClientRectangle.Width;

            double heightX = boxHeight / (double)height;
            double widthX = boxWidth / (double)width;

            int topBottom = (int)(numericTopBottomFixed * heightX);
            int leftRight = (int)(numericLeftRightFixed * widthX);

            Bitmap background = new Bitmap(320, 180);
            Brush brushWhite = new SolidBrush(Color.FromArgb(200, 255, 100, 100));
            Graphics g = Graphics.FromImage(background);

            if (checkTop.Checked)
            {
                int x1 = leftRight;
                int y1 = 0;
                int x2 = boxWidth - (leftRight * 2);
                int y2 = topBottom;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkBottom.Checked)
            {
                int x1 = leftRight;
                int y1 = boxHeight - topBottom;
                int x2 = boxWidth - (leftRight * 2);
                int y2 = boxHeight;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkLeft.Checked)
            {
                int x1 = 0;
                int y1 = topBottom;
                int x2 = leftRight;
                int y2 = boxHeight - (topBottom * 2);

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkRight.Checked)
            {
                int x1 = boxWidth - leftRight;
                int y1 = topBottom;
                int x2 = boxWidth;
                int y2 = boxHeight - (topBottom * 2);

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkTopLeft.Checked)
            {
                int x1 = 0;
                int y1 = 0;
                int x2 = leftRight;
                int y2 = topBottom;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkTopRight.Checked)
            {
                int x1 = boxWidth - leftRight;
                int y1 = 0;
                int x2 = boxWidth;
                int y2 = topBottom;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkBottomLeft.Checked)
            {
                int x1 = 0;
                int y1 = boxHeight - topBottom;
                int x2 = leftRight;
                int y2 = boxHeight;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            if (checkBottomRight.Checked)
            {
                int x1 = boxWidth - leftRight;
                int y1 = boxHeight - topBottom;
                int x2 = boxWidth;
                int y2 = boxHeight;

                g.FillRectangle(brushWhite, new Rectangle(x1, y1, x2, y2));
            }

            pictureBox1.Image = background;
        }

        private void trackFadeDelay_Scroll(object sender, EventArgs e)
        {
            numericFadeSpeed.Value = trackFadeSpeed.Value;
        }

        private void numericFadeDelay_ValueChanged(object sender, EventArgs e)
        {
            trackFadeSpeed.Value = (int)numericFadeSpeed.Value;
        }

        private void trackOpacity_Scroll(object sender, EventArgs e)
        {
            numericOpacity.Value = trackOpacity.Value;
        }

        private void numericOpacity_ValueChanged(object sender, EventArgs e)
        {
            trackOpacity.Value = (int)numericOpacity.Value;
        }

        private void txtShortcutFolder_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtShortcutFolder.Text)) txtShortcutFolder.BackColor = folderExist;
            else txtShortcutFolder.BackColor = folderNotExist;
        }

        private void txtCustom_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomProgram.Text == "" && txtArguments.Text == "") txtCustomProgram.BackColor = txtArguments.BackColor = folderExist;

            else
            {
                if (File.Exists(txtCustomProgram.Text)) txtCustomProgram.BackColor = folderExist;
                else txtCustomProgram.BackColor = folderNotExist;

                if (txtArguments.Text.Contains("%folder%")) txtArguments.BackColor = folderExist;
                else txtArguments.BackColor = folderNotExist;
            }
        }

        private void FormSettings_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string helpFile = Path.Combine(appDir, "RunIt.chm");

            if (File.Exists(helpFile))
            {
                Process.Start(helpFile);
            }

            e.Cancel = true;
        }
    }
}
