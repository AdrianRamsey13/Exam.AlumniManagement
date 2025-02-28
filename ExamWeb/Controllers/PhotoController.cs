using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWeb.Interfaces;
using ExamWeb.Models;
using ExamWeb.Services;
using Microsoft.Ajax.Utilities;

namespace ExamWeb.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IPhotoAlbumRepository _photoAlbumRepository;
        public int photoSizeLimit = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AlumniPhotoSizeLimit"]); // 3MB
        public string fileTypes = System.Configuration.ConfigurationManager.AppSettings["FileTypes"]; // "jpeg, jpg, png"
        public string uploadPhotoPath = System.Configuration.ConfigurationManager.AppSettings["PhotoPath"];

        public PhotoController()
        {
            _photoRepository = new PhotoRepository();
            _photoAlbumRepository = new PhotoAlbumRepository();
        }

        // GET: Photo
        public ActionResult Index(int albumID)
        {
            var album = _photoAlbumRepository.GetPhotoAlbumById(albumID);
            ViewBag.AlbumName = album.AlbumName;
            var photos = _photoRepository.GetPhotos(albumID);
            return View(photos);
        }

        public JsonResult GetPhotos(int albumID)
        {
            var photos = _photoRepository.GetPhotos(albumID);
            return Json(photos, JsonRequestBehavior.AllowGet);
        }

        // GET: Photo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photo/Create
        [HttpPost]
        public ActionResult Create(PhotoModel photo, int AlbumID)
        {
            try
            {
                // Validasi model
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Invalid data." });
                }

                // Cek apakah ada file yang diupload
                if (Request.Files.Count == 0 || Request.Files["PhotoFile"] == null)
                {
                    return Json(new { success = false, message = "Please upload a photo." });
                }

                var file = Request.Files["PhotoFile"];

                // Validasi ukuran file
                if (file.ContentLength > photoSizeLimit)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"File size must be less than {photoSizeLimit / 1024 / 1024} MB."
                    });
                }

                // Validasi ekstensi file
                var allowedExtensions = fileTypes.Split(',')
                                                 .Select(e => e.Trim().ToLower())
                                                 .ToList();
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    return Json(new
                    {
                        success = false,
                        message = $"Only {string.Join(", ", allowedExtensions)} files are allowed."
                    });
                }

                // Generate nama file unik
                var fileName = $"{Guid.NewGuid()}{extension}";
                var serverPath = Server.MapPath(uploadPhotoPath);

                // Pastikan direktori penyimpanan ada
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                // Simpan file ke server
                var filePath = Path.Combine(serverPath, fileName);
                file.SaveAs(filePath);

                // Simpan informasi file ke dalam database
                photo.PhotoPath = uploadPhotoPath;
                photo.PhotoFileName = fileName;
                photo.ModifiedDate = DateTime.Now;
                photo.AlbumID = AlbumID;
                photo.IsPhotoAlbumThumbnail = false;

                _photoRepository.InsertPhoto(photo, AlbumID);

                return Json(new { success = true, message = "Photo added successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        // POST: Photo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
