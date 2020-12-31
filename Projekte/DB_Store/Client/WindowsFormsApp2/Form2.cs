using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Drawing;
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Drawing.Text;
using System.Threading;
using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;


namespace WindowsFormsApp2
{

  

    public partial class Form2 : Form
    {

       
        public string temp;
        public string temp2;
        Kommunikation com = new Kommunikation();
        public Form2(string url,string summe,string form1temp)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            temp = url;
            temp2 = form1temp;
            InitializeComponent();
            lbl_summe.Text = summe;
            


        }
       
      public async void popup()
        {
           var item = com.GetResponseAsync("http://192.168.178.43:3000/222/abschluss");
           var test = await item;
           test = Cipher.Decrypt(test, "YFpoGQ@$VrUMf64tZ9eg^RiaQSZ^Pw%*");
            if (test != "create")
            {
                timer1.Stop();
                Console.WriteLine("timer gestopppt");
            }
            if (test == "approval")
            {
                msgbx m = new msgbx();
                m.Show();
            }
        }

       


        private void button1_Click(object sender, EventArgs e) 
        {
            
            Url generator = new Url(temp);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            
            pictureBox1.Image = qrCode.GetGraphic(4);
            timer1.Start();
          


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(temp2);
            form1.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            popup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form0 form0 = new Form0();
            Form1 form1 = new Form1(null);
            msgbx msgbx = new msgbx();

            form0.Show();
            form1.Close();
            msgbx.Close();
            this.Close();

        }
    }
}
