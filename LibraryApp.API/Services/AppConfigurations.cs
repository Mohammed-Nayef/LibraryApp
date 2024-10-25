namespace LibraryApp.API.Services
{
    public class AppConfigurations
    {
        public required string JwtSecret{ get; set; }
        public required string JwtAudience { get; set; }
        public required string JwtIssuer { get; set; }
        public int BooksMaxPageSize { get; set; } = 10;
        public AppConfigurations(IConfiguration configuration)
        {

            try
            {
                JwtSecret = configuration["Authentication:SecretKey"];
                JwtAudience = configuration["Authentication:Audience"];
                JwtIssuer = configuration["Authentication:Issuer"];

            }
            catch (Exception)
            {
                throw new ArgumentException("You missed one or more Configurations, ensure everthing is " +
                    "setted proparlly in the appsettings.json file");
            }
        }
    }
}
