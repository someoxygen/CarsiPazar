using CarsiPazarAPI.Data;
using CarsiPazarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsiPazarAPI.Data
{
    public class AppRepository : IAppRepository
    {
        DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //public List<City> GetCities()
        //{
        //    var cities = _context.Cities.Include(c => c.Photos).ToList();
        //    return cities;
        //}

        //public City GetCityById(int cityId)
        //{
        //    var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == cityId);
        //    return city;
        //}
        //public List<City> GetCitiesByUserId(int userId)
        //{
        //    var city = _context.Cities.Include(c => c.Photos).Where(c => c.UserId == userId).ToList();
        //    return city;
        //}
        public User GetUserById(int userId)
        {
            var user = _context.users.FirstOrDefault(c => c.Id == userId);
            return user;
        }

        //public Photo GetPhoto(int id)
        //{
        //    var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
        //    return photo;
        //}

        //public List<Photo> GetPhotosByCity(int cityId)
        //{
        //    var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
        //    return photos;
        //}

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}