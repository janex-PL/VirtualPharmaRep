using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.CustomObjects;

namespace VirtualPharmaRep.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException ex:
                {
                    context.Result = new ObjectResult(new MessageResponse {Message = ex.Message}){StatusCode = 422};
                    break;
                }
                case DbUpdateException ex:
                {
                    if (ex.InnerException != null)
                        context.Result = new ObjectResult(new MessageResponse {Message = $"Error while trying to update database: {ex.InnerException.Message}"})
                            {StatusCode = 500};
                    else
                        return;
                    break;
                }
                default:
                {
                    return;
                }
            }
            context.ExceptionHandled = true;
        }
    }
}
