using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
