using HandsOnLab.WebFormClient.Models;
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
        private CarsServices _carsService;

        private async Task FillForms(int carId)
        {
            var car = await _carsService.GetCar(carId);
            if (car != null)
            {
                hfCarId.Value = car.CarId.ToString();
                txtModel.Text = car.Model;
                txtType.Text = car.Type;
                txtBasePrice.Text = car.BasePrice.HasValue ? car.BasePrice.Value.ToString("N0") : string.Empty;
                txtColor.Text = car.Color;
                txtStock.Text = car.Stock.HasValue ? car.Stock.Value.ToString() : string.Empty;
            }
        }

        private void ClearForms()
        {
            hfCarId.Value = string.Empty;
            txtModel.Text = string.Empty;
            txtType.Text = string.Empty;
            txtBasePrice.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtModel.Focus();

            btnAdd.Enabled = false;
        }

        private async Task FillGridView()
        {
            gvCars.DataSource = await _carsService.GetCars();
            gvCars.DataBind();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {

            //check session username already exists async form
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx?ReturnUrl=Default.aspx", false);
            }
            else
            {
                var user = (UserViewModel)Session["username"];
                _carsService = new CarsServices(user.Token);

                if (!IsPostBack)
                {
                    var carId = Request.QueryString["CarId"];
                    if (!string.IsNullOrEmpty(carId))
                    {
                        await FillForms(int.Parse(carId));
                    }

                    await FillGridView();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForms();
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //add car
                if (!btnAdd.Enabled && txtModel.Text == string.Empty)
                {
                    var newCar = new CarInsert
                    {
                        Model = txtModel.Text,
                        Type = txtType.Text,
                        BasePrice = Convert.ToDouble(txtBasePrice.Text),
                        Color = txtColor.Text,
                        Stock = Convert.ToInt32(txtStock.Text)
                    };
                    var result = await _carsService.AddCar(newCar);
                    btnAdd.Enabled = true;
                    ClearForms();
                    ltMessage.Text = $"<span class='alert alert-success'>Add Car {result.Model} success !</span>";
                }
                else //update car
                {
                    var updateCar = new CarUpdate
                    {
                        CarId = int.Parse(hfCarId.Value),
                        Model = txtModel.Text,
                        Type = txtType.Text,
                        BasePrice = Convert.ToDouble(txtBasePrice.Text),
                        Color = txtColor.Text,
                        Stock = Convert.ToInt32(txtStock.Text)
                    };
                    var result = await _carsService.UpdateCar(updateCar);
                    ltMessage.Text = $"<span class='alert alert-success'>Update Car {result.Model} success !</span>";
                }
            }
            catch (Exception ex)
            {
                ltMessage.Text = $"<span class='alert alert-danger'>Error: {ex.Message}</span>";
            }
            finally
            {
                await FillGridView();
            }

        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var carId = int.Parse(hfCarId.Value);
                await _carsService.DeleteCar(carId);
                ltMessage.Text = $"<span class='alert alert-success'>Delete Car {carId} success !</span>";

                await FillGridView();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}