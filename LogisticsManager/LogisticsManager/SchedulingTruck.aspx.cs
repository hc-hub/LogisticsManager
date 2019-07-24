using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class SchedulingTruck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindrptTruck();
            }
        }
        public void BindrptTruck()
        {
            rpt_Truck.DataSource = LogisticsManagerBLL.TruckBLL.GetNotCommandTruck();
            rpt_Truck.DataBind();
        }

        protected void rpt_Truck_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="CommandTruck")
            {
                int carriersId = Convert.ToInt32(Request.QueryString["id"]);
                int truckId = Convert.ToInt32(e.CommandArgument);
                int userId = (Session["User"] as List<Users>)[0].UserID;
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.SchedulingBLL.CommanddTruck(carriersId,truckId,userId)+"')",true);
                BindrptTruck();
            }
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("SchedulingManager.aspx");
        }
    }
}