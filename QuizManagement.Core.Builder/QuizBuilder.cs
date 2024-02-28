using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Builder;

public static class QuizBuilder
{
    public static Quiz Build(string quizName, int totalQuestion, long loginUserId)
    {
        return new Quiz(quizName, totalQuestion, loginUserId);
    }
}
