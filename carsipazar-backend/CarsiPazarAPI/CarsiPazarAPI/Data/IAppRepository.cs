using CarsiPazarAPI.Models;

namespace CarsiPazarAPI.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        User GetUserById(int userId);
        //List<City> GetCities();
        //List<Photo> GetPhotosByCity(int cityId);
        //City GetCityById(int cityId);
        //List<City> GetCitiesByUserId(int userId);
        //Photo GetPhoto(int id);
    }
}
