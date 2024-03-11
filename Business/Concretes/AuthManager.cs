using Business.Abstracts;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Core.Utilities.Security.Dtos;
using Business.Requests.Applicants;
using Business.Requests.Instructors;
using Business.Requests.Employees;
using Business.Rules;
using Business.Constants;

namespace Business.Concretes;
public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly AuthBusinessRules _rules;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, IEmployeeRepository employeeRepository, IInstructorRepository instructorRepository, IApplicantRepository applicantRepository, AuthBusinessRules rules)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _applicantRepository = applicantRepository;
        _employeeRepository = employeeRepository;
        _instructorRepository = instructorRepository;
        _rules = rules;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == user.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.TokenIsCreated);
    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Employee employee)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == employee.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(employee, claims);
        return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.TokenIsCreated);

    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Instructor instructor)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == instructor.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(instructor, claims);
        return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.TokenIsCreated);

    }
    public async Task<DataResult<AccessToken>> CreateAccessToken(Applicant applicant)
    {
        List<OperationClaim> claims = await _userOperationClaimRepository.Query()
            .AsNoTracking().Where(x => x.UserId == applicant.Id).Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToListAsync();
        var accessToken = _tokenHelper.CreateToken(applicant, claims);
        return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.TokenIsCreated);

    }
    public async Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginRequest)
    {
        var user = await _userService.GetByMail(userForLoginRequest.Email);
        await _rules.UserShouldBeExists(user.Data);
        await _rules.UserEmailShouldBeExists(userForLoginRequest.Email);
        await _rules.UserPasswordShouldBeMatch(user.Data.Id, userForLoginRequest.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, AuthMessages.LoginMessage);
    }

    public async Task<DataResult<AccessToken>> EmployeeRegister(EmployeeForRegisterRequest employeeForRegisterRequest)
    {
        //await _rules.UserEmailShouldBeNotExists(employeeForRegisterRequest.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(employeeForRegisterRequest.Password, out passwordHash, out passwordSalt);
        var employee = new Employee
        {
            UserName = employeeForRegisterRequest.UserName,
            NationalIdentity = employeeForRegisterRequest.NationalIdentity,
            DateOfBirth = employeeForRegisterRequest.DateOfBirth,
            Email = employeeForRegisterRequest.Email,
            FirstName = employeeForRegisterRequest.FirstName,
            LastName = employeeForRegisterRequest.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Position = employeeForRegisterRequest.Position,
        };
        await _employeeRepository.AddAsync(employee);
        var createAccessToken = await CreateAccessToken(employee);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, AuthMessages.RegisterMessage);
    }

    public async Task<DataResult<AccessToken>> InstructorRegister(InstructorForRegisterRequest instructorForRegisterRequest)
    {
        //await _rules.UserEmailShouldBeNotExists(instructorForRegisterRequest.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(instructorForRegisterRequest.Password, out passwordHash, out passwordSalt);
        var instructor = new Instructor
        {
            UserName = instructorForRegisterRequest.UserName,
            NationalIdentity = instructorForRegisterRequest.NationalIdentity,
            DateOfBirth = instructorForRegisterRequest.DateOfBirth,
            Email = instructorForRegisterRequest.Email,
            FirstName = instructorForRegisterRequest.FirstName,
            LastName = instructorForRegisterRequest.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CompanyName = instructorForRegisterRequest.CompanyName,
        };
        await _instructorRepository.AddAsync(instructor);
        var createAccessToken = await CreateAccessToken(instructor);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, AuthMessages.RegisterMessage);
    }

    public async Task<DataResult<AccessToken>> ApplicantRegister(ApplicantForRegisterRequest applicantForRegisterRequest)
    {
        //await _rules.UserEmailShouldBeNotExists(applicantForRegisterRequest.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(applicantForRegisterRequest.Password, out passwordHash, out passwordSalt);
        var applicant = new Applicant
        {
            UserName = applicantForRegisterRequest.UserName,
            NationalIdentity = applicantForRegisterRequest.NationalIdentity,
            DateOfBirth = applicantForRegisterRequest.DateOfBirth,
            Email = applicantForRegisterRequest.Email,
            FirstName = applicantForRegisterRequest.FirstName,
            LastName = applicantForRegisterRequest.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            About = applicantForRegisterRequest.About,
        };
        await _applicantRepository.AddAsync(applicant);
        var createAccessToken = await CreateAccessToken(applicant);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, AuthMessages.RegisterMessage);
    }
}
