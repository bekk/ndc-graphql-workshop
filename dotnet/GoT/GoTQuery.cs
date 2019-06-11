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

            Field<CharacterType>(
                "character",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of the character" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "name of the character" }
                ),
                resolve: data.GetCharacter);

            Field<ListGraphType<HouseType>>("houses", resolve: context => data.GetHouses());

            Field<HouseType>(
                "house",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "id", Description = "id of the house"},
                    new QueryArgument<StringGraphType> {Name = "name", Description = "name of the house"}
                ),
                resolve: data.GetHouse);

            Field<ListGraphType<CastleType>>("castles", resolve: context => data.GetCastles());
        }
    }
}