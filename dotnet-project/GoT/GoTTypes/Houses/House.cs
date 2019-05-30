using System.Collections.Generic;

namespace GoT.GoTTypes.Houses
{
    public class House
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Words { get; set; }
        public IEnumerable<string> SeatIds { get; set; }
        public IEnumerable<string> Region { get; set; }
        public IEnumerable<string> AllegionHouseIds { get; set; }
        public string Image { get; set; }   
    }
}