using Microsoft.EntityFrameworkCore;

namespace DbSensor.Context
{
  
        public class SensorDbContext : DbContext
        {
        public DbSet<SensorData> SensorReadings { get; set; }

        public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options)
            {
            }

        }
    
}
