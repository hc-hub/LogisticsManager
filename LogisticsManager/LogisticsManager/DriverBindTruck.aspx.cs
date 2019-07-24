using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogisticsManager
{
    public partial class DriverBindTruck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    string driverId = Request.QueryString["id"];
                    lblDriverName.Text = LogisticsManagerBLL.DriverBLL.GetDriverNameById(Convert.ToInt32(driverId));
                    Bindrpt_Truck();
                }
                
            }
        }
        public void Bindrpt_Truck()
        {
            int driverId = Convert.ToInt32(Request.QueryString["id"]);
            rpt_Truck.DataSource = LogisticsManagerBLL.TruckBLL.GetTruckByDriverId(driverId);
            rpt_Truck.DataBind();
        }

        protected void rpt_Truck_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="BindTruck")
            {               
                int driverID = Convert.ToInt32(Request.QueryString["id"]);
                int truckID = Convert.ToInt32(e.CommandArgument);
                int truckId= Convert.ToInt32(e.CommandArgument);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('"+ LogisticsManagerBLL.ContactBLL.BindTruck(truckID, driverID) + "')", true);
                Response.Redirect("DriverInfo.aspx");
            }
        }
    }
}