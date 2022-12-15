using CM.Community_Back_end;
using Microsoft.EntityFrameworkCore;

namespace CmCommunityBackend.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public DbSet<WeatherForecast>? Weather { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}