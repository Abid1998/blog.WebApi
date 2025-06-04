using blog.Core.DTOs.AccountDtos;
using blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        // POST: api/Account/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };

            // Create the user with password
            var createUserResult = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return BadRequest(createUserResult.Errors);

            // Assign roles if any
            if (model.Roles != null && model.Roles.Any())
            {
                foreach (var roleName in model.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                        if (!roleResult.Succeeded)
                            return BadRequest(roleResult.Errors);
                    }
                }

                var addRolesResult = await _userManager.AddToRolesAsync(user, model.Roles);
                if (!addRolesResult.Succeeded)
                    return BadRequest(addRolesResult.Errors);
            }

            // Add claims if any
            if (model.Claims != null && model.Claims.Any())
            {
                var claims = model.Claims.Select(c => new Claim(c.Type, c.Value));
                var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);
                if (!addClaimsResult.Succeeded)
                    return BadRequest(addClaimsResult.Errors);
            }

            return Ok("User registered successfully with roles and claims.");
        }
    
        // POST: api/Account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized("Invalid login");

            // TODO: Implement JWT token generation properly here
            var token = "generate_token_here";

            return Ok(new { token });
        }

        // POST: api/Account/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // TODO: Send token by email to user

            return Ok(new { token });
        }

        // POST: api/Account/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest("User not found");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Password reset successful");
        }
    }
}













//using blog.Core.DTOs.AccountDtos;
//using blog.Core.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace blog.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly IConfiguration _config;

//        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration config)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _config = config;
//        }



//        public async Task<IdentityResult> RegisterUserAsync(RegisterDto model)
//        {
//            // Create user object
//            var user = new ApplicationUser
//            {
//                UserName = model.Email,
//                Email = model.Email,
//                FullName = model.FullName,
//                PhoneNumber = model.PhoneNumber
//            };

//            // Create user with password
//            var result = await _userManager.CreateAsync(user, model.Password);
//            if (!result.Succeeded)
//            {
//                return result; // return errors
//            }

//            // Assign roles if any
//            if (model.Roles != null && model.Roles.Any())
//            {
//                foreach (var roleName in model.Roles)
//                {
//                    // Check if role exists, if not create
//                    if (!await _roleManager.RoleExistsAsync(roleName))
//                    {
//                        await _roleManager.CreateAsync(new IdentityRole(roleName));
//                    }
//                }
//                // Add user to roles
//                await _userManager.AddToRolesAsync(user, model.Roles);
//            }

//            // Add claims if any
//            if (model.Claims != null && model.Claims.Any())
//            {
//                var claims = model.Claims.Select(c => new Claim(c.Type, c.Value));
//                await _userManager.AddClaimsAsync(user, claims);
//            }

//            return IdentityResult.Success;
//        }


//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromForm] LoginDto model)
//        {
//            var user = await _userManager.FindByEmailAsync(model.Email);
//            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
//                return Unauthorized("Invalid login");

//            // Create JWT token here
//            var token = "generate_token_here";
//            return Ok(new { token });
//        }

//        [HttpPost("forgot-password")]
//        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordDto model)
//        {
//            var user = await _userManager.FindByEmailAsync(model.Email);
//            if (user == null) return BadRequest("User not found");

//            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//            // Send token via email (you can implement)
//            return Ok(new { token });
//        }

//        [HttpPost("reset-password")]
//        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
//        {
//            var user = await _userManager.FindByEmailAsync(model.Email);
//            if (user == null) return BadRequest("User not found");

//            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
//            if (!result.Succeeded) return BadRequest(result.Errors);

//            return Ok("Password reset successful");
//        }
//    }
//}



//[HttpPost("register")]
//public async Task<IActionResult> Register([FromForm] RegisterDto model)
//{
//    var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName };
//    var result = await _userManager.CreateAsync(user, model.Password);

//    if (!result.Succeeded)
//        return BadRequest(result.Errors);

//    return Ok("User registered");
//}
