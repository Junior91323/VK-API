using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKApi.Interfaces;
using VKApi.Managers;

namespace VKMusic.Models
{

    public class User : ListManager<User>, IApiList
    {
        public string uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string photo { get; set; }

        public string ApiURL { get; set; }
    }

}
