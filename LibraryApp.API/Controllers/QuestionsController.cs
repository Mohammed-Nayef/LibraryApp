using LibraryApp.API.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly StackOverflowClient stackOverflowClient;
        private readonly ILogger<QuestionsController> logger;

        public QuestionsController(StackOverflowClient stackOverflowClient, ILogger<QuestionsController> logger)
        {
            this.stackOverflowClient = stackOverflowClient;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userAgent = Request.Headers.UserAgent.ToString();
            var questions = await stackOverflowClient.GetQuestions(userAgent);
            logger.LogInformation("fetched");
            return questions is null ? NotFound(): Ok(questions);
        }
    }
}
