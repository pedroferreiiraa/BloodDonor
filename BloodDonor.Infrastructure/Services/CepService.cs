using System.Net.Http.Json;
using BloodDonor.Core.Entities;
using BloodDonor.Core.Interfaces;

namespace BloodDonor.Infrastructure.Services;

public class CepService : ICepService
{
    private readonly HttpClient _httpClient;

    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Address?> GetAddressByCepAsync(string cep)
    {
        var response = await _httpClient.GetFromJsonAsync<Address>($"https://viacep.com.br/ws/{cep}/json/");
        return response;
    }
}