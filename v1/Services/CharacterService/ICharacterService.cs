using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<List<Character>> GetCharacters ();
       
       Task<Character> GetCharacter (int id);

       Task<List<Character>> CreateCharacter (Character newCharater); 
    }
}