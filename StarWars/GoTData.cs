using System.Collections.Generic;
using System.IO;
using GoT.GoTTypes.Character;
using GoT.Types;
using Newtonsoft.Json;

namespace GoT
{
    public class GoTData
    {
        private readonly List<Human> _humans = new List<Human>();
        private readonly List<Droid> _droids = new List<Droid>();
        private readonly List<Character> _characters;
        public GoTData()
        {
            var dataPath = Path.Combine(Directory.GetCurrentDirectory() + "..\\..\\data\\characters.json");
            //var JSON = System.IO.File.ReadAllText();
            var jsonText = System.IO.File.ReadAllText(dataPath);
            _characters = JsonConvert.DeserializeObject<CharacterWrapper>(jsonText).Characters;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _characters;
        }

        public Character GetCharacterById(string id)
        {
            return _characters.Find(x => x.Id == id);
        }
    }
}