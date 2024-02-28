using QuizManagement.Infra.Contract;
using QuizManagement.Infra.Domain;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Infra.Repository;

public class OptionBankRepository : IOptionBankRepository
{
    private readonly QuizContext _quizContext;

    public OptionBankRepository(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task AddOptionAsync(IList<OptionBank> optionBank)
    {
        await _quizContext.AddRangeAsync(optionBank);
        await _quizContext.SaveChangesAsync();
    }
}
