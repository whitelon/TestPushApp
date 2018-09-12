using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPushApp.Models
{
    public class Notification
    {

        public Notification(string apiToken, string userKey, string message)
        {
            ApiToken = apiToken;
            UserKey = userKey;
            Message = message;
        }

        /// <summary>
        /// App API Token for pushover notifications
        /// </summary>
        public string ApiToken { get; set; }

        /// <summary>
        /// User Key to send pushover notifications to concrete user
        /// </summary>
        public string UserKey { get; set; }

        /// <summary>
        /// Message to send in pushover notification
        /// </summary>
        public string Message { get; set; }

    }
}
