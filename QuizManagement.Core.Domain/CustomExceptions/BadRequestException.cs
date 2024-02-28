namespace QuizManagement.Core.Domain.CustomExceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : base() { }
    public BadRequestException(string? msg) : base(msg) { }
}
