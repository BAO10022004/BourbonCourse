namespace Web_KhoaHoc.Service
{
    public class AbstractService
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public AbstractService()
        {
            _httpClient = new HttpClient();
        }
    }
}
