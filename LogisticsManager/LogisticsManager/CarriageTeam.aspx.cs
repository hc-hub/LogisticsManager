using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class CarriageTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
                BindrptTruckTeam();
            }
        }
        public void BindddlTruckTeamName()
        {

            ddlTruck.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruck.DataTextField = "TeamName";
            ddlTruck.DataValueField = "TeamName";
            ddlTruck.DataBind();
            ddlTruck.Items.Insert(0, new ListItem("不限", "-1"));
        }
        public void BindrptTruckTeam()
        {
            rpt_TruckTeam.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckTeams();
            rpt_TruckTeam.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            TruckTeam tt = new TruckTeam()
            {
                TeamName = ddlTruck.SelectedValue,
                Leader=txtLeader.Text
            };
            rpt_TruckTeam.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckTeams(tt);
            rpt_TruckTeam.DataBind();
        }

        protected void rpt_TruckTeam_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Truck")
            {
                Response.Redirect("CarriageTruck.aspx?id="+e.CommandArgument);
            }
        }
        public static string StringTruncat(string oldStr)
        {
            return Utility.Class1.StringTruncat(oldStr, 20, "...");
        }
    }
}