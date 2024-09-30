using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.WebApi
{
    public static class Helper
    {
        public static async Task CreateUserAsync(WebApplication app)
        {

            // Admin kullıcısı oluşturmak için register sayfası olmadan
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any()) // Eğer hiç kullancı yok ise
                {
                    await userManager.CreateAsync(new()
                    {
                        FirstName = "Elif",
                        LastName = "Çalış",
                        Email = "admin@admin.com",
                        UserName = "admin",
                    }, "1"); //1 sifre
                }
            }
        }
    }
}
