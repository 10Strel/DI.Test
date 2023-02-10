using DI.Test.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DI.Test.Data
{
    public class MsSqlDbContext : DbContext
    {
        private static readonly AppSettings appSettings;

        public DbSet<User> Users { get; set; }

        static MsSqlDbContext()
        {
            appSettings = new AppSettings();

            IConfigurationRoot _configurationRoot;
            try
            {
                _configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("DI.Test.Data.AppSettings.json")
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
                GetConnectionString(),
                b => { b.MigrationsAssembly("DI.Test.Data"); b.CommandTimeout(120); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<User>().OwnsOne(p => p.Name);
            modelBuilder.Entity<User>().OwnsOne(p => p.Location);
            modelBuilder.Entity<User>().OwnsOne(p => p.Login);
            modelBuilder.Entity<User>().OwnsOne(p => p.DoB);
            modelBuilder.Entity<User>().OwnsOne(p => p.Registered);
            modelBuilder.Entity<User>().OwnsOne(p => p.UserId);
            modelBuilder.Entity<User>().OwnsOne(p => p.Picture);
        }

        public void DetachAllEntities()
        {
            this.ChangeTracker.Entries().ToList()
                .ForEach(x => x.State = EntityState.Detached);
        }
    }
}
