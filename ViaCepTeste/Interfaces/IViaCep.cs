using System.Collections.Generic;
using System.Threading.Tasks;
using ViaCepTeste.Models;

namespace ViaCepTeste.Interfaces
{
    public interface IViaCep
    {
        Task<CepResult> GetCep(string cep);
    }
}
