using QuizManagement.Core.Builder;
using QuizManagement.Core.Contract;
using QuizManagement.Infra.Contract;

namespace QuizManagement.Core.Services;

public class OptionBankServices : IOptionBankServices
{
    private readonly IOptionBankRepository _optionBankRepository;

    public OptionBankServices(IOptionBankRepository optionBankRepository)
    {
        _optionBankRepository = optionBankRepository;
    }

    public async Task AddOptionAsync(IList<string> optionBank, long questionID)
    {
        var list = OptionBankBuilder.Build(optionBank, questionID);
        await _optionBankRepository.AddOptionAsync(list);
    }
}
