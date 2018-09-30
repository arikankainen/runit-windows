using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form_Message : Form
    {
        private string topic;
        public string Topic
        {
            set { topic = value; }
        }

        private string message;
        public string Message
        {
            set { message = value; }
        }

        private double opa;
        public double Opa
        {
            set { opa = value; }
        }

        private Color colorBorder;
        public Color ColorBorder
        {
            set { colorBorder = value; }
        }

        private Color colorBackgroundTopic;
        public Color ColorBackgroundTopic
        {
            set { colorBackgroundTopic = value; }
        }

        private Color colorBackgroundButton;
        public Color ColorBackgroundButton
        {
            set { colorBackgroundButton = value; }
        }

        private Color colorBackgroundButtonHover;
        public Color ColorBackgroundButtonHover
        {
            set { colorBackgroundButtonHover = value; }
        }

        private Color colorBackground;
        public Color ColorBackground
        {
            set { colorBackground = value; }
        }

        private Color colorTopic;
        public Color ColorTopic
        {
            set { colorTopic = value; }
        }

        private Color colorText;
        public Color ColorText
        {
            set { colorText = value; }
        }

        private Font fontTopic;
        public Font FontTopic
        {
            set { fontTopic = value; }
        }

        private Font fontText;
        public Font FontText
        {
            set { fontText = value; }
        }

        private int locationX;
        public int LocationX
        {
            set { locationX = value; }
        }

        private int locationY;
        public int LocationY
        {
            set { locationY = value; }
        }

        private int borderSize;
        public int BorderSize
        {
            set { borderSize = value; }
        }

        private int marginElements;
        public int MarginElements
        {
            set { marginElements = value; }
        }

        private int locationMargin;
        public int LocationMargin
        {
            set { locationMargin = value; }
        }

        private int topicHeight;
        public int TopicHeight
        {
            set { topicHeight = value; }
        }

        private int fadeSpeed;
        public int FadeSpeed
        {
            set { fadeSpeed = value; }
        }

        private bool showTextBox;
        public bool ShowTextBox
        {
            set { showTextBox = value; }
        }

        private ContentAlignment topicAlign;
        public ContentAlignment TopicAlign
        {
            set { topicAlign = value; }
        }

        private DialogResult result;
        public DialogResult Result
        {
            get { return result; }
        }

        private string textEntered = "";
        public string TextEntered
        {
            get { return textEntered; }
            set { textEntered = value; }
        }

        private Color grayedOutBack;
        private Color grayedOutFore;
        private bool okEnabled;

        public Form_Message()
        {
            InitializeComponent();
        }

        private void Form_Message_Shown(object sender, EventArgs e)
        {
            fadeIn();
        }

        private void Form_Message_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.BackColor = colorBackground;
            panelBorder.BackColor = colorBorder;
            panelOk.BackColor = panelCancel.BackColor = colorBackgroundButton;
            labelTopic.ForeColor = colorTopic;
            txtText.ForeColor = labelText.ForeColor = labelOk.ForeColor = labelCancel.ForeColor = colorText;
            labelTopic.Font = fontTopic;
            labelText.Font = labelOk.Font = labelCancel.Font = fontText;

            labelTopic.Text = topic;
            labelText.Text = message;
            txtText.Text = textEntered;
            txtText.Focus();
            txtText.SelectionStart = txtText.TextLength;

            int r = colorBackground.R + 1;
            int g = colorBackground.G + 1;
            int b = colorBackground.B + 1;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            panelTextBox.BackColor = txtText.BackColor = grayedOutBack = Color.FromArgb(r, g, b);

            r = grayedOutBack.R + 20;
            g = grayedOutBack.G + 20;
            b = grayedOutBack.B + 20;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            grayedOutFore = Color.FromArgb(r, g, b);

            labelTopic.TextAlign = topicAlign;

            Screen screen = Screen.FromPoint(new Point(locationX, locationY));

            int l = locationX - (this.Width / 2);
            int t = locationY - (this.Height / 2);

            if (l < screen.WorkingArea.Left + locationMargin) l = screen.WorkingArea.Left + locationMargin;
            if (t < screen.WorkingArea.Top + locationMargin) t = screen.WorkingArea.Top + locationMargin;

            if (l + this.Width > screen.WorkingArea.Right - locationMargin) l = screen.WorkingArea.Right - locationMargin - this.Width;
            if (t + this.Height > screen.WorkingArea.Bottom - locationMargin) t = screen.WorkingArea.Bottom - locationMargin - this.Height;


            this.Top = t;
            this.Left = l;

            panelBorder.Left = panelBorder.Top = borderSize;
            panelBorder.Width = this.Width - (borderSize * 2);
            panelBorder.Height = this.Height - (borderSize * 2);

            panelTopic.Left = marginElements;
            panelTopic.Top = marginElements;
            panelTopic.Width = panelBorder.Width - (marginElements * 2);
            panelTopic.Height = topicHeight;

            panelOk.Left = marginElements;
            panelOk.Top = panelBorder.Height - panelOk.Height - marginElements;

            panelCancel.Left = panelBorder.Width - panelCancel.Width - marginElements;
            panelCancel.Top = panelBorder.Height - panelOk.Height - marginElements;

            panelTextBox.Left = marginElements;
            panelTextBox.Width = panelBorder.Width - (marginElements * 2);
            panelTextBox.Top = panelOk.Top - panelTextBox.Height - marginElements;

            if (showTextBox)
            {
                panelText.Left = marginElements;
                panelText.Top = panelTopic.Bottom + marginElements;
                panelText.Width = panelBorder.Width - (marginElements * 2);
                panelText.Height = panelTextBox.Top - panelText.Top - marginElements;

                panelOk.BackColor = grayedOutBack;
                labelOk.ForeColor = grayedOutFore;
                okEnabled = false;
            }

            else
            {
                panelTextBox.Visible = false;

                panelText.Left = marginElements;
                panelText.Top = panelTopic.Bottom + marginElements;
                panelText.Width = panelBorder.Width - (marginElements * 2);
                panelText.Height = panelOk.Top - panelText.Top - marginElements;

                okEnabled = true;
            }
        }

        private void labelOk_MouseEnter(object sender, EventArgs e)
        {
            if (okEnabled) panelOk.BackColor = colorBackgroundButtonHover;
        }

        private void labelOk_MouseLeave(object sender, EventArgs e)
        {
            if (okEnabled) panelOk.BackColor = colorBackgroundButton;
        }

        private void labelCancel_MouseEnter(object sender, EventArgs e)
        {
            panelCancel.BackColor = colorBackgroundButtonHover;
        }

        private void labelCancel_MouseLeave(object sender, EventArgs e)
        {
            panelCancel.BackColor = colorBackgroundButton;
        }

        private void labelOk_Click(object sender, EventArgs e)
        {
            if (okEnabled)
            {
                result = DialogResult.OK;
                textEntered = txtText.Text;
                fadeOut();
                this.Close();
            }
        }

        private void labelCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            fadeOut();
            this.Close();
        }

        private int originX;
        private int originY;

        private int originMouseX;
        private int originMouseY;

        private int mouseX;
        private int mouseY;
        
        private void Form_Message_MouseDown(object sender, MouseEventArgs e)
        {
            originX = this.Left;
            originY = this.Top;

            originMouseX = Cursor.Position.X;
            originMouseY = Cursor.Position.Y;
        }

        private void Form_Message_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int diffX = originMouseX - originX;
                int diffY = originMouseY - originY;

                int left = Cursor.Position.X - diffX;
                int right = left + this.Width;

                int top = Cursor.Position.Y - diffY;
                int bottom = top + this.Height;

                mouseX = this.Left + (this.Width / 2);
                mouseY = this.Top + (this.Height / 2);

                Screen screen = Screen.FromPoint(Control.MousePosition);

                if (left < screen.WorkingArea.Left + locationMargin) left = screen.WorkingArea.Left + locationMargin;
                if (right > screen.WorkingArea.Right - locationMargin) left = screen.WorkingArea.Right - locationMargin - this.Width;

                if (top < screen.WorkingArea.Top + locationMargin) top = screen.WorkingArea.Top + locationMargin;
                if (bottom > screen.WorkingArea.Bottom - locationMargin) top = screen.WorkingArea.Bottom - locationMargin - this.Height;

                this.Left = left;
                this.Top = top;
            }
        }

        private void fadeIn()
        {
            double fade = (double)fadeSpeed / 100;

            this.Opacity = 0;
            this.Show();

            for (double i = 0.0; i <= opa; i += fade)
            {
                Thread.Sleep(10);
                this.Opacity = i;
                Application.DoEvents();
            }

            this.Opacity = opa;
        }

        private void fadeOut()
        {
            double fade = (double)fadeSpeed / 100;

            for (double i = opa; i >= 0.0; i -= fade)
            {
                Thread.Sleep(10);
                this.Opacity = i;
                Application.DoEvents();
            }
            this.Hide();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (txtText.Visible)
            {
                if (txtText.Text != "" && txtText.Text != textEntered)
                {
                    panelOk.BackColor = colorBackgroundButton;
                    labelOk.ForeColor = colorText;
                    okEnabled = true;
                }

                else
                {
                    panelOk.BackColor = grayedOutBack;
                    labelOk.ForeColor = grayedOutFore;
                    okEnabled = false;
                }
            }
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labelOk_Click(null, null);
            }
        }
    }
}
