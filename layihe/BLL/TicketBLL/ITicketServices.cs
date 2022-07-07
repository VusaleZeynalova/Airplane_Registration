using layihe.Dtos.TicketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.TicketBLL
{
    public interface ITicketServices
    {
        Task Addsync(TicketToAddDto ticketToAddDto);
        Task<List<TicketToListDto>> Get();
        Task Delete(int id);
        Task<TicketToListDto> GetById(int id);
        Task<TicketToListDto> GetTicket(int ticketNumber);


    }
}
