using AppCore.Dto;
using AppCore.Models;
using AppCore.Models.Enum;
using AppCore.Services;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univ.Dto.AttendanceDtos;
using Univ.Requests.AttendanceRequests;
using Univ.Requests.EducationalGroupRequests;
using QRCode = Univ.Services.QRCode;

namespace Univ.Controllers;


[ApiController]
[Route("[controller]")]
public class AttendanceController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AttendanceController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAttendance([FromBody] CreateAttendanceDto attendanceDto)
    {
        var mapped = _mapper.Map<CreateAttendanceDto, Attendance>(attendanceDto);
        
        var result = await _mediator.Send(new CreateAttendanceRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpPost]
    [Route("qrCode/{qr}")]
    public async Task<IActionResult> CreateAttendanceWithQr([FromRoute] string qr,[FromBody] CreateAttendanceDto attendanceDto)
    {
        var qrCode = QRCode.GetInstance();
        
        if (!qrCode.IsValid(qr))
            return BadRequest();
        
        var mapped = _mapper.Map<CreateAttendanceDto, Attendance>(attendanceDto);
        
        var result = await _mediator.Send(new CreateAttendanceRequest(mapped));

        if (result is null)
            return BadRequest();

        return Ok(result);
    }
    
    [HttpGet]
    [Route("qrCode")]
    public async Task<IActionResult> GetQrCode()
    {
        return Ok(QRCode.GetInstance());
    }

}