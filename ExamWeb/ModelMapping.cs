using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ExamWeb.AlumniImageService;
using ExamWeb.AlumniService;
using ExamWeb.FacultyService;
using ExamWeb.JobHistoryService;
using ExamWeb.JobPostingService;
using ExamWeb.MajorService;
using ExamWeb.Models;

namespace ExamWeb
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ModelMapping>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<FacultyDTO, FacultyModel>().ReverseMap();
            CreateMap<MajorDTO, MajorModel>().ReverseMap();
            CreateMap<AlumniDTO, AlumniModel>().ReverseMap();
            CreateMap<JobHistoryDTO, JobHistoryModel>().ReverseMap();
            CreateMap<AlumniImageDTO, AlumniImageModel>().ReverseMap();
            CreateMap<HobbyDTO, HobbyModel>().ReverseMap();
            CreateMap<JobPostingDTO, JobPostingModel>().ReverseMap(); 
        }
    }
}