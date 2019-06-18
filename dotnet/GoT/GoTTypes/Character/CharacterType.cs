using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT.GoTTypes.Character
{
    public class CharacterType : ObjectGraphType<Character>
    {
        public CharacterType(GoTData data)
        {
            Name = "Character";

            Field(h => h.Id);
            Field(h => h.Name, nullable: true);
            Field(h => h.Image, nullable: true);
            Field<ListGraphType<CharacterType>>(
                "siblings",
                resolve: context => data.GetSiblings(context.Source)
            );
            

        }
    }
}