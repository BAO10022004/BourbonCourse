using Web_KhoaHoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Web_KhoaHoc.Service
{
    internal class SujectService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public SujectService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Subject>> GetAll()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "subject/all" );
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Subject>>() ?? new List<Subject>();
                return courses;
            }
            return null;
        }
       
    }
}
