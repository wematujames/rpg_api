using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<CreateCharacterDTO, Character>();
        }
    }
}