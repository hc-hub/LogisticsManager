using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogisticsManager
{
    public partial class SchedulingManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarriers();
            }
        }
        public void BindCarriers()
        {
            rpt_Carriers.DataSource = LogisticsManagerBLL.CarriersBLL.GetCarriers();
            rpt_Carriers.DataBind();
        }

        protected void rpt_Carriers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="CommandTruck")
            {
                Response.Redirect("SchedulingTruck.aspx?id="+e.CommandArgument);
            }
            if (e.CommandName=="Details")
            {
                Response.Redirect($"CarriersDetils.aspx?id={e.CommandArgument}");
            }
        }
    }
}