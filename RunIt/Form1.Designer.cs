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
            this.timerToolTip = new System.Windows.Forms.Timer(this.components);
            this.timerMouse = new System.Windows.Forms.Timer(this.components);
            this.timerDrag = new System.Windows.Forms.Timer(this.components);
            this.contextFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openShortcutFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextShortcut = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuShortcutTopic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.menuShortcutRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShortcutEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShortcutDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openShortcutFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentPositionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuGroupTopic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGroupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGroupRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openShortcutFolderToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentPositionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextTray = new System.Windows.Forms.ContextMenu();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.contextForm.SuspendLayout();
            this.contextShortcut.SuspendLayout();
            this.contextGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RunIt";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
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
            // contextFolder
            // 
            this.contextFolder.DropShadowEnabled = false;
            this.contextFolder.Name = "contextFolder";
            this.contextFolder.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextFolder.ShowItemToolTips = false;
            this.contextFolder.Size = new System.Drawing.Size(61, 4);
            // 
            // contextForm
            // 
            this.contextForm.DropShadowEnabled = false;
            this.contextForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGroupToolStripMenuItem,
            this.toolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.openShortcutFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveCurrentPositionToolStripMenuItem,
            this.toolStripMenuItem3,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextForm.Name = "contextFolder";
            this.contextForm.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextForm.ShowItemToolTips = false;
            this.contextForm.Size = new System.Drawing.Size(186, 176);
            // 
            // newGroupToolStripMenuItem
            // 
            this.newGroupToolStripMenuItem.Name = "newGroupToolStripMenuItem";
            this.newGroupToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newGroupToolStripMenuItem.Text = "New group...";
            this.newGroupToolStripMenuItem.Click += new System.EventHandler(this.menuGroupNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // openShortcutFolderToolStripMenuItem
            // 
            this.openShortcutFolderToolStripMenuItem.Name = "openShortcutFolderToolStripMenuItem";
            this.openShortcutFolderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openShortcutFolderToolStripMenuItem.Text = "Open shortcut folder";
            this.openShortcutFolderToolStripMenuItem.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // saveCurrentPositionToolStripMenuItem
            // 
            this.saveCurrentPositionToolStripMenuItem.Name = "saveCurrentPositionToolStripMenuItem";
            this.saveCurrentPositionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveCurrentPositionToolStripMenuItem.Text = "Save current position";
            this.saveCurrentPositionToolStripMenuItem.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextShortcut
            // 
            this.contextShortcut.DropShadowEnabled = false;
            this.contextShortcut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShortcutTopic,
            this.toolStripMenuItem11,
            this.menuShortcutRename,
            this.menuShortcutEdit,
            this.menuShortcutDelete,
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem1,
            this.openShortcutFolderToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.saveCurrentPositionToolStripMenuItem1,
            this.toolStripMenuItem6,
            this.settingsToolStripMenuItem1,
            this.helpToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.contextShortcut.Name = "contextFolder";
            this.contextShortcut.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextShortcut.ShowItemToolTips = false;
            this.contextShortcut.Size = new System.Drawing.Size(186, 248);
            // 
            // menuShortcutTopic
            // 
            this.menuShortcutTopic.Name = "menuShortcutTopic";
            this.menuShortcutTopic.Size = new System.Drawing.Size(185, 22);
            this.menuShortcutTopic.Text = "Shortcut topic";
            this.menuShortcutTopic.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(182, 6);
            // 
            // menuShortcutRename
            // 
            this.menuShortcutRename.Name = "menuShortcutRename";
            this.menuShortcutRename.Size = new System.Drawing.Size(185, 22);
            this.menuShortcutRename.Text = "Rename shortcut...";
            this.menuShortcutRename.Click += new System.EventHandler(this.menuShortcutRename_Click);
            // 
            // menuShortcutEdit
            // 
            this.menuShortcutEdit.Name = "menuShortcutEdit";
            this.menuShortcutEdit.Size = new System.Drawing.Size(185, 22);
            this.menuShortcutEdit.Text = "Edit shortcut...";
            this.menuShortcutEdit.Click += new System.EventHandler(this.menuShortcutEdit_Click);
            // 
            // menuShortcutDelete
            // 
            this.menuShortcutDelete.Name = "menuShortcutDelete";
            this.menuShortcutDelete.Size = new System.Drawing.Size(185, 22);
            this.menuShortcutDelete.Text = "Delete shortcut...";
            this.menuShortcutDelete.Click += new System.EventHandler(this.menuShortcutDelete_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(182, 6);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // openShortcutFolderToolStripMenuItem1
            // 
            this.openShortcutFolderToolStripMenuItem1.Name = "openShortcutFolderToolStripMenuItem1";
            this.openShortcutFolderToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.openShortcutFolderToolStripMenuItem1.Text = "Open shortcut folder";
            this.openShortcutFolderToolStripMenuItem1.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(182, 6);
            // 
            // saveCurrentPositionToolStripMenuItem1
            // 
            this.saveCurrentPositionToolStripMenuItem1.Name = "saveCurrentPositionToolStripMenuItem1";
            this.saveCurrentPositionToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.saveCurrentPositionToolStripMenuItem1.Text = "Save current position";
            this.saveCurrentPositionToolStripMenuItem1.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(182, 6);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextGroup
            // 
            this.contextGroup.DropShadowEnabled = false;
            this.contextGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGroupTopic,
            this.toolStripMenuItem12,
            this.menuGroupNew,
            this.menuGroupRename,
            this.menuGroupDelete,
            this.toolStripMenuItem7,
            this.menuPaste,
            this.toolStripMenuItem8,
            this.refreshToolStripMenuItem2,
            this.openShortcutFolderToolStripMenuItem2,
            this.toolStripMenuItem9,
            this.saveCurrentPositionToolStripMenuItem2,
            this.toolStripMenuItem10,
            this.settingsToolStripMenuItem2,
            this.helpToolStripMenuItem2,
            this.exitToolStripMenuItem2});
            this.contextGroup.Name = "contextFolder";
            this.contextGroup.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextGroup.ShowItemToolTips = false;
            this.contextGroup.Size = new System.Drawing.Size(186, 298);
            // 
            // menuGroupTopic
            // 
            this.menuGroupTopic.Name = "menuGroupTopic";
            this.menuGroupTopic.Size = new System.Drawing.Size(185, 22);
            this.menuGroupTopic.Text = "Group topic";
            this.menuGroupTopic.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(182, 6);
            // 
            // menuGroupNew
            // 
            this.menuGroupNew.Name = "menuGroupNew";
            this.menuGroupNew.Size = new System.Drawing.Size(185, 22);
            this.menuGroupNew.Text = "New group...";
            this.menuGroupNew.Click += new System.EventHandler(this.menuGroupNew_Click);
            // 
            // menuGroupRename
            // 
            this.menuGroupRename.Name = "menuGroupRename";
            this.menuGroupRename.Size = new System.Drawing.Size(185, 22);
            this.menuGroupRename.Text = "Rename group...";
            this.menuGroupRename.Click += new System.EventHandler(this.menuGroupRename_Click);
            // 
            // menuGroupDelete
            // 
            this.menuGroupDelete.Name = "menuGroupDelete";
            this.menuGroupDelete.Size = new System.Drawing.Size(185, 22);
            this.menuGroupDelete.Text = "Delete group...";
            this.menuGroupDelete.Click += new System.EventHandler(this.menuGroupDelete_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(182, 6);
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(185, 22);
            this.menuPaste.Text = "Paste shortcut";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(182, 6);
            // 
            // refreshToolStripMenuItem2
            // 
            this.refreshToolStripMenuItem2.Name = "refreshToolStripMenuItem2";
            this.refreshToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.refreshToolStripMenuItem2.Text = "Refresh";
            this.refreshToolStripMenuItem2.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // openShortcutFolderToolStripMenuItem2
            // 
            this.openShortcutFolderToolStripMenuItem2.Name = "openShortcutFolderToolStripMenuItem2";
            this.openShortcutFolderToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.openShortcutFolderToolStripMenuItem2.Text = "Open shortcut folder";
            this.openShortcutFolderToolStripMenuItem2.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(182, 6);
            // 
            // saveCurrentPositionToolStripMenuItem2
            // 
            this.saveCurrentPositionToolStripMenuItem2.Name = "saveCurrentPositionToolStripMenuItem2";
            this.saveCurrentPositionToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.saveCurrentPositionToolStripMenuItem2.Text = "Save current position";
            this.saveCurrentPositionToolStripMenuItem2.Click += new System.EventHandler(this.menuSavePosition_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(182, 6);
            // 
            // settingsToolStripMenuItem2
            // 
            this.settingsToolStripMenuItem2.Name = "settingsToolStripMenuItem2";
            this.settingsToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.settingsToolStripMenuItem2.Text = "Settings";
            this.settingsToolStripMenuItem2.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.helpToolStripMenuItem2.Text = "Help";
            this.helpToolStripMenuItem2.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // contextTray
            // 
            this.contextTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem17,
            this.menuItem20,
            this.menuItem21,
            this.menuItem22});
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "Open shortcut folder";
            this.menuItem15.Click += new System.EventHandler(this.menuOpenFolder_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 1;
            this.menuItem17.Text = "-";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.Text = "Settings";
            this.menuItem20.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 3;
            this.menuItem21.Text = "Help";
            this.menuItem21.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 4;
            this.menuItem22.Text = "Exit";
            this.menuItem22.Click += new System.EventHandler(this.menuExit_Click);
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
            this.contextForm.ResumeLayout(false);
            this.contextShortcut.ResumeLayout(false);
            this.contextGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timerToolTip;
        private System.Windows.Forms.Timer timerMouse;
        private System.Windows.Forms.Timer timerDrag;
        private System.Windows.Forms.ContextMenuStrip contextFolder;
        private System.Windows.Forms.ContextMenuStrip contextForm;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openShortcutFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextShortcut;
        private System.Windows.Forms.ContextMenuStrip contextGroup;
        private System.Windows.Forms.ContextMenu contextTray;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.ToolStripMenuItem menuShortcutRename;
        private System.Windows.Forms.ToolStripMenuItem menuShortcutEdit;
        private System.Windows.Forms.ToolStripMenuItem menuShortcutDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openShortcutFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentPositionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuGroupNew;
        private System.Windows.Forms.ToolStripMenuItem menuGroupRename;
        private System.Windows.Forms.ToolStripMenuItem menuGroupDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openShortcutFolderToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentPositionToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuShortcutTopic;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem menuGroupTopic;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
    }
}

