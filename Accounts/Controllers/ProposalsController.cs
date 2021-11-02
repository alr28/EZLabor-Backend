
using AutoMapper;
using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Services;
using EZLaborAPI.Accounts.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Accounts.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class ProposalsController : ControllerBase
    {

        private readonly IProposalService _proposalService;
        private readonly IMapper _mapper;

        public ProposalsController(IProposalService proposalService, IMapper mapper)
        {
            _proposalService = proposalService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all proposals",
            Description = "Get Proposals all proposals",
            OperationId = "ListAllProposals")]
        [HttpGet]
        public async Task<IEnumerable<ProposalResource>> GetAllAsync()
        {
            var proposals = await _proposalService.ListAsync();

            var resources = _mapper
                .Map<IEnumerable<Proposal>, IEnumerable<ProposalResource>>(proposals);
            return resources;
        }

        /*

        [SwaggerOperation(
            Summary = "Get proposal",
            Description = "Get a proposal by Id",
            OperationId = "GetProposal")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProposalResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _proposalService.ListByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var skillResource = _mapper.Map<Proposal, Proposal>(result.Resource);
            return Ok(skillResource);
        }

        

        [SwaggerOperation(
            Summary = "Post proposal",
            Description = "Post a new proposal",
            OperationId = "PostProposal")]
        [HttpPost]
        [ProducesResponseType(typeof(ProposalResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProposalResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var proposal = _mapper.Map<SaveProposalResource, Proposal>(resource);
            var result = await _proposalService.SaveAsync(proposal);


            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }

        [SwaggerOperation(
            Summary = "Delete proposals",
            Description = "Delete an Proposal",
            OperationId = "DeleteProposal")]
        [HttpDelete("employer/{employerId}")]
        public async Task<IActionResult> UnassignProposal(int employerId, int freelancerId)
        {
            var result = await _proposalService.UnassignProposalAsync(employerId, freelancerId);
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource.Employer);
            return Ok(employerResource);

        }

        */


    }
}
