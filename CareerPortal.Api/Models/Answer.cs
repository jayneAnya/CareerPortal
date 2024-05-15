using CareerPortal.Api.Models;

namespace CareerPortal.Models
{
    public class Answer : BaseEntity
    {
        public required string ApplicantId { get; set; }
        public int QuestionId { get; set; }
        public required string Response {  get; set; }    
    }
}
