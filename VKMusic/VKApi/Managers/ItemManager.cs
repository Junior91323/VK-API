using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VKApi.Interfaces;
using VKMusic.Models;

namespace VKApi.Managers
{
    public class ItemManager<T> where T : class, IApiItem
    {
        public static T GetItem(string url)
        {
            try
            {
                string responseText = VkRequest(url);

                if (!String.IsNullOrEmpty(responseText))
                {
                    var response = JsonConvert.DeserializeObject<T>(responseText);
                    return response;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection error!");
            }
        }
        protected static string VkRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();
            return responseText;
        }
    }
}
