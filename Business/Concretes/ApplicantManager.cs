using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;
public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;
    private readonly ApplicantBusinessRules _rules;
    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules rules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        List<Applicant> applicants = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, ApplicantMessages.ApplicantsListed);
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfApplicantNotExists(id);
        Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response);
    }

    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, ApplicantMessages.ApplicantAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        await _rules.CheckIfApplicantNotExists(request.UserId);
        Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.UserId);
        await _applicantRepository.DeleteAsync(applicant);
        return new SuccessResult(ApplicantMessages.ApplicantDeleted);
    }

    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await _rules.CheckIfApplicantNotExists(request.UserId);
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
        _mapper.Map(request, applicant);
        await _applicantRepository.UpdateAsync(applicant);
        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, ApplicantMessages.ApplicantUpdated);
    }
}
