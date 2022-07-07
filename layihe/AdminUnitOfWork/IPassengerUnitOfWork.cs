using layihe.DAL.PassengerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
  public  interface IPassengerUnitOfWork
    {
        public IPassengerRepository PassengerRepository { get; set; }
        Task Commit();
    }
}
