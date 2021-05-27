using AutoMapper;
using Solution.Entities;
using Solution.ViewModel;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UsersInRoles, RoleVm>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                                             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id));

            CreateMap<User, UserVm>();
            CreateMap<UserDto, User>();
            CreateMap<ProjetDto, Projet>();
           

        }
    }
}
