using AppCore.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.EducationalInstitutionDtos;
using Univ.Requests.EducationalInstitutionRequests;

namespace Univ.Controllers;


[ApiController]
[Route("[controller]")]
public class EducationalInstitutionController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public EducationalInstitutionController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    
    [HttpGet]
    [Route("educationalInstitutions")]
    public async Task<IActionResult> GetEducationalInstitutions()
    {
        var result = await _mediator.Send(new GetEducationalInstitutionsRequest());

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{educationalInstitutionId}")]
    public async Task<IActionResult> GetEducationalInstitutions([FromRoute] int educationalInstitutionId)
    {
        var result = await _mediator.Send(new GetEducationalInstitutionRequest(educationalInstitutionId));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateEducationalInstitution([FromBody] CreateEducationalInstitutionDto institutionDto)
    {
        var mapped = _mapper.Map<CreateEducationalInstitutionDto, EducationalInstitution>(institutionDto);
        
        var result = await _mediator.Send(new CreateEducationalInstitutionRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    
    [HttpDelete]
    [Route("{educationalInstitutionId}")]
    public async Task<IActionResult> DeleeteEducationalInstitution([FromRoute] int educationalInstitutionId)
    {
        var result = await _mediator.Send(new DeleteEducationalInstitutionRequest(educationalInstitutionId));

        if (!result)
            return BadRequest();

        return Ok(result);
    }
}