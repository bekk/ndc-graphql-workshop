using System.Collections.Generic;

namespace GoT.GoTTypes.Castles
{
    public class Castle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<string> Religion { get; set; }
        public IEnumerable<string> RulerIds { get; set; }
    }
}