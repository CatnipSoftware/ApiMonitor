using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monitor.Business.Contract;
using Monitor.Business.Module;
using Monitor.Domain.Model;
using Monitor.Domain.Settings;
using Monitor.Presentation.Contract;
using Monitor.Presentation.Module;

namespace Monitor
{
    public class Startup
    {
        private readonly AppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _appSettings = new AppSettings();
            Configuration.Bind(_appSettings);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
                    
            services.AddTransient<IApiRepository, ApiRepository>()
                    .AddTransient<IApplicationRepository, ApplicationRepository>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<ILogRepository, LogRepository>()
                    .AddTransient<IServerRepository, ServerRepository>()
                    .AddTransient<ITimeRepository, TimeRepository>()
                    .AddTransient<ITransactionRepository, TransactionRepository>()

                    .AddTransient<IApiPresentation, ApiPresentation>()
                    .AddTransient<IApplicationPresentation, ApplicationPresentation>()
                    .AddTransient<ILogPresentation, LogPresentation>()
                    .AddTransient<IServerPresentation, ServerPresentation>()
                    .AddTransient<ITransactionPresentation, TransactionPresentation>()
                    ;

            services.AddDbContext<MonitorContext>(options => options.UseSqlServer(_appSettings.ConnectionString));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}