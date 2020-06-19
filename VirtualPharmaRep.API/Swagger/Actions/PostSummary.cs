using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public static class PostSummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName)
        {
            operation.Summary = $"Adds new {resourceName} entity";
            operation.Responses["201"] = new OpenApiResponse
            {
                Description = $"Returns new {resourceName} entity",
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
            operation.Responses["409"] = new OpenApiResponse
            {
                Description = "If entity is valid, but has a conflict with other entity in database"
            };
            operation.Responses.Remove("200");
        }
    }
}
