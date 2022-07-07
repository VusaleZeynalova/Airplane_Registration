using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.TicketDAL
{
  public  interface ITicketRepository
    {
        Task Addsync(Ticket ticket);
        Task<List<Ticket>> Get();
        Task Delete(int id);
        Task<Ticket> GetById(int id);
        Task<Ticket> GetTicket(int ticketNumber);
    }
}
