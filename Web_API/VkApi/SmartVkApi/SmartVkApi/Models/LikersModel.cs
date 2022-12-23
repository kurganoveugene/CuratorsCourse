using System.Collections.Generic;

namespace SmartVkApi.Models
{
    public class LikersModel
    {
       public LikersResponce response { get; set; }

       public IList<string> GetItems() => response.items;
    }
}
