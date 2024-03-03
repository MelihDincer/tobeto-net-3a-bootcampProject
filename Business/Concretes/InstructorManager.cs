using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;
public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _rules;

    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules rules)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
        _rules = rules;
    }
    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
    {
        List<Instructor> instructors = await _instructorRepository.GetAllAsync();
        List<GetAllInstructorResponse> reponses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(reponses, InstructorMessages.InstructorsListed);
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfInstructorNotExists(id);
        Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
        return new SuccessDataResult<GetByIdInstructorResponse>(response);
    }

    public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Instructor instructor = _mapper.Map<Instructor>(request);
        await _instructorRepository.AddAsync(instructor);
        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response, InstructorMessages.InstructorAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
    {
        await _rules.CheckIfInstructorNotExists(request.UserId);
        Instructor instructor = await _instructorRepository.GetAsync(i => i.Id == request.UserId);
        await _instructorRepository.DeleteAsync(instructor);
        return new SuccessResult(InstructorMessages.InstructorDeleted);
    }

    public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        await _rules.CheckIfInstructorNotExists(request.UserId);
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
        _mapper.Map(request, instructor);
        await _instructorRepository.UpdateAsync(instructor);
        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
        return new SuccessDataResult<UpdateInstructorResponse>(response, InstructorMessages.InstructorUpdated);
    }
}
