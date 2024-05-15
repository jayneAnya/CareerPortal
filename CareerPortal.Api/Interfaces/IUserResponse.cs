using CareerPortal.Api.DTOs;
using CareerPortal.DTOs;
using CareerPortal.Models;

namespace CareerPortal.Api.Interfaces
{
    public interface IUserResponse
    {
       
        Task<bool> SaveCandidateResponseAsync(SaveCandidateResponseDTO createApplicationDTO);

    }
}
