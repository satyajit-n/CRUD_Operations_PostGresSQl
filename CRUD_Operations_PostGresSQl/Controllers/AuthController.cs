using CRUD_Operations_PostGresSQl.CustomActionFilter;
using CRUD_Operations_PostGresSQl.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD_Operations_PostGresSQl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        //method /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {

                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequestDto.Roles);


                    if (identityResult.Succeeded)
                    {
                        return Ok("User Created Successfuly");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var Roles = await userManager.GetRolesAsync(user);

                    if (Roles != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.Email, user.UserName),
                            new Claim(ClaimTypes.Role,Roles[0])
                        };
                        //foreach (var role in Roles)
                        //{
                        //    claims.Add(new Claim(ClaimTypes.Role, role));
                        //}
                        var claimsIdentity = new ClaimsIdentity(claims, "Login");

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));

                        return Ok(new
                        {
                            Name = loginRequestDto.UserName,
                            Role = Roles[0]
                        });
                    }
                }
            }
            return Unauthorized();
        }
    }
}
