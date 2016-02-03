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
    public partial class Form14 : Form
    {
        public delegate void InvokeDelegate();
        string characterness;
        string line;
        string PagasaCentralNum;
        string OthersNum;
        string OthersNumFin;
        string comlocation = @"C:\PagasaSmsConfig\configure\Comport.pagasa";
        string Two0location = @"C:\PagasaSmsConfig\configure\TwoZero.pagasa";
        string allnumberlocation = @"C:\PagasaSmsConfig\configure\AllNumber.pagasa";
        string inboxloc;
        int second = 0;
        int seconda = 0;
        int caretcheck = 0;
        int linefeedcheck = 0;
        char[] letters = { ':', '`','$','~' };
        private const int WM_NCHITTEST = 0x84;//make form movable
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        DateTime today = DateTime.Today.Date;
        DateTime tomorrow = DateTime.Now.AddDays(1).Date;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }//make form movable
        public Form14()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            this.Cursor = Cursors.Hand;
        }
        public void SaveInbox()
        {
           inboxloc = @"C:\PagasaSmsConfig\Inbox\"+today.ToString("dd-MM-yyyy")+tomorrow.ToString("dd-MM-yyyy")+".PagasaInb";
            try
            {
                using (FileStream fs = new FileStream(inboxloc, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(characterness);
                    MessageBox.Show("Inbox saved!");
                }
            }
            catch
            {
                using (File.Create(inboxloc)) {

                    using (FileStream fs = new FileStream(inboxloc, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(characterness);
                        MessageBox.Show("Inbox saved! and created a file");
                    }

                }
            }
        }
        public void ReadAllNumLines() //others readline
        {

            var textLines = File.ReadAllLines(allnumberlocation);

            foreach (var linea in textLines)
            {
                string[] dataArray = linea.Split('\n');
                OthersNum = dataArray[0] + "\n";
                string[] comaspl = OthersNum.Split(',');
                OthersNumFin = comaspl[0];
                comboBox1.Items.Add("(" + comaspl[1] + ")" + comaspl[0]);
            }
        }
        public void Load20file()
        {

            using (StreamReader reader = new StreamReader(Two0location))
            {
                PagasaCentralNum = reader.ReadLine();

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // Declare Thread Function
            textBox2.BeginInvoke(new InvokeDelegate(updateTextbox));
            // this.Invoke(new EventHandler(updateTextbox));
            //updateTextbox();
        }

        private void updateTextbox()
        {
            
            int[] rxbuf = new int[100];
            int ii = 0;
            int[] buu = new int[1024];
            int intBytes = serialPort1.BytesToRead;
            byte[] bytes = new byte[intBytes];
            serialPort1.Read(bytes, 0, intBytes);

            for (ii = 0; ii < bytes.Length; ii++)
            {
                if (bytes[ii] == 169)
                {
          
                    bytes[ii] = 32;
                }
                if (bytes[ii] == 13)
                {
                    //bytes[ii] = 0;
                    caretcheck = 1;
                }
                if (bytes[ii] == 10)
                {
                    // bytes[ii] = 0;
                    linefeedcheck = 1;
                }
                if (bytes[ii] < 16)
                    if ((bytes[ii] != 10) && (bytes[ii] != 13))
                    {
                        characterness += "0"; //important shit dont remove
                    }

                characterness += Convert.ToChar(bytes[ii]);
                textBox2.Text = characterness;
                if ((linefeedcheck == 1)&&(caretcheck == 1))
                {
                  
                        if (characterness.Contains("from:"))
                        {
                            // MessageBox.Show(characterness);
                            textBox2.Clear();
                        //save to messages
                        SaveInbox();
                        }
                        if (characterness.Contains("SMS SENT!!"))
                        {
                            //save to file

                        }
                        MessageBox.Show(characterness);
                        pictureBox1.Hide();
                        label3.Hide();
                        seconda = 0; //zerofy timer2 counter
                        timer2.Stop(); //stop 35 seconds timer
                    linefeedcheck = 0; //reset checker
                    caretcheck = 0; //reset checker
                }
            }
           

            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }
        public void LoadComfile()
        {

            using (StreamReader reader = new StreamReader(comlocation))
            {
                line = reader.ReadLine();

            }
        }
        public void openPort()
        {

            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    serialPort1.PortName = line.ToString();
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                }
                else
                {
                    serialPort1.PortName = line.ToString();
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                }

            }
            catch
            {
                MessageBox.Show("please check GSM connection.");
            }
        }
        public void HideOnLoad()
        {
            pictureBox1.Hide();
            label3.Hide();
            comboBox1.Hide();
            label5.Hide();
            textBox2.Hide();
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            //label4.Text="shet";
            HideOnLoad();
            checkBox1.Checked = true;
            ReadAllNumLines();
            Load20file();
            LoadComfile();
            openPort();
            timer1.Start();
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second + 1;
            if (second >= 7)
            {
                second = 0;
                timer1.Stop();
                serialPort1.Write("`");
                MessageBox.Show("GSM READY!");
                label5.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                comboBox1.Show();
         
            }
            else
            {
                comboBox1.Hide();
            }
        }
        public void SendMessageCentral()
        {
            pictureBox1.Show();
            label3.Show();
            serialPort1.Write(PagasaCentralNum+"~"+textBox1.Text+"$AG^"+textBox3.Text+":");

        }
        public void SendMessageOthers()
        {
            pictureBox1.Show();
            label3.Show();
            serialPort1.Write(OthersNumFin + "~" + textBox1.Text +":");

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconda = seconda + 1;
            if (seconda >= 35)
            {
                seconda = 0;
                timer2.Stop();
                serialPort1.Write("`");
                pictureBox1.Hide();
                label3.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool containsAnyLettera = textBox3.Text.IndexOfAny(letters) >= 0;
            bool containsAnyLetter = textBox1.Text.IndexOfAny(letters) >= 0;
            if (textBox1.Text=="")//validations.
            {
                textBox1.Focus();
                MessageBox.Show("Please Fill in the Text Box.");
            }
            if (textBox3.Text == "")//validations.
            {
                textBox3.Focus();
                MessageBox.Show("Please Fill SENT BY field with your initials.");
            }
            else if (containsAnyLetter == true)
                {
                    MessageBox.Show("characters `,~,$,: are not allowed.");
                }

            else if (containsAnyLettera == true)
                {
                    MessageBox.Show("characters `,~,$,: are not allowed.");
                }
                //booleans

            else
            {
                if (checkBox1.Checked == true)
                {

                    SendMessageCentral();
                }
                if (checkBox2.Checked == true)
                {
                     if (comboBox1.Text == "")//validations.
                    {
                        checkBox1.Focus();
                        MessageBox.Show("Please Select Number.");
                    }
                    else
                    {
                        //do program for others
                        SendMessageOthers();

                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             label4.Text = "Characters Remaining: "+(textBox1.MaxLength - textBox1.TextLength).ToString();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
