﻿using System.ComponentModel.DataAnnotations;
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
        [ForeignKey("Options")]
        public Guid OptionID { get; set; }
        public string OpenEndedAnswerText { get; set; }
        public bool isCorrect { get; set; }
    }
}
