using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public static class PutSummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName)
        {
            operation.Summary = $"Updates {resourceName} entity with specified ID";
            operation.Parameters[0].Description = $"ID of requested {resourceName} entity";
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = $"Returns updated {resourceName} entity",
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
            operation.Responses["400"] = new OpenApiResponse
            {
                Description = "If required data was not provided or if model validation has failed"
            };
            operation.Responses["404"] = new OpenApiResponse
            {
                Description = $"If {resourceName} entity couldn't be found"
            };
        }
    }
}
