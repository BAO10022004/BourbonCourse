using System.Net.Http.Json;
using Web_KhoaHoc.Models;

namespace Web_KhoaHoc.Service
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public AuthService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> Login(string username, string password)
        {
            LoginDTO loginDTO = new LoginDTO();
            loginDTO.email = username;
            loginDTO.password = password;

            var accounts = await new AccountService().GetAllAccounts();

            if (accounts != null)
            {
               var acc =  accounts.FirstOrDefault(x => (x.email ?? x.username) == (loginDTO.email));
                if (acc != null)
                {
                    if(acc.password == loginDTO.password)
                        return true;
                }
            }
            
           
            return false;
        }

    }
    class LoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
    }

}
