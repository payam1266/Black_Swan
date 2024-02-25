
using System.Net.Http;

namespace Black_Swan.MVC.Services.Base
{
    public partial class Client :IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

      
    }
}
