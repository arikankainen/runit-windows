namespace RunIt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextForm = new System.Windows.Forms.ContextMenu();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuRefresh = new System.Windows.Forms.MenuItem();
            this.menuOpenFolder = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuSavePosition = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.contextShortcut = new System.Windows.Forms.ContextMenu();
            this.menuShortcutRename = new System.Windows.Forms.MenuItem();
            this.menuShortcutEdit = new System.Windows.Forms.MenuItem();
            this.menuShortcutDelete = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.contextGroup = new System.Windows.Forms.ContextMenu();
            this.menuGroupNew = new System.Windows.Forms.MenuItem();
            this.menuGroupRename = new System.Windows.Forms.MenuItem();
            this.menuGroupDelete = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.menuPaste = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.timerToolTip = new System.Windows.Forms.Timer(this.components);
            this.timerMouse = new System.Windows.Forms.Timer(this.components);
            this.timerDrag = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RunIt";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextForm
            // 
            this.contextForm.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem15,
            this.menuRefresh,
            this.menuOpenFolder,
            this.menuItem2,
            this.menuSavePosition,
            this.menuItem28,
            this.menuSettings,
            this.menuHelp,
            this.menuExit});
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "New group...";
            this.menuItem14.Click += new System.EventHandler(this.menuGroupNew_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "-";
            // 
            // menuRefresh
            // 
            this.menuRefresh.Index = 2;
            this.menuRefresh.Text = "Refresh";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuOpenFolder
            // 
            this.menuOpenFolder.Index = 3;
            this.menuOpenFolder.Text = "Open shortcut folder";
            this.menuOpenFolder.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "-";
            // 
            // menuSavePosition
            // 
            this.menuSavePosition.Index = 5;
            this.menuSavePosition.Text = "Save current position";
            this.menuSavePosition.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 6;
            this.menuItem28.Text = "-";
            // 
            // menuSettings
            // 
            this.menuSettings.Index = 7;
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 8;
            this.menuHelp.Text = "Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 9;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextShortcut
            // 
            this.contextShortcut.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuShortcutRename,
            this.menuShortcutEdit,
            this.menuShortcutDelete,
            this.menuItem4,
            this.menuItem1,
            this.menuItem3,
            this.menuItem8,
            this.menuItem23,
            this.menuItem19,
            this.menuItem9,
            this.menuItem25,
            this.menuItem12});
            // 
            // menuShortcutRename
            // 
            this.menuShortcutRename.Index = 0;
            this.menuShortcutRename.Text = "Rename shortcut...";
            this.menuShortcutRename.Click += new System.EventHandler(this.menuShortcutRename_Click);
            // 
            // menuShortcutEdit
            // 
            this.menuShortcutEdit.Index = 1;
            this.menuShortcutEdit.Text = "Edit shortcut...";
            this.menuShortcutEdit.Click += new System.EventHandler(this.menuShortcutEdit_Click);
            // 
            // menuShortcutDelete
            // 
            this.menuShortcutDelete.Index = 2;
            this.menuShortcutDelete.Text = "Delete shortcut...";
            this.menuShortcutDelete.Click += new System.EventHandler(this.menuShortcutDelete_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "-";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "Refresh";
            this.menuItem1.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            this.menuItem3.Text = "Open shortcut folder";
            this.menuItem3.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 6;
            this.menuItem8.Text = "-";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 7;
            this.menuItem23.Text = "Save current position";
            this.menuItem23.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 8;
            this.menuItem19.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            this.menuItem9.Text = "Settings";
            this.menuItem9.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 10;
            this.menuItem25.Text = "Help";
            this.menuItem25.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 11;
            this.menuItem12.Text = "Exit";
            this.menuItem12.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextGroup
            // 
            this.contextGroup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuGroupNew,
            this.menuGroupRename,
            this.menuGroupDelete,
            this.menuItem26,
            this.menuPaste,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem10,
            this.menuItem24,
            this.menuItem16,
            this.menuItem11,
            this.menuItem27,
            this.menuItem13});
            // 
            // menuGroupNew
            // 
            this.menuGroupNew.Index = 0;
            this.menuGroupNew.Text = "New group...";
            this.menuGroupNew.Click += new System.EventHandler(this.menuGroupNew_Click);
            // 
            // menuGroupRename
            // 
            this.menuGroupRename.Index = 1;
            this.menuGroupRename.Text = "Rename group...";
            this.menuGroupRename.Click += new System.EventHandler(this.menuGroupRename_Click);
            // 
            // menuGroupDelete
            // 
            this.menuGroupDelete.Index = 2;
            this.menuGroupDelete.Text = "Delete group...";
            this.menuGroupDelete.Click += new System.EventHandler(this.menuGroupDelete_Click);
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 3;
            this.menuItem26.Text = "-";
            // 
            // menuPaste
            // 
            this.menuPaste.Index = 4;
            this.menuPaste.Text = "Paste shortcut";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 6;
            this.menuItem6.Text = "Refresh";
            this.menuItem6.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "Open shortcut folder";
            this.menuItem7.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 8;
            this.menuItem10.Text = "-";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 9;
            this.menuItem24.Text = "Save current position";
            this.menuItem24.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 10;
            this.menuItem16.Text = "-";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 11;
            this.menuItem11.Text = "Settings";
            this.menuItem11.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 12;
            this.menuItem27.Text = "Help";
            this.menuItem27.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 13;
            this.menuItem13.Text = "Exit";
            this.menuItem13.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // timerToolTip
            // 
            this.timerToolTip.Tick += new System.EventHandler(this.timerToolTip_Tick);
            // 
            // timerMouse
            // 
            this.timerMouse.Tick += new System.EventHandler(this.timerMouse_Tick);
            // 
            // timerDrag
            // 
            this.timerDrag.Interval = 10;
            this.timerDrag.Tick += new System.EventHandler(this.timerDrag_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1662, 1000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextForm;
        private System.Windows.Forms.ContextMenu contextShortcut;
        private System.Windows.Forms.MenuItem menuShortcutEdit;
        private System.Windows.Forms.MenuItem menuShortcutDelete;
        private System.Windows.Forms.ContextMenu contextGroup;
        private System.Windows.Forms.MenuItem menuGroupRename;
        private System.Windows.Forms.MenuItem menuGroupDelete;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.Windows.Forms.MenuItem menuRefresh;
        private System.Windows.Forms.MenuItem menuOpenFolder;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.Timer timerToolTip;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuShortcutRename;
        private System.Windows.Forms.MenuItem menuGroupNew;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.Timer timerMouse;
        private System.Windows.Forms.MenuItem menuSavePosition;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.Timer timerDrag;
        private System.Windows.Forms.MenuItem menuItem26;
        private System.Windows.Forms.MenuItem menuPaste;
        private System.Windows.Forms.MenuItem menuHelp;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem menuItem27;
        private System.Windows.Forms.MenuItem menuItem28;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem16;
    }
}

