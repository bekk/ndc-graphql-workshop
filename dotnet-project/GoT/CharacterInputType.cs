using GoT.GoTTypes.Character;
using GoT.Types;
using GraphQL.Types;

namespace GoT
{
    public class CharacterInputType : InputObjectGraphType<Character>
    {
        public CharacterInputType()
        {
            Name = "Characterinput";
            Field(x => x.Id);
        }
    }
}