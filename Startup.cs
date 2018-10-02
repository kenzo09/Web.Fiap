using Fiap01.Data;
using Fiap01.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fiap01.Extensions;

namespace Fiap01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<PerguntasContext>(o => o.UseSqlServer(connection));

            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            //app.UseMiddleware<LogMiddleware>();
            app.UseRequestTimeLogger();

            app.UseMvc(routes =>
            {
                routes.MapRoute("autor", "autor/{nome}", new { controller = "Autor", action = "Index" });
                routes.MapRoute("topicosdacategoria", "{categoria}/{topico}", new { controller = "Topicos", action = "Index" });
                routes.MapRoute("autoresDoAno", "{ano:int}/autor", new { controller = "Autor", action = "ListaDosAutoresDoAno" });
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
