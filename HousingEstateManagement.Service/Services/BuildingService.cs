using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HousingEstateManagement.Service.Services
{
    public class BuildingService:IBuildingService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IBuildingRepository _buildingRepository;

        public BuildingService(IMapper mapper, IUnitOfWork unitOfWork, IBuildingRepository buildingRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _buildingRepository = buildingRepository;
        }

        public async Task<IDataResult<BuildingDto>> GetByIdAsync(int id)
        {
            var buildingDto = _mapper.Map<BuildingDto>(await _unitOfWork.Buildings.GetByIdAsync(id));
            if (buildingDto != null)
            {
                return new SuccessDataResult<BuildingDto>(buildingDto);
            }
            return new ErrorDataResult<BuildingDto>();
        }

        public async Task<IDataResult<List<BuildingDto>>> GetAllAsync()
        {
            var buildingDtos = _mapper.Map<List<BuildingDto>>(await _unitOfWork.Buildings.GetAllAsync());
            if (buildingDtos != null)
            {
                return new SuccessDataResult<List<BuildingDto>>(buildingDtos); 
            }
            return new ErrorDataResult<List<BuildingDto>>();
        }

        public async Task<IDataResult<BuildingDto>> AddAsync(BuildingDto buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
            await _buildingRepository.AddAsync(building);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<BuildingDto>(buildingDto);
        }

        public async Task<IDataResult<List<BuildingDto>>> AddRangeAsync(List<BuildingDto> buildingDtos)
        {
            var buildings = _mapper.Map<List<Building>>(buildingDtos);
            await _buildingRepository.AddRangeAsync(buildings);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<BuildingDto>>(buildingDtos);
        }

        public IResult Remove(int id)
        {
            var building = _buildingRepository.GetByIdAsync(id).Result;
            _buildingRepository.Remove(building);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<BuildingDto> buildingDto)
        {
            var buildings = _mapper.Map<List<Building>>(buildingDto);
            _buildingRepository.RemoveRange(buildings);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<BuildingDto> Update(BuildingDto buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
            _buildingRepository.Update(building);
            _unitOfWork.Commit();
            return new SuccessDataResult<BuildingDto>(buildingDto);
        }
    }
}