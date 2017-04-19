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

namespace RunIt
{
    public partial class Form1
    {
        private ToolTip tip = new ToolTip();

        private string toolTipText = "";
        private string lastToolTip = "";

        private int toolTipWidth;
        private int toolTipHeight;

        private void prepareToolTip()
        {
            tip.AutoPopDelay = 30000;
            tip.InitialDelay = 0;
            tip.ReshowDelay = 0;
            tip.ShowAlways = true;
            tip.OwnerDraw = true;
            tip.UseFading = false;
            tip.UseAnimation = false;
            tip.StripAmpersands = false;

            tip.Draw += new DrawToolTipEventHandler(tip_Draw);
            tip.Popup += new PopupEventHandler(tip_Popup);
        }

        private void tip_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(toolTipWidth, toolTipHeight);
        }

        private void tip_Draw(object sender, DrawToolTipEventArgs e)
        {
            Brush brush = new SolidBrush(setColorToolTipBackground);
            e.Graphics.FillRectangle(brush, e.Bounds);
            brush.Dispose();

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                Brush brushFont = new SolidBrush(setColorToolTipFont);
                e.Graphics.DrawString(e.ToolTipText, setShortcutFont, brushFont, e.Bounds, sf);
                brushFont.Dispose();
            }
        }

        private void timerToolTip_Tick(object sender, EventArgs e)
        {
            IWin32Window win = this;
            tip.Hide(win);
            lastToolTip = "";
        }

        private void showToolTip(Control control)
        {
            timerToolTip.Stop();
            if (setShowShortcutTooltips)
            {
                WshShell shell = new WshShell();
                WshShortcut shortcut = (WshShortcut)shell.CreateShortcut(control.Tag.ToString());

                string comment = shortcut.Description;
                string name = Path.GetFileNameWithoutExtension(control.Tag.ToString());

                IWin32Window win = this;

                Point locationOnForm = control.FindForm().PointToClient(control.Parent.PointToScreen(control.Location));

                int x = locationOnForm.X + (control.Width / 2);
                int y = locationOnForm.Y + control.Height + setToolTipMarginTop;

                toolTipText = name;
                if (comment != "") toolTipText = toolTipText + Environment.NewLine + comment;

                Size textSize = TextRenderer.MeasureText(toolTipText, setShortcutFont);
                toolTipWidth = textSize.Width + 10 + setToolTipPaddingWidth;
                toolTipHeight = textSize.Height + 4 + setToolTipPaddingHeight;

                if (toolTipText != lastToolTip) tip.Show(toolTipText, win, x - (toolTipWidth / 2), y);
                lastToolTip = toolTipText;
            }
        }



    }
}
