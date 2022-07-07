using layihe.DAL.PilotDAL;
using layihe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public class PilotUnitOfWork : IPilotUnitOfWork
    {
        private readonly TestDbContext _testDbContext;
        public IPilotRepository PilotRepository { get ; set; }
        public PilotUnitOfWork(TestDbContext testDbContext,IPilotRepository pilotRepository)
        {
            _testDbContext = testDbContext;
            PilotRepository = pilotRepository;
        }

        public async Task Commit()
        {
            await _testDbContext.SaveChangesAsync();
        }
    }
}
