using System.Net.Http.Json;
using mmacoachai.client.Models;

namespace mmacoachai.client.Services;

public class AthleteApiService
{
    private readonly HttpClient _http;

    public AthleteApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<AthleteResponse>> GetAthletesAsync()
    {
        var athletes = await _http.GetFromJsonAsync<List<AthleteResponse>>(
            "api/athletes");

        return athletes ?? [];
    }

    public async Task<AthleteProfileResponse?> GetAthleteProfileAsync(int id)
    {
        return await _http.GetFromJsonAsync<AthleteProfileResponse>(
            $"api/athletes/{id}/profile");
    }

    public async Task<string?> GetRecommendationsAsync(int id)
    {
        return await _http.GetStringAsync(
            $"api/athletes/{id}/recommendations");
    }
}