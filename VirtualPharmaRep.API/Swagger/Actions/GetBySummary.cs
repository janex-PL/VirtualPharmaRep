using System.Linq;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public class GetBySummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName, string actionName)
        {
            var query = actionName.Split("GetBy").Last();
            operation.Summary = $"Get all {resourceName} entities by {query} ID";
            operation.Parameters[0].Description = $"ID of {query} entity";
        }
    }
}

