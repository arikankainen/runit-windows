namespace RunIt
{
    partial class Form_Message
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
            this.panelOk = new System.Windows.Forms.Panel();
            this.labelOk = new System.Windows.Forms.Label();
            this.panelCancel = new System.Windows.Forms.Panel();
            this.labelCancel = new System.Windows.Forms.Label();
            this.panelTopic = new System.Windows.Forms.Panel();
            this.labelTopic = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.panelTextBox = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.panelText = new System.Windows.Forms.Panel();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelOk.SuspendLayout();
            this.panelCancel.SuspendLayout();
            this.panelTopic.SuspendLayout();
            this.panelTextBox.SuspendLayout();
            this.panelText.SuspendLayout();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOk
            // 
            this.panelOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOk.Controls.Add(this.labelOk);
            this.panelOk.Location = new System.Drawing.Point(12, 138);
            this.panelOk.Name = "panelOk";
            this.panelOk.Size = new System.Drawing.Size(120, 30);
            this.panelOk.TabIndex = 0;
            // 
            // labelOk
            // 
            this.labelOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOk.Location = new System.Drawing.Point(1, 1);
            this.labelOk.Name = "labelOk";
            this.labelOk.Size = new System.Drawing.Size(118, 28);
            this.labelOk.TabIndex = 2;
            this.labelOk.Text = "OK";
            this.labelOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOk.Click += new System.EventHandler(this.labelOk_Click);
            this.labelOk.MouseEnter += new System.EventHandler(this.labelOk_MouseEnter);
            this.labelOk.MouseLeave += new System.EventHandler(this.labelOk_MouseLeave);
            // 
            // panelCancel
            // 
            this.panelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCancel.Controls.Add(this.labelCancel);
            this.panelCancel.Location = new System.Drawing.Point(233, 138);
            this.panelCancel.Name = "panelCancel";
            this.panelCancel.Size = new System.Drawing.Size(120, 30);
            this.panelCancel.TabIndex = 1;
            // 
            // labelCancel
            // 
            this.labelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCancel.Location = new System.Drawing.Point(1, 1);
            this.labelCancel.Name = "labelCancel";
            this.labelCancel.Size = new System.Drawing.Size(118, 28);
            this.labelCancel.TabIndex = 3;
            this.labelCancel.Text = "Cancel";
            this.labelCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCancel.Click += new System.EventHandler(this.labelCancel_Click);
            this.labelCancel.MouseEnter += new System.EventHandler(this.labelCancel_MouseEnter);
            this.labelCancel.MouseLeave += new System.EventHandler(this.labelCancel_MouseLeave);
            // 
            // panelTopic
            // 
            this.panelTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopic.Controls.Add(this.labelTopic);
            this.panelTopic.Location = new System.Drawing.Point(0, 0);
            this.panelTopic.Name = "panelTopic";
            this.panelTopic.Size = new System.Drawing.Size(365, 40);
            this.panelTopic.TabIndex = 1;
            // 
            // labelTopic
            // 
            this.labelTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTopic.Location = new System.Drawing.Point(0, 0);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(365, 40);
            this.labelTopic.TabIndex = 0;
            this.labelTopic.Text = "Topic";
            this.labelTopic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTopic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseDown);
            this.labelTopic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseMove);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Location = new System.Drawing.Point(8, 9);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(324, 13);
            this.txtText.TabIndex = 2;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
            // 
            // panelTextBox
            // 
            this.panelTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTextBox.Controls.Add(this.txtText);
            this.panelTextBox.Location = new System.Drawing.Point(12, 96);
            this.panelTextBox.Name = "panelTextBox";
            this.panelTextBox.Size = new System.Drawing.Size(341, 30);
            this.panelTextBox.TabIndex = 3;
            // 
            // labelText
            // 
            this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelText.Location = new System.Drawing.Point(0, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(341, 30);
            this.labelText.TabIndex = 4;
            this.labelText.Text = "Message";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelText.UseMnemonic = false;
            this.labelText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseDown);
            this.labelText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseMove);
            // 
            // panelText
            // 
            this.panelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelText.Controls.Add(this.labelText);
            this.panelText.Location = new System.Drawing.Point(12, 53);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(341, 30);
            this.panelText.TabIndex = 5;
            // 
            // panelBorder
            // 
            this.panelBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder.Controls.Add(this.panelOk);
            this.panelBorder.Controls.Add(this.panelCancel);
            this.panelBorder.Controls.Add(this.panelTopic);
            this.panelBorder.Controls.Add(this.panelTextBox);
            this.panelBorder.Controls.Add(this.panelText);
            this.panelBorder.Location = new System.Drawing.Point(10, 10);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(365, 180);
            this.panelBorder.TabIndex = 6;
            this.panelBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseDown);
            this.panelBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseMove);
            // 
            // Form_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 200);
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Message";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Message";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_Message_Load);
            this.Shown += new System.EventHandler(this.Form_Message_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Message_MouseMove);
            this.panelOk.ResumeLayout(false);
            this.panelCancel.ResumeLayout(false);
            this.panelTopic.ResumeLayout(false);
            this.panelTextBox.ResumeLayout(false);
            this.panelTextBox.PerformLayout();
            this.panelText.ResumeLayout(false);
            this.panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOk;
        private System.Windows.Forms.Panel panelCancel;
        private System.Windows.Forms.Panel panelTopic;
        private System.Windows.Forms.Label labelTopic;
        private System.Windows.Forms.Label labelOk;
        private System.Windows.Forms.Label labelCancel;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Panel panelTextBox;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Panel panelBorder;
    }
}