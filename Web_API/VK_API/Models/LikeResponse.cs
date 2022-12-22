using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Models
{
    internal class LikeResponse
    {
        public Response Response { get; set; }
    }

    public partial class Response
    {
        public int Liked { get; set; }
        public int Copied { get; set; }
    }
}
