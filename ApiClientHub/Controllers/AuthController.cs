using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiClientHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Realiza login de cliente", Description = "Realiza a autenticação do cliente e gera um token de acesso.")]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = await _authServices.GenerateToken(user.Id, user.Client);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private async Task<AuthToken> AuthenticateUser(LoginViewModel login)
        {
            var user = await _authServices.UserExists(login.Username);

            return user;
        }
    }
}
