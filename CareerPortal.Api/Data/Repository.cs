using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.Data;
using CareerPortal.DTOs;
using CareerPortal.Models;
using Microsoft.Azure.Cosmos;

namespace Candidate_Application.Data
{
    public class Repository : IRepository
    {
        private readonly Container _container;

        public Repository(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task<Question> GetQuestionAsync(string questionType)
        {
            try
            {
                var response = await _container.ReadItemAsync<Question>(questionType, new PartitionKey(questionType));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<bool> CreateApplicationAsync(CandidateInformation personalInformation)
        {
            var response = await _container.CreateItemAsync(personalInformation, new PartitionKey(personalInformation.Id));
            if (response.Resource != null)            
                return true;            
            return false;
        }

        public async Task<bool> EditQuestionAsync(Question question)
        {
            var existingQuestion = await _container.ReadItemAsync<Question>(question.Id.ToString(), new PartitionKey(question.Id));

            if (existingQuestion == null)
            {
                return false;
            }

            var result = await _container.ReplaceItemAsync(question, question.Id.ToString(), new PartitionKey(question.Id.ToString()));
            if (result != null)
                return true;
            return false;
        }

        public async Task<bool> SaveCandidateResponseAsync(List<Answer> answers)
        {
            var batch = _container.CreateTransactionalBatch(new PartitionKey(answers[0].ApplicantId));

            foreach (var answer in answers)
            {
                batch.CreateItem(answer);
            }
            var response = await batch.ExecuteAsync();

            if (response.IsSuccessStatusCode)
            {
                foreach (var operationResult in response)
                {
                    if (!operationResult.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CreateQuestionAsync(List<Question> questions)
        {
            var batch = _container.CreateTransactionalBatch(new PartitionKey(questions.First().Id));

            foreach (var question in questions)
            {
                batch.CreateItem(question);
            }
            var response = await batch.ExecuteAsync();

            if (response.IsSuccessStatusCode)
            {
                foreach (var operationResult in response)
                {
                    if (!operationResult.IsSuccessStatusCode)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
