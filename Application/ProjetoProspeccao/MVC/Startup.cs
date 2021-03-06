using BLL.Interfaces.DAL;
using BLL.Interfaces.Serrvices.PaisEstadoCidade;
using BLL.Interfaces.Services.Cliente;
using BLL.Interfaces.Services.Usuario;
using BLL.Service.Cliente;
using BLL.Service.PaisEstadoCidade;
using BLL.Service.Usuario;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using BLL.Interfaces.Services.Fluxo;
using BLL.Service.Fluxo;
using Data.EF;
using Data.Conexao;
using Microsoft.EntityFrameworkCore;
using BLL.Enums;

namespace MVC
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
            services.AddControllersWithViews();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/Home/Index");

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddTransient<IClienteService, ClienteService>();
            // services.AddTransient<IClienteDAL, ClienteDAL>();
            services.AddTransient<IClienteDAL, ClienteEF>();
            services.AddTransient<IPaisEstadoCidadeService, PaisEstadoCidadeService>();
            // services.AddTransient<IPaisEstadoCidadeDAL, PaisEstadoCidadeDAL>();
            services.AddTransient<IPaisEstadoCidadeDAL, PaisEstadoCidadeEF>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            // services.AddTransient<IUsuarioDAL, UsuarioDAL>();
            services.AddTransient<IUsuarioDAL, UsuarioEF>();
            services.AddTransient<IFluxoService, FluxoService>();
            // services.AddTransient<IFluxoDAL, FluxoDAL>();
            services.AddTransient<IFluxoDAL, FluxoEF>();

            services.AddAuthorization(options =>
                options.AddPolicy("CadastroCorrecaoCliente", policy => policy.RequireClaim("IdPerfil", $"{(int)EPerfil.Administracao}", $"{(int)EPerfil.Operacao}"))
            );
            services.AddAuthorization(options =>
                options.AddPolicy("Administrador", policy => policy.RequireClaim("IdPerfil", $"{(int)EPerfil.Administracao}"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
