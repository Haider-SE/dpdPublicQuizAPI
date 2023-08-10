using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class Answers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Questions")]
        public Guid QuestionID { get; set; }
        public string AnswerText { get; set; }
        public bool isCorrect { get; set; }
    }
}
