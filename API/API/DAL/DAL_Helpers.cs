namespace API.DAL
{
    public class DAL_Helpers
    {
        public static string Conn = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    }
}
