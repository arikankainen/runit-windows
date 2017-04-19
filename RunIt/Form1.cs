using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunIt
{
    public partial class Form1 : Form
    {
        private Settings settings = new Settings();
        private KeyboardHook hook = new KeyboardHook();
        private FlowLayoutPanel flowLayoutPanel1;

        private string appPath = Application.ExecutablePath;
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private string appFile = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(Application.ExecutablePath));

        private int paddingResizeForm = 5;

        private Color transparent = Color.FromArgb(0, Color.Black);

        private bool shortcutsFound = false;
        private bool settingsOpen = false;

        private Panel clickedPanel;
        private Label clickedLabel;

        private bool notFound;
        
        private bool enableDoubleBuffering = true;

        private int settingsPage = 0;
        public int SettingsPage
        {
            get { return settingsPage; }
            set { settingsPage = value; }
        }

        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        // double buffered controls
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                if (enableDoubleBuffering) cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                //cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Opacity = 0;

            this.LostFocus += new EventHandler(Form1_LostFocus);
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            notifyIcon1.ContextMenu = contextForm;

            prepareToolTip();

            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.BackColor = transparent;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.MouseUp += new MouseEventHandler(flow_MouseUp);
            flowLayoutPanel1.MouseDown += new MouseEventHandler(flow_MouseDown);
            flowLayoutPanel1.MouseMove += new MouseEventHandler(flow_MouseMove);

            this.Controls.Add(flowLayoutPanel1);

            loadSettings();

        }

    }
}
