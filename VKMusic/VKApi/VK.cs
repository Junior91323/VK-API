using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VKMusic.Models;

namespace VKApi
{
    public static class VK
    {
        public static string AccessToken { get; set; }
        public static string UserId { get; set; }

        static string VkRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseText = reader.ReadToEnd();
            return responseText;
        }

        public static List<object> GetList(Type T)
        {
            try
            {
                string str = string.Format("https://api.vk.com/method/audio.get?uid={0}&access_token={1}", UserId, AccessToken);

                var responseText = VkRequest(str);
                
                var response = JsonConvert.DeserializeObject<VKResponse<>> (responseText);

                var album = JsonConvert.DeserializeObject<VkAlbum>(responseText);
                AllComposition = album.response;
                albumCompositions.ItemsSource = album.response;
                Title = String.Format("Музыка пользователя: <{0} {1}> загружена", users.response[0].first_name,
                    users.response[0].last_name);

            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
