using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net.WebSockets;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILibraryDbUnitOfWork dbUnitOfWork;
        private readonly IMapper mapper;

        public CategoriesController(ILibraryDbUnitOfWork dbUnitOfWork, IMapper mapper)
        {
            this.dbUnitOfWork = dbUnitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GetCategoryResponse>> GetAll()
        {
            var categories = dbUnitOfWork.Categories.GetAllWithSubcategories();
            var res = mapper.Map<List<GetCategoryResponse>>(categories);
            return Ok(res);
            
        }
        [HttpGet("{id}",Name = "GeCategorytById")]
        public ActionResult<GetCategoryResponse> GetById(int id)
        {
            var category = dbUnitOfWork.Categories.GetWithSubcategories(id);
            var res = mapper.Map<GetCategoryResponse>(category);

            return Ok(res);
        }
        [HttpPost]
        public ActionResult<GetCategoryResponse> CreateCategory([FromBody] PostCategoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var category = mapper.Map<Category>(request);

            dbUnitOfWork.Categories.Add(category);
            dbUnitOfWork.Save();

            var res = mapper.Map<GetCategoryResponse>(category);

            return CreatedAtRoute("GeCategorytById",new { id = category.Id },res);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id,[FromBody] PostCategoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);

            var category = dbUnitOfWork.Categories.GetById(id);
            if (category == null)
                return NotFound("The specified category does not exist");

            mapper.Map(source:request,destination:category);

            dbUnitOfWork.Save();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = dbUnitOfWork.Categories.GetById(id);
            if (category == null)
                return NotFound("The specified category does not exist");

            dbUnitOfWork.Categories.Delete(category);
            dbUnitOfWork.Save();

            return NoContent();
        }

        // Subcategories 
        [HttpPost("{id}/subcategories/{subcategoryName}")]
        public ActionResult AddSubcategory(int id , string subcategoryName)
        {
            var category = dbUnitOfWork.Categories.GetById(id);
            if (category == null)
                return NotFound("The specified category does not exist");

            category.Subcategories.Add(new Subcategory() { Name = subcategoryName });
            dbUnitOfWork.Save();

            return NoContent();
        }

    }
}
