using layihe.DataContext;
using layihe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.DAL.PilotDAL
{
    public class PilotRepository : IPilotRepository
    {
        private readonly TestDbContext _testDbContext;
        public PilotRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;

        }
        public async Task Addasync(Pilot pilot)
        {
            await _testDbContext.AddAsync(pilot);

        }

        public async Task<List<Pilot>> Get()
        {
            return await _testDbContext.Pilots.ToListAsync();
        }
    }
}
