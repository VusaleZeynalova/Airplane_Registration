using layihe.Dtos;
using layihe.Dtos.PassengerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.PassengerBLL
{
   public interface IPassengerServices
    {
        Task Addsync(PassengerToAddDto passengerToAddDto);
        Task<PassengerToListDto> GetPassenger(int id);

    }
}
