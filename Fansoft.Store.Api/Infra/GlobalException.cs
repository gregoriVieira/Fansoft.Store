using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fansoft.Store.Api.Infra
{
    public class GlobalException : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            var ex = string.Empty;
            if (context.Exception.InnerException != null)
            {
                ex = context.Exception.InnerException.Message;
            }
            else
            {
                ex = context.Exception.Message;
            }
            context.Result = new JsonResult(new { msg = ex });
        }

    }
}