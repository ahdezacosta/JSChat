using JSChatModel.ViewModels;
using JSChatServices;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace JSChat
{
    public class ChatHub : Hub
    { 
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.Notifify(name, message);

            string code = message.ToLower().Contains("/stock=") ? message.Split('=')[1] : string.Empty;
            if (!String.IsNullOrEmpty(code))
            {
                StockModel stockModel = new BotServices().GetStockInfo(code);

                message =  stockModel !=null ? $"<strong>{stockModel.Symbol}</strong> quote is <strong>${stockModel.Close.ToString("0.##")}</strong> per share" : "Ooops! something went wrong!";

                Clients.All.Notifify(name, message); 
            }
        }
    }
}