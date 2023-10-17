namespace Web_Marina
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
			var app = builder.Build();

			// Aktiviert das wwwroot-Verzeichnis für statische Dateien
			app.UseStaticFiles();

			// rooting aktivieren
			app.UseRouting();


			app.MapControllerRoute(
				name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}