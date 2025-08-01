using HandsOnLab.BO;
using Microsoft.EntityFrameworkCore;

namespace HandsOnLab.DAL
{
    public class DealerCarDAL : IDealerCar
    {
        private readonly AutomotiveDB3Context _context;
        public DealerCarDAL(AutomotiveDB3Context context)
        {
            _context = context;
        }

        private bool IsExistDealerAndCar(int carId, int dealerId)
        {
            return _context.DealerCars.Any(dc => dc.CarId == carId && dc.DealerId == dealerId);
        }

        public DealerCar Create(DealerCar item)
        {
            try
            {
                var existingCarAndDealer = IsExistDealerAndCar(item.CarId, item.DealerId);

                if (existingCarAndDealer)
                {
                    throw new ArgumentException($"A dealer car with CarId {item.CarId} and DealerId {item.DealerId} already exists.");
                }

                _context.DealerCars.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (ArgumentException aEx)
            {
                // Log the exception (not implemented here)
                throw new ArgumentException($"{aEx.Message}");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while adding the dealer car.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var dealerCar = GetById(id);
                if (dealerCar == null)
                {
                    throw new Exception($"DealerCar with ID {id} not found.");
                }

                _context.DealerCars.Remove(dealerCar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while deleting the dealer car.", ex);
            }
        }

        public IEnumerable<DealerCar> GetAll()
        {
            var results = _context.DealerCars.Include(c => c.Car).Include(d => d.Dealer).AsNoTracking()
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
            try
            {
                var existingDealerCar = GetById(item.DealerCarId);
                if (existingDealerCar == null)
                {
                    throw new ArgumentException($"DealerCar with ID {item.DealerCarId} not found.");
                }
                else
                {
                    if (existingDealerCar.CarId != item.CarId && existingDealerCar.DealerId != item.DealerId)
                    {
                        var existingCarAndDealer = IsExistDealerAndCar(item.CarId, item.DealerId);
                        if (existingCarAndDealer)
                        {
                            throw new ArgumentException($"A dealer car with CarId {item.CarId} and DealerId {item.DealerId} already exists.");
                        }
                    }
                }

                existingDealerCar.CarId = item.CarId;
                existingDealerCar.DealerId = item.DealerId;
                existingDealerCar.Price = item.Price;
                existingDealerCar.Stock = item.Stock;
                existingDealerCar.DiscountPercent = item.DiscountPercent;
                existingDealerCar.FeePercent = item.FeePercent;

                _context.SaveChanges();
                return existingDealerCar;
            }
            catch (ArgumentException aEx)
            {
                // Log the exception (not implemented here)
                throw new ArgumentException($"{aEx.Message}");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while updating the dealer car.", ex);
            }
        }
    }
}
