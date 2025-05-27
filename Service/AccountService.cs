using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using Web_KhoaHoc.Models;
using System.Security.Principal;

namespace Web_KhoaHoc.Service
{
    internal class AccountService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public AccountService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + "accounts/all");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(jsonResponse,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return accounts;
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> CreateAccountAsync(Account account)
        {
            try
            {
                var req = new AccountDTO() { username = account.username, password = account.password};

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_baseUrl + "accounts/create", req);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
                return false;
            }
        }
        public async Task<Account> GetAccountByEmail(string email)
        {
            var response = await _httpClient.GetAsync(_baseUrl + "accounts/" +email);
            if (response.IsSuccessStatusCode)
            {
                var acc = await response.Content.ReadFromJsonAsync<Account>() ?? new Account();
                return acc;
            }
            return null;
        }
        public async Task<bool> deleteAccount(string username)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.DeleteAsync(_baseUrl + "accounts/"+ username);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
                return false;
            }
        }
    }
    public class AccountDTO{
       public  string username { get; set; }
        public string password { get; set; }
    }


}
