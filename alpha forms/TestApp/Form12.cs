using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void sYNOPMETARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Show();
            this.Close();
        }

        private void aGROMETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Close();
        }

        private void tAPORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Close();
        }

        private void tEMPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form6 frm6 = new Form6();
          //  frm6.Show();
            this.Close();
        }

        private void cUSTOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form7 frm7 = new Form7();
           // frm7.Show();
            this.Close();
        }

        private void oSADMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Form8 frm8 = new Form8();
           // frm8.Show();
            this.Close();
        }

        private void aDDEDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
            this.Close();
        }

        private void cOMPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
            this.Close();
        }

        private void iNITIALSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.Show();
            this.Close();
        }
    }
}
