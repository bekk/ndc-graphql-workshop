using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT
{
    public class GotQuery : ObjectGraphType<object>
    {
        public GotQuery(GoTData data)
        {
            Name = "Query";

            Field<ListGraphType<CharacterType>>("characters", resolve: context => data.GetCharacters());
        }
    }
}