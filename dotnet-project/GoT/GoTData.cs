using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL;
using GraphQL.Types;
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
            var charactersPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\..\\..\\data\\characters.json");
            //var JSON = System.IO.File.ReadAllText();
            var jsonText = System.IO.File.ReadAllText(charactersPath);
            _characters = JsonConvert.DeserializeObject<CharacterWrapper>(jsonText).Characters;

            var housesPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\..\\..\\data\\houses.json");
            //var JSON = System.IO.File.ReadAllText();
            var jsonTextHouses = System.IO.File.ReadAllText(housesPath);
            _houses = JsonConvert.DeserializeObject<HousesWrapper>(jsonTextHouses).Houses;

            var castlePath = Path.Combine(Directory.GetCurrentDirectory() + "..\\..\\..\\data\\castles.json");
            //var JSON = System.IO.File.ReadAllText();
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

        public Character GetCharacterByName(string name)
        {
            return _characters.Find(x => x.Name.Equals(name));
        }

        public IEnumerable<Character> GetLovers(Character character)
        {
            return character?.LoverIds?.Select(GetCharacterById);
        }

        public IEnumerable<Character> GetSpouses(Character character)
        {
            return character?.SpouseIds?.Select(GetCharacterById);
        }

        public IEnumerable<Character> GetSiblings(Character character)
        {
            return character?.SiblingIds?.Select(GetCharacterById);
        }

        public IEnumerable<House> GetHouses()
        {
            return _houses;
        }

        public House GetHouseById(string id)
        {
            return _houses.Find(x => x.Id == id);
        }

        public IEnumerable<House> GetAllegiance(House house)
        {
            return house?.AllegionHouseIds?.Select(GetHouseById);
        }

        public IEnumerable<Castle> GetCastles()
        {
            return _castles;
        }

        public IEnumerable<Castle> GetSeatsForHouse(House house)
        {
            return _castles.Where(castle => house.SeatIds.Any(id => id == castle.Id));
        }

        public IEnumerable<House> GetRulers(Castle castle)
        {
            return castle?.RulerIds.Select(GetHouseById);
        }

        public Character PushFromwindow(Character characterInput)
        {
            var characterId = characterInput.Id;

            var character = _characters.Find(x => x.Id == characterId);
            character.Healthy = false;
            return character;
        }

        public IEnumerable<Character> GetResidents(House house)
        {
            return _characters.Where(x => x.HouseId == house.Id);
        }

        public Character GetCharacter(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<string>("id");
            var name = context.GetArgument<string>("name");
            if (id != null)
            {
                return GetCharacterById(id);
            }

            if (name != null)
            {
                return GetCharacterByName(name);
            }

            return null;
        }

        public House GetHouse(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<string>("id");
            var name = context.GetArgument<string>("name");
            if (id != null)
            {
                return _houses.Find(x => x.Id == id);
            }

            if (name != null)
            {
                return _houses.Find(x => x.Name.Equals(name));
            }

            return null;
        }

        public Character AddTitles(Character characterinput)
        {
            var character = _characters.Find(x => x.Id == characterinput.Id);
            character.Titles = characterinput.Titles;
            return character;
        }
    }
}