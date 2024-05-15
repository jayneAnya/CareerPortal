using CareerPortal.Api.Enum;
using CareerPortal.Api.Models;

namespace CareerPortal.Models
{
    public class Question : BaseEntity
    {
        public required string QuestionText { get; set; }
        public required QuestionTypes type { get; set; }
    }
    
}
