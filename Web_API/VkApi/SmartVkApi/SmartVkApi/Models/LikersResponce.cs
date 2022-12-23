using System.Collections.Generic;

namespace SmartVkApi.Models
{
    public class LikersResponce
    {
       public int count { get; set; }
       
       public IList<string> items { get; set; }
    }
}
