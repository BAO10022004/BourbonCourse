using Web_KhoaHoc.Models;

namespace Web_KhoaHoc.Service
{
    public class ClassService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";
        public ClassService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Class>> GetByTeacherCourse(int tcId)
        {
            TeacherCourse tc =( await new TeacherCourseService().GetAll() ).FirstOrDefault(x=> x.id == tcId) ?? new TeacherCourse();
            var response = await _httpClient.GetAsync(_baseUrl + $"class/get_class/{tc.teacher.id}/{tc.course.id}");
            if (response.IsSuccessStatusCode)
            {
                var classes = await response.Content.ReadFromJsonAsync<List<Class>>() ?? new List<Class>();
                return classes;
            }
            return null;
        }
    }
}
