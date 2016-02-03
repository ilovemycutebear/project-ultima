using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace TestApp
{
    public partial class Form4 : Form
    {
        public delegate void InvokeDelegate();
        string characterness;
        string line;
        string PagasaCentralNum;
        string OthersNum;
        string comlocation = @"C:\PagasaSmsConfig\configure\Comport.pagasa";
        string Two0location = @"C:\PagasaSmsConfig\configure\TwoZero.pagasa";
        string allnumberlocation = @"C:\PagasaSmsConfig\configure\AllNumber.pagasa";
        int second =0;
        int caretcheck = 0;
        int linefeedcheck = 0;
        private const int WM_NCHITTEST = 0x84;//make form movable
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }//make form movable
        public Form4()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            this.Cursor = Cursors.Hand;
        }
        public void ReadAllNumLines() //others readline
        {
          
            var textLines = File.ReadAllLines(allnumberlocation);

            foreach (var linea in textLines)
            {
                string[] dataArray = linea.Split('\n');
                OthersNum += dataArray[0] + "\n";
                comboBox1.Items.Add(OthersNum);
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
                    bytes[ii] =32;
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
                    if ((bytes[ii] != 10)|| (bytes[ii] != 13)){
                    characterness += "0"; //important shit dont remove
                }
               
                characterness += Convert.ToChar(bytes[ii]);
                textBox2.Text = characterness;
            }
            if ((linefeedcheck == 1) && (caretcheck == 1))
            {
                if (characterness.Contains("from:"))
                {
                    MessageBox.Show(characterness);
                    textBox2.Clear();
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
        }
        private void Form4_Load(object sender, EventArgs e)
        {
           
            HideOnLoad();
            checkBox1.Checked=true;
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
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
