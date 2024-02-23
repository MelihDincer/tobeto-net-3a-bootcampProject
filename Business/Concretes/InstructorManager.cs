using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            List<Instructor> instructors = await _instructorRepository.GetAllAsync();
            List<GetAllInstructorResponse> reponses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
            return new SuccessDataResult<List<GetAllInstructorResponse>>(reponses, "Başarıyla listelendi");
        }

        public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
            GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
            return new SuccessDataResult<GetByIdInstructorResponse>(response);
        }

        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.AddAsync(instructor);
            CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(response, "Başarıyla eklendi");
        }

        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.DeleteAsync(instructor);
            return new SuccessResult("Başarıyla silindi");

        }

        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _instructorRepository.UpdateAsync(instructor);
            UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(response, "Başarıyla güncellendi");
        }
    }
}
