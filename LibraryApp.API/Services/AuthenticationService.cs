using LibraryApp.API.DTOs.Requests;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.API.Services
{
    public class AuthenticationService
    {
        private readonly AppConfigurations appConfigurations;
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;

        public AuthenticationService(AppConfigurations appConfigurations, ILibraryDbUnitOfWork dbUnitOfWork)
        {
            this.appConfigurations = appConfigurations;
            this.dbUnitOfWork = dbUnitOfWork;
        }
        public string GenerateToken(AppUser appUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, appUser.Role),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Name,$"{appUser.FirstName} {appUser.LastName}"),
                new Claim(ClaimTypes.DateOfBirth,appUser.Birthdate.ToString())
            };


            if(appUser.Role == "Employee")
            {
                var employee = dbUnitOfWork.Employees.Find(emp => emp.AppUserId == appUser.Id).FirstOrDefault();
                claims.Add(new Claim("title", employee.Title));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()));
            }
            else if(appUser.Role =="Customer")
            {
                var customer = dbUnitOfWork.Customers.Find(customer => customer.AppUserId == appUser.Id).FirstOrDefault();

                claims.Add(new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()));
            }
            else
            {
                var author = dbUnitOfWork.Authors.Find(author => author.AppUserId == appUser.Id).FirstOrDefault();

                claims.Add(new Claim(ClaimTypes.NameIdentifier, author.Id.ToString()));
            }

            // genereate jwt token with the same configurations that are registered
            var keyStr = appConfigurations.JwtSecret;
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(keyStr));

            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: appConfigurations.JwtIssuer,
                audience: appConfigurations.JwtAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                notBefore:DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(2)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }
    }
}
