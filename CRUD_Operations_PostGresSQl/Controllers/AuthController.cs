﻿using CRUD_Operations_PostGresSQl.CustomActionFilter;
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        //method /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
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
                            new Claim(ClaimTypes.Role,Roles[0]),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                        };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity));

                            return Ok(new
                            {
                                loginRequestDto.UserName,
                                Role = Roles[0],
                            });
                        }
                    }
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        //method /api/Auth/Logout
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok(new { Message = "You are logged out" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
