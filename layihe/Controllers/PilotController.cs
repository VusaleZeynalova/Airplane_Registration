using layihe.BLL.PilotBLL;
using layihe.Dtos.PilotDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace layihe.Controllers
{
    public class PilotController : Controller
    {
        private readonly IPilotServices _pilotServices;
        private readonly IWebHostEnvironment _environment;
        public PilotController(IPilotServices pilotServices, IWebHostEnvironment webHostEnvironment)
        {
            _pilotServices = pilotServices;
            _environment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _pilotServices.Get());
        }
        public IActionResult Registration()
        {
            return View();
        }
        public async Task<IActionResult> Add([FromForm] PilotToAddDto pilottoadddto)
        {
            try
            {
                var originalFileName = pilottoadddto.ImagePath.FileName;
                string fileExtension = pilottoadddto.ImagePath.FileName.Substring(pilottoadddto.ImagePath.FileName.LastIndexOf('.') + 1);
                Guid guid = Guid.NewGuid();
                var uploads = Path.Combine(_environment.WebRootPath, "files");
                string fileName = guid.ToString() + "-fileName-" + pilottoadddto.ImagePath.FileName;
                string filePath = "/" + fileName;
                if (!Directory.Exists(Path.Combine(uploads)))
                    Directory.CreateDirectory(Path.Combine(uploads));

                if (pilottoadddto.ImagePath.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await pilottoadddto.ImagePath.CopyToAsync(fileStream);
                    }
                }
                await _pilotServices.Addsync(pilottoadddto, fileName);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

   }

