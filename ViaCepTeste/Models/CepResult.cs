using System;
using System.Collections.Generic;

namespace ViaCepTeste.Models
{
    public class CepResult
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public int ibge { get; set; }
        public int gia { get; set; }
        public int ddd { get; set; }
        public int siafi { get; set; }
        public string Origem { get; set; }
    }
}
