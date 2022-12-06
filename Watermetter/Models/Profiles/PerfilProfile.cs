using AutoMapper;

namespace Watermetter.Models.Profiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Perfil, Perfil>();
        }
    }
}
