using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Web_KhoaHoc.Models;

namespace Web_KhoaHoc.Service
{
    public class LessonService : AbstractService
    {
        public LessonService() : base()
        {
        }

        public async Task<List<Lesson>> GetByClass(int divisionId)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"lesson/getAllByDivision/{divisionId}");
            if (response.IsSuccessStatusCode)
            {
                var lessons = await response.Content.ReadFromJsonAsync<List<Lesson>>() ?? new List<Lesson>();
                return lessons;
            }
            return new List<Lesson>();
        }
        public async Task<List<Lesson>> GetAllLesson()
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"lesson/all");
            if (response.IsSuccessStatusCode)
            {
                var lessons = await response.Content.ReadFromJsonAsync<List<Lesson>>() ?? new List<Lesson>();
                return lessons;
            }
            return new List<Lesson>();
        }
        public async Task<List<SubLesson>> GetSublessonByLesson(int lessonId)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"sublesson/getAllByLesson/{lessonId}");
            if (response.IsSuccessStatusCode)
            {
                var subLessons = await response.Content.ReadFromJsonAsync<List<SubLesson>>() ?? new List<SubLesson>();
                return subLessons;
            }
            return new List<SubLesson>();
        }
        public async Task<List<SubLesson>> GetAllAllSublesson()
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"sublesson/all");
            if (response.IsSuccessStatusCode)
            {
                var subLessons = await response.Content.ReadFromJsonAsync<List<SubLesson>>() ?? new List<SubLesson>();
                return subLessons;
            }
            return new List<SubLesson>();
        }
        public async Task<List<SubLessonLink>> GetSublessonBySubLesson(int slId)
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"sublesson-links/by-sublesson/{slId}");
            if (response.IsSuccessStatusCode)
            {
                var subLessonLinks = await response.Content.ReadFromJsonAsync<List<SubLessonLink>>() ?? new List<SubLessonLink>();
                return subLessonLinks;
            }
            return new List<SubLessonLink>();
        }
        public async Task<List<SubLessonLink>> GetSubLessonLinks()
        {
            var response = await _httpClient.GetAsync(_baseUrl + $"sublesson-links/all");
            if (response.IsSuccessStatusCode)
            {
                var subLessonLinks = await response.Content.ReadFromJsonAsync<List<SubLessonLink>>() ?? new List<SubLessonLink>();
                return subLessonLinks;
            }
            return new List<SubLessonLink>();
        }
    }
}