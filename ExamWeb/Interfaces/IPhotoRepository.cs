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
        
        IEnumerable<PhotoDTO> GetPhotos();

        
        PhotoDTO GetPhotoByID(int id);

        
        void InsertPhoto(PhotoModel photo);

        
        void UpdatePhoto(PhotoModel photo);

        
        void DeletePhoto(int id);
    }
}
