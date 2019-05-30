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
            Field(h => h.HouseId, nullable: true);
            Field(h => h.Image, nullable: true);
            Field(h => h.SpouseIds, nullable: true);
            Field(h => h.LoverIds, nullable: true);
            Field(h => h.Allegiances, nullable: true);
            Field<ListGraphType<CharacterType>>(
                "lovers",
                resolve: context => data.GetLovers(context.Source)
            );
            Field<ListGraphType<CharacterType>>(
                "spouses",
                resolve: context => data.GetSpouses(context.Source)
            );
            Field<ListGraphType<CharacterType>>(
                "siblings",
                resolve: context => data.GetSiblings(context.Source)
            );
            Field<HouseType>(
                "house",
                resolve: context => data.GetHouseById(context.Source.HouseId)
            );
            Field(h => h.Healthy, nullable: true);
            Field(h => h.Titles, nullable: true);

        }
    }
}