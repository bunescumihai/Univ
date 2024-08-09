using AppCore.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.TimeDistributionDtos;
using Univ.Requests.TimeDistributionRequests;

namespace Univ.Controllers;


[ApiController]
[Route("[controller]")]
public class TimeDistributionController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TimeDistributionController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    
    [HttpGet]
    [Route("{educationalInstitutionId}")]
    public async Task<IActionResult> GetTimeDistributionsByEducationalInstitution([FromRoute] int educationalInstitutionId)
    {
        var result = await _mediator.Send(new GetTimeDistributionsByEducationalInstitutionRequest(educationalInstitutionId));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetEducationalInstitutions([FromBody] CreateTimeDistributionDto timeDistributionDto)
    {
        var mapped = _mapper.Map<CreateTimeDistributionDto, TimeDistribution>(timeDistributionDto);
        
        var result = await _mediator.Send(new CreateTimeDistributionRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    
    [HttpDelete]
    [Route("{timeDistributionId}")]
    public async Task<IActionResult> DeleteEducationalInstitution([FromRoute] int timeDistributionId)
    {
        var result = await _mediator.Send(new DeleteTimeDistributionRequest(timeDistributionId));

        if (!result)
            return BadRequest();

        return Ok(result);
    }
}