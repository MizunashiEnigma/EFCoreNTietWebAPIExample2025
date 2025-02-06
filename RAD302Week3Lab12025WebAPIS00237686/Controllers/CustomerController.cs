using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAD302Week3Lab12025CL.S00237686;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPIS00237686.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer<Customer> _repository;
        public CustomerController(ICustomer<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley",
                activityName: "Rad302 Week 3 Lab 1", Task: "Testing Basic Controller Call");
            return _repository.GetAll();
        }

        // Get Customer By ID
        [HttpGet("GetCustomerbyID/{id:int}")]
        public ActionResult<Customer> GetCustomerbyID(int id)
        {
            var customer = _repository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley",
                activityName: "Rad302 Week 3 Lab 1", Task: "Testing Get Customer By ID Call");

            return Ok(customer);
        }

        // Check Customer Credit
        [HttpGet("checkcredit/{id}/{amount}")]
        public ActionResult<bool> CheckCustomerCredit(int id, decimal amount)
        {
            var customer = _repository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            bool result = amount < (decimal)customer.CreditRating;

            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley",
                activityName: "Rad302 Week 3 Lab 1", Task: "Testing Check Customer Credit Rating Call");

            return Ok(result);
        }
    }
}
