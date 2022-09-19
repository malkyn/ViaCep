using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaCepTeste.Interfaces;
using ViaCepTeste.Models;

namespace ViaCepTeste.Services
{
    public class CepCacheService : ICepCacheService
    {
        private readonly IViaCep _viaCepServices;

        public CepCacheService(IViaCep services)
        {
            _viaCepServices = services;
        }
        public async Task<CepResult> SetCache(string key, IMemoryCache cache, CepModel cep, List<CepResult> ceps)
        {
            ceps = await InsertCepIntoList(cep, ceps);
            cache.Set(key, ceps, SetMemoryOptions());
            var result = ceps.FirstOrDefault(x => x.cep.Replace("-", "") == cep.Cep);
            result.Origem = "ViaCep";
            return result;
        }
        private async Task<List<CepResult>> InsertCepIntoList(CepModel cep, List<CepResult> ceps)
        {

            if (ceps != null)
            {
                ceps.Add(await _viaCepServices.GetCep(cep.Cep));
            }
            else
            {
                ceps = new List<CepResult>()
                {
                    await _viaCepServices.GetCep(cep.Cep)
                };
            }
            return ceps;
        }
        private MemoryCacheEntryOptions SetMemoryOptions(int min = 5)
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(min)
            };
        }
    }
}
