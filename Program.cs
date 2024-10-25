using EhitusfirmaProc.Data;
using Microsoft.EntityFrameworkCore;

namespace EhitusfirmaProc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StoredEhitusfirmaProcDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            //Harjutus 2
            //Tegemist on ehitusfirmaga, millel on projektid.
            //Projektidesse on pandud spetsialistid.
            //Igal projektil on töötajad.
            //Igal töötajal on unikaalne töötaja nr.
            //Igal töötajal on nimi, mis jaguneb ees-ja perekonnanimeks.
            //Iga projekt on unikaalne.

        }
    }
}
