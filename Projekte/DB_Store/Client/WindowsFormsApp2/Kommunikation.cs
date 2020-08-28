using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Kommunikation
    {
        public string price { get; set; }

        public void PostRequest(string url,string ticket,string ziel,string payid)
        {
            string start = "gummersbachdieringhausen";
            //string ziel = "koelnhbf";
            //string ticketart = "einzelticket1x4";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string json = "{\"id\":\"" + payid + "\"," +
                                "\"ziel\":\"" + ziel + "\"," +
                              "\"start\":\"" + start + "\"," +
                              "\"ticketart\":\"" + ticket + "\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                price = result;
            }
        }
        public async Task<string> GetResponseAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string text = await strReader.ReadToEndAsync();
            // Console.WriteLine(text);
            return text;
        }
        public async Task<string> GetReq(string url)
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
