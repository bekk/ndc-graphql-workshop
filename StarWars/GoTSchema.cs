using GraphQL;
using GraphQL.Types;

namespace GoT
{
    public class GoTSchema : Schema
    {
        public GoTSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<GotQuery>();
        }
    }
}