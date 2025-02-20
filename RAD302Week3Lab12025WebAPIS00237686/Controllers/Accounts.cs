using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RAD302Week3Lab12025WebAPIS00237686.DataLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RAD302Week3Lab12025WebAPIS00237686.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Accounts")]
    public class Accounts : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Accounts(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }

    [HttpPost("/Token")]
        public async Task<IActionResult> Token([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityOptions _options = new IdentityOptions();
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                           // Adding claims for ASP .NET Authentication if needed
                            //new Claim(_options.ClaimsIdentity.UserIdClaimType,user.Id),
                            //new Claim(_options.ClaimsIdentity.UserNameClaimType,user.UserName),
                        };

                        var userRoles = await _userManager.GetRolesAsync(user);
                        foreach (var userRole in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, userRole));
                            var role = await _roleManager.FindByNameAsync(userRole);
                            if (role != null)
                            {
                                var roleClaims = await _roleManager.GetClaimsAsync(role);
                                foreach (Claim roleClaim in roleClaims)
                                {
                                    claims.Add(roleClaim);
                                }
                            }
                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_config["Tokens:Issuer"], _config["Tokens:Audience"], claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: creds);

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };

                        return Created("", results);
                    }
                }
            }
            return BadRequest();
        }
    }
}
