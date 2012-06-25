using AutoMapper;

namespace MS.Bordro.Web.Helpers
{
    public static class MapperHelper
    {

        public static void HandleMappings()
        {
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