using JSChatModel; 
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System;
using JSChatServices;
using System.Net;
using JSChatModel.ViewModels;

namespace JSChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.USERID = User.Identity.GetUserId();
            return View(new MessageServices().GetMessages());
        }

        public ActionResult CreateMessage()
        {
            return PartialView(new CreateMessageViewModel
            {
                UserName = User.Identity.Name,
                UserId = User.Identity.GetUserId(),
                Message = string.Empty
            });
        } 
      

        #region Actions        
        public ActionResult Create(CreateMessageViewModel model)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The Message could not be created");

            try
            {
                new MessageServices().Add(new tMessage
                {
                    MDate = DateTime.Now,
                    Message = model.Message,
                    UserId = model.UserId,
                    UserName = model.UserName
                });
            }
            catch (System.Exception exeption)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, exeption.Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }


        #endregion
    }
}