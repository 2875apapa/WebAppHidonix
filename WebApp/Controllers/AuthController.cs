using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.EfCore;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        


        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            ResponseType type = new ResponseType();
            string data = null;

            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if(userExists != null)
            {
                type = ResponseType.Failure;
                data = "Utente già presente con questo indirizzo e-mail";
                return BadRequest(ResponseHandler.GetAppResponse(type, data));
            }


            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (!result.Succeeded)
            {
                type = ResponseType.Failure;
                data = "Si è verificato un errore durante l'elaborazione di registrazione. Riprova!";
                return BadRequest(ResponseHandler.GetAppResponse(type, data));
            }
            else
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Role));
                }
                await _userManager.AddToRoleAsync(user, model.Role);
                type = ResponseType.Success;
                data = "Account creato con successo";
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            ResponseType type = new ResponseType();
            string data = null;
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                type = ResponseType.Success;
                data = "Accesso eseguitocon successo";
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            else
            {
                type = ResponseType.Failure;
                data = "Email o password non validi";
                return BadRequest(ResponseHandler.GetAppResponse(type, data));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            ResponseType type = ResponseType.Success;
            string data = "Logout eseguito con successo";
            await _signInManager.SignOutAsync();
            return Ok(ResponseHandler.GetAppResponse(type, data));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            ResponseType type = new ResponseType();
            string data = null;
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                type = ResponseType.Failure;
                data = "Utente non trovato";
                return BadRequest(ResponseHandler.GetAppResponse(type, data));
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Invio toker per il ripristino della password
            type = ResponseType.Success;
            data = token.ToString();
            return Ok(ResponseHandler.GetAppResponse(type, data));
        }
    }
}
