using layihe.DAL.TicketDAL;
using layihe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public class TicketUnitOfWork : ITicketUnitOfWork
    {
        private readonly TestDbContext _testDbContext;
        public ITicketRepository TicketRepository { get; set; }
        public TicketUnitOfWork(TestDbContext testDbContext,ITicketRepository ticketRepository)
        {
            _testDbContext = testDbContext;
            TicketRepository = ticketRepository;
        }
        public async Task Commit()
        {
            await _testDbContext.SaveChangesAsync();
        }
    }
}
