using AppCore.Dto;
using AppCore.Models;
using AppCore.Models.Enum;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Requests.EducationalGroupRequests;
using Univ.Dto.SpecialityDtos;
using Univ.Requests.SpecialityRequests;

namespace Univ.Controllers;


[ApiController]
[Route("[controller]")]
public class SpecialityController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SpecialityController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    
    [HttpGet]
    [Route("specialities")]
    public async Task<IActionResult> GetEducationalInstitutions()
    {
        var result = await _mediator.Send(new GetSpecialitiesRequest());

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{specialityId}")]
    public async Task<IActionResult> GetEducationalInstitutions([FromRoute] int specialityId)
    {
        var result = await _mediator.Send(new GetSpecialityRequest(specialityId));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSpeciality([FromBody] CreateSpecialityDto specialityDto)
    {
        var speciality = _mapper.Map<CreateSpecialityDto, Speciality>(specialityDto);
        
        var result = await _mediator.Send(new CreateSpecialityRequest(speciality));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    
    [HttpDelete]
    [Route("{specialityId}")]
    public async Task<IActionResult> DeleeteEducationalInstitution([FromRoute] int specialityId)
    {
        var result = await _mediator.Send(new DeleteSpecialityRequest(specialityId));

        if (!result)
            return BadRequest();

        return Ok(result);
    }
}