using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API.Models
{
    internal class WallFileParameters
    {
        public List<Response> Response { get; set; }
    }

    public partial class Response
    {
        public long Album_Id { get; set; }
        public long Date { get; set; }
        public long Id { get; set; }
        public long Owner_Id { get; set; }
        public string Access_Key { get; set; }
        public List<Size> Sizes { get; set; }
        public string Text { get; set; }
        public bool HasTags { get; set; }
    }

    public partial class Size
    {
        public long Height { get; set; }
        public Uri Url { get; set; }
        public string Type { get; set; }
        public long Width { get; set; }
    }
}
