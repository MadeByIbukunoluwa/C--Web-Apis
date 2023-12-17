using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Rpg_Api 
{
    public class AutoMapperProfile: Profile {
        public AutoMapperProfile()
        {
            // map a character object into a GetCharacterDto
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}

