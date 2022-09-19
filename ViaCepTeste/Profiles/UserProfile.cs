using AutoMapper;
using ViaCepTeste.Data.DTOs;
using ViaCepTeste.Models;

namespace ViaCepTeste.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginUserDto, User>();
        }
    }
}
