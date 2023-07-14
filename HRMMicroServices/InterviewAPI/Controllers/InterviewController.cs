using Interview.Core.Contracts.Services;
using Interview.Core.Models;
using Interview.Core.Models.External;
using InterviewAPI.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace InterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService service;
        public InterviewController(IInterviewService service)
        {
            this.service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.AddInterviewAsync(model));
            }
            return BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetInterviewByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviews());
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewAsync(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewAsync(model));
            }
            return BadRequest();
        }
        [HttpGet("OrganizeInterview")]
        public async Task<IActionResult> Organize(int SubmissionId)
        {
            HttpClient client = new HttpClient();
            var submissionResponse = await client.GetFromJsonAsync<SubmissionResponseModel>(ApiUrls.GetSubmission + SubmissionId);
            if (submissionResponse == null)
            {
                return BadRequest();
            }
            var candidateResponse = await client.GetFromJsonAsync<CandidateResponseModel>(ApiUrls.GetCandidate + submissionResponse.CandidateId);
            if (candidateResponse == null)
            {
                return BadRequest();
            }
            InterviewerRequestModel model = new InterviewerRequestModel
            {
                FirstName = candidateResponse.FirstName,
                LastName = candidateResponse.LastName,
                EmployeeId = candidateResponse.CandidateId
            };
            // todo
            // find a proper recruiter response this interview
            var interviewerResponse = await client.PostAsJsonAsync("http://host.docker.internal:40125/api/interviewer/create", model);
            InterviewRequestModel model2 = new InterviewRequestModel
            {
                RecruiterId = 1,
                SubmissionId = submissionResponse.SubmissionId,
                InterviewTypeCode = 1,
                InterviewRound = 1,
                ScheduledOn = DateTime.Today,
                InterviewerId = Convert.ToInt32(await interviewerResponse.Content.ReadAsStringAsync()),
            };
            return await Create(model2);

        }

        [HttpGet("GetCandidate")]
        public async Task<IActionResult> GetCandidate()
        {
            string str = "http://host.docker.internal:40123/api/candidate/getall";
            HttpClient client = new HttpClient();
            //  client.BaseAddress = new Uri( "http://localhost:40123/api/");
            var candidateResponse = await client.GetFromJsonAsync<IEnumerable<CandidateResponseModel>>(str);
            return Ok(candidateResponse);
        }
    }
}
