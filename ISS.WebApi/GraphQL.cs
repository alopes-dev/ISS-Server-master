using GraphQL.Authorization;
using System.Collections.Generic;
using System.Security.Claims;

namespace ISWebApp
{
    public class GraphQLUserContext : Dictionary<string, object>, IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }
}
