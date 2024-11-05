using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static Character knight = new Character();
        
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character {Id = 1, Name = "Sam" },
            new Character {Id = 2, Name = "Doe"},
        };

        public async Task<ServiceResponse<List<Character>>> GetCharacters ()
        {
            var serviceRes = new ServiceResponse<List<Character>>();
            
            serviceRes.Data = characters;

            return serviceRes; 
        }

        public async Task<ServiceResponse<Character>> GetCharacter(int id)
        {
            var serviceRes = new ServiceResponse<Character>();

            var character = characters.FirstOrDefault(c => c.Id == id);
            
            serviceRes.Data = character;

            if (character != null) {
                return serviceRes;
            }

            serviceRes.Message = "No character found!";
            serviceRes.Success = false;

            return serviceRes;
        }

        public async Task<ServiceResponse<List<Character>>> CreateCharacter(Character newCharacter)
        {

            var serviceRes =  new ServiceResponse<List<Character>>();

            characters.Add(newCharacter);

            serviceRes.Data = characters;

            return serviceRes;
        }

    }
}