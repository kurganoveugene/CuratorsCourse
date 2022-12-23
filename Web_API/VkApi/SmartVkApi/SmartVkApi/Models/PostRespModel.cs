namespace SmartVkApi.Models
{
    public class PostRespModel
    {
       public PostResponse response { get; set; }
       public int GetPostId() => response.post_id;
    }
}
