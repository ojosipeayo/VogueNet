using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace VogueForex
{
    public class Program
           
    {
        
        //supply the key
        private const string Key ="your_secret_key";
       
        
        public static void Main(string[] args)
        {
              StringBuilder builder = new StringBuilder();
                builder.Append("https://voguepay.com/?p=currency_api").Append("&secure_key=").Append(Key).Append("&type=json");
            
            
            HttpWebRequest req = WebRequest.Create(builder.ToString())
                       as HttpWebRequest;
            string result = null;

              using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
              {
                StreamReader reader =
                    new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
                
              }

		
            //print all
            Console.WriteLine("Total: "+result);
                    
           
            
        }
    }
}
