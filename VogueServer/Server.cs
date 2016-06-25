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


namespace VogueServer
{
    public class Program
           
    {    
        //supply the voguepay url
        private const string url = "https://voguepay.com/";
        //supply merchant ID
        private const string merchant ="0000-003000";
        
        //supply the transaction memo, avoid whitespace between words
        private const string memo ="NYSC+fee+payment";
        
        
        //supply the total Amount to be charged
        private const string total ="13000";
        
        
        //supply merchant ref[optional], any value kept here can be retrieved during notification"
        private const string mref ="user-567";
        
        
        //other optional field include 'notify_url','success_url','fail_url' etc. Visit our page for explainations
        
        
        
        //sample final string..visit voguepay.com/developers for GET params explanation
        //"https://voguepay.com/?p=linkToken&v_merchant_id=9227-0032579&merchant_ref=234-567-890&memo=Bulk+order+from+McAckney+Web+Shop&total=13000"
        
        
        public static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(url).Append("?p=linkToken").Append("&v_merchant_id=").Append(merchant)
                .Append("&merchant_ref=").Append(mref).Append("&memo=").Append(memo).Append("&total=").Append(total);
            
             HttpWebRequest req = WebRequest.Create(builder.ToString())
                       as HttpWebRequest;
          string result = null;
          using (HttpWebResponse resp = req.GetResponse()
                                        as HttpWebResponse)
          {
            StreamReader reader =
                new StreamReader(resp.GetResponseStream());
            result = reader.ReadToEnd();
          }
            
           //output string which can be parse as controller action redirect or hrefs in anchor tag.
           //you may test url result on browser address bar
           
            Console.WriteLine(result);        
            
        }
    }
}

