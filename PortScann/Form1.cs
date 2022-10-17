using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PortScann
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.run = true;
        }
        public bool run; 


        public void clearComponents()
        {
            this.txt_ip.Text = "";
            this.txt_max.Text = "";
            this.txt_min.Text= "";
            this.txt_ports.Clear();
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            int minPort = Convert.ToInt32(txt_min.Text);
            int maxPort = Convert.ToInt32(txt_max.Text);

            for(int i = minPort; i <= maxPort; i++)
            {
                TcpClient tcpportScan = new TcpClient();
                try
                {
                    if(this.run)
                    {
                        tcpportScan.Connect("localhost", i);
                        txt_ports.AppendText("Port: " + i + " is open");
                        txt_ports.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        this.clearComponents();
                    }
                }
                catch
                {
                    txt_ports.AppendText("Port: " + i + " is closed");
                    txt_ports.AppendText(Environment.NewLine);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.run = false;
        }
    }
}
