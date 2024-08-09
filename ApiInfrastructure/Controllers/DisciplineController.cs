using AppCore.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.DisciplineDtos;
using Univ.Requests.DisciplineRequests;

namespace Univ.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplineController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public DisciplineController(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{disciplineId}")]
    public async Task<IActionResult> GetDisciplineById([FromRoute] int disciplineId)
    {
        var result = await _mediator.Send(new GetDisciplineByIdRequest(disciplineId));
        
        var mapped = _mapper.Map<Discipline, DisciplineShortDto>(result);
        
        if (mapped is null)
            return NotFound();

        return Ok(mapped);
    }
    
    
    [HttpGet]
    [Route("disciplines")]
    public async Task<IActionResult> GetDisciplines()
    {
        var result = await _mediator.Send(new GetDisciplinesRequest());

        var mapped = _mapper.Map<List<Discipline>, List<DisciplineShortDto>>(result);
        
        return Ok(mapped);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateDiscipline([FromBody] CreateDisciplineDto discipline)
    {
        var mapped = _mapper.Map<CreateDisciplineDto, Discipline>(discipline);
        
        var result = await _mediator.Send(new CreateDisciplineRequest(mapped));
        
        if (result is null)
            return BadRequest();
        
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{DisciplineId}")]
    public async Task<IActionResult> DeleteDiscipline([FromRoute] int disciplineId)
    {
        var result = await _mediator.Send(new DeleteDisciplineRequest(disciplineId));
        
        if (!result)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpPut]
    [Route("{DisciplineId}")]
    public async Task<IActionResult> UpdateDiscipline([FromRoute] int disciplineId, [FromBody] CreateDisciplineDto discipline)
    {
        var mapped = _mapper.Map<CreateDisciplineDto, Discipline>(discipline);
        var result = await _mediator.Send(new UpdateDisciplineRequest(disciplineId, mapped));
        
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
}