using dpdPublicQuizAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace dpdPublicQuizAPI.Data.ContextConfiguration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<QuestionsType> QuestionType { get; set; }
    }
}
