using QuizManagement.Core.Domain.RequestModels;
using QuizManagement.Infra.Domain.Entities;

namespace QuizManagement.Core.Builder;

public static class OptionBankBuilder
{
    public static IList<OptionBank> Build(IList<string> option, long questionId)
    {
        var list = new List<OptionBank>();
        foreach (var item in option)
        {
            list.Add(new OptionBank(item,questionId));
        }
        return list;
    }
}
