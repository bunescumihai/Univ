using AppCore.Models;
using AppCore.Models.Enum;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.PairDtos;
using Univ.Requests.PairRequests;

namespace Univ.Controllers;

[ApiController]
[Route("[controller]")]
public class PairController : ControllerBase
{
    
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PairController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    
    [HttpPost]
    public async Task<IActionResult> CreatePair([FromBody] CreatePairDto pairDto)
    {
        var mapped = _mapper.Map<CreatePairDto, Pair>(pairDto);
        var result = await _mediator.Send(new CreatePairRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpPost]
    [Route("pairAcademicGroup")]
    public async Task<IActionResult> CreatePairAcademicGroup([FromBody] CreatePairAcademicGroupDto pairAcademicGroupDto)
    {
        var mapped = _mapper.Map<CreatePairAcademicGroupDto, PairAcademicGroup>(pairAcademicGroupDto);
        
        var result = await _mediator.Send(new CreatePairAcademicGroupRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    
    [HttpDelete]
    [Route("{pairId}")]
    public async Task<IActionResult> DeletePair([FromRoute] int pairId)
    {
        var result = await _mediator.Send(new DeletePairRequest(pairId));

        if (!result)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpGet]
    [Route("{weekDay}")]
    public async Task<IActionResult> GetPairsByWeekDay([FromRoute] WeekDay weekDay)
    {
        var result = await _mediator.Send(new GetPairsByWeekDayRequest(weekDay));

        return Ok(result);
    }
}