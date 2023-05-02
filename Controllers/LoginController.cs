using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticatiosAutorization.Models;
using AutenticatiosAutorization.Repositorio;
using AutenticatiosAutorization.Service;
using Microsoft.AspNetCore.Mvc;

namespace AutenticatiosAutorization.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepositorio.Get(model.UserName, model.Password);

            if (user == null)
                return NotFound(new { message = "Utilizador ou senha invalida" });

            var token = TokenService.GenerateToken(user);

            user.Password = "****";

            return new
            {
                nome = user.UserName,
                Pass = user.Password,
                token = token

            };
        }
    }
}