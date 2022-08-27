using Microsoft.EntityFrameworkCore;
using RentaCar.Core.Model;

namespace RentaCar.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Hire> Hires { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<PaymentType> PaymentTypes { get; set; }
        DbSet<CarImage> CarImages { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("Server = localhost; Database = rentacardb; Uid = root; Pwd =" +
        //        " 1234", new MySqlServerVersion(new Version(8, 0, 29)));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
            .HasOne(b => b.Category)
            .WithOne(i => i.Car)
            .HasForeignKey<Car>(b => b.CategoriesId);
        }
    }
    
}

