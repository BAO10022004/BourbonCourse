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
    internal class TeacherCourseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public TeacherCourseService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<TeacherCourse> GetTeacherCourse(int teacherId, int courseId)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"teacher_course/{teacherId}/{courseId}");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<TeacherCourse>() ?? new TeacherCourse();
                return courses;
            }
            return null;
        }
        public async Task<List<TeacherCourse>> GetAll()
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"teacher_course/all");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<TeacherCourse>>() ?? new List<TeacherCourse>();
                return courses;
            }
            return null;
        }
        internal async Task<List<Teacher>> GetTeachers(int value)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"teacher_course/get_teacher_course/{value}");
            if (response.IsSuccessStatusCode)
            {
                var courses = await response.Content.ReadFromJsonAsync<List<Teacher>>() ?? new List<Teacher>();
                return courses;
            }
            return null;
        }
    }
}
