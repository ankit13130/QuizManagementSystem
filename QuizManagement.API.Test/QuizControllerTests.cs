using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuizManagement.API.Controllers;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.ResponseModels;
using System.Security.Claims;

namespace QuizManagement.API.Test;

public class QuizControllerTests
{
    private readonly Mock<IQuizServices> _mockQuizServices;
    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
    private readonly Mock<IQuestionBankServices> _mockQuestionBankServices;
    private readonly Mock<IParticipantServices> _mockParticipantServices;
    private readonly Mock<IQuestionAnswerServices> _mockQuestionAnswerServices;
    private readonly Mock<IOptionBankServices> _mockOptionBankServices;
    private readonly QuizController _quizController;

    public QuizControllerTests()
    {
        _mockQuizServices = new Mock<IQuizServices>();
        _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        _mockQuestionBankServices = new Mock<IQuestionBankServices>();
        _mockParticipantServices = new Mock<IParticipantServices>();
        _mockQuestionAnswerServices = new Mock<IQuestionAnswerServices>();
        _mockOptionBankServices = new Mock<IOptionBankServices>();

        var identity = new ClaimsIdentity(new[] 
        { 
            new Claim(ClaimTypes.Sid,"100")
        });
        _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(new ClaimsPrincipal(identity));
        
        _quizController = new QuizController(_mockQuizServices.Object,_mockHttpContextAccessor.Object , _mockQuestionBankServices.Object, _mockParticipantServices.Object, _mockQuestionAnswerServices.Object, _mockOptionBankServices.Object);
    }

    [Fact]
    public async Task GetAnalysisAsync_Must_Pass()
    {
        _mockQuizServices.Setup(service => service.GetAnalysisAsync(It.IsAny<long>(), It.IsAny<long>())).ReturnsAsync(Mock.Of<IList<QuizAnalysisModel>>);

        var result = await _quizController.GetAnalysisAsync(It.IsAny<long>());

        Assert.IsType<OkObjectResult>(result);
    }
}