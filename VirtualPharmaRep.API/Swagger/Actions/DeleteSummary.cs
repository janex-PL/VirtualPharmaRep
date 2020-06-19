using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public static class DeleteSummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName)
        {
            operation.Summary = $"Deletes {resourceName} entity with specified ID";
            operation.Parameters[0].Description = $"ID of requested {resourceName} entity";
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = $"Returns deleted{resourceName} entity",
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    {
                        "application/json", new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
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
            };
            operation.Responses["404"] = new OpenApiResponse
            {
                Description = $"If {resourceName} entity couldn't be found"
            };
        }
    }
}
