using Web_KhoaHoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Web_KhoaHoc.Models;
namespace Web_KhoaHoc.Service
{
    internal class AccountCourseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public AccountCourseService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Accountcourse>> GetAccountcourseByAccount(string userrname)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"acount-course/{userrname}");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Accountcourse>>() ?? new List<Accountcourse>();
                return courses;
            }
            return null;
        }
        public async Task<List<Accountcourse>> GetAll()
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"acount-course/all");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Accountcourse>>() ?? new List<Accountcourse>();
                return courses;
            }
            return null;
        }
        public async Task<Accountcourse> GetAccountcourseyAccountById(long id)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"acount-course/id/{id}");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<Accountcourse>() ?? new Accountcourse();
                return courses;
            }
            return null;
        }
        public async Task<bool> AddAccountCourse(AccountcourseDTO accountCourse)
        {
            var response = await _httpClient.PutAsJsonAsync(_baseUrl + $"acount-course/add", accountCourse);

            return response?.IsSuccessStatusCode ?? false;
        }
        public async Task<bool> DeleteAccountCourse(int tcId)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + $"acount-course/{tcId}");
            return response?.IsSuccessStatusCode ?? false;
        }
            
    
    }
    public class AccountcourseDTO
    {
        public string username { get; set; }
        public int teacherId { get; set; }
        public int courseId { get; set; }
    }
}
