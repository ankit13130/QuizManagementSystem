using AutoMapper;
using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Core.Domain.ResponseModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.API.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponseModel>();
        CreateMap<Quiz, QuizResponseModel>();
        CreateMap<Participant, ParticipantResponseModel>();
        CreateMap<ParticipantRequestModel, Participant>();
        CreateMap<QuestionAnswerRequestModel, QuestionAnswer>();
    }
}
