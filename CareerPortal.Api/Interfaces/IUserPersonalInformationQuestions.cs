using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.DTOs;
using CareerPortal.Models;

namespace CareerPortal.Api.Interfaces
{
    public interface IUserPersonalInformationQuestions
    {
        Task<bool> CreateQuestionAsync(CreateApplicationDTO createApplicationDTO);
        Task<bool> EditQuestionAsync(QuestionDTO createQuestionDTO);
        Task<Question> GetQuestionAsync(QuestionTypes questionType);

    }
}
