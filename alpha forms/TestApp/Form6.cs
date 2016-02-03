using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;


namespace TestApp
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public void InboxList()
        {
            string[] array1 = Directory.GetFiles(@"C:\PagasaSmsConfig\Inbox\");
            foreach (string name in array1)
            {
                comboBox1.Items.Add(name);
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            InboxList();
        }
        public void ReadInboxContent()
        {
        
            textBox1.Text = "";
            var textLines = File.ReadAllLines(comboBox1.Text);

            foreach (var line in textLines)
            {
                string[] dataArray = line.Split('\n');
                textBox1.Text += dataArray[0] + "\n";
            }
        
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadInboxContent();
        }
    }
}
