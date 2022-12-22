using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Models
{
    public partial class WallPostResponse
    {
        public Response Response { get; set; }
    }

    public partial class Response
    {
        public string Post_Id { get; set; }
    }
}
