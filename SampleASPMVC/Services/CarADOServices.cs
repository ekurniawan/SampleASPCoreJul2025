using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using SampleASPMVC.Models;
using System.Collections.Generic;
using System.Drawing;

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

                    //CREATE PROCEDURE dbo.InsertCar
                    //    @Model NVARCHAR(100),
                    //    @Type NVARCHAR(50),
                    //    @BasePrice DECIMAL(18,2),
                    //    @Color NVARCHAR(50),
                    //    @Stock INT
                    //AS
                    //BEGIN
                    //    SET NOCOUNT ON;

                    //    INSERT INTO Car (Model, Type, BasePrice, Color, Stock)
                    //    VALUES (@Model, @Type, @BasePrice, @Color, @Stock);

                    //    SELECT SCOPE_IDENTITY() AS NewCarId;
                    //END

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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    //CREATE PROCEDURE dbo.DeleteCar
                    //    @CarID INT
                    //AS
                    //BEGIN
                    //    SET NOCOUNT OFF;
                    //    DELETE FROM Car WHERE CarID = @CarID;
                    //END
                    string strSql = @"DeleteCar";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarID", id);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("No rows were deleted. The car may not exist.");
                    }
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

        public IEnumerable<Car> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var cars = conn.Query<Car>("GetAllCar", commandType: System.Data.CommandType.StoredProcedure).ToList();
                return cars;

                //conn.Open();
                //using (SqlCommand cmd = new SqlCommand("GetAllCar", conn))
                //{
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        List<Car> cars = new List<Car>();
                //        while (reader.Read())
                //        {
                //            Car car = new Car
                //            {
                //                CarID = Convert.ToInt32(reader["CarID"]),
                //                Model = reader["Model"].ToString(),
                //                Type = reader["Type"].ToString(),
                //                BasePrice = Convert.ToDouble(reader["BasePrice"]),
                //                Color = reader["Color"].ToString(),
                //                Stock = Convert.ToInt32(reader["Stock"])
                //            };
                //            cars.Add(car);
                //        }
                //        return cars;
                //    }
                //}
            }
        }

        public IEnumerable<Car> GetByColor(string color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetByModel(string model)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var cars = conn.Query<Car>("SearchCars",
                    new { Model = "%" + model + "%", Type = "%" + model + "%", Color = "%" + model + "%" },
                    commandType: System.Data.CommandType.StoredProcedure).ToList();
                return cars;
                //                CREATE PROCEDURE dbo.SearchCars
                //    @Model NVARCHAR(100),
                //    @Type NVARCHAR(100),
                //    @Color NVARCHAR(100)
                //AS
                //BEGIN
                //    SET NOCOUNT ON;

                //                SELECT*
                //                FROM Car
                //                WHERE Model LIKE @Model
                //                   OR Type LIKE @Type
                //                   OR Color LIKE @Color
                //                ORDER BY Model ASC;
                //                END
                //string strSql = @"SearchCars";
                //SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Model", "%" + model + "%");
                //cmd.Parameters.AddWithValue("@Type", "%" + model + "%");
                //cmd.Parameters.AddWithValue("@Color", "%" + model + "%");
                //conn.Open();
                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    List<Car> cars = new List<Car>();
                //    while (reader.Read())
                //    {
                //        Car car = new Car
                //        {
                //            CarID = Convert.ToInt32(reader["CarID"]),
                //            Model = reader["Model"].ToString(),
                //            Type = reader["Type"].ToString(),
                //            BasePrice = Convert.ToDouble(reader["BasePrice"]),
                //            Color = reader["Color"].ToString(),
                //            Stock = Convert.ToInt32(reader["Stock"])
                //        };
                //        cars.Add(car);
                //    }
                //    return cars;
                //}
            }
        }

        public IEnumerable<Car> GetByType(string type)
        {
            throw new NotImplementedException();
        }

        public Car Read(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var car = conn.QueryFirstOrDefault<Car>("GetCarById",
                    new { CarID = id }, commandType: System.Data.CommandType.StoredProcedure);

                if (car == null)
                {
                    throw new Exception("Car not found.");
                }
                return car;
                //conn.Open();
                //using (SqlCommand cmd = new SqlCommand("GetCarById", conn))
                //{
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@CarID", id);
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {
                //        if (reader.Read())
                //        {
                //            return new Car
                //            {
                //                CarID = Convert.ToInt32(reader["CarID"]),
                //                Model = reader["Model"].ToString(),
                //                Type = reader["Type"].ToString(),
                //                BasePrice = Convert.ToDouble(reader["BasePrice"]),
                //                Color = reader["Color"].ToString(),
                //                Stock = Convert.ToInt32(reader["Stock"])
                //            };
                //        }
                //        return null; // or throw an exception if not found
                //    }
                //}
            }
        }

        public Car Update(Car item)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    //                    CREATE PROCEDURE dbo.UpdateCar
                    //                        @CarID INT,
                    //    @Model NVARCHAR(100),
                    //    @Type NVARCHAR(50),
                    //    @BasePrice DECIMAL(18,2),
                    //    @Color NVARCHAR(50),
                    //    @Stock INT
                    //AS
                    //BEGIN
                    //    SET NOCOUNT OFF;

                    //                    UPDATE Car
                    //    SET
                    //        Model = @Model,
                    //        Type = @Type,
                    //        BasePrice = @BasePrice,
                    //        Color = @Color,
                    //        Stock = @Stock
                    //    WHERE CarID = @CarID;
                    //                    END


                    string strSql = @"UpdateCar";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CarID", item.CarID);
                    cmd.Parameters.AddWithValue("@Model", item.Model);
                    cmd.Parameters.AddWithValue("@Type", item.Type);
                    cmd.Parameters.AddWithValue("@BasePrice", item.BasePrice ?? 0.0);
                    cmd.Parameters.AddWithValue("@Color", item.Color);
                    cmd.Parameters.AddWithValue("@Stock", item.Stock ?? 0);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return item; // Return the updated car object
                    }
                    else
                    {
                        throw new Exception("No rows were updated. The car may not exist.");
                    }
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
    }
}
