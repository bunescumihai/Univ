using AppCore.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.TeacherDtos;
using Univ.Requests.PersonRequests.TeacherRequests;

namespace Univ.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public TeacherController(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{teacherId}")]
    public async Task<IActionResult> GetTeacherById([FromRoute] int teacherId)
    {
        var result = await _mediator.Send(new GetTeacherByIdRequest(teacherId));

        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    
    [HttpGet]
    [Route("teachers")]
    public async Task<IActionResult> GetTeachers()
    {
        var result = await _mediator.Send(new GetTeachersRequest());

        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromForm] CreateTeacherDto teacher, [FromForm] IFormFile image)
    {
        var mapped = _mapper.Map<CreateTeacherDto, Teacher>(teacher);
        
        var result = await _mediator.Send(new CreateTeacherRequest(mapped, image));
        
        if (result is null)
            return BadRequest();
        
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{teacherId}")]
    public async Task<IActionResult> DeleteTeacher([FromRoute] int teacherId)
    {
        var result = await _mediator.Send(new DeleteTeacherRequest(teacherId));
        
        if (!result)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpPut]
    [Route("{teacherId}")]
    public async Task<IActionResult> UpdateTeacher([FromRoute] int teacherId, [FromBody] CreateTeacherDto teacher)
    {
        var mapped = _mapper.Map<CreateTeacherDto, Teacher>(teacher);

        var result = await _mediator.Send(new UpdateTeacherRequest(teacherId, mapped));
        
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
}