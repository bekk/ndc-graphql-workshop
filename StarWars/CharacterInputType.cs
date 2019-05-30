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
            Field(x => x.Healthy, nullable:true);
            Field(x => x.Titles, nullable:true);
            Field(x => x.Name, nullable: true);
        }
    }
}