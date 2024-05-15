using CareerPortal.Api.DTOs;
using CareerPortal.Api.Enum;
using CareerPortal.Api.Interfaces;
using CareerPortal.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUserPersonalInformationQuestions _service;
        public QuestionController(IUserPersonalInformationQuestions service)
        {
            _service = service;
        }

        [HttpPost("create-question")]
        public async Task<IActionResult> CreateQuestion(CreateApplicationDTO createApplication)
        {
            var result = await _service.CreateQuestionAsync(createApplication);
            if (result)
                return Ok(new ResponseDTO
                {
                    Data = result,
                    Status = true,
                    Message = "Successful"
                });

            else
            {
                return BadRequest(new ResponseDTO
                {
                    Data = result,
                    Status = false,
                    Message = "Error occured, pls try again"
                });
            }

        }

        [HttpPost("edit-question")]
        public async Task<IActionResult> EditQuestion(QuestionDTO createQuestion)
        {
            var result = await _service.EditQuestionAsync(createQuestion);
            if (result)
                return Ok(new ResponseDTO
                {
                    Data = result,
                    Status = true,
                    Message = "Successful"
                });

            else
            {
                return BadRequest(new ResponseDTO
                {
                    Data = result,
                    Status = false,
                    Message = "Error occured, pls try again"
                });
            }

        }

        [HttpPost("get-question")]
        public async Task<IActionResult> GetQuestion(QuestionTypes questionType)
        {
            var result = await _service.GetQuestionAsync(questionType);
            if (result != null)
                return Ok(new ResponseDTO
                {
                    Data = result,
                    Status = true,
                    Message = "Successful"
                });

            else
            {
                return BadRequest(new ResponseDTO
                {
                    Status = false,
                    Message = "Record not found"
                });
            }

        }

       
    }
}
