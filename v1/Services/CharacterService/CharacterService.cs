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
        private readonly ICharacterService _characterService;

        public CharacterService(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        public List<Character> GetCharacters ()
        {
            return characters;
        }

        public Character GetCharacter(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public List<Character> CreateCharater(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

    }
}