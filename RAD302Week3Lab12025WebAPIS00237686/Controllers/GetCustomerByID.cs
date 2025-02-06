using Microsoft.AspNetCore.Mvc;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025WebAPIS00237686.Controllers
{
    public class GetCustomerByID : Controller
    {
        public IActionResult Index()
        {

            ActivityAPIClient.Track(StudentID: "S00237686", StudentName: "Tristan Cawley",
    activityName: "Rad302 Week 3 Lab 1", Task: "Testing Check Customer Credit Rating Call");
            return View();
        }
    }
}
