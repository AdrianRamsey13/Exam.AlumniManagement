using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWeb.PhotoService;
using ExamWeb.Models;
using ExamWeb.Interfaces;

namespace ExamWeb.Services
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotoServiceClient _photoServiceClient;

        public PhotoRepository()
        {
            _photoServiceClient = new PhotoServiceClient();
        }

        public IEnumerable<PhotoDTO> GetPhotos()
        {
            var data = _photoServiceClient.GetPhotos();
            return data;
        }

        public PhotoDTO GetPhotoByID(int id)
        {
            var data = _photoServiceClient.GetPhotoByID(id);
            return data;
        }

        public void InsertPhoto(PhotoModel photo)
        {
            var data = Mapping.Mapper.Map<PhotoDTO>(photo);
            _photoServiceClient.InsertPhoto(data);
        }

        public void UpdatePhoto(PhotoModel photo)
        {
            var data = Mapping.Mapper.Map<PhotoDTO>(photo);
            _photoServiceClient.UpdatePhoto(data);
        }

        public void DeletePhoto(int id)
        {
            _photoServiceClient.DeletePhoto(id);
        }
    }
}