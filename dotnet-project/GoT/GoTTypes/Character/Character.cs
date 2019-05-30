using System.Collections.Generic;

namespace GoT.GoTTypes.Character
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string HouseId { get; set; }
        public IEnumerable<string> Allegiances { get; set; }
        public IEnumerable<string> SpouseIds { get; set; }
        public IEnumerable<string> LoverIds { get; set; }
        public IEnumerable<string> SiblingIds { get; set; }
        public IEnumerable<string> Titles { get; set; }
        public bool? Healthy { get; set; }
    }
}