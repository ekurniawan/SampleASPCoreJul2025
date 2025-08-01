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
    }
}