using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Newtonsoft.Json;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {


        
        public string ziel;
        public string temp2;
        Kommunikation com = new Kommunikation();

        public Form1(string temp)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            temp2 = temp;
            switch (temp)
            {
                case "Köln Hbf":
                    ziel = "koelnhbf";
                    break;
                case "Köln (Deutz)":
                    ziel = "koelndeutz";
                    break;
                case "Overath":
                    ziel = "overath";
                    break;
                case "Engelskirchen":
                    ziel = "engels";
                    break;
                case "Gummersbach":
                    ziel = "gmbach";
                    break;
                case "Köln Trimbornstr":
                    ziel = "trimborn";
                    break;
                case "Köln Frankfurterstr":
                    ziel = "frankfurter";
                    break;
                case "Rösrath-Stümpen":
                    ziel = "stümpen";
                    break;
                case "Rösrath":
                    ziel = "rösrath";
                    break;
                case "Hoffnungsthal":
                    ziel = "hoffnung";
                    break;
                case "Honrath":
                    ziel = "honrath";
                    break;
                case "Ründerroth":
                    ziel = "ründerr";
                    break;
                case "Marienheide":
                    ziel = "marienh";
                    break;
                case "Meinerzhagen":
                    ziel = "meinerz";
                    break;
                case "Kierspe":
                    ziel = "kierspe";
                    break;
                case "Halver-Oberbrügge":
                    ziel = "halver";
                    break;
                case "Lüdenscheid-Brügge":
                    ziel = "lüdenscheid";
                    break;

            }
            
            InitializeComponent();
            ziellabel.Text = temp;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private async void button5_Click(object sender, EventArgs e)
        {
            var item = com.GetResponseAsync("http://192.168.178.43:3000/222/paypal");
            var url = await item;
            Char[] trenner = { '+' };
            string[] splitter = url.Split(trenner);
            Console.WriteLine(splitter[0]);
            Form2 form2 = new Form2(splitter[0],com.price,temp2);
            form2.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(null, null, null);
            msgbx msgbx = new msgbx();
            form2.Close();
            msgbx.Close();
            this.Close();
        }

   
        

        private void button4_Click(object sender, EventArgs e)
        {
            Form0 form0 = new Form0();
            form0.Show();
            this.Close();
        }

        private void EinzelTickE_CheckedChanged(object sender, EventArgs e)
        {
            
            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener__1_;

            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "einzelticket1", ziel, "222");
            price.Text = com.price;
            tktart.Text = "Einzelticket";
            alter.Text = "Erwachsener";
        }

        private void EinzelTickK_CheckedChanged(object sender, EventArgs e)
        {
            
            EinzelTickK.Image = Properties.Resources.EinzelticketKindrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "einzelticket2", ziel, "222");
            price.Text = com.price;
            tktart.Text = "Einzelticket";
            alter.Text = "Kind (6-14 Jahre)";
        }

        private void Tick4E_CheckedChanged(object sender, EventArgs e)
        {
            
            Tick4E.Image = Properties.Resources._4erticketErot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "ticket1x4", ziel, "222");
            price.Text = com.price;
            tktart.Text = "4erTicket";
            alter.Text = "Erwachsener";
        }

        private void Tick4K_CheckedChanged(object sender, EventArgs e)
        {
            
            Tick4K.Image = Properties.Resources._4erticketkindrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "ticket2x4", ziel, "222");
            price.Text = com.price;
            tktart.Text = "4erTicket";
            alter.Text = "Kind (6-14 Jahre)";
        }

        private void Tick4M_CheckedChanged(object sender, EventArgs e)
        {
            
            Tick4M.Image = Properties.Resources._4erTicketMobilrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "ticketM", ziel, "222");
            price.Text = com.price;
            tktart.Text = "4erTicket";
            alter.Text = "Mobilpass";
        }

        private void Tick24_CheckedChanged(object sender, EventArgs e)
        {
            
            Tick24.Image = Properties.Resources._24stundenrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "ticket24", ziel, "222");
            price.Text = com.price;
            tktart.Text = "24StundenTickets";
            alter.Text = "1 oder 5 Personen";
        }

        private void Fahrradk_CheckedChanged(object sender, EventArgs e)
        {
            
            Fahrradk.Image = Properties.Resources.fahrradrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Zuschlag.Image = Properties.Resources.Zuschlag;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "bike",ziel, "222");
            price.Text = com.price;
            tktart.Text = "Fahrradkarten";
            alter.Text = "";
        }

        private void Zuschlag_CheckedChanged(object sender, EventArgs e)
        {
            
            Zuschlag.Image = Properties.Resources.firstclassrot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zeitkarte.Image = Properties.Resources.Zeitkarten;

            com.PostRequest("http://192.168.178.43:3000/", "firstclass", ziel, "222");
            price.Text = com.price;
            tktart.Text = "Zuschlag 1. Klasse";
            alter.Text = "";
        }

        private void Zeitkarte_CheckedChanged(object sender, EventArgs e)
        {
            
            Zeitkarte.Image = Properties.Resources.zeitkarterot;

            EinzelTickE.Image = Properties.Resources.Einzelticketerwachsener;
            EinzelTickK.Image = Properties.Resources.Einzelticketkind;
            Tick4E.Image = Properties.Resources._4erticketerwachsener;
            Tick4K.Image = Properties.Resources._4erticketkind;
            Tick4M.Image = Properties.Resources._4erticketmobilpass;
            Tick24.Image = Properties.Resources._24stunden;
            Fahrradk.Image = Properties.Resources.Fahrradkarten;
            Zuschlag.Image = Properties.Resources.Zuschlag;

            com.PostRequest("http://192.168.178.43:3000/", "time", ziel, "222");
            price.Text = com.price;
            tktart.Text = "Zeitkarten";
            alter.Text = "";
        }
       
    }
}
