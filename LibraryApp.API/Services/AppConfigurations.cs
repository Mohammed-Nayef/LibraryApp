namespace LibraryApp.API.Services
{
    public class AppConfigurations
    {
        public AppConfigurations(IConfiguration configuration)
        {
            try
            {

            }
            catch (Exception)
            {
                throw new ArgumentException("You missed one or more Configurations, ensure everthing is " +
                    "setted proparlly in the appsettings.json file");
            }
        }
    }
}
