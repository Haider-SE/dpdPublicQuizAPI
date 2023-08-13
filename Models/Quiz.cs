using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string QuizName {get; set; }
        [ForeignKey("ClassRoom")]
        public string ClassId {get; set; }
    }
}
