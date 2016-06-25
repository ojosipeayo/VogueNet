using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net;
using RestSharp;



namespace VogueWithdraw
{
    class Program
    {
        private const string task = "withdraw";

	      //Replace with your unique command api token
        private const string command_api_token = "D3Kc4vMatqQ7pQtU39D22j35aKqy8";
	
	      //your registered email on voguepay
        private const string merchant_email_on_voguepay = "abc@wyz.com";

        private string HashData(string unhashed)
        {
            return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(unhashed))).Replace("-", String.Empty).ToUpper();
        }

        static void Main(string[] args)
        {
           
            Random rnd = new Random();
            string refl = DateTime.Now + rnd.Next(1, 9999999).ToString();
            string hdata = command_api_token + task + merchant_email_on_voguepay + refl ;

            string hash = HashData(hdata);

            //load all fields as json and serialize
            var keyValues = new Dictionary<string, string>
               {
                    { "task", "withdraw"},
                    { "merchant", "1234-4567"},
                    { "ref",refl},
                    { "hash",hash},
                    { "remarks", "custom memo"},
                    { "bank_name", "my bank plc"},
                    { "bank_acct_name", "my acct name"},
                    { "bank_acct_no", "01891818998"},
                    { "amount", "1000"}
               };

            //serialization using Newtonsoft JSON 
           string json = JsonConvert.SerializeObject(keyValues);
           
            //url encode the json
            var postString = WebUtility.UrlEncode(json);
          
	          //calling API with Restsharp
            var client = new RestClient("https://voguepay.com/api/");
            var request = new RestRequest(Method.POST);
            request.AddParameter("json", json);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
            Console.ReadKey();


        }
    }
}
