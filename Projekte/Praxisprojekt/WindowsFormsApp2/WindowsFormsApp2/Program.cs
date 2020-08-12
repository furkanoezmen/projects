using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
  
       
    
    class Program : Kommunikation
    {


        
        public string Communication()
        {
            PostReq("http://192.168.178.43:3000/");
            string temp = GetReq("http://192.168.178.43:3000/").Result;
            return temp;
        }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Program pro = new Program();
            
            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(pro.Communication()));
        }

        
        
    }
}
