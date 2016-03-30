using System.IO;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Extensions.PlatformAbstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNet.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, IApplicationEnvironment env)
        {
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            string path = Path.Combine(env.ApplicationBasePath, "node_modules");
            var physicalFileProvider = new PhysicalFileProvider(path);
            options.FileProvider = physicalFileProvider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
