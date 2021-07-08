using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.SharedLibrary.Results;


namespace HousingEstateManagement.Service.Services
{
    public class FlatService:IFlatService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IFlatRepository _flatRepository;

        public FlatService(IMapper mapper, IUnitOfWork unitOfWork, IFlatRepository flatRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _flatRepository = flatRepository;
        }
        
        public async Task<IDataResult<FlatDto>> GetByIdAsync(int id)
        {
             var flatDto = _mapper.Map<FlatDto>(await _unitOfWork.Flats.GetByIdAsync(id));
            if (flatDto != null) 
            {
                return new SuccessDataResult<FlatDto>(flatDto);
            }
             return new ErrorDataResult<FlatDto>();
        }

        public async Task<IDataResult<List<FlatDto>>> GetAllAsync()
        {
            var flatDtos = _mapper.Map<List<FlatDto>>(await _unitOfWork.Flats.GetAllAsync());
            if (flatDtos != null)
            {
                return new SuccessDataResult<List<FlatDto>>(flatDtos);
            }
            return new ErrorDataResult<List<FlatDto>>();
        }

        public async Task<IDataResult<FlatCreateDto>> AddAsync(FlatCreateDto flatCreateDto)
        {
            var flat = _mapper.Map<Flat>(flatCreateDto);
            await _flatRepository.AddAsync(flat);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<FlatCreateDto>(flatCreateDto);
        }

        public async Task<IDataResult<List<FlatCreateDto>>> AddRangeAsync(List<FlatCreateDto> flatCreateDtos)
        {
            var flat = _mapper.Map<List<Flat>>(flatCreateDtos);
            await _flatRepository.AddRangeAsync(flat);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<FlatCreateDto>>(flatCreateDtos);
        }

        public IResult Remove(int id)
        {
            var flat = _flatRepository.GetByIdAsync(id).Result;
            _flatRepository.Remove(flat);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<FlatDto> flatDtos)
        {
            var flat = _mapper.Map<List<Flat>>(flatDtos);
            _flatRepository.RemoveRange(flat);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<FlatUpdateDto> Update(FlatUpdateDto flatUpdateDto)
        {
             var flat = _mapper.Map<Flat>(flatUpdateDto);
             _flatRepository.Update(flat);
             _unitOfWork.Commit();
             return new SuccessDataResult<FlatUpdateDto>(flatUpdateDto);
        }

        public async Task<IDataResult<List<FlatDto>>> GetAllFlatsByRelations()
        {
            var flats = await _flatRepository.GetAllFlatsByRelations();
            var flatDtos = flats.Select(f => new FlatDto()
            {
                Id = f.Id,
                FlatNumber = f.FlatNumber,
                TypeOfFlat = f.TypeOfFlat,
                IsEmpty = f.IsEmpty,
                UserName = f.User.UserName,
                BuildingName = f.Building.BuildingName
            }).ToList();
            return new SuccessDataResult<List<FlatDto>>(flatDtos);
        }
    }
}