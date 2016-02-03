using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace TestApp
{
    public partial class Form10 : Form
    {
        string line;
        string comlocation = @"C:\PagasaSmsConfig\configure\Comport.pagasa";
        public Form10()
        {
            InitializeComponent();
        }
       public void LoadComfile()
        {
            
            using (StreamReader reader = new StreamReader(comlocation))
            {
                line = reader.ReadLine();
                label1.Text = "Current Setting: "+ line;
            }
        }
        public void writeFile()
        {
            try {
                var lines = System.IO.File.ReadAllLines(comlocation);
                System.IO.File.WriteAllLines(comlocation, lines.Take(lines.Length - 1).ToArray());
                using (FileStream fs = new FileStream(comlocation, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
            catch
            {
                using (FileStream fs = new FileStream(comlocation, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }

        }
        private void Form10_Load(object sender, EventArgs e)
        {
            LoadComfile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeFile();
            LoadComfile();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form12 frm12 = new Form12();
            frm12.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
