using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.Services;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;
        private readonly ILogger<AccountsController> logger;
        private readonly AuthenticationService authenticationService;

        public AccountsController(ILibraryDbUnitOfWork dbUnitOfWork, ILogger<AccountsController> logger, AuthenticationService authenticationService)
        {
            this.dbUnitOfWork = dbUnitOfWork;
            this.logger = logger;
            this.authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            // check credintials
            var appUser = dbUnitOfWork.AppUsers.GetByEmail(request.Email);
            if (appUser == null)
                return NotFound();
            // TODO : Implement PasswordHashing Service
            if (appUser.PasswordHash != request.Password)
                return BadRequest();
            return Ok(authenticationService.GenerateToken(appUser));
        }
        [HttpPost("register")]
        public ActionResult Register(string request)
        {
            return Ok();
        }
    }
}
