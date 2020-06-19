using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace VirtualPharmaRep.API.Swagger.Actions
{
    public class PostRangeSummary
    {
        public static void Apply(ref OpenApiOperation operation, string resourceName)
        {
            operation.Summary = $"Adds list of new {resourceName} entities";
            operation.Responses["201"] = new OpenApiResponse
            {
                Description = $"Returns list of new {resourceName} entities",
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
