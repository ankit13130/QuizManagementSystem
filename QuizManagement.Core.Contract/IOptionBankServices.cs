using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Contract;

public interface IOptionBankServices
{
    Task AddOptionAsync(IList<string> optionBank, long questionID);
}
