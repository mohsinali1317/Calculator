using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace CalculatorApiApp.Helpers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                if (actionExecutedContext.Request.Method.Method == "OPTIONS")
                {
                    actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                    actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", actionExecutedContext.Request.Headers.GetValues("Access-Control-Request-Headers"));

                    actionExecutedContext.Response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }

    }
}