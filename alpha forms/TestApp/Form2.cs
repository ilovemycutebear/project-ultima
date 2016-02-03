using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlphaForms;

namespace TestApp
{
    public partial class Form2 : AlphaForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Hide();
            /*DrawControlBackground(this.picBoxClose, false);
            UpdateLayeredBackground(); */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            UpdateLayeredBackground();
        }
    }
}
