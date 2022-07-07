using layihe.DAL.TicketDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
  public  interface ITicketUnitOfWork
    {
        public ITicketRepository TicketRepository { get; set; }
        Task Commit();
    }
}
