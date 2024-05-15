using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.DTOs;
using CareerPortal.Models;

namespace CareerPortal.Api.Interfaces
{
    public interface IUserPersonalInformationQuestions
    {
        Task<bool> CreatePersonalInformationAsync(CreateApplicationDTO createApplicationDTO);
        Task<bool> EditPersonalInformationAsync(CreateApplicationDTO createApplicationDTO);
        Task<Question> GetQuestionAsync(QuestionTypes questionType);
        Task<bool> CreateQuestionAsync(QuestionDTO createApplicationDTO);

    }
}
