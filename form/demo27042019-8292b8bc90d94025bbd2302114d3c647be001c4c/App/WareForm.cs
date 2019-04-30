using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class WareForm : Form
    {
        public WareForm()
        {
            InitializeComponent();
        }

        private void фToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form furnitura = new FurnituraForm();
            furnitura.Show();
            this.Close();
        }

        private void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tkani = new TkaniForm();
            tkani.Show();
            this.Close();
        }
    }
}
