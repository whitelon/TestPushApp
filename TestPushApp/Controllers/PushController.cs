using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using TestPushApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPushApp.Controllers
{
    [Route("api/[controller]")]
    public class PushController : Controller
    {
        /// <summary>
        /// Send notification via pushover
        /// </summary>
        /// <param name="notification">Notification parameters: App API token, user key, message</param>
        /// <returns>Returns response from pushover</returns>
        [HttpPost]
        public IActionResult Post([FromBody]Notification notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }

            using (var client = new HttpClient())
            {
                // creating request to send pushover notification
                var requestParameters = new Dictionary<string, string>
                {
                    ["token"] = notification.ApiToken,
                    ["user"] = notification.UserKey,
                    ["message"] = notification.Message
                };
                var content = new FormUrlEncodedContent(requestParameters);

                // sending request to pushover and returning response from it
                var response = client.PostAsync("https://api.pushover.net/1/messages.json", content).Result;
                string responseContent = response.Content.ReadAsStringAsync().Result;

                return base.StatusCode((int)response.StatusCode, responseContent);

            }

        }

    }
}
