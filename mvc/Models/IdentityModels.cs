using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mvc.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> //инициализатор бд
        {
            protected override void Seed(ApplicationDbContext context)
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context)); 

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));//для управления ролями

                // создаем две роли
                var role1 = new IdentityRole { Name = "admin" };
                var role2 = new IdentityRole { Name = "User" };

                // добавляем роли в бд
                roleManager.Create(role1);
                roleManager.Create(role2);

                // создаем пользователей
                var admin = new ApplicationUser { Email = "administrator@mail.ru", UserName = "administrator@mail.ru" };
                string password = "ad46D_ewr3";
                var result = userManager.Create(admin, password);

                // если создание пользователя прошло успешно
                if (result.Succeeded)
                {
                    // добавляем для пользователя роль
                    userManager.AddToRole(admin.Id, role1.Name);
                    userManager.AddToRole(admin.Id, role2.Name);
                }

                base.Seed(context);
            }
        }
    }
}