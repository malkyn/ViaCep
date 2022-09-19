using System;
using System.ComponentModel.DataAnnotations;

namespace ViaCepTeste.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
