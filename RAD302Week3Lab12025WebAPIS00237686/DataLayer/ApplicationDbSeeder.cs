using Microsoft.AspNetCore.Identity;

namespace RAD302Week3Lab12025WebAPIS00237686.DataLayer
{
    public class ApplicationDbSeeder
    {
        private readonly ApplicationDbContext _ctx;

        private readonly UserManager<ApplicationUser> _userManager;
        
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbSeeder(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            // seed main user
            ApplicationUser user = await _userManager.FindByEmailAsync("jbloggs@itsligo.ie");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    LastName = "Bloggs",
                    FirstName = "Joe",
                    Email = "jbloggs@itsligo.ie",
                    UserName = "jbloggs@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var result = await _userManager.CreateAsync(user, "Rad302$1");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeding");
                }
                _ctx.SaveChanges();
            }
        }
    }
}
