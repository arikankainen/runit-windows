using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form1
    {
        private Color setColorBackground;
        private Color setColorBackgroundWarning = ColorTranslator.FromHtml("#cc0000");
        private Color setColorGroupBackground;
        private Color setColorShortcutBackground;
        private Color setColorShortcutBackgroundHover;
        private Color setColorGroupFont;
        private Color setColorShortcutFont;
        private Color setColorToolTipBackground;
        private Color setColorToolTipFont;

        private Font setGroupFont;
        private Font setShortcutFont;

        private ContentAlignment setGroupTopicAlign;
        private ContentAlignment setShortcutTextAlign;

        private int setOuterMargin;
        private int setGroupMargin;
        private int setShortcutMargin;
        private int setGroupLabel;
        private int setHorizontal;
        private int setShortcutRectangleSize;
        private int setIconSize;
        private int setShortcutLabelHeight;
        private int setToolTipMarginTop;
        private int setToolTipPaddingWidth;
        private int setToolTipPaddingHeight;

        private double setOpacity;
        private bool setFade;
        private int setFadeSpeed;

        private string setFolder;
        private string setHotkey;

        private bool setHotkeyAlt;
        private bool setHotkeyCtrl;
        private bool setHotkeyShift;
        private bool setShowShortcutLabels;
        private bool setShowShortcutTooltips;

        private long setWaitingTime;
        private int setLeftRight;
        private int setTopBottom;

        private bool setTop;
        private bool setBottom;
        private bool setLeft;
        private bool setRight;

        private bool setTopLeft;
        private bool setTopRight;
        private bool setBottomLeft;
        private bool setBottomRight;

        private int setLocationMargin;

        private bool setLocationTop;
        private bool setLocationBottom;
        private bool setLocationLeft;
        private bool setLocationRight;

        private bool setLocationTopLeft;
        private bool setLocationBottomLeft;
        private bool setLocationTopRight;
        private bool setLocationBottomRight;

        private bool setLocationMouseCursor;
        private bool setLocationCenter;

        private bool setLocationCustom;
        private int setLocationCustomX;
        private int setLocationCustomY;
        private bool setLocationCustomLeft;
        private bool setLocationCustomTop;

        private void exampleShortcuts()
        {
            saveShortcut(Path.Combine(setFolder, exampleShortcutFolderName), "Calculator", "calc.exe");
            saveShortcut(Path.Combine(setFolder, exampleShortcutFolderName), "Notepad", "notepad.exe");
            saveShortcut(Path.Combine(setFolder, exampleShortcutFolderName), "File Explorer", "explorer.exe");
            saveShortcut(Path.Combine(setFolder, exampleShortcutFolderName), "WordPad", "write.exe");

            string helpFile = Path.Combine(appDir, "RunIt.chm");
            if (System.IO.File.Exists(helpFile))
            {
                saveShortcut(Path.Combine(setFolder, exampleShortcutFolderName2), "RunIt Manual", helpFile);
                Process.Start(helpFile);
            }
        }

        private string exampleShortcutFolderName = "Example shortcuts";
        private string exampleShortcutFolderName2 = "Help";

        private void saveShortcut(string folder, string name, string exe)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(folder, name + ".lnk"));
            shortcut.TargetPath = exe;
            shortcut.WorkingDirectory = Path.GetDirectoryName(exe);
            shortcut.Save();
        }

        private void loadSettings()
        {

            setFolder = settings.LoadSetting("ShortcutFolder");

            if (setFolder == "")
            {
                setFolder = Path.Combine(appDir, "Shortcuts");
                settings.SaveSetting("ShortcutFolder", setFolder);
            }

            try
            {
                if (!Directory.Exists(setFolder))
                {
                    Directory.CreateDirectory(Path.Combine(setFolder, exampleShortcutFolderName));
                    Directory.CreateDirectory(Path.Combine(setFolder, exampleShortcutFolderName2));
                    exampleShortcuts();
                }
            }

            catch
            {
                setFolder = Path.Combine(appDir, "Shortcuts");
                settings.SaveSetting("ShortcutFolder", setFolder);

                if (!Directory.Exists(setFolder))
                {
                    Directory.CreateDirectory(Path.Combine(setFolder, exampleShortcutFolderName));
                    Directory.CreateDirectory(Path.Combine(setFolder, exampleShortcutFolderName2));
                    exampleShortcuts();
                }
            }

            if (setFolder != "" && setFolder.Substring(setFolder.Length) != "\\") setFolder = setFolder + "\\";

            settings.OpenSettings();

            setHotkey = settings.GetSetting("Hotkey");
            setHotkeyAlt = settings.GetSetting("HotkeyAlt", "bool", "false");
            setHotkeyCtrl = settings.GetSetting("HotkeyCtrl", "bool", "false");
            setHotkeyShift = settings.GetSetting("HotkeyShift", "bool", "false");

            string mod = "";
            if (setHotkeyAlt) mod += "Alt";
            if (setHotkeyCtrl) mod += "Ctrl";
            if (setHotkeyShift) mod += "Shift";

            keyboardHook.DisposeKeysOnly();
            hookKey(mod, setHotkey);

            setWaitingTime = settings.GetSetting("MouseWaitingTime", "int", "200");
            setTopBottom = settings.GetSetting("MouseTopBottomEdge", "int", "10");
            setLeftRight = settings.GetSetting("MouseLeftRightEdge", "int", "10");

            setTop = settings.GetSetting("MouseTop", "bool", "false");
            setBottom = settings.GetSetting("MouseBottom", "bool", "false");
            setLeft = settings.GetSetting("MouseLeft", "bool", "false");
            setRight = settings.GetSetting("MouseRight", "bool", "false");

            setTopLeft = settings.GetSetting("MouseTopLeft", "bool", "false");
            setTopRight = settings.GetSetting("MouseTopRight", "bool", "false");
            setBottomLeft = settings.GetSetting("MouseBottomLeft", "bool", "false");
            setBottomRight = settings.GetSetting("MouseBottomRight", "bool", "false");

            setLocationMargin = settings.GetSetting("EdgeMargin", "int", "10");

            setLocationTop = settings.GetSetting("LocationTop", "bool", "false");
            setLocationBottom = settings.GetSetting("LocationBottom", "bool", "false");
            setLocationLeft = settings.GetSetting("LocationLeft", "bool", "false");
            setLocationRight = settings.GetSetting("LocationRight", "bool", "false");

            setLocationTopLeft = settings.GetSetting("LocationTopLeft", "bool", "false");
            setLocationTopRight = settings.GetSetting("LocationTopRight", "bool", "false");
            setLocationBottomLeft = settings.GetSetting("LocationBottomLeft", "bool", "false");
            setLocationBottomRight = settings.GetSetting("LocationBottomRight", "bool", "false");

            setLocationMouseCursor = settings.GetSetting("LocationMousePosition", "bool", "false");
            setLocationCenter = settings.GetSetting("LocationCenter", "bool", "true");

            setLocationCustom = settings.GetSetting("LocationCustomPosition", "bool", "false");
            setLocationCustomX = settings.GetSetting("LocationCustomX", "int", "0");
            setLocationCustomY = settings.GetSetting("LocationCustomY", "int", "0");
            setLocationCustomTop = settings.GetSetting("LocationCustomTop", "bool", "true");
            setLocationCustomLeft = settings.GetSetting("LocationCustomLeft", "bool", "true");

            string setColorBackgroundTemp = settings.GetSetting("ColorBackground", "string", "#1F1F1F");
            string setColorGroupBackgroundTemp = settings.GetSetting("ColorGroupBackground", "string", "#161616");
            string setColorShortcutBackgroundTemp = settings.GetSetting("ColorShortcutBackground", "string", "#333333");
            string setColorShortcutBackgroundHoverTemp = settings.GetSetting("ColorShortcutBackgroundHover", "string", "#3F3F3F");
            string setColorToolTipBackgroundTemp = settings.GetSetting("ColorToolTipBackground", "string", "#3F3F3F");

            string setColorGroupFontTemp = settings.GetSetting("ColorGroupFont", "string", "#ADADAD");
            string setColorShortcutFontTemp = settings.GetSetting("ColorShortcutFont", "string", "#DADADA");
            string setColorToolTipFontTemp = settings.GetSetting("ColorShortcutFont", "string", "#DADADA");

            if (setColorBackgroundTemp == "") setColorBackgroundTemp = "#1F1F1F";
            if (setColorGroupBackgroundTemp == "") setColorGroupBackgroundTemp = "#161616";
            if (setColorShortcutBackgroundTemp == "") setColorShortcutBackgroundTemp = "#333333";
            if (setColorShortcutBackgroundHoverTemp == "") setColorShortcutBackgroundHoverTemp = "#3F3F3F";
            if (setColorToolTipBackgroundTemp == "") setColorToolTipBackgroundTemp = "#3F3F3F";

            if (setColorGroupFontTemp == "") setColorGroupFontTemp = "#ADADAD";
            if (setColorShortcutFontTemp == "") setColorShortcutFontTemp = "#DADADA";
            if (setColorToolTipFontTemp == "") setColorToolTipFontTemp = "#DADADA";

            setColorBackground = ColorTranslator.FromHtml(setColorBackgroundTemp);
            setColorGroupBackground = ColorTranslator.FromHtml(setColorGroupBackgroundTemp);
            setColorShortcutBackground = ColorTranslator.FromHtml(setColorShortcutBackgroundTemp);
            setColorShortcutBackgroundHover = ColorTranslator.FromHtml(setColorShortcutBackgroundHoverTemp);
            setColorToolTipBackground = ColorTranslator.FromHtml(setColorToolTipBackgroundTemp);

            setColorGroupFont = ColorTranslator.FromHtml(setColorGroupFontTemp);
            setColorShortcutFont = ColorTranslator.FromHtml(setColorShortcutFontTemp);
            setColorToolTipFont = ColorTranslator.FromHtml(setColorToolTipFontTemp);


            string groupFont = settings.GetSetting("FontGroup", "string", "Segoe UI");
            float groupFontSize = settings.GetSetting("FontGroupSize", "float", "12");
            bool groupFontBold = settings.GetSetting("FontGroupBold", "bool", "false");
            bool groupFontItalic = settings.GetSetting("FontGroupItalic", "bool", "false");

            FontStyle groupFontStyle;
            if (groupFontBold && groupFontItalic) groupFontStyle = FontStyle.Bold | FontStyle.Italic;
            else if (groupFontBold) groupFontStyle = FontStyle.Bold;
            else if (groupFontItalic) groupFontStyle = FontStyle.Italic;
            else groupFontStyle = FontStyle.Regular;

            setGroupFont = new Font(groupFont, groupFontSize, groupFontStyle);


            string shortcutFont = settings.GetSetting("FontShortcut", "string", "Microsoft Sans Serif");
            float shortcutFontSize = settings.GetSetting("FontShortcutSize", "float", "8");
            bool shortcutFontBold = settings.GetSetting("FontShortcutBold", "bool", "false");
            bool shortcutFontItalic = settings.GetSetting("FontShortcutItalic", "bool", "false");

            FontStyle shortcutFontStyle;
            if (shortcutFontBold && shortcutFontItalic) shortcutFontStyle = FontStyle.Bold | FontStyle.Italic;
            else if (shortcutFontBold) shortcutFontStyle = FontStyle.Bold;
            else if (shortcutFontItalic) shortcutFontStyle = FontStyle.Italic;
            else shortcutFontStyle = FontStyle.Regular;

            setShortcutFont = new Font(shortcutFont, shortcutFontSize, shortcutFontStyle);


            setGroupMargin = settings.GetSetting("GroupMargin", "int", "10") / 2;
            setOuterMargin = settings.GetSetting("OuterMargin", "int", "0") + (setGroupMargin / 2);
            setShortcutMargin = settings.GetSetting("ShortcutMargin", "int", "10") / 2;
            setGroupLabel = settings.GetSetting("GroupLabelHeight", "int", "23");
            setHorizontal = settings.GetSetting("HorizontalShortcuts", "int", "4");
            setShortcutRectangleSize = settings.GetSetting("ShortcutBoxSize", "int", "80");
            setIconSize = settings.GetSetting("ShortcutIconSize", "int", "32");
            setToolTipMarginTop = settings.GetSetting("ToolTipMarginTop", "int", "2");
            setToolTipPaddingWidth = settings.GetSetting("ToolTipPaddingWidth", "int", "0");
            setToolTipPaddingHeight = settings.GetSetting("ToolTipPaddingHeight", "int", "0");

            setShortcutLabelHeight = settings.GetSetting("ShortcutLabelHeight", "int", "26");
            setShowShortcutLabels = settings.GetSetting("ShowShortcutLabels", "bool", "true");
            setShowShortcutTooltips = settings.GetSetting("ShowShortcutTooltips", "bool", "false");

            string setGroupTopicAlignTemp = settings.GetSetting("GroupTopicAlign", "string", "Left");
            if (setGroupTopicAlignTemp == "Left") setGroupTopicAlign = ContentAlignment.MiddleLeft;
            else if (setGroupTopicAlignTemp == "Center") setGroupTopicAlign = ContentAlignment.MiddleCenter;
            else if (setGroupTopicAlignTemp == "Right") setGroupTopicAlign = ContentAlignment.MiddleRight;

            string setShortcutTextAlignTemp = settings.GetSetting("ShortcutTextAlign", "string", "Middle");
            if (setShortcutTextAlignTemp == "Top") setShortcutTextAlign = ContentAlignment.TopCenter;
            else if (setShortcutTextAlignTemp == "Middle") setShortcutTextAlign = ContentAlignment.MiddleCenter;
            else if (setShortcutTextAlignTemp == "Bottom") setShortcutTextAlign = ContentAlignment.BottomCenter;

            decimal setOpacityTemp = settings.GetSetting("Opacity", "dec", "0,96");
            setOpacity = Convert.ToDouble(setOpacityTemp);

            setFade = settings.GetSetting("Fade", "bool", "true");
            setFadeSpeed = settings.GetSetting("FadeSpeed", "int", "15");
            if (setFadeSpeed == 0) setFadeSpeed = 15;

            flowLayoutPanel.Padding = new Padding(setOuterMargin);
            flowLayoutPanel.Width = this.Width - (2 * paddingResizeForm);
            flowLayoutPanel.Height = this.Height - (2 * paddingResizeForm);
            flowLayoutPanel.Top = paddingResizeForm;
            flowLayoutPanel.Left = paddingResizeForm;

            int height = settings.GetSetting("Height", "int", "1200");
            int width = settings.GetSetting("Width", "int", "1200");

            this.Height = height;
            this.Width = width;

            this.BackColor = setColorBackground;
            createGroups();
        }

        public void ReloadSettings(bool saveDimensions)
        {
            bool visible = this.Visible;

            flowLayoutPanel.Visible = false;
            flowLayoutPanel.SuspendLayout();

            saveList();

            if (saveDimensions)
            {
                settings.SaveSetting("Width", this.Width.ToString());
                settings.SaveSetting("Height", this.Height.ToString());
            }

            loadSettings();

            this.Opacity = setOpacity;

            flowLayoutPanel.ResumeLayout();
            flowLayoutPanel.Visible = true;

            resizeWindow();

            disableFade = true;
            ShowWindow();
            disableFade = false;
        }

        private void saveList()
        {
            try
            {
                if (shortcutsFound)
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(appDir, "shortcuts.cfg")))
                    {
                        foreach (Control c1 in flowLayoutPanel.Controls)
                        {
                            sw.WriteLine("<group>");
                            foreach (Control c2 in c1.Controls)
                            {
                                if (c2 is Label)
                                {
                                    sw.WriteLine("  <label>" + c2.Text + "</label>");
                                }

                                else if (c2 is Panel)
                                {
                                    string file = c2.Tag.ToString();
                                    file = file.Replace(setFolder, "");

                                    sw.WriteLine("  <shortcut>" + file + "</shortcut>");
                                }
                            }
                            sw.WriteLine("</group>");
                            sw.WriteLine("");

                        }
                    }
                }
            }

            catch { }

        }

        private void loadList()
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(appDir, "shortcuts.cfg")))
                {
                    using (StreamReader reader = System.IO.File.OpenText(Path.Combine(appDir, "shortcuts.cfg")))
                    {
                        string line = "";
                        string group = "";
                        dictionary.Clear();

                        while (reader.Peek() >= 0)
                        {
                            line = reader.ReadLine();

                            if (line == "<group>")
                            {
                                List<string> list = new List<string>();
                                line = reader.ReadLine();
                                group = line.Replace("<label>", "").Replace("</label>", "").Trim();

                                while (true)
                                {
                                    line = reader.ReadLine();
                                    if (line == "</group>") break;
                                    string file = line.Replace("<shortcut>", "").Replace("</shortcut>", "").Trim();
                                    list.Add(Path.Combine(setFolder, file));
                                }

                                dictionary.Add(group, list);
                            }
                        }
                    }
                }
            }

            catch { }
            sortList();
        }

        private void sortList()
        {
            bool groupFound = false;
            int groupIndex = 0;
            foreach (KeyValuePair<string, List<string>> pair in dictionary)
            {
                foreach (Control c1 in flowLayoutPanel.Controls)
                {
                    if (c1 is FlowLayoutPanel && c1.Name == "Group")
                    {
                        foreach (Control c2 in c1.Controls)
                        {
                            if (c2 is Label)
                            {
                                if (c2.Text == pair.Key)
                                {
                                    flowLayoutPanel.Controls.SetChildIndex(c1, groupIndex);
                                    groupFound = true;
                                }
                            }
                        }
                    }

                    if (groupFound) groupIndex++;
                    groupFound = false;
                }

                int valueIndex = 1;
                foreach (string value in pair.Value)
                {
                    foreach (Control c1 in flowLayoutPanel.Controls)
                    {
                        if (c1 is FlowLayoutPanel && c1.Name == "Group")
                        {
                            foreach (Control c2 in c1.Controls)
                            {
                                if (c2 is Label)
                                {
                                    if (c2.Text == pair.Key)
                                    {
                                        foreach (Control c3 in c1.Controls)
                                        {
                                            if (c3 is Panel)
                                            {
                                                foreach (Control c4 in c3.Controls)
                                                {
                                                    if (c4 is Label)
                                                    {
                                                        if (c4.Tag.ToString() == value)
                                                        {
                                                            c1.Controls.SetChildIndex(c3, valueIndex);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        c1.Invalidate();
                    }
                    valueIndex++;
                }
            }
            flowLayoutPanel.Invalidate();
        }
    }
}
