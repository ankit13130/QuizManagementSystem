using Microsoft.Extensions.DependencyInjection.Extensions;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Services;
using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Repository;

namespace QuizManagement.API.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserServices, UserServices>();
        
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IQuizServices, QuizServices>();
        
        services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();
        services.AddScoped<IQuestionBankServices, QuestionBankServices>();
        
        services.AddScoped<IParticipantRepository, ParticipantRepository>();
        services.AddScoped<IParticipantServices, ParticipantServices>();
        
        services.AddScoped<IQuestionAnswerRepository, QuestionAnswerRepository>();
        services.AddScoped<IQuestionAnswerServices, QuestionAnswerServices>();
        
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IFeedbackServices, FeedbackServices>();
        
        services.AddScoped<IOptionBankRepository, OptionBankRepository>();
        services.AddScoped<IOptionBankServices, OptionBankServices>();

        services.AddScoped<IEmailServices, EmailServices>();
        
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddAutoMapper(typeof(MappingProfile));
        
    }
}
