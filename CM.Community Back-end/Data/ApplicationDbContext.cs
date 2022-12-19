using CM.Community_Back_end;
using Microsoft.EntityFrameworkCore;

namespace CmCommunityBackend.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}