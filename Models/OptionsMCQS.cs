using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class OptionsMCQS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Questions")]
        public Guid QuestionID { get; set; }
        public string OptionText { get; set; }
        public bool isCorrect { get; set; }
    }
}
