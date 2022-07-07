using AutoMapper;
using layihe.BLL.FlightBLL;
using layihe.BLL.PassengerBLL;
using layihe.BLL.TicketBLL;
using layihe.Dtos;
using layihe.Dtos.FlightDtos;
using layihe.Dtos.PassengerDtos;
using layihe.Dtos.TicketDtos;
using layihe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa;
namespace layihe.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightServices _flightServices;
        private readonly ITicketServices _ticket;
        private readonly IPassengerServices _passenger;
        private readonly IMapper _mapper;
        public FlightController(IFlightServices flightServices,ITicketServices ticket,IPassengerServices passenger,IMapper mapper)
        {
            _flightServices = flightServices;
            _ticket = ticket;
            _passenger = passenger;
            _mapper = mapper;
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
                if (flightToAddDto.DepartureCityId != 0 && flightToAddDto.ArrivialCityId != 0 && flightToAddDto.DepartureTime !=null)
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

        public  IActionResult RegisterPassenger(int id)
        {
            try
            {
                TempData["flightId"] = id;
                return View();
            }
            catch(Exception ex)
            {
                return View(BadRequest(ex.Message));
            }
        }
        public  async Task<IActionResult> SellTicket(TicketToAddDto ticketToAddDto)
        {
            Random rd = new Random();
                try
                {
                 await _passenger.Addsync(ticketToAddDto.Passenger);
                ticketToAddDto.NewFlightId =Convert.ToInt32(TempData["flightId"]);
                ticketToAddDto.TicketNumber = rd.Next(100000000, 999999999);
                
                await _ticket.Addsync(ticketToAddDto);
                return View("TicketImage",ticketToAddDto);
            }
            catch(Exception ex)
            {
                return View(BadRequest(ex.Message));
            }
        }

        public async Task<IActionResult> TicketImage()
        {
            return View();
        }
      public async Task<IActionResult> FlightCancel(int id)
        {
            await _flightServices.Delete(id);
            return RedirectToAction("Index");
        }
      public async Task<IActionResult> Info(int id)
        {
            return View(await _flightServices.GetFlight(id));

        }
    }
}
