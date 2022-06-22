using layihe.BLL.FlightBLL;
using layihe.Dtos.FlightDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightServices _flightServices;
        public FlightController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _flightServices.Get());
        }
      
        public async Task<IActionResult> Registration()
        {
            
            return View(await _flightServices.InnerModel());
        }
        public async Task<IActionResult> Add(FlightToAddDto flightToAddDto)
        {
            await _flightServices.Addasync(flightToAddDto);
            return RedirectToAction("Index");
        }

    }
}
