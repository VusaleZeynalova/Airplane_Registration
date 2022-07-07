using layihe.BLL.FlightBLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Controllers
{
    public class ReportController : Controller
    {
        private readonly IFlightServices _flightServices;
        public ReportController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _flightServices.Get());
        }
     
    }
}
