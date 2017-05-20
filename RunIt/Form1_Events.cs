using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Threading;

namespace RunIt
{
    public partial class Form1
    {
        private void hookKey(string mod, string key)
        {
            if (string.IsNullOrEmpty(mod) && !string.IsNullOrEmpty(key)) hook.RegisterHotKey((ModifierKeys)0, (Keys)Enum.Parse(typeof(Keys), key));
            else if (!string.IsNullOrEmpty(mod) && !string.IsNullOrEmpty(key)) hook.RegisterHotKey((ModifierKeys)Hotkeys.GetGlobalHotkeyModNumber(mod), (Keys)Enum.Parse(typeof(Keys), key));
        }

        private int mouseX;
        private int mouseY;

        private void mousePosition()
        {
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {

            if (!this.Visible)
            {
                mousePosition();
                ShowWindow();
            }

            else HideWindow();
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownX = 0;
            mouseDownY = 0;

            if (e.Button == MouseButtons.Left)
            {
                string file = null;

                try
                {
                    //this.Hide();
                    if (!keepOpen) HideWindow();

                    Control control = (Control)sender;
                    file = control.Tag.ToString();

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = file;
                    if (System.IO.File.Exists(file)) Process.Start(startInfo);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace + Environment.NewLine + Environment.NewLine + file);
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                Control control = (Control)sender;

                if (control is Panel)
                {
                    clickedPanel = (Panel)control;
                    showShortcutContext((Panel)control, e.Location);
                }

                else
                {
                    clickedPanel = (Panel)control.Parent;
                    showShortcutContext((Panel)control.Parent, e.Location);
                }
            }
        }

        private void hideToolTip()
        {
            timerToolTip.Start();
        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = setColorShortcutBackgroundHover;

            showToolTip(control);
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = setColorShortcutBackground;

            hideToolTip();
        }

        private void panelChild_MouseEnter(object sender, EventArgs e)
        {
            Control temp = (Control)sender;
            Control control = temp.Parent;
            control.BackColor = setColorShortcutBackgroundHover;

            showToolTip(control);
        }

        private void panelChild_MouseLeave(object sender, EventArgs e)
        {
            Control temp = (Control)sender;
            Control control = temp.Parent;
            control.BackColor = setColorShortcutBackground;

            hideToolTip();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            resizeWindow();
            HideWindow();

            timerMouse.Start();
            disableFade = false;

            //if (!shortcutsFound)
            //{
            //    menuSettings.PerformClick();
            //}
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //if (shortcutsFound)
                //{
                    mousePosition();
                    ShowWindow();
                //}

                //else menuSettings.PerformClick();
            }
        }

        void Form1_LostFocus(object sender, EventArgs e)
        {
            mouseDownX = 0;
            mouseDownY = 0;

            if (!settingsOpen && !keepOpen)
            {
                Thread.Sleep(100);
                HideWindow();
            }
        }


        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            windowDragged = true;
            resizeWindow();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }

