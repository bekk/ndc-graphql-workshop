using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL;
using Newtonsoft.Json;

namespace GoT
{
    public class GoTData
    {
        private readonly List<Character> _characters;
        private readonly List<House> _houses;
        private readonly List<Castle> _castles;

        public GoTData()
        {
            var charactersPath = Path.Combine(Directory.GetCurrentDirectory() + "\\..\\GoT\\data\\characters.json");
            var jsonText = System.IO.File.ReadAllText(charactersPath);
            _characters = JsonConvert.DeserializeObject<CharacterWrapper>(jsonText).Characters;

            var housesPath = Path.Combine(Directory.GetCurrentDirectory() + "\\..\\GoT\\data\\houses.json");
            var jsonTextHouses = System.IO.File.ReadAllText(housesPath);
            _houses = JsonConvert.DeserializeObject<HousesWrapper>(jsonTextHouses).Houses;

            var castlePath = Path.Combine(Directory.GetCurrentDirectory() + "\\..\\GoT\\data\\castles.json");
            var jsonTextCastles = System.IO.File.ReadAllText(castlePath);
            _castles = JsonConvert.DeserializeObject<CastleWrapper>(jsonTextCastles).Castles;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _characters;
        }

        public Character GetCharacterById(string id)
        {
            return _characters.Find(x => x.Id == id);
        }

        public IEnumerable<Character> GetSiblings(Character character)
        {
            return character?.SiblingIds?.Select(GetCharacterById);
        }
    }
}