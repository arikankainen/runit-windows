using System;
using System.Windows.Forms;

namespace RunIt
{
    public partial class FormRename : Form
    {
        public string Topic
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string NewName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string ButtonName
        {
            get { return btnRename.Text; }
            set { btnRename.Text = value; }
        }

        public FormRename()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Close();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
