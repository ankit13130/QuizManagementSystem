namespace QuizManagement.Infra.Domain.Entities;

public class Quiz
{
    public long QuizId { get; set; }
    public string QuizName { get; set; }
    public string QRCodeImage { get; set; }
    public long UserId { get; set; }
    public int TotalQuestions { get; set; }
    public User? User { get; set; }
    public Quiz(string quizName, int totalQuestions, long userId)
    {
        QuizName = quizName;
        QRCodeImage = Guid.NewGuid().ToString();
        UserId = userId;
        TotalQuestions = totalQuestions;
    }
}