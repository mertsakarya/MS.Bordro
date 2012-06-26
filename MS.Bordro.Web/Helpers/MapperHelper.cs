using AutoMapper;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.Helpers
{
    public static class MapperHelper
    {

        public static void HandleMappings()
        {
            Mapper.CreateMap<Company, CompanyModel>();
            Mapper.CreateMap<CompanyLocation, CompanyLocationModel>();
            Mapper.CreateMap<Employee, EmployeeModel>();
            Mapper.CreateMap<RouteInformation, RouteInformationModel>();
            Mapper.CreateMap<Vehicle, VehicleModel>();
            Mapper.CreateMap<Worker, WorkerModel>();
            Mapper.CreateMap<WorkRequest, WorkRequestModel>();

            Mapper.CreateMap<CompanyModel, Company>();
            Mapper.CreateMap<CompanyLocationModel, CompanyLocation>();
            Mapper.CreateMap<EmployeeModel, Employee>();
            Mapper.CreateMap<RouteInformationModel, RouteInformation>();
            Mapper.CreateMap<VehicleModel, Vehicle>();
            Mapper.CreateMap<WorkerModel, Worker>();
            Mapper.CreateMap<WorkRequestModel, WorkRequest>();

            //Mapper.CreateMap<Profile, ProfileModel>();
            //Mapper.CreateMap<ProfileModel, Profile>()
            //    .ForMember(dest => dest.BreastSize, opt => opt.MapFrom(src => (byte?) src.BreastSize))
            //    .ForMember(dest => dest.DickSize, opt => opt.MapFrom(src => (byte?) src.DickSize))
            //    .ForMember(dest => dest.DickThickness, opt => opt.MapFrom(src => (byte?) src.DickThickness));


            //Mapper.CreateMap<ConversationModel, Conversation>();
            //Mapper.CreateMap<Conversation, ConversationModel>();

            //Mapper.CreateMap<ConversationResultModel, ConversationResult>()
            //    .ForMember(dest => dest.FromId, opt => opt.MapFrom(src => src.From.Id))
            //    .ForMember(dest => dest.ToId, opt => opt.MapFrom(src => src.To.Id));
            //Mapper.CreateMap<ConversationResult, ConversationResultModel>().ConvertUsing(ConversationResultTypeConverter.GetInstance());
        }
    }
}