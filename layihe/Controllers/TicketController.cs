using layihe.BLL.TicketBLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketServices _ticketServices;
        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ticketServices.Get());
        }
        public async Task<IActionResult> TicketCancel(int id)
        {
            await _ticketServices.Delete(id);
            return RedirectToAction("Index", "Ticket");
        }
        public async Task<IActionResult> SearchTicket(int ticketNumber)
        {
           var ticket=await _ticketServices.GetTicket(ticketNumber);
            if (ticket != null)
            {
                return View(ticket);
            }
            return RedirectToAction("index", "Ticket");

        }

    }
}
