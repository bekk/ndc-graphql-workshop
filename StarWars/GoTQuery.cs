using GoT.GoTTypes.Character;
using GraphQL.Types;

namespace GoT
{
    public class GotQuery : ObjectGraphType<object>
    {
        public GotQuery(GoTData data)
        {
            Name = "Query";

            Field<ListGraphType<CharacterType>>("getCharacters", resolve: context => data.GetCharacters());

            Field<CharacterType>(
                "getById",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the character" }
                ),
                resolve: context => data.GetCharacterById(context.GetArgument<string>("id")));
        }
    }
}