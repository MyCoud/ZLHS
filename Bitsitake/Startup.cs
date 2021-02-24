using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitDal;
using Swashbuckle.AspNetCore.Swagger;
namespace Bitsitake
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");

            services.AddDbContext<MyContext>(option => option.UseSqlServer(sqlConnection));

            services.AddMvc();
            //1��ע�����Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "by JiaJia"
                });
            });
            #region ����  

            //���ÿ���������������Դ��

            services.AddCors(options =>

            {

                options.AddPolicy("kuayu", builder =>

                {

                    builder.AllowAnyOrigin() //�����κ���Դ����������

                    .AllowAnyMethod();

                    builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS").AllowAnyHeader();  //����дAllowAnyHeader����ǰ�˵���

                    //.AllowCredentials();//ָ������cookie

                });

            });
        }
        #endregion
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }
            //2����ӵ��ܵ�


            app.UseRouting();
            app.UseCors("kuayu");//ȫ�ֿ���,��Ӱ�����п�����
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
