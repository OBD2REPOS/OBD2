using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        private string DispString;   //used to store the values read

        public Form1()
        {
            InitializeComponent();
        }

        public void createSerialPort()
        {
            //Port name can be identified by checking the ports
            // section in Device Manager after connecting your device
            serialPort1.PortName = "COM7";
            //Provide the name of port to which device is connected

            //default values of hardware[check with device specification document]
            serialPort1.BaudRate = 115200;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;

            serialPort1.Open(); //opens the port
            serialPort1.ReadTimeout = 2000;
            if (serialPort1.IsOpen)
            {
                DispString = "";
                
            }
            textBox1.AppendText("Serial Port Open...");
            //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Debug.WriteLine("Test");
            if (textBox1.Text.Length >= 400)
            {
                serialPort1.Close(); //call your own method to perform some operation
            }
            else
            {
                DispString = serialPort1.ReadExisting();
                this.Invoke(new EventHandler(DisplayText));
            }
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(DispString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*
            serialPort1.WriteLine("ATZ\r\n");
            System.Threading.Thread.Sleep(2000);
            serialPort1.WriteLine("ATE0");
            System.Threading.Thread.Sleep(1000);
            serialPort1.WriteLine("ATL0");
            System.Threading.Thread.Sleep(500);
            serialPort1.WriteLine("ATH1");
            System.Threading.Thread.Sleep(500);
            serialPort1.WriteLine("ATSP0");
            System.Threading.Thread.Sleep(500);
            */
            
            Debug.WriteLine("Test 1");
            serialPort1.WriteLine(textBox2.Text+"\r");
//            System.Threading.Thread.Sleep(1000);

            Debug.WriteLine("Test 2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createSerialPort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] test = new char[serialPort1.ReadBufferSize];
            serialPort1.Read(test, 0, serialPort1.ReadBufferSize);
            string readed = new string(test);
            
            textBox1.AppendText("@ " + readed);
        }
    }
}
