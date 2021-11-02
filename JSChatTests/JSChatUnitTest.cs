using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JSChat.Controllers;
using JSChatModel.ViewModels;
using System.Web.Mvc;

namespace JSChatTests
{
    [TestClass]
    public class JSChatUnitTest
    {
        [TestMethod]
        public void CreateMethodTest()
        {
            HomeController homeController = new HomeController();
            ActionResult actionResult = homeController.Create(new CreateMessageViewModel
            {
                Message = "Test Message",
                UserId = new Guid().ToString(),
                UserName = "TestUser"
            });
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void GetStockInfoTest()
        {
            string stock_code = "aapl.us";

            JSChatServices.BotServices BotServicesTest = new JSChatServices.BotServices();

            StockModel stockModel = BotServicesTest.GetStockInfo(stock_code);

            Assert.IsNotNull(stockModel); 

        }
    }
}
