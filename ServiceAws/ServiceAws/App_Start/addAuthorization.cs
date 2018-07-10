using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Filters;

namespace ServiceAws
{
    public class AddAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            string authorization; //= context.ActionContext.Request.Headers.Authorization.Parameter;
            IEnumerable<string> values = new List<string>();
            bool op = context.ActionContext.Request.Headers.TryGetValues("Authorization", out values);
            if (op)
            {
                authorization = values.First();
                context.Response.Headers.Add("Authorization", new string[] { authorization });
            }

            base.OnActionExecuted(context);
        }
    }
}