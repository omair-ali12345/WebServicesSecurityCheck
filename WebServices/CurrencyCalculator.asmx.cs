using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for CurrencyConverter
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CurrencyConverter : System.Web.Services.WebService
    {
       
        [WebMethod]
        public double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            string url = $"https://open.er-api.com/v6/latest/{fromCurrency}";
            var client = new WebClient();
            var response = client.DownloadString(url);
            JObject json = JObject.Parse(response);

            double rate = (double)json["rates"][toCurrency];
            return amount * rate;
        }
    }
}

  

