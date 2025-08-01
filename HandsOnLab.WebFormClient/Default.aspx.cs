using HandsOnLab.WebFormClient.Servives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandsOnLab.WebFormClient
{
    public partial class _Default : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var carService = new CarsServices();
                gvCars.DataSource = await carService.GetCars();
                gvCars.DataBind();
            }
        }
    }
}