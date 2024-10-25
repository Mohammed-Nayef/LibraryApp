using LibraryApp.Domain.Common.Classes;
using LibraryApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/Tags")]
    public class TagsController : ControllerBase
    {
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;

        public TagsController(ILibraryDbUnitOfWork dbUnitOfWork)
        {
            this.dbUnitOfWork = dbUnitOfWork;
        }
        [HttpGet]
        public ActionResult<List<TagFromProcedure>> GetAll()
        {
            return Ok(dbUnitOfWork.StoredProcedures.GetAllTags());
        }
    }
}
