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

        [HttpPost("user-info")]
        public async Task<IActionResult> CreateApplication(CreateApplicationDTO createApplication)
        {
            var result = await _service.CreatePersonalInformationAsync(createApplication);
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

        [HttpPost("edit-user-info")]
        public async Task<IActionResult> EditApplication(CreateApplicationDTO createApplication)
        {
            var result = await _service.EditPersonalInformationAsync(createApplication);
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

        [HttpPost("get-user-info")]
        public async Task<IActionResult> GetPersonalInformationQuestion(QuestionTypes questionType)
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

        [HttpPost("create-question")]
        public async Task<IActionResult> CreateQuestion(QuestionDTO createApplication)
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
    }
}
