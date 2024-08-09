using AppCore.Dto;
using AppCore.Models;
using AppCore.Models.Enum;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Requests.EducationalGroupRequests;

namespace Univ.Controllers;


[ApiController]
[Route("[controller]")]
public class AcademicGroupController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AcademicGroupController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    
    [HttpGet]
    [Route("academicGroups")]
    public async Task<IActionResult> GetAcademiGroups()
    {
        List<AcademicGroup> academicGroups = await _mediator.Send(new GetAcademicGroupsRequest());
        
        return Ok(academicGroups);
    }
    
    [HttpGet]
    [Route("year/{studyYear}")]
    public async Task<IActionResult> GetAcademicGroupsByYear([FromRoute] StudyYear studyYear)
    {
        
        List<AcademicGroup> academicGroups = await _mediator.Send(new GetAcademicGroupsByYearRequest(studyYear));
        
        var result = _mapper.Map<List<AcademicGroup>, List<AcademicGroupShortDto>>(academicGroups);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAcademicGroup([FromBody] CreateAcademicGroupDto academicGroup)
    {
        var result = await _mediator.Send(new CreateAcademicGroupRequest(academicGroup.Name, academicGroup.StudyYear, academicGroup.SpecialityId));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }

    [HttpPut]
    [Route("{academicGroupId}")]
    public async Task<IActionResult> UpdateAcademicGroup([FromRoute] int academicGroupId,
        [FromBody] CreateAcademicGroupDto academicGroup)
    {
        var result = await _mediator.Send(new UpdateAcademicGroupRequest(academicGroupId, academicGroup.Name));
        
        if (result is null)
            return BadRequest();

        var mapped =  _mapper.Map<AcademicGroup, AcademicGroupShortDto>(result);
        
        return Ok(mapped);
    }

    [HttpDelete]
    [Route("{academicGroupId}")]
    public async Task<IActionResult> DeleteAcademicGroup([FromRoute] int academicGroupId)
    {
        var result = await _mediator.Send(new DeleteAcademicGroupRequest(academicGroupId));
        
        if (result)
            return Ok();
        
        return BadRequest();
    }
    
    [HttpGet]
    public async Task<IActionResult> ExistsAcademicGroup([FromQuery] string name)
    {
        var response = await _mediator.Send(new ExistsAcademicGroupRequest(name));
        
        if (response)
            return Ok(response);
        
        return NotFound();
    }
    
    [HttpGet]
    [Route("{academicGroupId}")]
    public async Task<IActionResult> GetAcademicGroupById([FromRoute] int academicGroupId)
    {
        var response = await _mediator.Send(new GetAcademicGroupByIdWithStudentsRequest(academicGroupId));
        
        if (response is null)
            return NotFound(response);
        
        
        return Ok(response);
    }
}