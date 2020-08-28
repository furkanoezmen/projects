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
    public partial class msgbx : Form
    {
        public int i = 0;
        public msgbx()
        {
            

            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form0 form0 = new Form0();
            Form1 form1 = new Form1(null);
            Form2 form2 = new Form2(null,null,null);
            i ++;
           // label2.Text = i.ToString();
            if (i == 50)
            {
                form0.Show();
                form1.Close();
                form2.Close();
                this.Close();
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form0 form0 = new Form0();
            Form1 form1 = new Form1(null);
            Form2 form2 = new Form2(null, null, null);
            form0.Show();
            form1.Close();
            form2.Close();
            this.Close();
        }

        
    }
}
