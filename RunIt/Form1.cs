using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form1 : Form
    {
        private Settings settings = new Settings();
        private KeyboardHook keyboardHook = new KeyboardHook();
        private FlowLayoutPanel flowLayoutPanel;

        private string appPath = Application.ExecutablePath;
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private string appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath));

        private int paddingResizeForm = 5;

        private Color transparent = Color.FromArgb(0, Color.Black);

        private bool shortcutsFound = false;
        private bool settingsOpen = false;

        private Panel clickedPanel;
        private Label clickedLabel;

        private bool enableDoubleBuffering = true;

        private int settingsPage = 0;
        public int SettingsPage
        {
            get { return settingsPage; }
            set { settingsPage = value; }
        }

        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        // double buffered controls
        private const int WS_EX_COMPOSITED = 0x02000000;
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                if (enableDoubleBuffering) cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Opacity = 0;

            this.LostFocus += new EventHandler(Form1_LostFocus);
            keyboardHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            notifyIcon1.ContextMenu = contextForm;

            prepareToolTip();

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.BackColor = transparent;
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.MouseUp += new MouseEventHandler(flow_MouseUp);
            flowLayoutPanel.MouseDown += new MouseEventHandler(flow_MouseDown);
            flowLayoutPanel.MouseMove += new MouseEventHandler(flow_MouseMove);

            this.Controls.Add(flowLayoutPanel);

            loadSettings();
        }
    }
}
