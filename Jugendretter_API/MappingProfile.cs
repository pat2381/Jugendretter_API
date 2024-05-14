using AutoMapper;
using Jugendretter_API.Entities;
using Jugendretter_API.Entities.DTO;

namespace Jugendretter_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserDto>();

        }

    }
}
