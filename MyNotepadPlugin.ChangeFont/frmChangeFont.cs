using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepadPlugin.ChangeFont
{
    public partial class frmChangeFont : Form
    {
        private TextBox txtBox;

        public frmChangeFont()
        {
            InitializeComponent();
        }

        public frmChangeFont(TextBox txtBox)
            : this()
        {
            // TODO: Complete member initialization
            this.txtBox = txtBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtBox.Font = new Font(comboBox1.Text, float.Parse(comboBox2.Text.Trim()));
            this.Close();
        }
    }
}
