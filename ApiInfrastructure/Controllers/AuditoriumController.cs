using AppCore.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.AuditoriumDtos;
using Univ.Requests.AuditoriumRequests;

namespace Univ.Controllers;

[ApiController]
[Route("[controller]")]
public class AuditoriumController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public AuditoriumController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAuditorium([FromBody] CreateAuditoriumDto auditorium)
    {
        var mapped = _mapper.Map<CreateAuditoriumDto, Auditorium>(auditorium);
        
        var result = await _mediator.Send(new CreateAuditoriumRequest(mapped));
        
        if (result is null)
            return BadRequest();
        
        return Ok(result);
    }
    
    
    [HttpDelete]
    [Route("{auditoriumId}")]
    public async Task<IActionResult> DeleteAuditorium([FromRoute] int auditoriumId)
    {
        var result = await _mediator.Send(new DeleteAuditoriumRequest(auditoriumId));
        
        if (!result)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpGet]
    [Route("auditoriums")]
    public async Task<IActionResult> GetPairs()
    {
        var result = await _mediator.Send(new GetAuditoriumsRequest());

        var mapped = _mapper.Map<List<Auditorium>, List<AuditoriumShortDto>>(result);
        
        return Ok(mapped);
    }

    
}