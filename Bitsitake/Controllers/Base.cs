using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;



namespace Bitsitake.Controllers
{
    public static class Base
    {
        private static Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostEnviroment;
        public static string WebPath => _hostEnviroment.WebRootPath;

        public static string MapPath(string path)
        {
            return Path.Combine(_hostEnviroment.WebRootPath, path);
        }

        internal static void Configure(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnviroment)
        {
            _hostEnviroment = hostEnviroment;
        }
    }
    public static class StaticHostEnviromentExtensions
    {
        public static IApplicationBuilder UseStaticHostEnviroment(this IApplicationBuilder app)
        {
            var webHostEnvironment = app.ApplicationServices.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();
            Base.Configure(webHostEnvironment);
            return app;
        }
    } 


}
