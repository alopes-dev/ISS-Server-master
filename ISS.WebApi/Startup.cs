using ISS.GraphQL.Repository;
using ISS.GraphQL.ServiceExtentions;
using ISWebApp.Models;
using ISWebLib;
using ISS.Application.LinqToDb;
using ISS.Application.Models;
using ISS.Application.Services;
using ISS.Application.Services.Email;
using ISS.Application.Services.Validation;
using LinqToDB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;
using ISS.Application;

namespace ISWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration,
                       IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Workaround until GraphQL can swap off Newtonsoft.Json and onto the new MS one.
            // Depending on whether you're using IIS or Kestrel, the code required is different
            // See: https://github.com/graphql-dotnet/graphql-dotnet/issues/1116
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors();
#if !DEBUG
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            DataConnection.DefaultSettings = new DbSettings(Configuration.GetConnectionString("Connection"));
            services.AddTransient<DapperContext>( (service) => new DapperContext(Configuration.GetConnectionString("Connection")));
            services.AddScoped<SqlConnection>(s => new SqlConnection(Configuration["ConnectionStrings:Connection"]));
#else
            services.AddTransient((service) => new DapperContext(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            DataConnection.DefaultSettings = new DbSettings(Configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped<SqlConnection>(s => new SqlConnection(Configuration["ConnectionStrings:DefaultConnection"]));
#endif
            services.AddScoped<LinqDbContext>();
            services.AddIdentity<Usuario, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
            

            services.AddAuthentication()
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });
            if(Environment.IsDevelopment())
            {
                services.AddGraphQLAuth((_, s) =>
                {
                    _.AddPolicy("AdminPolicy", p => p.RequireClaim("role", "Admin"));
                });
            }

            #region GraphQL Config
            services.AddISSGraphQL(Configuration,Environment.IsDevelopment());
            #endregion

            #region Other Services
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IQRCoder, ISS.Application.Services.QRCoder>();
            services.AddSingleton<IValidationRepository,ValidationRepository>();
            // services.AddSingleton<IRabbitMQClient,  >();
            // services.AddSingleton<IBaseBot, BaseT>();
            
            // Configurar o serviço de caching com o redis
            services.AddDistributedCacheService(Configuration);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors(conf =>
            {
                conf.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseWebSockets();

            app.UseISSGraphQL();
        }
    }
}
