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
    public partial class Form11 : Form
    {
        string line;
        string comlocation = @"C:\PagasaSmsConfig\configure\Registered.pagasa";
        public Form11()
        {
            InitializeComponent();
        }
        public void writeFile()
        {
            try {
                using (StreamReader sr = File.OpenText(comlocation))
                {
                    string[] lines = File.ReadAllLines(comlocation);
                    bool isMatch = false;
                    for (int x = 0; x < lines.Length - 1; x++)
                    {
                        if (textBox1.Text == lines[x])
                        {
                            sr.Close();
                            MessageBox.Show("initials is already registered. please specify a different one");
                            isMatch = true;
                            textBox1.Focus();
                        }
                    }
                    if (!isMatch)
                    {
                        sr.Close();
                       // MessageBox.Show("there is no match");
                        using (FileStream fs = new FileStream(comlocation, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(textBox1.Text);
                            MessageBox.Show("Initials successflly saved!");
                        }
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("File Does not exist please contact technical support.");
            }
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            writeFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
            this.Close();

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
