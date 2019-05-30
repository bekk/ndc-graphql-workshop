using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT.GoTTypes.Castles
{
    public class CastleType : ObjectGraphType<Castle>
    {
        public CastleType(GoTData data)
        {
            Name = "Castles";

            Field(h => h.Id);
            Field(h => h.Name, nullable: true);
            Field(h => h.Location, nullable: true);
            Field(h => h.Religion, nullable: true);
            Field(h => h.RulerIds, nullable: true);
            Field<ListGraphType<HouseType>>(
                "rulers",
                resolve: context => data.GetRulers(context.Source)
            );  
        }
    }
}