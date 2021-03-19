using AutoMapper;
using RealManager.Domain;
using RealManager.Domain.Enums;
using RealManager.Repositories.Models;

namespace RealManager.Repositories.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDb>()
                .ForMember(src => src.Position, opt => opt.MapFrom(dest => (int)dest.Position));

            CreateMap<PlayerDb, Player>()
                .ForMember(src => src.Position, opt => opt.MapFrom(dest => (Position)dest.Position));
        }
    }
}
