using layihe.DataContext;
using layihe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.TicketDAL
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TestDbContext _testDbContext;
        public TicketRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }
        public async Task Addsync(Ticket ticket)
        {
             await _testDbContext.AddAsync(ticket);

        }

        public async Task Delete(int id)
        {
            var result = await _testDbContext.Tickets.FindAsync(id);
             _testDbContext.Tickets.Remove(result);
            
        }

        public async Task<List<Ticket>> Get()
        {
            return await _testDbContext.Tickets.Include(m => m.NewFlight).ThenInclude(x=>x.DepartureCity).Include(m=>m.NewFlight).ThenInclude(x=>x.ArrivialCity).Include(m => m.Passenger).ToListAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _testDbContext.Tickets.FindAsync(id);
        }

        public async Task<Ticket> GetTicket(int ticketNumber)
        {
            return await  _testDbContext.Tickets.FirstOrDefaultAsync(m => m.TicketNumber == ticketNumber);
        }
    }
}
