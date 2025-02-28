using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExamWeb.PhotoService;
using ExamWeb.Models;

namespace ExamWeb.Interfaces
{
    public interface IPhotoRepository
    {        
        IEnumerable<PhotoModel> GetPhotos(int AlbumID);

        
        PhotoModel GetPhotoByID(int AlbumID, int id);

        
        void InsertPhoto(PhotoModel photo, int AlbumID);

        
        void DeletePhoto(int AlbumID, int id);
    }
}
