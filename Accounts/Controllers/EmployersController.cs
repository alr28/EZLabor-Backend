﻿using AutoMapper;
using EZLaborAPI.Accounts.Domain.Model;
using EZLaborAPI.Accounts.Domain.Services;
using EZLaborAPI.Accounts.Resources;
using EZLaborAPI.Commons.Extensions;
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
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public EmployersController(IEmployerService employerService, IMapper mapper)
        {
            _employerService = employerService;
            _mapper = mapper;
        }
        /*
        [SwaggerOperation(
            Summary = "List all employers",
            Description = "List of Employers",
            OperationId = "ListAllEmployers")]
        [SwaggerResponse(200, "List of Employers", typeof(IEnumerable<EmployerResource>))]
        */
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IEmployerService>), 200)]
        public async Task<IEnumerable<EmployerResource>> GetAllAsync()
        {
            var employers = await _employerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Employer>, IEnumerable<EmployerResource>>(employers);

            return resources;
        }


        [SwaggerOperation(
            Summary = "Get employer",
            Description = "Get an Employer by Id",
            OperationId = "GetEmployer")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _employerService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [SwaggerOperation(
            Summary = "Post employer",
            Description = "Post a new Employer",
            OperationId = "PostEmployer")]
        [HttpPost]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.SaveAsync(employer);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [SwaggerOperation(
            Summary = "Update employer",
            Description = "Update an Employer",
            OperationId = "UpdateEmployer")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.UpdateAsync(id, employer);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

        [SwaggerOperation(
            Summary = "Delete employer",
            Description = "Delete an Employer",
            OperationId = "DeleteEmployer")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmployerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, EmployerResource>(result.Resource);
            return Ok(employerResource);
        }

    }
}
