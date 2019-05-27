using System.Security.Claims;

namespace dotnet
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
