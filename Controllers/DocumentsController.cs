using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TN_Treasury_Web_Portal.Data;
using TN_Treasury_Web_Portal.Models;

namespace TN_Treasury_Web_Portal.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public async Task<IActionResult> IndexAsync()
        {
            return _context.Document != null ?
                          View(await _context.Document.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Document'  is null.");
          
        }




        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file , string description )
        {
            if (file != null && file.Length > 0)
            {
                try
                {

                    string uploadDir = Path.Combine(_environment.WebRootPath, "Uploads");


                    if (!Directory.Exists(uploadDir))
                        Directory.CreateDirectory(uploadDir);

                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadDir, file.FileName);
                    string relativeFilePath = "/Uploads/" + fileName;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var document = new Document
                    {
                        FileName = fileName,
                        FilePath = relativeFilePath,
                        Description = description
                    };
                    

                    _context.Add(document);
                    await _context.SaveChangesAsync(); 

                    ViewBag.Message = "File uploaded successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Error = "Please select a file";
                return RedirectToAction("Index");
            }


            
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
          
                var document = await _context.Document.FindAsync(id);

                if (document == null)
                {
                    return NotFound();
                }


                if (!string.IsNullOrEmpty(document.FilePath)) 
                {
                    try
                    {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "Uploads");
                    string filePath = Path.Combine(uploadDir, document.FileName);

                    System.IO.File.Delete(filePath);  

                    }
                    catch (Exception ex)
                    {
                    return StatusCode(500, $"An error occurred while deleting the file: {ex.Message}");
                }
                }

                _context.Document.Remove(document);
                await _context.SaveChangesAsync();
          

            return RedirectToAction("Index");   
        }




    }
}
