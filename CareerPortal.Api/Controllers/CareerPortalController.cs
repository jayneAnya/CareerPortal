using CareerPortal.Api.DTOs;
using CareerPortal.Api.Interfaces;
using CareerPortal.Data;
using CareerPortal.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerPortalController : ControllerBase
    {
        private readonly IUserResponse _service;

        public CareerPortalController(IUserResponse service  )
        {
            _service = service;
        }

        
        [HttpPost("user-response")]
        public async Task<IActionResult> SaveApplication(SaveCandidateResponseDTO saveApplication)
        {
            var result = await _service.SaveCandidateResponseAsync(saveApplication);
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
                    Message = "Record not found"
                });
            }

        }

        
    }
}
