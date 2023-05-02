using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutenticatiosAutorization.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutenticatiosAutorization.Controllers
{
    [ApiController]
    [Route("v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anónimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated()
            => $" Autorizado - {User.Identity.Name}";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "admin,empregado,gerente")]
        public string Employee()
            => "Funcionarios";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "admin, gerente")]
        public string Manage()
            => "Gerente";


    }
}
