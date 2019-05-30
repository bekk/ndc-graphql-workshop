using GoT.GoTTypes.Character;
using GraphQL.Types;

namespace GoT
{
    public class CharacterInputType : InputObjectGraphType<Character>
    {
        public CharacterInputType()
        {
            Name = "Characterinput";
            Field(x => x.Id);
            Field(x => x.Titles, nullable:true);
        }
    }
}