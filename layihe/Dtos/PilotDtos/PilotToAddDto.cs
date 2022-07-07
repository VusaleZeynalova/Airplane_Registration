using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Dtos.PilotDtos
{
    public class PilotToAddDto
    {
        public string PilotName { get; set; }
        public string ImagePath { get; set; }
    }
}
