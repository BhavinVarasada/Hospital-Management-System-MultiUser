namespace Hospital_Management_System.DAL
{
    public class DALHelper
    {
        #region Database connection string
        public static string MyConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
        #endregion
    }
}
