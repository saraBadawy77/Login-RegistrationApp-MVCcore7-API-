using Microsoft.EntityFrameworkCore;

namespace RegistrationApp.Models
{
    public class RegistrationDbcontext :DbContext
    {

        public RegistrationDbcontext() : base()
        {

        }

        public RegistrationDbcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Registration> registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=2B_registrations;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
