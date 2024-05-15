using CareerPortal.Api.DTOs;
using CareerPortal.DTOs;
using CareerPortal.Models;

namespace CareerPortal.Data
{
    public interface IRepository
    {
        Task<bool> CreateApplicationAsync(CandidateInformation createApplicationDTO);
        Task<bool> EditApplicationAsync(CandidateInformation createApplicationDTO);
        Task<bool> SaveCandidateResponseAsync(List<Answer> createApplicationDTO);
        Task<Question> GetQuestionAsync(string questionType);
        Task<bool> CreateQuestionAsync(Question createApplicationDTO);

    }
}
