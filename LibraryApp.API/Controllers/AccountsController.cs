using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.API.Services;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;
        private readonly ILogger<AccountsController> logger;
        private readonly AuthenticationService authenticationService;
        private readonly IMapper mapper;

        public AccountsController(ILibraryDbUnitOfWork dbUnitOfWork,
            ILogger<AccountsController> logger,
            AuthenticationService authenticationService,
            IMapper mapper)
        {
            this.dbUnitOfWork = dbUnitOfWork;
            this.logger = logger;
            this.authenticationService = authenticationService;
            this.mapper = mapper;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

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
        public ActionResult Register([FromBody] PostCustomerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            if(dbUnitOfWork.AppUsers.IsEmailUsed(request.Email))
            {
                ModelState.AddModelError("AlreadyUsedEmail", "The Email Address is already in use ,please use different email address address");
                return BadRequest(modelState:ModelState);
            }

            var customer = mapper.Map<Customer>(request);

            dbUnitOfWork.Customers.Add(customer);
            dbUnitOfWork.Save();
            var res = mapper.Map<GetCustomerResponse>(customer);

            return CreatedAtAction(actionName:nameof(CustomersController.GetById), controllerName: "Customers", routeValues: new { id = customer.Id }, res);
        }

        [HttpGet("TestAuth")]
        [Authorize]
        public ActionResult TestAuth()
        {

            return Ok(new
            {
                EmailClaimValue = User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value,
                RoleClaimValue = User.Claims.First(claim => claim.Type == ClaimTypes.Role).Value,
                NameIdentifireClaimValue = User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value,
                UserNameClaimValue = User.Claims.First(claim => claim.Type == ClaimTypes.Name).Value,
            });
        }
    }
}
