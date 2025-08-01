using HandsOnLab.WebFormClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace HandsOnLab.WebFormClient.Servives
{
    public class CarsServices
    {
        private HttpClient httpClient;
        public CarsServices()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7095");
        }

        public async Task<List<Car>> GetCars()
        {
            try
            {
                var response = await httpClient.GetAsync("/api/Cars");
                if (response.IsSuccessStatusCode)
                {
                    var cars = await response.Content.ReadAsStringAsync();
                    List<Car> carList = JsonConvert.DeserializeObject<List<Car>>(cars);
                    return carList;
                }
                else
                {
                    throw new Exception("Error fetching cars data");
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Car> GetCar(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/api/Cars/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var car = await response.Content.ReadAsStringAsync();
                    Car carObj = JsonConvert.DeserializeObject<Car>(car);
                    return carObj;
                }
                else
                {
                    throw new Exception("Error fetching car data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Car> AddCar(CarInsert carInsert)
        {
            try
            {
                var json = JsonConvert.SerializeObject(carInsert);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/Cars", content);
                if (response.IsSuccessStatusCode)
                {
                    var addedCar = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Car>(addedCar);
                }
                else
                {
                    throw new Exception("Error adding car");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Car> UpdateCar(CarUpdate carUpdate)
        {
            try
            {
                var json = JsonConvert.SerializeObject(carUpdate);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"/api/Cars/{carUpdate.CarId}", content);
                if (response.IsSuccessStatusCode)
                {
                    var updatedCar = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Car>(updatedCar);
                }
                else
                {
                    throw new Exception("Error updating car");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}