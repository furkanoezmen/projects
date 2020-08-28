using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form0 : Form
    {
        public int x = 0;
        private bool isCollapsed = true;
        private bool loeschen = false;
        public string ziel;
        public string value;
        List<string> Haltestellen = new List<string>();
        List<string> Auswahl = new List<string>();
        public Form0()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
            befuellen();
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
            timer2.Start();
            timer3.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                x += 5;   
                mainPanel.Location = new Point(160 + x, 84);
                flowLayoutPanel1.Height += 35;
                flowLayoutPanel1.Width += 20;
                
               if (mainPanel.Location == new Point(170, 84))
                {
                    timer3.Stop();
                }

                if (flowLayoutPanel1.Size == flowLayoutPanel1.MaximumSize )
                {
                    timer1.Stop();
                    isCollapsed =false;
                }

            }
            else
            {
                x -= 5;         
                mainPanel.Location = new Point(170 + x, 84);
                flowLayoutPanel1.Height -= 35;
                flowLayoutPanel1.Width -= 20;
                if (mainPanel.Location == new Point(160, 84))
                {
                    timer3.Stop();
                }
                if (flowLayoutPanel1.Size == flowLayoutPanel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            
                Form1 form1 = new Form1(value);
                form1.Show();
                
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ziel_txtbox.Text = button2.Text;
            value = button2.Text;
            button7.Enabled = true;
            button7.BackColor = Color.Red;
            button7.ForeColor = Color.White;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = button3.Text;
            value = button3.Text;
            button7.Enabled = true;
            button7.BackColor = Color.Red;
            button7.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = button4.Text;
            value = button4.Text;
            button7.Enabled = true;
            button7.BackColor = Color.Red;
            button7.ForeColor = Color.White;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = button5.Text;
            value = button5.Text;
            button7.Enabled = true;
            button7.BackColor = Color.Red;
            button7.ForeColor = Color.White;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = button6.Text;
            value = button6.Text;
            button7.Enabled = true;
            button7.BackColor = Color.Red;
            button7.ForeColor = Color.White;

        }

        private void taste_Q_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Q";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text+"q";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_W_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "W";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "w";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_E_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "E";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "e";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_R_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "R";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "r";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_T_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "T";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "t";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_Z_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Z";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "z";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_U_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "U";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "u";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_I_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "I";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "i";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_O_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "O";
            }
            else
            {
             
               ziel_txtbox.Text = ziel_txtbox.Text + "o";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_P_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "P";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "p";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_Ü_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Ü";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "ü";
                checkup();
                btnbefuellen();
            }
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Auswahl.Clear();
            button7.Enabled = false;
            button7.BackColor = Color.DarkGray;
            try
            {
                if(ziel_txtbox.Text==" ")
                {
                    ziel_txtbox.Text = Strings.Mid(ziel_txtbox.Text, 1, Strings.Len(ziel_txtbox.Text) - 1 + 1);
                }
                else
                {
                    ziel_txtbox.Text = Strings.Mid(ziel_txtbox.Text, 1, Strings.Len(ziel_txtbox.Text) - 1 );
                }
            }catch(Exception ERR)
            {

            }
           
        }

        private void taste_A_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..."||ziel_txtbox.Text=="")
            {
                ziel_txtbox.Text = "A";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "a";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_S_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "S";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "s";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_D_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "D";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "d";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_F_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "F";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "f";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_G_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "G";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "g";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_H_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "H";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "h";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_J_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "J";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "j";
                checkup();
                btnbefuellen();
            }
           
        }

        private void taste_Leerzeichen_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = ziel_txtbox.Text + " ";
        }

        private void L_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text ==  "")
            {
                ziel_txtbox.Text = "L";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "l";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_Ö_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Ö";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "ö";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_Ä_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Ä";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "ä";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_Y_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "Y";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "y";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_X_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "X";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "x";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_C_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "C";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "c";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_V_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "V";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "v";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_B_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "B";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "b";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_N_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "N";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "n";
                checkup();
                btnbefuellen();
            }
            
        }

        private void taste_M_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "M";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "m";
                checkup();
                btnbefuellen();
            }
           
        }

        private void tasteminus_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = ziel_txtbox.Text + "-";
        }

        private void taste_ß_Click(object sender, EventArgs e)
        {
            ziel_txtbox.Text = ziel_txtbox.Text + "ß";
            checkup();
            btnbefuellen();

        }

        private void taste_K_Click(object sender, EventArgs e)
        {
            if (ziel_txtbox.Text == "..." || ziel_txtbox.Text == "")
            {
                ziel_txtbox.Text = "K";
            }
            else
            {
                ziel_txtbox.Text = ziel_txtbox.Text + "k";
                checkup();
                btnbefuellen();
            }
           
        }

        private void befuellen()
        {
            Haltestellen.Add("Köln Hbf");
            Haltestellen.Add("Deutz (Köln)");
            Haltestellen.Add("Köln Trimbornstr");
            Haltestellen.Add("Köln Frankfurterstr");
            Haltestellen.Add("Rösrath-Stümpen");
            Haltestellen.Add("Rösrath");
            Haltestellen.Add("Hoffnungsthal");
            Haltestellen.Add("Honrath");
            Haltestellen.Add("Overath");
            Haltestellen.Add("Engelskirchen");
            Haltestellen.Add("Ründerroth");
            Haltestellen.Add("Gummersbach-Dieringhausen");
            Haltestellen.Add("Gummersbach");
            Haltestellen.Add("Marienheide");
            Haltestellen.Add("Meinerzhagen");
            Haltestellen.Add("Kierspe");
            Haltestellen.Add("Halver-Oberbrügge");
            Haltestellen.Add("Lüdenscheid-Brügge");
        }
        private void checkup()
        {
           
            foreach (string x in Haltestellen)
            {
                if (x.Contains(ziel_txtbox.Text))
                {
                    Auswahl.Add(x);
                }
               
            }
        }
        private void btnbefuellen()
        {
            for(int i=0; i < Auswahl.Count; i++)
            {
                if (Auswahl[i] != null)
                {
                    if (i >= 0)
                    {
                        button2.Enabled = true;
                        button2.Text = Auswahl[0];
                    }
                    else
                    {
                        button2.Enabled = false;
                    }
                    if (i >= 1)
                    {
                        button3.Enabled = true;
                        button3.Text = Auswahl[1];
                    }
                    else
                    {
                        button3.Enabled = false;
                    }
                    if (i >= 2)
                    {
                        button4.Enabled = true;
                        button4.Text = Auswahl[2];
                    }
                    else
                    {
                        button4.Enabled = false;
                    }
                    if (i >= 3)
                    {
                        button5.Enabled = true;
                        button5.Text = Auswahl[3];
                    }
                    else
                    {
                        button5.Enabled = false;
                    }
                    if (i >= 4)
                    {
                        button6.Enabled = true;
                        button6.Text = Auswahl[4];
                    }
                    else
                    {
                        button6.Enabled = false;
                    }
                }
            }
            /*    if (Auswahl[0] != null)
             {
                 button2.Text =Auswahl[0];

                 if (Auswahl[1] != null)
                 {
                     button3.Text = Auswahl[1];

                     if (Auswahl[2] != null)
                     {
                         button4.Text = Auswahl[2];

                         if (Auswahl[3] != null)
                         {
                             button5.Text = Auswahl[3];

                             if (Auswahl[4] != null)
                             {
                                 button6.Text = Auswahl[4];
                             }
                         }
                     }
                 }
             }*/
        }
    }
}
