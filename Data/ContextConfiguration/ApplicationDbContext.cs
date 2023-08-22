using dpdPublicQuizAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace dpdPublicQuizAPI.Data.ContextConfiguration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<QuestionsType> QuestionType { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
