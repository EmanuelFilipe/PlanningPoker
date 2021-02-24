using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanningPoker.ViewModels;

namespace PlanningPoker.Controllers
{
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar([FromBody]RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(result);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.AppendLine(error.Description);
                    }

                    return NotFound(new { Mensagem = sb.ToString() });
                }
            }

            return BadRequest();
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login([FromBody]LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

                if (result.Succeeded)
                    return Ok(loginUser);
                else if (result.IsLockedOut)
                    return BadRequest(new { Mensagem = "Usuário temporariamente bloqueado por tentativas inválidas" });
                else
                    return BadRequest(new { Mensagem = "Usuário ou Senha incorretos" });
            }

            return BadRequest();
        }
    }
}