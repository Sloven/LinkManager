using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Microsoft.Owin;
using PathString = Microsoft.Owin.PathString;

namespace WebAPI.CustomMiddleware
{
    internal class CustomHeaderMiddleware : OwinMiddleware
    {
        public CustomHeaderMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var origin = context.Request.Headers["Origin"].ToLower();
            var referer = context.Request.Headers["Referer"].ToLower();
            var section1 = referer.Replace(origin, "");

            if (section1.IndexOf("/demo",StringComparison.Ordinal) == 0)
            {
                context.Request.Headers.Append("isdemo", "true");

                //var rightPath = context.Request.Path.ToString().Replace("demo/", "");
                //context.Request.Path = new PathString(rightPath);
            }
            await Next.Invoke(context);
        }
    }
}