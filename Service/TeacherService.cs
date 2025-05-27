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
    internal class TeacherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public TeacherService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Teacher>> GetTeacherByCourse(int courseId)
        {
            var response = await _httpClient.GetAsync(_baseUrl + "teacher_course/get_teacher_course/" + courseId);
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Teacher>>() ?? new List<Teacher>();
                return courses;
            }
            return null;
        }
        public async Task<List<Teacher>> GetTeachers()
        {
            var response = await _httpClient.GetAsync(_baseUrl + "teacher/all");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Teacher>>() ?? new List<Teacher>();
                return courses;
            }
            return null;
        }
    }
}
