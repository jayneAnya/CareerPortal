using CareerPortal.Api.Enum;
using CareerPortal.Models;

namespace CareerPortal.DTOs
{
    public class QuestionandAnswer
    {
        public int QuestionId { get; set; }
        public required string Answer { get; set; }

    }
}
