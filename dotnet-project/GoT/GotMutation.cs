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
                    return data.PushFromwindow(character.Name);
                });
            Field<ListGraphType<CharacterType>>(
                "marry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "spouseName1" },
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "spouseName2" }
                ),
                resolve: context =>
                {
                    var spouse1 = context.GetArgument<Character>("spouseName1");
                    var spouse2 = context.GetArgument<Character>("spouseName2");
                    return data.Marry(spouse1.Name, spouse2.Name);
                });
            Field<CharacterType>(
                "addTitle",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType>> { Name = "character" }
                ),
                resolve: context =>
                {
                    var character = context.GetArgument<Character>("character");
                    return data.AddTitles(character.Name, character.Titles);
                });
        }

    }
}