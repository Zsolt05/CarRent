using AutoMapper;
using CarRent.Data;
using CarRent.Models;
using CarRent.Models.Car;
using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Services
{
    public interface ICarService
    {
        Task<Car> GetCar(int id);
        Task<PagedResult<Car>> GetCars(int pageNumber, int pageSize);
        Task<PagedResult<Category>> GetCategories(int pageNumber, int pageSize);
        //Task<PagedResult<Car>> CreateCar(CreateCarDto createFoodDto);
        //Task<PagedResult<Car>> UpdateCar(int id, CreateCarDto updateCarDto);
        //Task<PagedResult<Car>> DeleteCar(int id);
    }
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<Category>> GetCategories(int pageNumber, int pageSize)
        {
            var categories = await _context.Category.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = categories.Create(await _context.Category.CountAsync(), pageNumber, pageSize);
            return result;
        }
        public async Task<Car> GetCar(int id)
        {
            return await _context.Cars.Include(f => f.Category).FirstOrDefaultAsync(f => f.ID == id) ?? throw new Exception("Autó nem található");
        }
        public async Task<PagedResult<Car>> GetCars(int pageNumber, int pageSize)
        {
            var foods = await _context.Cars.Include(f => f.Category).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var result = foods.Create(await _context.Cars.CountAsync(), pageNumber, pageSize);
            return result;
        }

    }
}
