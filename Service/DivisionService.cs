using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Web_KhoaHoc.Models;
using System.Text.Json;

namespace Web_KhoaHoc.Service
{
    public class DivisionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api-coursemanager-1.onrender.com/api/";

        public DivisionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Division>> GetByClass(int classId)
        {
            try
            {
                string url = $"{_baseUrl}division/getDivisions/{classId}";

                // Ensure proper URL formatting
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                // Log the request URL for debugging
                Console.WriteLine($"Requesting: {url}");

                var response = await _httpClient.GetAsync(url);

                // Log response status
                Console.WriteLine($"Response status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"API returned error status: {response.StatusCode}");
                    return new List<Division>();
                }

                // Read the response content as string first for debugging
                var responseContent = await response.Content.ReadAsStringAsync();

                // Log the raw response content
                Console.WriteLine($"Response content: {responseContent}");

                if (string.IsNullOrEmpty(responseContent))
                {
                    Console.WriteLine("API returned empty content");
                    return new List<Division>();
                }

                // Try to manually deserialize the JSON string
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var divisions = JsonSerializer.Deserialize<List<Division>>(responseContent, options);
                return divisions ?? new List<Division>();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception in GetByClass: {ex}");

                // For more detailed nested exceptions
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner exception: {innerException}");
                    innerException = innerException.InnerException;
                }

                return new List<Division>();
            }
        }
    }
}