using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.PilotDAL
{
    public interface IPilotRepository
    {
        Task Addasync(Pilot pilot);
        Task<List<Pilot>> Get();
    }
}
