using Microsoft.EntityFrameworkCore;
using Training_diary.Model;

namespace Training_diary.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
    }
}
