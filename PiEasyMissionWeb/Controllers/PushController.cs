//using Newtonsoft.Json.Linq;
//using PiEasyMission.Domain.Entities;
//using PushBots.NET;
//using PushBots.NET.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;


//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace PiEasyMissionWeb.Controllers
//{
//    public class PushController 
//    {
//        private readonly PushBotsClient _pushBotsClient;
//        private const string AppId = "xxx"; // Use your Application ID found in the PushBots Dashboard
//        private const string Secret = "xxx"; // Use your Secret Key found in the PushBots Dashboard

//        public PushController()
//        {
//            _pushBotsClient = new PushBotsClient(AppId, Secret);
//        }

//        [HttpPost]
//        public async Task<HttpResponseMessage> Post(string alias, string message)
//        {
//            try
//            {
//                var device = await _pushBotsClient.GetDeviceByAlias(alias);

//                if (device != null)
//                {
//                    var pushMessage = new SinglePush
//                    {
//                        Platform = device.Platform,
//                        Token = device.Token,
//                        Message = message,
//                        Sound = "",
//                        Badge = "+1",
//                        Payload = new JObject()
//                    };

//                    var result = await _pushBotsClient.Push(pushMessage);

//                    if (result.IsSuccessStatusCode)
//                    {
//                        return Request.CreateResponce(HttpStatusCode.OK, result.ReasonPhrase);
                      
//                    }

//                    return Request.CreateErrorResponse(result.StatusCode, result.Content.ReadAsAsync<JObject>().Result.ToString());
//                }

//                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't find device with alias: " + alias);
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
//            }
//        }

//        // GET: Push
//        public ActionResult Index()
//        {
//            return View();
//        }
//    }
//}