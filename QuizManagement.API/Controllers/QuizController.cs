using Microsoft.AspNetCore.Mvc;
using QuizManagement.Core.Contract;
using QuizManagement.Core.Domain.RequestModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace QuizManagement.API.Controllers;

//[Authorize]
[Route("[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizServices _quizServices;
    private readonly IQuestionBankServices _questionBankServices;
    private readonly IParticipantServices _participantServices;
    private readonly IQuestionAnswerServices _questionAnswerServices;
    private readonly IOptionBankServices _optionBankServices;
    private readonly long _loginUserId;

    public QuizController(IQuizServices quizServices, IHttpContextAccessor contextAccessor, IQuestionBankServices questionBankServices, IParticipantServices participantServices, IQuestionAnswerServices questionAnswerServices, IOptionBankServices optionBankServices)
    {
        _quizServices = quizServices;
        _loginUserId = Convert.ToInt64(contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
        _questionBankServices = questionBankServices;
        _participantServices = participantServices;
        _questionAnswerServices = questionAnswerServices;
        _optionBankServices = optionBankServices;
    }

    [HttpPost("createQuiz")]
    public async Task<IActionResult> AddQuizAsync([Required]string quizName, [FromBody] IList<QuestionBankRequestModel> questionBankRequestModel)
    {
        long quizId = await _quizServices.AddQuizAsync(quizName,questionBankRequestModel.Count, _loginUserId);
        //string correctOption = questionBankRequestModel.Co
        foreach (var question in questionBankRequestModel)
        {
            long questionId = await _questionBankServices.AddQuestionBankAsync(quizId, question, _loginUserId);
            await _optionBankServices.AddOptionAsync(question.Option,questionId);
            await _questionBankServices.UpdateQuestionBankAsync(question.CorrectOption, questionId);
        }
        
        return Created("Success", null);
    }

    [HttpGet("getLoginUserEligibleQuiz")]
    public async Task<IActionResult> GetAllQuizByLoginIdAsync()
    {
        return Ok(await _participantServices.GetAllQuizByLoginIdAsync(_loginUserId));
    }

    [HttpPost("takeQuiz/{quizId}")]
    public async Task<IActionResult> TakeQuizAsync(long quizId, List<QuestionAnswerRequestModel> questionAnswerRequestModels)
    {
        var result = await _questionAnswerServices.AddQuestionAnswerAsync(quizId, questionAnswerRequestModels, _loginUserId);
        return Ok(result);
    }

    [HttpPost("addParticipant")]
    public async Task<IActionResult> AddParticipantAsync(ParticipantRequestModel participantRequestModel)
    {
        await _participantServices.AddParticipantAsync(participantRequestModel);
        return Created("Success", null);
    }

    [HttpGet("{quizId}")]
    public async Task<IActionResult> GetAllParticipantsByQuizIdAsync(long quizId)
    {
        return Ok(await _participantServices.GetAllParticipantByQuizAsync(quizId));
    }

    [HttpGet("getAnalysis/{quizId}")]
    public async Task<IActionResult> GetAnalysisAsync(long quizId)
    {
        return Ok(await _quizServices.GetAnalysisAsync(quizId, _loginUserId));
    }
}
