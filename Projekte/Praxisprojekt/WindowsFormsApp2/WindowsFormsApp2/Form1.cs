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

  

    public partial class Form1 : Form
    {

        public string temp;
        
        public Form1(string url)
        {
            temp = url;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            Url generator = new Url(temp);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // lbl.Text = form1.oeffentliches;
            pictureBox1.Image = qrCode.GetGraphic(2);


        }
      
    }
}
