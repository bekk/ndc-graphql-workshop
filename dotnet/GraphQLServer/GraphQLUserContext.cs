using System.Security.Claims;

namespace GraphQLServer
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
