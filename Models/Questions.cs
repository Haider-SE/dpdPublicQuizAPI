using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("QuestionType")]
        public Guid QuestionTypeID { get; set; }
        public string QuestionText { get; set; }
        public bool isActive { get; set; }
    }
}
