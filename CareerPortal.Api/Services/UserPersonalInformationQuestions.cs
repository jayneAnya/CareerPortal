using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.Api.Interfaces;
using CareerPortal.Data;
using CareerPortal.DTOs;
using CareerPortal.Models;

namespace CareerPortal.Api.Services
{
    public class UserPersonalInformationQuestions : IUserPersonalInformationQuestions
    {
        private readonly IRepository _repository;
        public UserPersonalInformationQuestions(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreatePersonalInformationAsync(CreateApplicationDTO createApplicationDTO)
        {
            try
            {
                var createApplicationModel = new CandidateInformation
                {
                    Address = createApplicationDTO.Address,
                    DateOfBirth = createApplicationDTO.DateOfBirth,
                    Email = createApplicationDTO.Email,
                    FirstName = createApplicationDTO.FirstName,
                    Gender = createApplicationDTO.Gender,
                    LastName = createApplicationDTO.LastName,
                    Nationality = createApplicationDTO.Nationality,
                    PhoneNumber = createApplicationDTO.PhoneNumber,
                };
                var res = await _repository.CreateApplicationAsync(createApplicationModel);
                if (res)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> EditPersonalInformationAsync(CreateApplicationDTO createApplicationDTO)
        {
            var createApplicationModel = new CandidateInformation
            {
                Address = createApplicationDTO.Address,
                DateOfBirth = createApplicationDTO.DateOfBirth,
                Email = createApplicationDTO.Email,
                FirstName = createApplicationDTO.FirstName,
                Gender = createApplicationDTO.Gender,
                LastName = createApplicationDTO.LastName,
                Nationality = createApplicationDTO.Nationality,
                PhoneNumber = createApplicationDTO.PhoneNumber,
            };
            var res = await _repository.EditApplicationAsync(createApplicationModel);
            if (res) return true;
            return false;
        }
        public async Task<Question> GetQuestionAsync(QuestionTypes questionType)
        {
            var question = questionType.ToString();
            var res = await _repository.GetQuestionAsync(question);
            return res;
        }

        public async Task<bool> CreateQuestionAsync(QuestionDTO createApplicationDTO)
        {
            var createQuestion = new Question
            {
                QuestionText = createApplicationDTO.QuestionText,
                type = createApplicationDTO.QuestionType,
            };

            var res = await _repository.CreateQuestionAsync(createQuestion);
            if (res) return true;
            return false;
        }


    }
}
