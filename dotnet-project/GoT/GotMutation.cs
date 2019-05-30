using GoT.GoTTypes.Character;
using GraphQL.Types;

namespace GoT
{
    public class GotMutation : ObjectGraphType
    {
        public GotMutation(GoTData data)
        {
            Name = "Mutation";

            Field<CharacterType>(
                "pushFromWindow",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "character" }
                ),
                resolve: context =>
                {
                    var character = context.GetArgument<Character>("character");
                    return data.PushFromwindow(character);
                });
            Field<CharacterType>(
                "addTitle",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "character" }
                ),
                resolve: context =>
                {
                    var character = context.GetArgument<Character>("character");
                    return data.AddTitles(character);
                });
        }

    }
}