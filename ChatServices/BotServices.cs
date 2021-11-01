using JSChatModel.ViewModels;
using System;
using System.Globalization;
using System.Net.Http;

namespace JSChatServices
{
    public class BotServices
    {
        public BotServices()
        {            
        }
        public StockModel GetStockInfo(string stock_code)
        {
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = client.GetAsync($"https://stooq.com/q/l/?s={stock_code}&f=sd2t2ohlcv&h&e=csv").Result)
            using (HttpContent content = response.Content)
            {
                string serviceResponse = content.ReadAsStringAsync().Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return new StockModel();

                var dataArray = serviceResponse.Substring(serviceResponse.IndexOf(Environment.NewLine, StringComparison.Ordinal) + 2).Split(',');
                
                return new StockModel
                {
                    Symbol = dataArray[0],
                    Date = dataArray[1].Contains("N/D") ? default :  DateTime.Parse(dataArray[1]),
                    Time = dataArray[2].Contains("N/D") ? default : DateTime.Parse(dataArray[2]).TimeOfDay,
                    Open = dataArray[3].Contains("N/D") ? default : decimal.Parse(dataArray[3], CultureInfo.InvariantCulture),
                    High = dataArray[4].Contains("N/D") ? default : decimal.Parse(dataArray[4], CultureInfo.InvariantCulture),
                    Low = dataArray[5].Contains("N/D") ? default : decimal.Parse(dataArray[5], CultureInfo.InvariantCulture),
                    Close = dataArray[6].Contains("N/D") ? default : decimal.Parse(dataArray[6], CultureInfo.InvariantCulture),
                    Volume = dataArray[7].Contains("N/D") ? default : decimal.Parse(dataArray[7], CultureInfo.InvariantCulture)
                };
            }
        } 
    }
}
