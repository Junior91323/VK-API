using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKApi.Interfaces;
using System.Configuration;
using VKApi.Managers;

namespace VKMusic.Models
{
    public class Audio : ListManager<Audio>, IApiList
    {
        public string aid { get; set; }
        public string owner_id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string duration { get; set; }
        public string url { get; set; }

        public string ApiURL
        {
            get; set;
        }
    }

}
