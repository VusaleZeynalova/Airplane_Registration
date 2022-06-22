using layihe.Dtos.FlightDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.FlightBLL
{
   public interface IFlightServices
    {
        Task Addasync(FlightToAddDto flightToAddDto);
        Task<List<FlightToListDto>> Get();
        Task<FlightToAddDto> InnerModel();

    }
}
