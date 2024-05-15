using CareerPortal.Api.Enum;

namespace CareerPortal.Api.DTOs
{
    public class QuestionDTO
    {
        public required string QuestionText { get; set; }
        public required QuestionTypes QuestionType { get; set; }
    }
}
