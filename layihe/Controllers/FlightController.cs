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
        
        public async Task<IActionResult> Search( )
        {
         return View(await _flightServices.InnerModel());
        }
        public async Task<IActionResult> Find(FlightToAddDto flightToAddDto)
        {
            try
            {
                if (flightToAddDto.DepartureCityId != null && flightToAddDto.ArrivialCityId != null && flightToAddDto.DepartureTime != null)
                {
                    var flight = await _flightServices.Find(flightToAddDto.DepartureCityId, flightToAddDto.ArrivialCityId,(flightToAddDto.DepartureTime).ToShortDateString());
                    if (flight.Count == 0)
                    {
                        return RedirectToAction("DontFindFlight",new { id = flightToAddDto.DepartureCityId });
                    }
                    else
                    {
                        return View(flight);
                    }
                }
                else
                {
                  return RedirectToAction("DontFindFlight");

                }
            }
            catch(Exception ex)
            {
                return View(BadRequest(ex.Message));
            }
        }
        public async Task<IActionResult> DontFindFlight(int id)
        {
            return View(await _flightServices.Get(id));
        }

    }
}
