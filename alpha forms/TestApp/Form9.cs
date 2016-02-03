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
    public partial class Form9 : Form
    {
        string line;
        string Two0location = @"C:\PagasaSmsConfig\configure\TwoZero.pagasa";
        RadioButton box;
        int i;
        string checkedradio;
        string allnumberlocation= @"C:\PagasaSmsConfig\configure\AllNumber.pagasa";
        public Form9()
        {
            InitializeComponent();
        }
        public void ReadAllLines()
        {
            label1.Text = "";
            var textLines = File.ReadAllLines(allnumberlocation);

            foreach (var line in textLines)
            {
                string[] dataArray = line.Split('\n');
                label1.Text += dataArray[0]+"\n";
            }
        }
        public void RadioBoxChecker()
        {
            foreach (RadioButton tb in this.Controls.OfType<RadioButton>())
            {
                if (tb.Checked == true)
                {
                    checkedradio = tb.Text;
                    //MessageBox.Show(checkedradio);
                }
            }
        }
        public void RadioBoxHide()
        {
            foreach (RadioButton tb in this.Controls.OfType<RadioButton>())
            {
                tb.Hide();
            }
        }
        public void DeleteRadio()
        {
            RadioBoxChecker();
            string strSearchText = checkedradio;
            string strOldText;
            string n = "";
            StreamReader sr = File.OpenText(allnumberlocation);
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    n += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(allnumberlocation, n);
            RadioBoxHide();
        }
        public void DynamicRadio()
        {
            i = 0;
            var textLines = File.ReadAllLines(allnumberlocation);
           
            foreach (var line in textLines)
            {
                i++;
            string[] dataArray = line.Split('\n');
             box = new RadioButton();
            box.Tag = dataArray[0].ToString();
            box.Text = dataArray[0];
            box.AutoSize = true;
            box.BackColor = Color.Transparent;
            box.Location = new Point(173,177+(i*20)); //vertical
                                                  //box.Location = new Point(i * 50, 10); //horizontal
            this.Controls.Add(box);
                
               // label1.Text += dataArray[0] + "\n";
            }
        }
        public void Load20file()
        {

            using (StreamReader reader = new StreamReader(Two0location))
            {
                line = reader.ReadLine();
                label1.Text = "PAGASA 20: " + line;
            }
        }
        public void writeFile()
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(Two0location);
                System.IO.File.WriteAllLines(Two0location, lines.Take(lines.Length - 1).ToArray());
                using (FileStream fs = new FileStream(Two0location, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(textBox1.Text);
                    MessageBox.Show("Number successflly saved!");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
        public void writeFileOther()
        {
            try
            {
                using (StreamReader sr = File.OpenText(allnumberlocation))
                {
                    string[] lines = File.ReadAllLines(allnumberlocation);
                    bool isMatch = false;
                    for (int x = 0; x < lines.Length - 1; x++)
                    {
                        if (textBox1.Text == lines[x])
                        {
                            sr.Close();
                            MessageBox.Show("Number is already registered. please specify a different one");
                            isMatch = true;
                            textBox1.Focus();
                        }
                    }
                    if (!isMatch)
                    {
                        sr.Close();
                        // MessageBox.Show("there is no match");
                        using (FileStream fs = new FileStream(allnumberlocation, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(textBox1.Text+","+textBox2.Text);
                            MessageBox.Show("Number successflly saved!");
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("File Does not exist please contact technical support.");
            }


        }
        private void Form9_Load(object sender, EventArgs e)
        {
            checkBox1.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button3.Show();
                label1.Hide();
                DynamicRadio();
            }
            else
            {
                button3.Hide();
                RadioBoxHide();
                ReadAllLines();
                label1.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();
            checkBox1.Checked = false;
            DeleteRadio();
            ReadAllLines();
            label1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="PAGASA 20")
            {
                textBox2.Hide();
                label4.Hide();
                checkBox1.Hide();
                Load20file();
            }
            else if (comboBox1.Text == "OTHERS")
            {
                textBox2.Show();
                label4.Show();
                label1.Text = "";
                ReadAllLines();
                checkBox1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PAGASA 20")
            {
                writeFile();
                checkBox1.Hide();
                Load20file();
            }
            else if (comboBox1.Text == "OTHERS")
            {
                writeFileOther();
                label1.Text = "";
                ReadAllLines();
                checkBox1.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form12 frm12 = new Form12();
            frm12.Show();
        }
    }
}
