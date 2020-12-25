using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client3
{
    public partial class Client3 : Form
    {
        IPEndPoint ip;
        Socket server;

        public Client3()
        {
            InitializeComponent();
            
        }

        void Connect(IPEndPoint ip, Socket server)   //Connect to Server, use Try - catch to check IP Address.
        {
            try
            {
                server.Connect(ip);
                btnConvert.Enabled = true;
                btnReset.Enabled = true;
                txbNhap.Enabled = true;
                panel1.Enabled = true;
                IPv4txb.Enabled = false;
                connectbtn.Enabled = false;
            }
            catch (SocketException)
            {
                MessageBox.Show("Sai địa chỉ IP, mời nhập lại !", "Thông báo", MessageBoxButtons.OK);
                IPv4txb.Clear();
            }

        }

        Encoding OutputEncoding = Encoding.UTF8;  

        string input;  

        private void btnConvert_Click(object sender, EventArgs e)  
        {
            
            input = txbNhap.Text;  //Input is textbox "txbNhap"

            double n;

            if (!double.TryParse(input, out n))  //Check the format of input number
            {
                MessageBox.Show("Dãy số sai định dạng, mời nhập lại !", "Thông báo", MessageBoxButtons.OK);

                txbNhap.Clear();

                return;
            }

            //Choose 1 of 3 languages to convert
            if (rdbtnTV.Checked == true)  //Radiobutton "Tiếng Việt"
            {
                server.Send(Encoding.UTF8.GetBytes("tv " + input));    //convert from UTF-8 to byte array and send the array to server
                byte[] data = new byte[1024];
                int recv = server.Receive(data);     //receive the byte array from server
                string a = Encoding.UTF8.GetString(data, 0, recv);      //convert from utf-8 byte to string a
                txbKetqua.Text = a;       //textbox "txbKetqua" is a

            }
            else if (rdbtnTA.Checked == true)  //Radiobutton "Tiếng Anh"
            {
                server.Send(Encoding.UTF8.GetBytes("ta " + input));
                byte[] data = new byte[1024];
                int recv = server.Receive(data);
                string a = Encoding.UTF8.GetString(data, 0, recv);
                txbKetqua.Text = a;
            }
            else if (rdbtnTP.Checked == true)  //Radiobutton "Tiếng Pháp"
            {
                server.Send(Encoding.UTF8.GetBytes("tp " + input));
                byte[] data = new byte[1024];
                int recv = server.Receive(data);
                string a = Encoding.UTF8.GetString(data, 0, recv);
                txbKetqua.Text = a;
            }
            
        }

        private void txbNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)  //Reset the app
        {
            txbNhap.Clear();
            rdbtnTV.Checked = true;
            txbKetqua.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)  //Exit the app
        {
            this.Close();
            server.Close();
        }

        private void txbNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')  //Allow entering number, two characters '.' and '-' into the textbox "txbNhap"
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txbNhap.Text.IndexOf('.') > -1) e.Handled = true; //Allow entering only one character '.'

            else if (e.KeyChar == '-' && txbNhap.Text.IndexOf('-') > -1) e.Handled = true; //Allow entering only one character '-'

            else if (e.KeyChar == '-' && txbNhap.Text.IndexOf('.') > -1) e.Handled = true;  //Do not allow entering a character '-' behind '.'.

        }
        
        private void Client3_Load(object sender, EventArgs e)
        {

        }
     
        private void txbNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        public void connectbtn_Click(object sender, EventArgs e)  //Button connect to server
        {
            string test = IPv4txb.Text;   //test is the IP Address of server
            string[] parts = test.Split('.');  //parts is 4 octets of a IPAddress

            if (parts.Length < 4)  //if octet < 4 then error
            {
                MessageBox.Show("IP sai định dạng, mời nhập lại !", "Thông báo", MessageBoxButtons.OK);

                IPv4txb.Clear();

                return;
            }
            else
            {
                foreach (string part in parts)  //check each octet (part = 1 octer)
                {
                    byte checkPart = 0;  //checkPart is byte => max = 255, eg: 255.255.255.255

                    if (!byte.TryParse(part, out checkPart))   //if 1 octet > checkPart then error 
                    {
                        MessageBox.Show("IP sai định dạng, mời nhập lại !", "Thông báo", MessageBoxButtons.OK);

                        IPv4txb.Clear();

                        return;
                    }
                }

                ip = new IPEndPoint(IPAddress.Parse(test), 9050); //ip is IPAddress and Port number of server
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //Use Socket to connect to server
                ContextMenu l_menu = new ContextMenu();
                txbNhap.ContextMenu = l_menu;
                Connect(ip, server);   
            }
        }
                
        private void IPv4txb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')  //Allow entering number, a character '.' into the textbox "IPv4txb"
            {
                e.Handled = true;
            }
        }
    }
}



