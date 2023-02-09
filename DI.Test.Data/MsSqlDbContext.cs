using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DI.Test.Data
{
    public class MsSqlDbContext : DbContext
    {
        private static readonly AppSettings appSettings;
                     
        static MsSqlDbContext()
        {
            appSettings = new AppSettings();

            IConfigurationRoot _configurationRoot;
            try
            {
                _configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("DI.Text.Data.AppSettings.json")
                .Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            var section = _configurationRoot.GetSection(nameof(AppSettings));
            section.Bind(appSettings);
        }

        public static string GetConnectionString()
        {
            return appSettings.ConnectionString;
        }
    
        public MsSqlDbContext() : base() { }

        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                GetConnectionString(), b => b.MigrationsAssembly("DI.Test.Data"));
        }
    }
}
