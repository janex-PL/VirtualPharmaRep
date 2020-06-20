using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using VirtualPharmaRep.API.Swagger.Actions;

namespace VirtualPharmaRep.API.Swagger
{
    public class ApplySummariesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!(context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)) return;
            var actionName = controllerActionDescriptor.ActionName;
            var resourceName = controllerActionDescriptor.ControllerName;

            switch (actionName)
            {
                case { } name when name.Contains("GetBy"):
                    GetBySummary.Apply(ref operation, resourceName, actionName);
                    break;
                case "Get" when operation.Parameters.Count == 2:
                    GetAllSummary.Apply(ref operation, resourceName);
                    break;
                case "Get" when controllerActionDescriptor.Parameters.Count == 1:
                    GetSummary.Apply(ref operation, resourceName);
                    break;
                case "Post":
                    PostSummary.Apply(ref operation, resourceName);
                    break;
                case "Put":
                    PutSummary.Apply(ref operation, resourceName);
                    break;
                case "Delete":
                    DeleteSummary.Apply(ref operation, resourceName);
                    break;
            }
            operation.Responses["403"] = new OpenApiResponse
            {
                Description = "If administrator has blocked access to the requested action."
            };
            operation.Responses["401"] = new OpenApiResponse
            {
                Description = "If user is not registered or logged in"
            };
        }
    }
}
