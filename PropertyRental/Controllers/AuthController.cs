using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using PropertyRental.Application.DTOs;
using PropertyRental.Application.Services;
using PropertyRental.Domain.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PropertyRental.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private UserAppService _userService;
    private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        
        public AuthController(UserAppService userService,UserManager<User> userManager,SignInManager<User> signInManager,IConfiguration configuration)
        {
            _userService = userService;
            _signInManager = signInManager;
            _configuration = configuration;
               _userManager = userManager;
        }
        [HttpPost("login")]
        public  IActionResult Login([FromBody] Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //verifyUserName
            var user = _userService.GetByUserName(model.UserName);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });
            // Verify the password
            var result =  _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.IsCompletedSuccessfully)
                return Unauthorized(new { message = "Invalid credentials" });
            var token = GenerateJwtToken(user);
            return Ok(new { token });

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new UserDTO
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Image = model.Image,
                Password = model.Password,
                RoleId = model.RoleId
                
            };

            var result = _userService.Insert(user);
            if (!result.IsCompletedSuccessfully)
                return BadRequest(result.Exception.Message);

            return Ok(new { message = "User registered successfully!" });
        }
        [HttpPut("editprofile")]
        public async Task<IActionResult> EditProfile([FromBody] EditProfile model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get the current logged-in user 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound(new { message = "User not found." });

            // Check if the new username is already taken
            if (user.UserName != model.UserName)
            {
                var existingUser = await _userManager.FindByNameAsync(model.UserName);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Username is already taken." });
                }
            }

            // Check if the new email is already taken
            if (user.Email != model.Email)
            {
                var existingEmail = await _userManager.FindByEmailAsync(model.Email);
                if (existingEmail != null)
                {
                    return BadRequest(new { message = "Email is already in use." });
                }
            }

            // Update the user information
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;

            // Save the updated user information
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Profile updated successfully!" });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new { message = "Password changed successfully!" });
        }

        private string GenerateJwtToken(User user)
        {
            if (user == null)
                return " ";
            var claims = new List<Claim>
{
    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
