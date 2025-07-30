using Microsoft.EntityFrameworkCore;
using SampleAspMvcEF.Models;

namespace SampleAspMvcEF.DAL
{
    public class DealerCarDAL : IDealerCar
    {
        private readonly AutomotiveDB3Context _context;
        public DealerCarDAL(AutomotiveDB3Context context)
        {
            _context = context;
        }

        public DealerCar Create(DealerCar item)
        {
            try
            {
                _context.DealerCars.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while creating the dealer car.", ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DealerCar> GetAll()
        {
            var results = _context.DealerCars.Include(c => c.Car).Include(d => d.Dealer)
                                              .ToList();

            //var results = from dc in _context.DealerCars
            //              join c in _context.Cars on dc.CarId equals c.CarId
            //              join d in _context.Dealers on dc.DealerId equals d.DealerId
            //              orderby dc.Price descending
            //              select new DealerCar
            //              {
            //                  DealerCarId = dc.DealerCarId,
            //                  CarId = dc.CarId,
            //                  DealerId = dc.DealerId,
            //                  Price = dc.Price,
            //                  Stock = dc.Stock,
            //                  DiscountPercent = dc.DiscountPercent,
            //                  FeePercent = dc.FeePercent,
            //                  Car = c,
            //                  Dealer = d
            //              };

            return results;
        }

        public DealerCar GetById(int id)
        {
            var result = _context.DealerCars.Include(c => c.Car).Include(d => d.Dealer)
                                        .FirstOrDefault(dc => dc.DealerCarId == id);

            if (result == null)
                throw new Exception($"DealerCar with ID {id} not found.");

            return result;
        }

        public DealerCar Update(DealerCar item)
        {
            throw new NotImplementedException();
        }
    }
}
