using Microsoft.EntityFrameworkCore;

namespace FoodAutomation{
      public class BContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=127.0.0.1,1433;Database=proTest;User ID=CommanderAPI;Password=*******;");
    }
}