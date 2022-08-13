using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Model;

namespace RentaCar.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server = localhost; Database = rentacardb; Uid = root; Pwd = 1234",new MySqlServerVersion(new Version(8,0,29)));

        }
        DbSet<Status> Statuses { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Hire> Hires { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<PaymentType> PaymentTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
