using GraphQL.Types;

namespace GoT.GoTTypes.Character
{
    public class CharacterType : ObjectGraphType<Character>
    {
        public CharacterType(GoTData data)
        {
            Name = "Character";

            Field(h => h.Id).Description("The id of the character.");
            Field(h => h.Name, nullable: true).Description("The name of the character.");
            Field(h => h.Image, nullable: true).Description("The url to the image");
            Field(h => h.House, nullable: true).Description("The name of the human.");
        }
    }
}