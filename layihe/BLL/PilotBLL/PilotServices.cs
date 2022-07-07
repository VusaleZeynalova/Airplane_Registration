using AutoMapper;
using layihe.AdminUnitOfWork;
using layihe.Dtos.PilotDtos;
using layihe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.BLL.PilotBLL
{
    public class PilotServices : IPilotServices
    {
        private readonly IMapper _mapper;
        private readonly IPilotUnitOfWork _pilotUnitOf;
        public PilotServices(IMapper mapper,IPilotUnitOfWork pilot)
        {
            _mapper = mapper;
            _pilotUnitOf = pilot;

        }
        public async Task Addsync(PilotToAddDto pilotToAddDto,string imagePath)
        {
            Pilot pilot = _mapper.Map<Pilot>(pilotToAddDto);
            pilot.ImagePath = imagePath;
            await _pilotUnitOf.PilotRepository.Addasync(pilot);
            await _pilotUnitOf.Commit();
        }

        public async Task<List<PilotToListDto>> Get()
        {
            List<Pilot> pilots = await _pilotUnitOf.PilotRepository.Get();
            List<PilotToListDto> pilotToListDtos = _mapper.Map<List<PilotToListDto>>(pilots);
            return pilotToListDtos;
        }
    }
}
