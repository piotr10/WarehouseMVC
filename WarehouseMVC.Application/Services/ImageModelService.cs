using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services
{
    public class ImageModelService : IImageModelService
    {

        private readonly IImageModelRepository _imageModelRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ImageModelService(IImageModelRepository imageModelRepo, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _imageModelRepo = imageModelRepo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public int AddImageModel(NewImageModelVm imageModel, IFormFile[] attachments)
        {
            var image = _mapper.Map<ImageModel>(imageModel);
            var id = _imageModelRepo.AddImageModel(image);
            return id;
        }

        public ListImageModelForListVm GetAllImageModelForList(int pageSize, int pageNo, string searchString)
        {
            var imageModel = _imageModelRepo.GetAllImageModel().Where(p => p.Name.StartsWith(searchString) | p.Surname.StartsWith(searchString))
                .ProjectTo<ImageForListVm>(_mapper.ConfigurationProvider).ToList();
            
            var imageToShow = imageModel.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var imageList = new ListImageModelForListVm()
            {
                ImageModels = imageToShow,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = imageModel.Count
            };

            return imageList;
        }

        public ImageModelDetailsVm GetImageModelDetails(int? id)
        {
            var imageModel = _imageModelRepo.GetImageModel(id);
            var imageVm = _mapper.Map<ImageModelDetailsVm>(imageModel);

            return imageVm;
        }

        public void DeleteImageModel(int id)
        {
            throw new System.NotImplementedException();
        }

        public NewImageModelVm GetImageModelForEdit(int id)
        {
            var imageModel = _imageModelRepo.GetImageModel(id);
            var imageVm = _mapper.Map<NewImageModelVm>(imageModel);

            return imageVm;
        }

        public void UpdateImageModel(NewImageModelVm model)
        {
            var imageModel = _mapper.Map<ImageModel>(model);
            _imageModelRepo.UpdateImageModel(imageModel);
        }
    }
}