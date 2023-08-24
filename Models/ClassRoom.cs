using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        [ForeignKey("Users")]
        public Guid TeacherId { get; set; }
        public string ClassName { get; set; }
        public ICollection<Users> Students { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }

    }
}
