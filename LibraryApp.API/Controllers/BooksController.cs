using AutoMapper;
using Azure.Identity;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.API.Services;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;
        private readonly ILogger<BooksController> logger;
        private readonly AppConfigurations configurations;
        private readonly IMapper mapper;

        public BooksController(ILibraryDbUnitOfWork dbUnitOfWork,
            ILogger<BooksController> logger,
            AppConfigurations configurations,
            IMapper mapper)
        {
            this.dbUnitOfWork = dbUnitOfWork;
            this.logger = logger;
            this.configurations = configurations;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<GetBookResponse>> GetAll([FromQuery] PaginationOptions paginationOptions)
        {
            paginationOptions.PageNumber = (paginationOptions.PageNumber < 1 )? 1 : paginationOptions.PageNumber;
            paginationOptions.PageSize = (paginationOptions.PageSize > configurations.BooksMaxPageSize || paginationOptions.PageSize < 2) ? configurations.BooksMaxPageSize : paginationOptions.PageSize;

            var books = dbUnitOfWork.Books.GetAllByPage(paginationOptions);

            var res = mapper.Map<List<GetBookResponse>>(books);
            return Ok(res);
        }

        [HttpGet("{id}",Name ="GetById")]
        public ActionResult<GetBookResponse> GetById(int id)
        {
            var book = dbUnitOfWork.Books.GetWithTFullNavigations(id);
            if(book == null) 
                return NotFound();

            var res = mapper.Map<GetBookResponse>(book);

            return Ok(res);
        }

        // TODO : Test 
        [HttpPost]
        public ActionResult<GetBookResponse> CreateBook([FromBody] PostBookRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dbUnitOfWork.Authors.GetById(request.AuthorId) == null)
                return NotFound("Author Specified does not exist");
            if (dbUnitOfWork.Categories.GetById(request.CategoryId) == null)
                 return NotFound("Category specified does not exist");
            if (dbUnitOfWork.Subcategories.GetById(request.SubcategoryId) == null)
                 return NotFound("Subcategory specified does not exist");
            
            var tags = dbUnitOfWork.Tags.Find(tag => request.TagsIds.Contains(tag.Id));
            if (tags.Count() < request.TagsIds.Count())
                return NotFound("One or more Tag Id does not exist");

            var book = mapper.Map<Book>(request);

            dbUnitOfWork.Books.Add(book);
            dbUnitOfWork.Save();

            var res = mapper.Map<GetBookResponse>(book);

            return CreatedAtRoute("GetById", new { id = book.Id },res);

        }

        [HttpGet("/category/{id}")]
        public ActionResult<List<GetBookResponse>> GetByCategoryId(int id)
        {
            var books = dbUnitOfWork.Books.GetByCategoryId(id);

            var res = mapper.Map<List<GetBookResponse>>(books);
            return Ok(res);
        }

        [HttpGet("/category/{categoryId}/subcategory/{subcategoryId}")]
        public ActionResult<List<GetBookResponse>> GetByCategoryIdAndSubcategoryId(int categoryId ,int subcategoryId)
        {
            var books = dbUnitOfWork.Books.GetByCategoryAndSubcategory(categoryId,subcategoryId);

            var res = mapper.Map<List<GetBookResponse>>(books);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = dbUnitOfWork.Books.GetById(id);
            if (book == null)
                return NotFound();

            dbUnitOfWork.Books.Delete(book);
            dbUnitOfWork.Save();

            return NoContent();
        }
    }
}
