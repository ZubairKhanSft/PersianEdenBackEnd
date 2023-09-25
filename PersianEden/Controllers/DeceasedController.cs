using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PersianEden.Helpers;
using PersianEden.Infrastructure.Managers;
using PersianEden.Models.Deceased;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersianEden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeceasedController : ControllerBase
    {

        private readonly IHostingEnvironment _environment;
        public readonly IDeceasedPersonManager _manager;
        public DeceasedController(IDeceasedPersonManager manager, IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }        

       [HttpPost]
       [Route("Add-Deceased-Person")]
        public async Task<IActionResult> Add(AddDeceasedPersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
               var DeceasedId = await _manager.AddAsync(model);
                AddDeceasedPersonModel multi = new AddDeceasedPersonModel();
                multi.Id = DeceasedId;
                
                string extensions;
                string extension;
                if (model.FuneralVideo != null)
                {
                    foreach (var item in model.FuneralVideo)
                    {
                        if (item!=null && item!="" && item!="string")
                        {
                            var data1 = item.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                                case "IVBOR":
                                    extension = ".jpg";
                                    extensions = "jpg";
                                    break;

                                case "/9J/4":
                                    extension = ".png";
                                    extensions = "png";
                                    break;

                                case "AAAAI":
                                    extension = ".mp4";
                                  
                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";
                                  
                                    extensions = "jpeg";
                                    break;
                            }
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "FuneralVideo");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "video/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(item);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            multi.FileUrl = filename;
                            await _manager.AddFuneralVideo(multi);
                        }
                    }
                }

                if(model.FuneralImage != null)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                {
                    foreach (var item in model.FuneralImage)
                    {
                        if (item != null && item != "" && item != "string")
                        {
                            var data1 = item.Substring(0, 5);
                            switch (data1.ToUpper())
                            {
                               

                                case "AAAAI":
                                    extension = ".mp4";

                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";

                                    extensions = "jpeg";
                                    break;
                            }
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "FuneralImage");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "image/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(item);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            multi.FileUrl = filename;
                            await _manager.AddFuneralImage(multi);
                        }
                    }

                }

                if (model.MemorialVideo != null)
                {
                    foreach (var item in model.MemorialVideo)
                    {
                        if (item != null && item != "" && item != "string")
                        {
                            var data1 = item.Substring(0, 5);
                            switch (data1.ToUpper())
                            {


                                case "AAAAI":
                                    extension = ".mp4";

                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";

                                    extensions = "jpeg";
                                    break;
                            }
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "MemorialVideo");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "video/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(item);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            multi.FileUrl = filename;
                            await _manager.AddMemorialVideo(multi);
                        }
                    }

                }

                if (model.MemorialImage != null)
                {
                    foreach (var item in model.MemorialImage)
                    {
                        if (item != null && item != "" && item != "string")
                        {
                            var data1 = item.Substring(0, 5);
                            switch (data1.ToUpper())
                            {


                                case "AAAAI":
                                    extension = ".mp4";

                                    extensions = "mp4";
                                    break;

                                default:
                                    extension = ".jpeg";

                                    extensions = "jpeg";
                                    break;
                            }
                            var myfilename = string.Format(@"{0}", Guid.NewGuid());

                            var fileExtension = Path.GetExtension(myfilename);

                            string uploadsFolder = Path.Combine(_environment.WebRootPath, "Attachment", "MemorialImage");

                            string filepath = uploadsFolder + "/" + myfilename + extension;

                            string filename = "image/" + myfilename + extension;

                            var bytess = Convert.FromBase64String(item);
                            using (var imageFile = new FileStream(filepath, FileMode.Create))
                            {
                                imageFile.Write(bytess, 0, bytess.Length);
                                imageFile.Flush();
                            }
                            multi.FileUrl = filename;
                            await _manager.AddMemorialImage(multi);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok("Added");

        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAllAsync());
        }

        [HttpPost]
        [Route("GetAll-V1")]
        public async Task<IActionResult> GetAll_V1()
        {
            return Ok(await _manager.GetAll_V1());
        }
    }
}
