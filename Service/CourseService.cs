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
    internal class CourseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public CourseService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Course>> GetCourses()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "course/all");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Course>>() ?? new List<Course>();
                return courses;
            }
            return null;
        }
        public async Task<bool> AddCourse(String name )
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + $"course/add/{name}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> DeleteCourse(int id)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.DeleteAsync(_baseUrl + $"course/{id}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra: {ex.Message}");
                return false;
            }
        }
    }
}
