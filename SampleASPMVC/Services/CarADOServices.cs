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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string strSql = @"InsertCar";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Model", item.Model);
                    cmd.Parameters.AddWithValue("@Type", item.Type);
                    cmd.Parameters.AddWithValue("@BasePrice", item.BasePrice ?? 0.0);
                    cmd.Parameters.AddWithValue("@Color", item.Color);
                    cmd.Parameters.AddWithValue("@Stock", item.Stock ?? 0);
                    conn.Open();
                    var result = Convert.ToInt32(cmd.ExecuteScalar());
                    item.CarID = result; // Set the CarID to the newly created ID
                    return item; // Return the created car object
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Number: {sqlEx.Number} Ket:{sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetCarById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Car
                            {
                                CarID = Convert.ToInt32(reader["CarID"]),
                                Model = reader["Model"].ToString(),
                                Type = reader["Type"].ToString(),
                                BasePrice = Convert.ToDouble(reader["BasePrice"]),
                                Color = reader["Color"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                        }
                        return null; // or throw an exception if not found
                    }
                }
            }
        }

        public Car Update(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
