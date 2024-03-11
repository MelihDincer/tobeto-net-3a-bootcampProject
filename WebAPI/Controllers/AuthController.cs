using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register/Employee")]
    public async Task<IActionResult> EmployeeRegister(EmployeeForRegisterRequest employeeForRegisterRequest)
    {
        var result = await _authService.EmployeeRegister(employeeForRegisterRequest);
        return HandleDataResult(result);
    }

    [HttpPost("Register/Instructor")]
    public async Task<IActionResult> InstructorRegister(InstructorForRegisterRequest instructorForRegisterRequest)
    {
        var result = await _authService.InstructorRegister(instructorForRegisterRequest);
        return HandleDataResult(result);
    }

    [HttpPost("Register/Applicant")]
    public async Task<IActionResult> ApplicantRegister(ApplicantForRegisterRequest applicantForRegisterRequest)
    {
        var result = await _authService.ApplicantRegister(applicantForRegisterRequest);
        return HandleDataResult(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        var result = await _authService.Login(userForLoginDto);
        return HandleDataResult(result);
    }
}