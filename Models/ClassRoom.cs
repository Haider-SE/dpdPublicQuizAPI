using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dpdPublicQuizAPI.Models
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Teacher")]
        public Guid TeacherId { get; set; }
        public Guid Id { get; set; }
        public string ClassName { get; set; }
    }
}
