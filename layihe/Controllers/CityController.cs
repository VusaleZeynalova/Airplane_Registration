using layihe.BLL.CityBLL;
using layihe.Dtos.CityDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Controllers
{
    public class CityController : Controller
    {
        private readonly IDepartureCityServices _cityServices;
        private readonly IArrivialCityService _arrivialCityService;
        public CityController(IDepartureCityServices cityServices,IArrivialCityService arrivialCityService)
        {
            _cityServices = cityServices;
            _arrivialCityService = arrivialCityService;
        }
        public ActionResult Main()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddDeparture()
        {
            return View();
        }
        public async Task<ActionResult> AddDeparture(DepatureCityToAddDto depatureCityToAddDto)
        {
            try
            {
                await _cityServices.Addsync(depatureCityToAddDto);
                return RedirectToAction("Main");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AddArrivial()
        {
            return View();
        }
        public async Task<ActionResult> AddArrivial(ArrivialToAddDto arrivialToAddDto)
        {
            try
            {
                await _arrivialCityService.Addsync(arrivialToAddDto);
                return RedirectToAction("Main");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
       


       
    }
}
