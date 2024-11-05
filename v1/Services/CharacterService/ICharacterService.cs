using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnet_rpg.v1.Services.CharacterService
{
    public interface ICharacterService
    {
       List<Character> GetCharacters ();
       Character GetCharacter (int id);

       List<Character> CreateCharater (Character newCharater); 
    }
}