using layihe.DAL.PilotDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public interface IPilotUnitOfWork
    {
        public IPilotRepository PilotRepository { get; set; }
        Task Commit();
    }
}
