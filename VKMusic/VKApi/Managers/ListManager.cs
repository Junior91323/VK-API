using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VKApi.Interfaces;
using VKApi.Managers;
using VKMusic.Models;

namespace VKApi.Managers
{
    public class ListManager<T> : ItemManager<T> where T : class, IApiList
    {
        public static T[] GetList(string url)
        {
            try
            {
                string responseText = VkRequest(url);

                if (!String.IsNullOrEmpty(responseText))
                {
                    var response = JsonConvert.DeserializeObject<VKResponse<T>>(responseText);
                    if (response != null)
                        return response.response;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection error!");
            }
        }



    }
}
