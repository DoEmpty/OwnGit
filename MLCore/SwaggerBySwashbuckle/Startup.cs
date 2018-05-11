using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;

namespace SwaggerBySwashbuckle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(x => {
                //参数一：用于生成的swagger文档的名字，必须与SwaggerEndPoint的url保持一致
                x.SwaggerDoc("empty", new Swashbuckle.AspNetCore.Swagger.Info { Title = "swashbuckle api", Version = "V1" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "SwaggerBySwashbuckle.xml");
                x.IncludeXmlComments(filePath);
                x.IgnoreObsoleteActions();
            });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/empty/swagger.json", "EmptySwagger");
            });
            app.UseMvc();
        }
    }
}
