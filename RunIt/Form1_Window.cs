using System;
using System.Threading;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form1
    {
        private bool fadeInProgress = false;
        private bool disableFade = true;
        private bool windowDragged = false;
        private bool widthWarning = false;
        private bool widthWarningOk = false;

        public void ShowWindow()
        {
            bool alreadyOpen = this.Visible;

            if (!alreadyOpen)
            {
                resizeWindow();

                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;
                this.Opacity = 0;
                this.Show();
                this.WindowState = FormWindowState.Normal;

                if (setFade && !disableFade) fadeIn();
                else this.Show();
            }

            this.Opacity = setOpacity;
            this.BringToFront();
            this.Focus();
            this.Activate();
            this.TopMost = true;
        }

        public void HideWindow()
        {
            if (setFade && !disableFade && this.Visible) fadeOut();
            else this.Hide();
            windowDragged = false;
        }

        private void fadeIn()
        {
            double fade = (double)setFadeSpeed / 100;

            if (!fadeInProgress)
            {
                this.Opacity = 0;
                this.Show();
                enableDoubleBuffering = false;

                for (double i = 0.0; i <= setOpacity; i += fade)
                {
                    Thread.Sleep(10);
                    this.Opacity = i;
                    Application.DoEvents();
                }

                enableDoubleBuffering = true;
                fadeInProgress = false;
            }
        }

        private void fadeOut()
        {
            double fade = (double)setFadeSpeed / 100;

            if (!fadeInProgress)
            {
                fadeInProgress = true;
                enableDoubleBuffering = false;

                for (double i = setOpacity; i >= 0.0; i -= fade)
                {
                    Thread.Sleep(10);
                    this.Opacity = i;
                    Application.DoEvents();
                }
                this.Hide();

                enableDoubleBuffering = true;
                fadeInProgress = false;
            }
        }

        private void saveCurrentPosition()
        {
            Screen screen = Screen.FromPoint(Control.MousePosition);

            int left = screen.WorkingArea.Left + this.Left;
            int top = screen.WorkingArea.Top + this.Top;
            int right = screen.WorkingArea.Right - this.Right;
            int bottom = screen.WorkingArea.Bottom - this.Bottom;

            if (left <= right)
            {
                settings.SaveSetting("LocationCustomLeft", "True");
                settings.SaveSetting("LocationCustomX", left.ToString());
                setLocationCustomLeft = true;
                setLocationCustomX = left;
            }

            else
            {
                settings.SaveSetting("LocationCustomLeft", "False");
                settings.SaveSetting("LocationCustomX", right.ToString());
                setLocationCustomLeft = false;
                setLocationCustomX = right;
            }

            if (top <= bottom)
            {
                settings.SaveSetting("LocationCustomTop", "True");
                settings.SaveSetting("LocationCustomY", top.ToString());
                setLocationCustomTop = true;
                setLocationCustomY = top;
            }

            else
            {
                settings.SaveSetting("LocationCustomTop", "False");
                settings.SaveSetting("LocationCustomY", bottom.ToString());
                setLocationCustomTop = false;
                setLocationCustomY = bottom;
            }

            settings.SaveSetting("LocationTop", "False");
            settings.SaveSetting("LocationBottom", "False");
            settings.SaveSetting("LocationLeft", "False");
            settings.SaveSetting("LocationRight", "False");

            settings.SaveSetting("LocationTopLeft", "False");
            settings.SaveSetting("LocationTopRight", "False");
            settings.SaveSetting("LocationBottomLeft", "False");
            settings.SaveSetting("LocationBottomRight", "False");

            settings.SaveSetting("LocationMousePosition", "False");
            settings.SaveSetting("LocationCenter", "False");

            settings.SaveSetting("LocationCustomPosition", "True");

            setLocationTop = setLocationBottom = setLocationLeft = setLocationRight = setLocationTopLeft = setLocationTopRight = setLocationBottomLeft = setLocationBottomRight = setLocationMouseCursor = setLocationCenter = false;
            setLocationCustom = true;
        }

        private void centerForm()
        {
            this.WindowState = FormWindowState.Normal;
            Screen screen = Screen.FromPoint(Control.MousePosition);

            if (windowDragged)
            {
                int left = this.Left;
                int right = this.Right;

                int top = this.Top;
                int bottom = this.Bottom;

                if (left < screen.WorkingArea.Left + setLocationMargin) left = screen.WorkingArea.Left + setLocationMargin;
                if (right > screen.WorkingArea.Right - setLocationMargin) left = screen.WorkingArea.Right - setLocationMargin - this.Width;

                if (top < screen.WorkingArea.Top + setLocationMargin) top = screen.WorkingArea.Top + setLocationMargin;
                if (bottom > screen.WorkingArea.Bottom - setLocationMargin) top = screen.WorkingArea.Bottom - setLocationMargin - this.Height;

                this.Left = left;
                this.Top = top;
            }

            else if (setLocationMouseCursor)
            {
                if (settingsOpen)
                {
                    this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
                    this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
                }

                else
                {
                    int x = mouseX;
                    int y = mouseY;

                    int xCenter = this.Width / 2;
                    int yCenter = this.Height / 2;

                    int xPositionLeft = x - xCenter - setLocationMargin;
                    int xPositionRight = x + xCenter + setLocationMargin;
                    int yPositionTop = y - yCenter - setLocationMargin;
                    int yPositionBottom = y + yCenter + setLocationMargin;

                    if (xPositionLeft < screen.WorkingArea.Left + setLocationMargin) xPositionLeft = screen.WorkingArea.Left + setLocationMargin;
                    else if (xPositionRight > screen.WorkingArea.Right + setLocationMargin) xPositionLeft = screen.WorkingArea.Right - this.Width - setLocationMargin;

                    if (yPositionTop < screen.WorkingArea.Top + setLocationMargin) yPositionTop = screen.WorkingArea.Top + setLocationMargin;
                    else if (yPositionBottom > screen.WorkingArea.Bottom + setLocationMargin) yPositionTop = screen.WorkingArea.Bottom - this.Height - setLocationMargin;

                    this.Left = xPositionLeft;
                    this.Top = yPositionTop;
                }
            }

            else if (setLocationCustom)
            {
                if (setLocationCustomTop)
                {
                    this.Top = screen.WorkingArea.Top + setLocationCustomY;
                }

                else
                {
                    this.Top = screen.WorkingArea.Bottom - setLocationCustomY - this.Height;
                }

                if (setLocationCustomLeft)
                {
                    this.Left = screen.WorkingArea.Left + setLocationCustomX;
                }

                else
                {
                    this.Left = screen.WorkingArea.Right - setLocationCustomX - this.Width;
                }
            }

            else
            {
                if (setLocationTop)
                {
                    this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
                    this.Top = screen.WorkingArea.Top + setLocationMargin;
                }

                else if (setLocationBottom)
                {
                    this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
                    this.Top = screen.WorkingArea.Top + screen.WorkingArea.Height - this.Height - setLocationMargin;
                }

                else if (setLocationLeft)
                {
                    this.Left = screen.WorkingArea.Left + setLocationMargin;
                    this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
                }

                else if (setLocationRight)
                {
                    this.Left = screen.WorkingArea.Left + screen.WorkingArea.Width - this.Width - setLocationMargin;
                    this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
                }

                else if (setLocationTopLeft)
                {
                    this.Left = screen.WorkingArea.Left + setLocationMargin;
                    this.Top = screen.WorkingArea.Top + setLocationMargin;
                }

                else if (setLocationBottomLeft)
                {
                    this.Left = screen.WorkingArea.Left + setLocationMargin;
                    this.Top = screen.WorkingArea.Top + screen.WorkingArea.Height - this.Height - setLocationMargin;
                }

                else if (setLocationTopRight)
                {
                    this.Left = screen.WorkingArea.Left + screen.WorkingArea.Width - this.Width - setLocationMargin;
                    this.Top = screen.WorkingArea.Top + setLocationMargin;
                }

                else if (setLocationBottomRight)
                {
                    this.Left = screen.WorkingArea.Left + screen.WorkingArea.Width - this.Width - setLocationMargin;
                    this.Top = screen.WorkingArea.Top + screen.WorkingArea.Height - this.Height - setLocationMargin;
                }

                else //if (setLocationCenter)
                {
                    this.Left = screen.WorkingArea.Left + ((screen.WorkingArea.Width / 2) - (this.Width / 2));
                    this.Top = screen.WorkingArea.Top + ((screen.WorkingArea.Height / 2) - (this.Height / 2));
                }
            }
        }

        private void maximizeHeight()
        {
            Screen screen = Screen.FromPoint(Control.MousePosition);

            this.Top = 0;
            this.Height = screen.WorkingArea.Height;
            resizeWindow();
            resizeWindow();
        }

        private void maximizeWidth()
        {
            Screen screen = Screen.FromPoint(Control.MousePosition);

            this.Top = 0;
            this.Height = 0;
            resizeWindow();
            resizeWindow();
        }

        private void resizeWindow()
        {
            int bottom = 0;
            int right = 0;
            bool foldersFound = false;

            Screen screen = Screen.FromPoint(Control.MousePosition);
            int maxWidth = screen.WorkingArea.Width - (setLocationMargin * 2);
            int maxHeight = screen.WorkingArea.Height - (setLocationMargin * 2);

            bool widthWarningTemp = false;

            foreach (Control c1 in flowLayoutPanel.Controls)
            {
                if (c1 is FlowLayoutPanel && c1.Name == "Group")
                {
                    foldersFound = true;
                    if (c1.Bottom > bottom && c1.Bottom <= maxHeight && c1.Right <= maxWidth) bottom = c1.Bottom;


                    if (c1.Right > right && c1.Right <= maxWidth)
                    {
                        right = c1.Right;
                    }

                    else if (c1.Right > maxWidth)
                    {
                        widthWarningTemp = true;
                    }
                }
            }

            if (widthWarningTemp)
            {
                if (!widthWarning) widthWarningOk = false;
                widthWarning = true;
            }

            else
            {
                widthWarning = false;
                widthWarningOk = false;
            }
            
            if (foldersFound)
            {
                this.Height = bottom + (paddingResizeForm * 2) + setOuterMargin + setGroupMargin;
                this.Width = right + (paddingResizeForm * 2) + setOuterMargin + setGroupMargin;

                if (widthWarning) this.BackColor = setColorBackgroundWarning;
                else this.BackColor = setColorBackground;

                if (widthWarning && !widthWarningOk)
                {
                    bool wasOpen = settingsOpen;
                    widthWarningOk = true;
                    settingsOpen = true;

                    MessageBox.Show(
                        "There are some groups that does not fit to screen, and for that reason window background was changed to red." + Environment.NewLine + Environment.NewLine +
                        "You may try to:" + Environment.NewLine + Environment.NewLine +
                        " - Increase window height" + Environment.NewLine +
                        " - Decrease element sizes via Settings" + Environment.NewLine +
                        " - Delete some groups"
                        , "RunIt");

                    settingsOpen = wasOpen;
                }

            }

            else
            {
                this.Height = 400;
                this.Width = 400;
            }

            centerForm();
        }

        private void resizeGroups()
        {
            foreach (Control c1 in flowLayoutPanel.Controls)
            {
                if (c1 is FlowLayoutPanel && c1.Name == "Group")
                {
                    int count = 0;

                    foreach (Control c2 in c1.Controls)
                    {
                        if (c2 is Panel) count++;
                    }

                    double iconRows = 0;

                    if (count > 0) iconRows = (double)count / setHorizontal;
                    int rows = (int)Math.Ceiling(iconRows);

                    int extraForEmptyGroup = 0;
                    if (count == 0) extraForEmptyGroup = setShortcutMargin;
                    c1.Height = setGroupLabel + (2 * setShortcutMargin) + (rows * (setShortcutRectangleSize + (2 * setShortcutMargin)) + extraForEmptyGroup);
                }
            }
        }
    }
}
