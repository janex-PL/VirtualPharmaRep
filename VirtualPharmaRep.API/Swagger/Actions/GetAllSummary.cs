using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public static class GetAllSummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName)
        {
            operation.Summary = $"Get all {resourceName} entities";
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = $"Returns list of {resourceName} entities",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    {
                        "application/json", new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "array",
                                Items = new OpenApiSchema
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Id = $"{resourceName}Dto",
                                        Type = ReferenceType.Schema
                                    }
                                }
                            }
                        }

                    }
                }
            };
		}
    }
}
