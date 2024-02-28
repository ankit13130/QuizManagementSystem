using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Contract;

public interface IOptionBankRepository
{
    Task AddOptionAsync(IList<OptionBank> optionBank);
}
