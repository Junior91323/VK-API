using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKMusic.Models
{
    public class VKResponse<T>
    {
        public T[] response { get; set; }
    }
}
