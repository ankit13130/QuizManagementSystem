namespace QuizManagement.Core.Domain.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string? msg) : base(msg) { }
}
