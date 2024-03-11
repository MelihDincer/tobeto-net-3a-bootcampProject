﻿using Business.Requests.Applicants;
using Business.Requests.Employees;
using Business.Requests.Instructors;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    Task<DataResult<AccessToken>> EmployeeRegister(EmployeeForRegisterRequest employeeForRegisterRequest);
    Task<DataResult<AccessToken>> InstructorRegister(InstructorForRegisterRequest instructorForRegisterRequest);
    Task<DataResult<AccessToken>> ApplicantRegister(ApplicantForRegisterRequest applicantForRegisterRequest);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);
}