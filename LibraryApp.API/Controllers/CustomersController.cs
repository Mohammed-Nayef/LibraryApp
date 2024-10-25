using AutoMapper;
using LibraryApp.API.DTOs.Requests;
using LibraryApp.API.DTOs.Responses;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private ILibraryDbUnitOfWork dbUnitOfWork;
        private ILogger<CustomersController> logger;
        private IMapper mapper;

        public CustomersController(ILibraryDbUnitOfWork dbUnitOfWork,
            ILogger<CustomersController> logger,
            IMapper mapper)
        {
            this.dbUnitOfWork = dbUnitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<GetCustomerResponse>> GetAll()
        {
            var customers = dbUnitOfWork.Customers.GetAllWithUserInfo();

            var res = mapper.Map<List<GetCustomerResponse>>(customers);
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public ActionResult<GetCustomerResponse> GetById(int id)
        {
            var customer = dbUnitOfWork.Customers.GetWithUserInfo(id);
            if (customer == null)
                return NotFound();

            var res = mapper.Map<GetCustomerResponse>(customer);
            return Ok(res);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var customer = dbUnitOfWork.Customers.GetWithUserInfo(id);

            if (customer == null)
                return NotFound();
            dbUnitOfWork.Customers.Delete(customer);
            dbUnitOfWork.Save();

            return NoContent();
        }

        [HttpGet("{id:int}/borrows")]
        public ActionResult<List<GetBookBorrowResponse>> GetBookBorrow(int id) { 
            
            var bookBorrowsWithBook = dbUnitOfWork.Customers.GetCustomerBookBorrows(id);
            var res = mapper.Map<List<GetBookBorrowResponse>>(bookBorrowsWithBook);
            return Ok(res);
        
        }
        [HttpGet("{id:int}/borrows/{bookBorrowId:int}",Name ="GetCustomerBookBorrowById")]
        public ActionResult<GetBookBorrowResponse> GetBookBorrow(int id, int bookBorrowId)
        {
            var bookBorrow = dbUnitOfWork.BookBorrows.GetById(id);
            if (bookBorrow == null)
                return NotFound();
            if (bookBorrow.CustomerId != id)
                return BadRequest("the Book Borrow specified doesn't belong to specified Customer");

            // load book to be mapped with the response ( not best practice 2 queries )
            // TODO :  Implement BookBorrowRepository and add method that includes book witht he fetched BookBorrow 
            dbUnitOfWork.Books.GetById(bookBorrow.BookId);


            var res = mapper.Map<GetBookBorrowResponse>(bookBorrow);
            return Ok(res);
        }

        [HttpPost("{id:int}/borrows")]
        public ActionResult<GetBookBorrowResponse> BorrowBook(int id,[FromBody] PostBookBorrowRequest request)
        {
            if (ModelState.IsValid)
                return BadRequest(modelState: ModelState);
            
            if (id != request.CustomerId)
                return BadRequest();

            var customer = dbUnitOfWork.Customers.GetWithUserInfo(id);
            
            if (customer == null) 
                return NotFound();

            var bookBorrow = mapper.Map<BookBorrow>(request);

            bookBorrow.ExpiryDate = DateTime.UtcNow.AddDays(14);
            dbUnitOfWork.BookBorrows.Add(bookBorrow);
            dbUnitOfWork.Save();

            var res = mapper.Map<GetBookBorrowResponse>(bookBorrow);

            return CreatedAtRoute("GetCustomerBookBorrowById",new {id = customer.Id , bookBorrowId = bookBorrow.Id},res);
        }

    }
}