        bool keepOpen = false;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!timerDrag.Enabled) HideWindow();
            }

            if (e.KeyCode == Keys.ControlKey) keepOpen = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) keepOpen = false;
        }

        // ************************** Menuitems *************************

        private void showShortcutContext(Panel panel, Point location)
        {
            menuShortcutDelete.Tag = menuShortcutEdit.Tag = menuShortcutRename.Tag = panel.Tag;

            Point screenPoint = Cursor.Position;
            contextShortcut.Show(this, this.PointToClient(screenPoint));
        }

        private void panelGroup_MouseUp(object sender, MouseEventArgs e)
        {
            Point screenPoint = Cursor.Position;
            if (e.Button == MouseButtons.Right) contextForm.Show(this, this.PointToClient(screenPoint));
        }

        private void groupLabel_MouseUp(object sender, MouseEventArgs e)
        {
            int lnkFound = 0;
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection list = Clipboard.GetFileDropList();
                lnkFound = list.Count;
            }

            if (lnkFound > 0) menuPaste.Enabled = true;
            else menuPaste.Enabled = false;

            if (lnkFound <= 1) menuPaste.Text = "Paste shortcut";
            else menuPaste.Text = "Paste " + lnkFound + " shortcuts";

            clickedLabel = (Label)sender;
            menuGroupDelete.Tag = menuGroupRename.Tag = menuPaste.Tag = clickedLabel.Text;

            Point screenPoint = Cursor.Position;
            if (e.Button == MouseButtons.Right) contextGroup.Show(this, this.PointToClient(screenPoint));

            /*
            int lnkFound = 0;
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection list;
                list = Clipboard.GetFileDropList();

                foreach (string file in list)
                {
                    string fileExt = Path.GetExtension(file);
                    if (fileExt == ".lnk") lnkFound++;
                }
            }
            if (lnkFound > 0) menuPaste.Enabled = true;
            else menuPaste.Enabled = false;

            if (lnkFound <= 1) menuPaste.Text = "Paste shortcut";
            else menuPaste.Text = "Paste " + lnkFound + " shortcuts";

            clickedLabel = (Label)sender;
            menuGroupDelete.Tag = menuGroupRename.Tag = menuPaste.Tag = clickedLabel.Text;

            Point screenPoint = Cursor.Position;
            if (e.Button == MouseButtons.Right) contextGroup.Show(this, this.PointToClient(screenPoint));
            */
        }

        private void flow_MouseUp(object sender, MouseEventArgs e)
        {
            Point screenPoint = Cursor.Position;
            if (e.Button == MouseButtons.Right) contextForm.Show(this, this.PointToClient(screenPoint));
        }

        private void menuMaximize_Click(object sender, EventArgs e)
        {
            maximizeHeight();
        }

        private void menuMaximizeWidth_Click(object sender, EventArgs e)
        {
            maximizeWidth();
        }

        private void menuShortcutRename_Click(object sender, EventArgs e)
        {
            string file = menuShortcutRename.Tag.ToString();
            string path = Path.GetDirectoryName(file);
            string name = Path.GetFileNameWithoutExtension(file);

            settingsOpen = true;
            windowDragged = true;

            FormRename form = new FormRename();
            form.Topic = "Rename shortcut";
            form.NewName = name;
            form.ShowDialog();

            if (form.NewName != "")
            {
                string oldName = file;
                string newName = Path.Combine(path, form.NewName + ".lnk");
                string oldNamePng = oldName.Replace(".lnk", ".png");
                string newNamePng = newName.Replace(".lnk", ".png");

                bool success = false;

                try
                {
                    if (!System.IO.File.Exists(newName))
                    {
                        if (System.IO.File.Exists(oldName)) System.IO.File.Move(oldName, newName);
                        if (System.IO.File.Exists(oldNamePng)) System.IO.File.Move(oldNamePng, newNamePng);
                        success = true;
                    }
                }

                catch { }

                if (success)
                {
                    clickedPanel.Tag = newName;
                    ReloadSettings(true);
                }

            }

            settingsOpen = false;
        }

        private void menuShortcutEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string file = menuShortcutEdit.Tag.ToString();

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = file;
                startInfo.Verb = "Properties";
                if (System.IO.File.Exists(file)) Process.Start(startInfo);
            }

            catch { }
        }

        private void menuShortcutDelete_Click(object sender, EventArgs e)
        {
            settingsOpen = true;
            windowDragged = true;

            string file = menuShortcutDelete.Tag.ToString();
            string name = Path.GetFileNameWithoutExtension(file);

            DialogResult result = MessageBox.Show(name, "Delete shortcut?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (System.IO.File.Exists(file)) System.IO.File.Delete(file);

                ReloadSettings(true);
            }

            settingsOpen = false;
        }

        private void menuGroupNew_Click(object sender, EventArgs e)
        {
            settingsOpen = true;
            windowDragged = true;

            FormRename form = new FormRename();
            form.Topic = "Add new group";
            form.ButtonName = "Add";
            form.ShowDialog();

            if (form.NewName != "")
            {
                bool success = false;

                try
                {
                    string dir = Path.Combine(setFolder, form.NewName);

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                        success = true;
                    }
                }

                catch { }

                if (success)
                {
                    ReloadSettings(true);
                }
            }

            settingsOpen = false;
        }

        private void menuGroupRename_Click(object sender, EventArgs e)
        {
            string group = menuGroupRename.Tag.ToString();

            settingsOpen = true;
            windowDragged = true;

            FormRename form = new FormRename();
            form.Topic = "Rename group";
            form.NewName = group;
            form.ShowDialog();

            if (form.NewName != "")
            {
                string oldName = Path.Combine(setFolder, group);
                string newName = Path.Combine(setFolder, form.NewName);

                bool success = false;

                try
                {
                    if (!Directory.Exists(newName))
                    {
                        if (Directory.Exists(oldName)) Directory.Move(oldName, newName);
                        success = true;
                    }
                }

                catch { }

                if (success)
                {
                    clickedLabel.Text = form.NewName;
                    ReloadSettings(true);
                }
            }

            settingsOpen = false;
        }

        private void menuGroupDelete_Click(object sender, EventArgs e)
        {
            settingsOpen = true;
            windowDragged = true;

            string group = menuGroupDelete.Tag.ToString();
            string dir = Path.Combine(setFolder, group);

            DialogResult result = MessageBox.Show(group, "Delete group?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (Directory.Exists(dir)) Directory.Delete(dir, true);

                ReloadSettings(true);
            }

            settingsOpen = false;
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection list = Clipboard.GetFileDropList();

                foreach (string file in list)
                {
                    addShortcut(file, menuPaste.Tag.ToString());
                }

                Clipboard.Clear();
                ReloadSettings(true);
            }

            /*
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection list;
                list = Clipboard.GetFileDropList();

                foreach (string file in list)
                {
                    addShortcut(file, menuPaste.Tag.ToString());
                }

                Clipboard.Clear();
                ReloadSettings(true);
            }
            */
        }

        private void menuSavePosition_Click(object sender, EventArgs e)
        {
            saveCurrentPosition();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shortcutsFound)
            {
                saveList();
                settings.SaveSetting("Width", this.Width.ToString());
                settings.SaveSetting("Height", this.Height.ToString());
            }
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            if (shortcutsFound)
            {
                settings.SaveSetting("Width", this.Width.ToString());
                settings.SaveSetting("Height", this.Height.ToString());
            }

            disableFade = true;
            settingsOpen = true;
            FormSettings form = new FormSettings();
            form.ShowDialog();
            resizeWindow();
            settingsOpen = false;
            disableFade = false;
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            ReloadSettings(true);
            /*
            this.Visible = false;
            this.SuspendLayout();
            saveList();
            createGroups();

            Application.DoEvents();
            this.ResumeLayout();
            this.Visible = true;
            */
        }

        private void menuOpenFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(setFolder)) Process.Start(setFolder);
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            string helpFile = Path.Combine(appDir, "RunIt.chm");
            if (System.IO.File.Exists(helpFile))
            {
                Process.Start(helpFile);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ************************** Mouse *************************

        private DateTime mouseEnteredTime;
        private bool mouseEntered;
        private bool mouseHit = false;

        private void timerMouse_Tick(object sender, EventArgs e)
        {
            if (this.Visible && !settingsOpen && !fadeInProgress)
            {
                this.Activate();
                this.Focus();
            }

            bool mouseIn = false;

            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            Screen screen = Screen.FromPoint(Control.MousePosition);

            int height = screen.Bounds.Height;
            int width = screen.Bounds.Width;

            if (setTopLeft &&
                x >= screen.Bounds.Left + 0 &&
                x <= screen.Bounds.Left + setLeftRight &&
                y >= screen.Bounds.Top + 0 &&
                y <= screen.Bounds.Top + setTopBottom)
                mouseIn = true;

            if (setTopRight &&
                x >= screen.Bounds.Left + width - setLeftRight &&
                x <= screen.Bounds.Left + width &&
                y >= screen.Bounds.Top + 0 &&
                y <= screen.Bounds.Top + setTopBottom)
                mouseIn = true;

            if (setBottomLeft &&
                x >= screen.Bounds.Left + 0 &&
                x <= screen.Bounds.Left + setLeftRight &&
                y >= screen.Bounds.Top + height - setTopBottom &&
                y <= screen.Bounds.Top + height)
                mouseIn = true;

            if (setBottomRight &&
                x >= screen.Bounds.Left + width - setLeftRight &&
                x <= screen.Bounds.Left + width &&
                y >= screen.Bounds.Top + height - setTopBottom &&
                y <= screen.Bounds.Top + height)
                mouseIn = true;


            if (setTop &&
                x >= screen.Bounds.Left + setLeftRight &&
                x <= screen.Bounds.Left + width - setLeftRight &&
                y >= screen.Bounds.Top + 0 &&
                y <= screen.Bounds.Top + setTopBottom)
                mouseIn = true;

            if (setBottom &&
                x >= screen.Bounds.Left + setLeftRight &&
                x <= screen.Bounds.Left + width - setLeftRight &&
                y >= screen.Bounds.Top + height - setTopBottom &&
                y <= screen.Bounds.Top + height)
                mouseIn = true;

            if (setLeft &&
                x >= screen.Bounds.Left + 0 &&
                x <= screen.Bounds.Left + setLeftRight &&
                y >= screen.Bounds.Top + setTopBottom &&
                y <= screen.Bounds.Top + height - setTopBottom)
                mouseIn = true;

            if (setRight &&
                x >= screen.Bounds.Left + width - setLeftRight &&
                x <= screen.Bounds.Left + width &&
                y >= screen.Bounds.Top + setTopBottom &&
                y <= screen.Bounds.Top + height - setTopBottom)
                mouseIn = true;

            if (mouseIn)
            {
                if (!mouseEntered)
                {
                    mouseEntered = true;
                    mouseEnteredTime = DateTime.Now;
                }

                long elapsedTime = DateTime.Now.Millisecond - mouseEnteredTime.Millisecond;
                long elapsedTicks = DateTime.Now.Ticks - mouseEnteredTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

                if (elapsedSpan.TotalMilliseconds >= setWaitingTime)
                {
                    if (!mouseHit)
                    {
                        mouseHit = true;
                        if (!this.Visible)
                        {
                            mousePosition();
                            ShowWindow();
                        }

                        else HideWindow();
                    }

                }
            }

            else
            {
                mouseEntered = false;
                mouseHit = false;
            }
        }




    }
}
