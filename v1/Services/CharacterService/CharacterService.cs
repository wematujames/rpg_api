
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static Character knight = new Character();
        private readonly IMapper _mapper;
        
        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character {Id = 1, Name = "Sam" },
            new Character {Id = 2, Name = "Doe"},
        };

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetCharacters ()
        {
            var serviceRes = new ServiceResponse<List<GetCharacterDTO>>();
            
            serviceRes.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceRes; 
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacter(int id)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            var character = characters.FirstOrDefault(c => c.Id == id);
            
            serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);

            if (character != null) {
                return serviceRes;
            }

            serviceRes.Message = "No character found!";
            serviceRes.Success = false;

            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> CreateCharacter(CreateCharacterDTO newCharacter)
        {
            var serviceRes =  new ServiceResponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;

            characters.Add(character);

            serviceRes.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            return serviceRes;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharater)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharater.Id) ?? throw new Exception("Character not found");
                character.Name = updatedCharater.Name;
                character.HitPoints = updatedCharater.HitPoints;
                character.Strength = updatedCharater.Strength;
                character.Defense = updatedCharater.Defense;
                character.Intelligence = updatedCharater.Intelligence;
                character.Class = updatedCharater.Class;
    
                serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);
    
                return serviceRes;
            }
            catch (Exception ex)
            {
                serviceRes.Success = false;
                serviceRes.Message = ex.Message ?? "An error occured";
                return serviceRes;
            }
        }

        public async Task<ServiceResponse<GetCharacterDTO>> DeleteCharacter(int id)
        {
            var serviceRes = new ServiceResponse<GetCharacterDTO>();

            try
            {
                var character = characters.First(c => c.Id == id);
                
                characters.Remove(character);
                
                serviceRes.Data = _mapper.Map<GetCharacterDTO>(character);
    
                return serviceRes;
            }
            catch (Exception ex)
            {
                serviceRes.Success = false;
                serviceRes.Message = ex.Message ?? "An error occured";
                return serviceRes;
            }
        }
    }
}