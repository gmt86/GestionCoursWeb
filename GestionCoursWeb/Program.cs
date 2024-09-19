using GestionCours.Model;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace GestionCoursWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //ce service permet de gérer la persistence de données, 
            //on laisse .Net se débrouiller à instancier se contexte
            builder.Services.AddDbContext<AnnuaireContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GestionCoursWeb")) );
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Annuaire}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
