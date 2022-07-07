using layihe.Dtos.PilotDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.PilotBLL
{
  public  interface IPilotServices
    {
        Task Addsync(PilotToAddDto pilotToAddDto,string imagePath);
        Task<List<PilotToListDto>> Get();
    }
}
