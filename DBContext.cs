using FoodAutomation.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodAutomation{
      public class BContext : DbContext
    {
        //very important : define a many to many relation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonFood>().HasKey(pf=>new{pf.FoodId,pf.PersonId});
            modelBuilder.Entity<PersonFood>().HasOne(pf=>pf.Person).WithMany(p=>p.PersonFood).HasForeignKey(pf=>pf.PersonId);
            modelBuilder.Entity<PersonFood>().HasOne(pf=>pf.Food).WithMany(p=>p.PersonFood).HasForeignKey(pf=>pf.FoodId);
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonFood> PersonFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=127.0.0.1,1433;Database=proTest;User ID=CommanderAPI;Password=25686471;");
    }
}