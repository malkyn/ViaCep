using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViaCepTeste.Data;
using ViaCepTeste.Data.DTOs;
using ViaCepTeste.Models;
using ViaCepTeste.Services;

namespace ViaCepTeste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public LoginController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user = _context.Get(user.Usuario, user.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            var token = await TokenService.GenerateToken(user);
            user.Senha = "";
            user.Token = token;

            return Ok(new
            {
                usuario = user.Usuario,
                tokenDeAcesso = token
            });
        }
    }
}
