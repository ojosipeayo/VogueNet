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


namespace VogueNotify
{
    public class Program
           
    {

	     
        //supply the voguepay url
        private const string url = "https://voguepay.com/";
        
        //supply the transaction ID to be fetched
        private const string trxID ="xxxxxxxxxxxx";
        
        //supply merchant ID for response validation
        private const string merchant ="XXXYX";
        
        
        public static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(url).Append("?v_transaction_id=").Append(trxID).Append("&type=json");
            
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

		
            //print all
            Console.WriteLine("Total: "+result);
                    
            //result string response may be parsed into array as below
            
            
            /*
                Now we have the following keys in our $transaction array
                
                transaction['merchant_id'],
                transaction['transaction_id'],
                transaction['email'],
                transaction['total'], 
                transaction['merchant_ref'], 
                transaction['memo'],
                transaction['status'],
                transaction['date'],
                transaction['referrer'],
                transaction['method']
                */
            
            
            
            
        }
    }
}

