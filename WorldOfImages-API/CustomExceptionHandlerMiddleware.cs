using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text;

namespace WorldOfImagesAPI
{
    public class CustomExceptionHandlerMiddleware
    {
        public void UseExceptionHandler(IApplicationBuilder errorApp)
        {
            //Static Cling - unit testing this because Run is extenstion method (static one) is not a simple task...
            errorApp.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                //TODO: add logging

                if (ex != null)
                {
                    UnicodeEncoding uniencoding = new UnicodeEncoding();
                    var err = "There was an error during processing your request. We are working to solve it.";
                    var errInBytes = uniencoding.GetBytes(err);
                    await context.Response.Body.WriteAsync(errInBytes, 0, errInBytes.Length).ConfigureAwait(false);
                }
            });
        }
    }
}