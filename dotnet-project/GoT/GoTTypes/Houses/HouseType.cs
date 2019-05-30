using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GraphQL.Types;

namespace GoT.GoTTypes.Houses
{
    public class HouseType : ObjectGraphType<House>
    {
        public HouseType(GoTData data)
        {
            Name = "House";

            Field(h => h.Id);
            Field(h => h.Name, nullable: true);
            Field(h => h.Region, nullable: true);
            Field(h => h.Image, nullable: true);
            Field(h => h.Words, nullable: true);
            Field(h => h.AllegionHouseIds, nullable: true);
            Field<ListGraphType<HouseType>>(
                "Allegion",
                resolve: context => data.GetAllegiance(context.Source)
            );
            Field<ListGraphType<CharacterType>>(
                "Members",
                resolve: context => data.GetResidents(context.Source)
            );
            Field<ListGraphType<CastleType>>(
                "Seats",
                resolve: context => data.GetSeatsForHouse(context.Source)
            );
        }
    }
}