using IWshRuntimeLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RunIt
{
    public partial class Form1
    {
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer(Form1 form) : base(new MyColors(form)) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            Form1 _form;

            public MyColors(Form1 form)
            {
                _form = form;
            }

            public override Color MenuItemSelected
            {
                get { return _form.SetColorShortcutBackgroundHover; }
            }

            public override Color MenuItemBorder
            {
                get { return _form.SetColorShortcutBackground; }
            }

            public override Color MenuBorder
            {
                get { return _form.SetColorGroupBackground; }
            }

            public override Color SeparatorDark
            {
                get { return _form.SetColorShortcutBackgroundHover; }
            }

            public override Color SeparatorLight
            {
                get { return _form.SetColorShortcutBackground; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return _form.SetColorShortcutBackground; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return _form.SetColorShortcutBackground; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return _form.SetColorShortcutBackground; }
            }
        }

        private Bitmap exctractIconSmall(string fName)
        {
            try
            {
                SHFILEINFO shinfo = new SHFILEINFO();
                IntPtr hImgSmall = Win32.SHGetFileInfo(fName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
                Icon icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
                Win32.DestroyIcon(shinfo.hIcon);

                return icon.ToBitmap();
            }

            catch
            {
                return new Bitmap(16, 16);
            }
        }

        private bool isUrl(string filename)
        {
            if (filename.Contains("http://") || filename.Contains("https://") || filename.Contains("ftp://")) return true;
            else return false;
        }

        private void CreateFolderMenu(string link)
        {
            WshShell shell = new WshShell();
            WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(link);

            string linkFolder = shortcut.TargetPath;
            string linkArguments = shortcut.Arguments;
            string linkIcon = shortcut.IconLocation;

            if (Directory.Exists(linkFolder))
            {
                string[] folderList = Directory.GetDirectories(linkFolder, "*", SearchOption.TopDirectoryOnly);
                string[] fileList = Directory.GetFiles(linkFolder, "*", SearchOption.TopDirectoryOnly);

                contextFolder.Items.Clear();
                contextFolder.SuspendLayout();

                ToolStripMenuItem topItem = new ToolStripMenuItem();
                topItem.Text = Path.GetFileName(linkFolder);
                //topItem.Font = setGroupFont;
                topItem.Font = new Font(topItem.Font, FontStyle.Bold);
                topItem.Image = exctractIconSmall(linkFolder);
                topItem.Tag = linkFolder;
                topItem.Click += new EventHandler(toolStripMenuItem_Click);

                contextFolder.Items.Add(topItem);

                contextFolder.Items.Add("-");

                foreach (string file in folderList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = Path.GetFileName(file);
                    item.Tag = file;
                    item.ImageScaling = ToolStripItemImageScaling.None;

                    if (isUrl(file)) item.Image = Properties.Resources.url.ToBitmap();
                    else item.Image = exctractIconSmall(file);

                    item.Click += new EventHandler(toolStripMenuItem_Click);

                    contextFolder.Items.Add(item);
                }

                if (folderList.Count() > 0) contextFolder.Items.Add("-");

                foreach (string file in fileList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = Path.GetFileName(file);
                    item.Tag = file;
                    item.ImageScaling = ToolStripItemImageScaling.None;

                    if (isUrl(file)) item.Image = Properties.Resources.url.ToBitmap();
                    else item.Image = exctractIconSmall(file);

                    item.Click += new EventHandler(toolStripMenuItem_Click);

                    contextFolder.Items.Add(item);
                }

                if (folderList.Count() == 0 && fileList.Count() == 0)
                {
                    ToolStripMenuItem emptyItem = new ToolStripMenuItem();
                    emptyItem.Text = "Empty folder";
                    emptyItem.ImageScaling = ToolStripItemImageScaling.None;
                    emptyItem.Enabled = false;
                    contextFolder.Items.Add(emptyItem);
                }

                contextFolder.ResumeLayout();
                contextFolder.Show(MousePosition);
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string filename = item.Tag.ToString();

            
            if (System.IO.File.Exists(filename) || Directory.Exists(filename))
            {
                StartFileOrFolder(filename);
            }

            else if (isUrl(filename))
            {
                Process.Start(filename);
            }

            else MessageBox.Show("File or folder \"" + filename + "\" does not exists.", "RunIt");
        }

        private void createGroups()
        {
            flowLayoutPanel.Controls.Clear();
            shortcutsFound = false;

            if (setFolder != "" && Directory.Exists(setFolder))
            {
                string[] linkDirectories = Directory.GetDirectories(setFolder, "*", SearchOption.TopDirectoryOnly);

                foreach (string directory in linkDirectories)
                {
                    string[] links = Directory.GetFiles(directory, "*.lnk", SearchOption.TopDirectoryOnly);
                    string dirText = directory.Split(Path.DirectorySeparatorChar).Last();

                    float vert = (float)links.Count() / (float)setHorizontal;
                    int iconsVertical = (int)Math.Ceiling(vert);
                    int width = setHorizontal * setShortcutRectangleSize + setHorizontal * setShortcutMargin * 2 + setShortcutMargin * 2;
                    int height = iconsVertical * setShortcutRectangleSize + iconsVertical * setShortcutMargin * 2 + setShortcutMargin * 2;

                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.BackColor = setColorGroupBackground;
                    panel.Name = "Group";
                    panel.Tag = dirText;
                    panel.Width = width;
                    panel.Height = height + setGroupLabel;
                    panel.Padding = new Padding(setShortcutMargin);
                    panel.Margin = new Padding(setGroupMargin);
                    panel.AllowDrop = true;
                    panel.MouseUp += new MouseEventHandler(panelGroup_MouseUp);
                    panel.MouseDown += new MouseEventHandler(flow_MouseDown);
                    panel.MouseMove += new MouseEventHandler(flow_MouseMove);
                    panel.DragDrop += new DragEventHandler(groupPanel_DragDrop);
                    panel.DragEnter += new DragEventHandler(groupPanel_DragEnter);
                    panel.GiveFeedback += new GiveFeedbackEventHandler(groupPanel_GiveFeedback);
                    flowLayoutPanel.Controls.Add(panel);

                    Label label = new Label();
                    label.AutoSize = false;
                    label.Width = width - (setShortcutMargin * 4);
                    label.Height = setGroupLabel;
                    label.ForeColor = setColorGroupFont;
                    label.BackColor = transparent;
                    label.Name = dirText;
                    label.Text = dirText;
                    label.Font = setGroupFont;
                    label.TextAlign = setGroupTopicAlign;
                    label.Margin = new Padding(setShortcutMargin, 0, setShortcutMargin, 0);
                    panel.Controls.Add(label);

                    label.AllowDrop = true;
                    label.UseMnemonic = false;
                    label.MouseUp += new MouseEventHandler(groupLabel_MouseUp);
                    label.MouseDown += new MouseEventHandler(groupLabel_MouseDown);
                    label.MouseMove += new MouseEventHandler(groupLabel_MouseMove);
                    label.DragDrop += new DragEventHandler(groupLabel_DragDrop);
                    label.DragEnter += new DragEventHandler(groupLabel_DragEnter);
                    label.GiveFeedback += new GiveFeedbackEventHandler(groupLabel_GiveFeedback);

                    foreach (string link in links)
                    {
                        createShortcut(link, panel);
                        shortcutsFound = true;
                    }
                }

                loadList();
            }
        }

        private Image GetGroupIcon()
        {
            Image image = new Bitmap(16, 16);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(new SolidBrush(setColorGroupBackground), 0, 0, 16, 16);
                g.FillRectangle(new SolidBrush(setColorShortcutBackground), 2, 2, 5, 5);
                g.FillRectangle(new SolidBrush(setColorShortcutBackground), 9, 2, 5, 5);
                g.FillRectangle(new SolidBrush(setColorShortcutBackground), 2, 9, 5, 5);
            }

            return image;
        }

        private Image GetIcon(string link)
        {
            Image image = new Bitmap(16, 16);

            WshShell shell = new WshShell();
            WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(link);

            string png = link.Replace(".lnk", ".png");
            string file = shortcut.TargetPath;
            string icon = shortcut.IconLocation;
            int iconIndex = -1;

            if (icon.Contains(","))
            {
                icon = shortcut.IconLocation.Split(',')[0];
                iconIndex = Convert.ToInt32(shortcut.IconLocation.Split(',')[1]);
            }

            if (System.IO.File.Exists(png))
            {
                try
                {
                    Image img;
                    using (var bmpTemp = new Bitmap(png))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                    image = img;
                }

                catch { }
            }

            else if (icon != "" && System.IO.File.Exists(icon) && System.IO.Path.GetExtension(icon) == ".ico")
            {
                try
                {
                    Icon myIcon = new Icon(icon);
                    Icon buttonIcon = new Icon(myIcon, setIconSize, setIconSize);
                    image = buttonIcon.ToBitmap();
                }

                catch { }
            }

            else if (icon != "" && System.IO.File.Exists(icon) && iconIndex > -1)
            {
                try
                {
                    image = IconExtractor.Extract(icon, iconIndex, false).ToBitmap();
                }

                catch { }
            }

            else try { image = ShellEx.GetBitmapFromFilePath(file, ShellEx.IconSizeEnum.SmallIcon16); } catch { }

            return image;
        }

        private void createShortcut(string link, FlowLayoutPanel flowPanel)
        {
            WshShell shell = new WshShell();
            WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(link);

            string png = link.Replace(".lnk", ".png");
            string file = shortcut.TargetPath;
            string arguments = shortcut.Arguments;
            string icon = shortcut.IconLocation;
            int iconIndex = -1;

            if (icon.Contains(","))
            {
                icon = shortcut.IconLocation.Split(',')[0];
                iconIndex = Convert.ToInt32(shortcut.IconLocation.Split(',')[1]);
            }

            Panel panel = new Panel();
            panel.Tag = link;
            panel.Width = setShortcutRectangleSize;
            panel.Height = setShortcutRectangleSize;
            panel.BackColor = setColorShortcutBackground;
            panel.Margin = new Padding(setShortcutMargin);
            panel.MouseUp += new MouseEventHandler(panel_MouseUp);
            panel.MouseDown += new MouseEventHandler(shortcutPanel_MouseDown);
            panel.MouseMove += new MouseEventHandler(shortcutPanel_MouseMove);
            panel.MouseEnter += new EventHandler(panel_MouseEnter);
            panel.MouseLeave += new EventHandler(panel_MouseLeave);
            panel.DragDrop += new DragEventHandler(shortcutPanel_DragDrop);
            panel.DragEnter += new DragEventHandler(shortcutPanel_DragEnter);
            panel.GiveFeedback += new GiveFeedbackEventHandler(shortcutPanel_GiveFeedback);

            panel.AllowDrop = true;
            flowPanel.Controls.Add(panel);

            int pad = (setShortcutRectangleSize - setIconSize - setShortcutLabelHeight) / 2;

            PictureBox picture = new PictureBox();
            picture.Tag = link;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Width = setIconSize;
            picture.Height = setIconSize;
            picture.Left = (setShortcutRectangleSize - setIconSize) / 2;
            if (setShowShortcutLabels) picture.Top = pad;
            else picture.Top = (setShortcutRectangleSize - setIconSize) / 2;


            if (System.IO.File.Exists(png))
            {
                try
                {
                    Image img;
                    using (var bmpTemp = new Bitmap(png))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                    picture.Image = img;
                }

                catch { }
            }

            else if (icon != "" && System.IO.File.Exists(icon) && System.IO.Path.GetExtension(icon) == ".ico")
            {
                try
                {
                    Icon myIcon = new Icon(icon);
                    Icon buttonIcon = new Icon(myIcon, setIconSize, setIconSize);
                    picture.Image = buttonIcon.ToBitmap();
                }

                catch { }
            }

            else if (icon != "" && System.IO.File.Exists(icon) && iconIndex > -1)
            {
                try
                {
                    if (setIconSize == 16) picture.Image = IconExtractor.Extract(icon, iconIndex, false).ToBitmap();
                    else picture.Image = IconExtractor.Extract(icon, iconIndex, true).ToBitmap();
                }

                catch { }
            }

            else if (setIconSize == 16) try { picture.Image = ShellEx.GetBitmapFromFilePath(file, ShellEx.IconSizeEnum.SmallIcon16); } catch { }
            else if (setIconSize > 16 && setIconSize <= 32) try { picture.Image = ShellEx.GetBitmapFromFilePath(file, ShellEx.IconSizeEnum.MediumIcon32); } catch { }
            else if (setIconSize > 32 && setIconSize <= 48) try { picture.Image = ShellEx.GetBitmapFromFilePath(file, ShellEx.IconSizeEnum.LargeIcon48); } catch { }
            else try { picture.Image = ShellEx.GetBitmapFromFilePath(file, ShellEx.IconSizeEnum.ExtraLargeIcon); } catch { }

            picture.MouseUp += new MouseEventHandler(panel_MouseUp);
            picture.MouseDown += new MouseEventHandler(shortcutPanelChild_MouseDown);
            picture.MouseMove += new MouseEventHandler(shortcutPanelChild_MouseMove);
            picture.MouseEnter += new EventHandler(panelChild_MouseEnter);
            picture.MouseLeave += new EventHandler(panelChild_MouseLeave);
            panel.Controls.Add(picture);

            if (setShowShortcutLabels)
            {
                Label label = new Label();
                label.Font = setShortcutFont;
                label.UseMnemonic = false;
                label.Tag = link;
                label.AutoSize = false;
                label.Width = setShortcutRectangleSize - 10;
                label.Height = setShortcutLabelHeight;
                label.Left = 5;
                label.Top = setIconSize + pad + 3;
                label.ForeColor = setColorShortcutFont;
                label.Text = Path.GetFileNameWithoutExtension(link);
                label.TextAlign = setShortcutTextAlign;
                label.MouseUp += new MouseEventHandler(panel_MouseUp);
                label.MouseDown += new MouseEventHandler(shortcutPanelChild_MouseDown);
                label.MouseMove += new MouseEventHandler(shortcutPanelChild_MouseMove);
                label.MouseEnter += new EventHandler(panelChild_MouseEnter);
                label.MouseLeave += new EventHandler(panelChild_MouseLeave);
                label.DragDrop += new DragEventHandler(shortcutPanelChild_DragDrop);
                label.DragEnter += new DragEventHandler(shortcutPanelChild_DragEnter);
                label.GiveFeedback += new GiveFeedbackEventHandler(shortcutPanelChild_GiveFeedback);
                label.AllowDrop = true;
                panel.Controls.Add(label);
            }

            else
            {
                Label label = new Label();
                label.Tag = link;
                label.AutoSize = false;
                label.Width = 0;
                label.Height = 0;
                label.Left = 0;
                label.Top = panel.Bottom;
                panel.Controls.Add(label);
            }
        }

        private void StartFileOrFolder(string link)
        {
            WshShell shell = new WshShell();
            WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(link);
            string fileOrFolder = shortcut.TargetPath;

            bool file = false;
            bool folder = false;

            if (Directory.Exists(fileOrFolder)) folder = true;
            if (System.IO.File.Exists(fileOrFolder)) file = true;

            if (file)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = link;
                if (System.IO.File.Exists(fileOrFolder)) Process.Start(startInfo);
            }

            else if (folder)
            {
                if (setCustomProgram != null && setCustomProgram != "" && System.IO.File.Exists(setCustomProgram) && setCustomProgramArguments != null && setCustomProgramArguments.Contains("%folder%"))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = setCustomProgram;
                    startInfo.Arguments = setCustomProgramArguments.Replace("%folder%", fileOrFolder);
                    if (Directory.Exists(fileOrFolder)) Process.Start(startInfo);
                }

                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = fileOrFolder;
                    if (Directory.Exists(fileOrFolder)) Process.Start(startInfo);
                }
            }



        }
    }
}
