using MatchMaking.UI.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace MatchMaking.UI.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("api/users");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<User>>(_jsonOptions) ?? new List<User>();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/users/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<User>(_jsonOptions);
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>(_jsonOptions);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/{user.Id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>?> GetRandomPairAsync()
        {
            var response = await _httpClient.GetAsync("api/users/random-pair");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<List<User>>(_jsonOptions);
        }

        public async Task<bool> VoteForUserAsync(int id)
        {
            var response = await _httpClient.PostAsync($"api/users/{id}/vote", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetRankingsAsync()
        {
            var response = await _httpClient.GetAsync("api/users/rankings");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<User>>(_jsonOptions) ?? new List<User>();
        }
    }
}
