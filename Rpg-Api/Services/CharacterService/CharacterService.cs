using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Rpg_Api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1 , Name = "Sam"}
        };

        private readonly IMapper _mapper;
        public CharacterService (IMapper mapper) {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters ()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>
            {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {   
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try {

                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character == null) throw new Exception($"Character with Id `{updatedCharacter.Id}` not found");
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Hitpoints = updatedCharacter.Hitpoints;
                character.Name = updatedCharacter.Name;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

                return serviceResponse;
            } catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}


// when my applciation launches i get localhost not found on the root locahost, but when i add the swagger route i get redirected , okay , then lets make the swagger route the root route, abi?

// it doesnt happen when i use dotnet watch run sha 


