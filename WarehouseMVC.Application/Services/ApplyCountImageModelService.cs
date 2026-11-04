using AutoMapper;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services
{
    public class ApplyCountImageModelService : IApplyCountImageModelService
    {
        private readonly IApplyCountImageModelRepository _applyCountImageModelRepository;
        private readonly IMapper _mapper;

        public ApplyCountImageModelService(IApplyCountImageModelRepository applyCountImageModelRepository, IMapper mapper)
        {
            _applyCountImageModelRepository = applyCountImageModelRepository;
            _mapper = mapper;
        }

        public int AddApplyCountImageModel(ApplyCountImageModel applyCount)
        {
            var apply = _mapper.Map<ApplyCountImageModel>(applyCount);
            var id = _applyCountImageModelRepository.AddApplyCountImageModel(apply);
            return id;
        }

        public void UpdateImageModel(ApplyCountImageModel apply)
        {
            //var applyCount = _mapper.Map<ApplyCountImageModel>(apply);
            _applyCountImageModelRepository.UpdateApplyCountImageModel(apply);
        }
    }
}