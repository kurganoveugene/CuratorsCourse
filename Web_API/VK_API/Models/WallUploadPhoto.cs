using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Models
{
    internal class WallUploadPhoto
    {
        public Response Response { get; set; }
    }

    public partial class Response
    {
        public string Upload_Url { get; set; }
        public int Album_id { get; set; }
        public int User_Id { get; set; }
    }
}

