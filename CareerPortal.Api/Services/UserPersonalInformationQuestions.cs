using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.Api.Interfaces;
using CareerPortal.Data;
using CareerPortal.DTOs;
using CareerPortal.Models;
using System.Transactions;

namespace CareerPortal.Api.Services
{
    public class UserPersonalInformationQuestions : IUserPersonalInformationQuestions
    {
        private readonly IRepository _repository;
        public UserPersonalInformationQuestions(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateQuestionAsync(CreateApplicationDTO createApplicationDTO)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // Create PersonalInformation object
                    var personalInfo = new CandidateInformation
                    {
                        Email = createApplicationDTO.Email,
                        FirstName = createApplicationDTO.FirstName,
                        LastName = createApplicationDTO.LastName,
                        PhoneNumber = createApplicationDTO.PhoneNumber,
                        Nationality = createApplicationDTO.Nationality,
                        Address = createApplicationDTO.Address,
                        DateOfBirth = createApplicationDTO.DateOfBirth,
                        Gender = createApplicationDTO.Gender
                    };
                    var personalInfoSaved = await _repository.CreateApplicationAsync(personalInfo);

                    if (personalInfoSaved)
                    {
                        var questions = new List<Question>();

                        foreach (var question in createApplicationDTO.Questions)
                        {
                            var quest = new Question
                            {
                                QuestionText = question.QuestionText,
                                CreatedDate = DateTime.Now,
                                type = question.QuestionType,
                            };

                            questions.Add(quest);
                        }
                        var questionsSaved = await _repository.CreateQuestionAsync(questions);
                        if (questionsSaved)
                        {
                            scope.Complete();
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> EditQuestionAsync(QuestionDTO createQuestionDTO)
        {
            var createQuestionModel = new Question
            {
                type = createQuestionDTO.QuestionType,
                QuestionText = createQuestionDTO.QuestionText,
                UpdatedDate = DateTime.Now,
            };
            var res = await _repository.EditQuestionAsync(createQuestionModel);
            if (res) return true;
            return false;
        }
        public async Task<Question> GetQuestionAsync(QuestionTypes questionType)
        {
            var question = questionType.ToString();
            var res = await _repository.GetQuestionAsync(question);
            return res;
        }

        
    }
}
