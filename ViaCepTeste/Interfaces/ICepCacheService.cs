using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViaCepTeste.Models;

namespace ViaCepTeste.Interfaces
{
    public interface ICepCacheService
    {
        public Task<CepResult> SetCache(string key, IMemoryCache cache, CepModel cep, List<CepResult> ceps);
    }
}
