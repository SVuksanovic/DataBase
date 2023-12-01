using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class EditForm : Form
    {
        editingForm editingform;
        public EditForm(editingForm owner)
        {
            editingform = owner;
            InitializeComponent();

            /*this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            editingform.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddLine(this).Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
