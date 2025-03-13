using Microsoft.AspNetCore.Mvc;
using Tracker.WebAPIClient;
using Week8ProductModelS00237686;

namespace Week8ProductWebAPI2025S00237686.Controllers
{
    public class GRNController : Controller
    {
        private readonly IGRN<GRN> _repository;
        //this for the correct test name.
        public GRNController(IGRN<GRN> repository)
        {
            _repository = repository;

            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley", activityName: "RAD30223 Week 8 Lab 1", Task: "Testing GRN Controller Actions");
        }

        public IEnumerable<GRN> Get()
        {
            return _repository.GetAll();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
