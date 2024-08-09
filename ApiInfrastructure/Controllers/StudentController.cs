using AppCore.Dto;
using AppCore.Models;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto;
using Univ.Requests.PersonRequests.StudentRequests;

namespace Univ.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public StudentController(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{studentId}")]
    public async Task<IActionResult> GetStudentById([FromRoute] int studentId)
    {
        var result = await _mediator.Send(new GetStudentByIdRequest(studentId));
        
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    
    [HttpGet]
    [Route("students")]
    public async Task<IActionResult> GetStudents()
    {
        var result = await _mediator.Send(new GetStudentsRequest());
        
        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromForm] IFormFile image,[FromForm] CreateStudentDto student)
    {
        /*ValidationResult validationResult = await _validator.ValidateAsync(student);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);*/

        var mapped = _mapper.Map<CreateStudentDto, Student>(student);
        
        var result = await _mediator.Send(new CreateStudentRequest(mapped, image));
        
        if (result is null)
            return BadRequest();
            
        return Ok(result);
    }
    
    [HttpGet]
    [Route("createStudentInfo")]
    public async Task<IActionResult> CreateStudentInfo()
    {
        return Ok(await _mediator.Send(new CreateStudentInfoRequest()));
    }
    
    [HttpDelete]
    [Route("{studentId}")]
    public async Task<IActionResult> DeleteStudent([FromRoute] int studentId)
    {
        var result = await _mediator.Send(new DeleteStudentRequest(studentId));
        
        if (!result)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpPut]
    [Route("{studentId}")]
    public async Task<IActionResult> UpdateStudent([FromRoute] int studentId, [FromBody] CreateStudentDto student)
    {
        var mapped = _mapper.Map<CreateStudentDto, Student>(student);

        var result = await _mediator.Send(new UpdateStudentRequest(studentId, mapped));
        
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
}