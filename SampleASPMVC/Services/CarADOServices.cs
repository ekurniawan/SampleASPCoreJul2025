using Microsoft.Data.SqlClient;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services
{
    public class CarADOServices : ICar
    {
        private readonly IConfiguration _config;

        public CarADOServices(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("AutomotiveDBConnectionString");
        }

        public Car Create(Car item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllCar", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Car> cars = new List<Car>();
                        while (reader.Read())
                        {
                            Car car = new Car
                            {
                                CarID = Convert.ToInt32(reader["CarID"]),
                                Model = reader["Model"].ToString(),
                                Type = reader["Type"].ToString(),
                                BasePrice = Convert.ToDouble(reader["BasePrice"]),
                                Color = reader["Color"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                            cars.Add(car);
                        }
                        return cars;
                    }
                }
            }
        }

        public IEnumerable<Car> GetByColor(string color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetByModel(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetByType(string type)
        {
            throw new NotImplementedException();
        }

        public Car Read(int id)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
