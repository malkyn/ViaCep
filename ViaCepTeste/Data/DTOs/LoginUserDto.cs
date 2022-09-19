using System.ComponentModel.DataAnnotations;

namespace ViaCepTeste.Data.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
