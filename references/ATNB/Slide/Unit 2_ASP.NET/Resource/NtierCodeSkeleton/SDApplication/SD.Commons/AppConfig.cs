using System.Configuration;
namespace SD.Commons
{
    public static class AppConfig
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
             }
}
