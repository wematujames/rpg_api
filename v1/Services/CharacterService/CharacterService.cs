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

        public async Task<List<Character>> GetCharacters ()
        {
            return characters;
        }

        public async Task<Character> GetCharacter(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            
            if (character != null) return character;
            
            throw new Exception("Character not found");
        }

        public async Task<List<Character>> CreateCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

    }
}