using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;
public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;
    private readonly BootcampBusinessRules _rules;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules rules)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
    {
        List<Bootcamp> bootcamps = await _bootcampRepository.GetAllAsync(include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, BootcampMessages.BootcampsListed);
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfBootcampNotExists(id);
        Bootcamp bootcamp = await _bootcampRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response);
    }

    public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        await _rules.CheckIfInstructorNotExists(request.InstructorId);
        await _rules.CheckIfBootcampStateNotExists(request.BootcampStateId);
        await _rules.CheckBootcampNameIfExist(request.Name);
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);
        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, BootcampMessages.BootcampAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
    {
        await _rules.CheckIfBootcampNotExists(request.Id);
        Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == request.Id);
        await _bootcampRepository.DeleteAsync(bootcamp);
        return new SuccessResult(BootcampMessages.BootcampDeleted);
    }

    public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        await _rules.CheckIfBootcampNotExists(request.Id);
        await _rules.CheckIfInstructorNotExists(request.InstructorId);
        await _rules.CheckIfBootcampStateNotExists(request.BootcampStateId);
        await _rules.CheckBootcampNameIfExist(request.Name);
        Bootcamp bootcamp = await _bootcampRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Instructor).Include(x => x.BootcampState));
        _mapper.Map(request, bootcamp);
        await _bootcampRepository.UpdateAsync(bootcamp);
        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, BootcampMessages.BootcampUpdated);
    }
}
