using layihe.DAL.PassengerDAL;
using layihe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.AdminUnitOfWork
{
    public class PassengerUnitOfWork : IPassengerUnitOfWork
    {
        private readonly TestDbContext _testDbContext;

        public IPassengerRepository PassengerRepository { get; set; }
        public PassengerUnitOfWork(TestDbContext testDbContext,IPassengerRepository passengerRepository)
        {
            _testDbContext = testDbContext;

            PassengerRepository = passengerRepository;

        }
        public async Task Commit()
        {
            await _testDbContext.SaveChangesAsync();
        }
    }
}
