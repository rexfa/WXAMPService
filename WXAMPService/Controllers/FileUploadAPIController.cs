using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using WXAMPService.Infrastructures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WXAMPService.Controllers
{
    [Route("api/[controller]")]
    public class FileUploadAPIController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileUploadAPIController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            //var filePath = Path.GetTempFileName();
            string filePath = "";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string imagesDir = webRootPath+@"/uploaddir/images/";
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        filePath = imagesDir + formFile.FileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {                            
                            await formFile.CopyToAsync(stream);
                        }                   
                        SySImageHandle.NormalizationImageAndSave(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                var data = new { message = ex.Message, filePath="", size="" };
                return Json(data);
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { message = "Success", count = files.Count, size, filePath });
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
