namespace Rest_API.Utils
{
    public class Client
    {
        private static RestClient? RestClient;

        public static RestClient GetRestClient(Uri url)
        {
            if (RestClient == null)
                RestClient = new RestClient(url);
            return RestClient;
        }
    }
}
