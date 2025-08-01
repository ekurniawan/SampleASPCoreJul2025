using HandsOnLab.WebFormClient.Servives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandsOnLab.WebFormClient
{
    public partial class _Default : Page
    {
        private CarsServices _carsService = new CarsServices();

        private async Task FillForms(int carId)
        {
            var car = await _carsService.GetCar(carId);
            if (car != null)
            {
                txtModel.Text = car.Model;
                txtType.Text = car.Type;
                txtBasePrice.Text = car.BasePrice.HasValue ? car.BasePrice.Value.ToString("N0") : string.Empty;
                txtColor.Text = car.Color;
                txtStock.Text = car.Stock.HasValue ? car.Stock.Value.ToString() : string.Empty;
            }
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            var carId = Request.QueryString["CarId"];
            if (!string.IsNullOrEmpty(carId))
            {
                await FillForms(int.Parse(carId));
            }

            if (!IsPostBack)
            {
                var carService = new CarsServices();
                gvCars.DataSource = await carService.GetCars();
                gvCars.DataBind();
            }
        }
    }
}