using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Kommunikation
    {

        
        public async static void PostReq(string url)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("ziel","koelnhbf"),
                new KeyValuePair<string, string>("start","gummersbachdieringhausen"),
                new KeyValuePair<string, string>("ticketart","einzelticket1")
            };
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(mycontent);
                    }
                }
            }
        }
        public static async Task<string> GetReq(string url)
        {
            string appr_url = null;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        appr_url = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        // Console.WriteLine(appr_url);
                    }
                }
            }
            return appr_url;
        }
    }
    
}
