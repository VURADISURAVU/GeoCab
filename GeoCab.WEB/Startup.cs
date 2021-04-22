using GeoCab.BLL.Interfaces;
using GeoCab.BLL.Services;
using GeoCab.DAL.DataContext;
using GeoCab.DAL.Repositories;
using GeoCab.WEB.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GeoCab.WEB
{
	public class Startup
	{
		public const string AuthMethod = "cock";
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }
		private string Connection { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c => { c.SwaggerDoc("v5", new OpenApiInfo {Title = "GeoCab.WEB", Version = "v5"}); });
			
			Connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<GeoCabDbContext>(option => option.UseSqlServer(Connection));
			services.AddScoped(x => new UserRepository(x.GetService<GeoCabDbContext>()));
			services.AddScoped(x => new EmployeeRepository(x.GetService<GeoCabDbContext>()));
			services.AddScoped(x => new WorkRepository(x.GetService<GeoCabDbContext>()));

			services.AddScoped<IWorkService, WorkService>(x => new WorkService(
				x.GetService<WorkRepository>())
			);
			services.AddScoped<IUserService, UserService>(x => new UserService(
				x.GetService<UserRepository>())
			);
			
			services.AddScoped<UserMiddleware>(
				x => new UserMiddleware(
					x.GetService<UserRepository>(),
					x.GetService<IHttpContextAccessor>())
			);

			services.AddHttpContextAccessor();
			
			services.AddControllersWithViews();
			
			services.AddAuthentication(AuthMethod)
				.AddCookie(AuthMethod, config =>
				{
					config.Cookie.Name = "B";
					config.LoginPath = "/user/login";
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v5/swagger.json", "GeoCab.WEB v5"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			
			app.UseStaticFiles();

			app.UseAuthentication();
			
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}