using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ViaCepTeste.Data;
using ViaCepTeste.Interfaces;
using ViaCepTeste.Models;

namespace ViaCepTeste.Services
{
    public class ViaCepServices : IViaCep
    {
        //private readonly ICepConfig _config;
        private readonly HttpClient _httpClient;
        readonly string baseUrl = Environment.GetEnvironmentVariable("BASEURL");

        public ViaCepServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResult> GetCep(string cep)
        {
             return await _httpClient.GetFromJsonAsync<CepResult>($"{baseUrl}ws/{cep}/json/");
        }
    }
}
