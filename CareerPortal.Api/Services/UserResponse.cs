using CareerPortal.Api.DTOs;
using CareerPortal.Api.Interfaces;
using CareerPortal.Data;
using CareerPortal.DTOs;
using CareerPortal.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CareerPortal.Services
{
    public class UserResponse : IUserResponse
    {
        private readonly IRepository _repository;
        public UserResponse(IRepository repository)
        {
            _repository = repository;
        }
       
       
        public async Task<bool> SaveCandidateResponseAsync(SaveCandidateResponseDTO request)
        {
            var personalInfo = new CandidateInformation
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Nationality = request.Nationality,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender
            };
            var isSavedpersonalInfo = await _repository.CreateApplicationAsync(personalInfo);

            if (isSavedpersonalInfo)
            {
                var answers = new List<Answer>();

                foreach (var question in request.Questions)
                {
                    var answer = new Answer
                    {
                        ApplicantId = request.Email,
                        QuestionId = question.QuestionId,
                        Response = question.Answer
                    };

                    answers.Add(answer);
                }
                var questionsSaved = await _repository.SaveCandidateResponseAsync(answers);
                if (questionsSaved)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
