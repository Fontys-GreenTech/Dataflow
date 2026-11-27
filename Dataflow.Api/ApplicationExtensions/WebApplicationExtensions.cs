using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Dataflow.Api.ApplicationExtensions;

internal static class WebApplicationExtensions
{
    public static WebApplication UseDataflowApi(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.UseRouting();

        return app;
    }
}
