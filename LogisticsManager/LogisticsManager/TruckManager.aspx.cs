using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogisticsManager
{
    public partial class TruckManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddl_TruckTeam_Name();
                Bindddl_Truck_Type();
                Bindddl_Truck_State();
                Bindgv_Truck();
                //searchOrders();
            }
        }
        public void Bindddl_TruckTeam_Name()
        {

            ddlTruckTeam.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruckTeam.DataTextField = "TeamName";
            ddlTruckTeam.DataValueField = "TeamID";
            ddlTruckTeam.DataBind();
            ddlTruckTeam.Items.Insert(0, new ListItem("不限", "-1"));
        }
        public void Bindddl_Truck_Type()
        {
            ddlTruckType.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck_Type();
            ddlTruckType.DataTextField = "Type";
            ddlTruckType.DataValueField = "Type";
            ddlTruckType.DataBind();
            ddlTruckType.Items.Insert(0, new ListItem("--全部--", "-1"));
        }
        public void Bindddl_Truck_State()
        {
            ddlTruckState.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck_State();
            ddlTruckState.DataTextField = "StateName";
            ddlTruckState.DataValueField = "State";
            ddlTruckState.DataBind();
            ddlTruckState.Items.Insert(0, new ListItem("--全部--", "-1"));
        }
        public void Bindgv_Truck()
        {
            Truck tk = new Truck();
            tk.FK_TeamID = Convert.ToInt32(ddlTruckTeam.SelectedValue);
            tk.Number = txtNumber.Text;
            tk.Type = ddlTruckType.SelectedValue;
            tk.State = Convert.ToInt32(ddlTruckState.SelectedValue);
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int recordCount = 0;
            gv_Truck.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck(tk, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;
            
            gv_Truck.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            searchOrders();
            
        }

        protected void gv_Truck_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int truckId = Convert.ToInt32(gv_Truck.DataKeys[e.RowIndex].Value);

            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.TruckBLL.DeleteTruck(truckId) + "')", true);
            Bindgv_Truck();

        }

        protected void gv_Truck_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detils")
            {
                Response.Redirect("TruckInfo.aspx?id=" + e.CommandArgument);
            }
            if (e.CommandName == "Update")
            {
                Response.Redirect("UpdateTruck.aspx?id=" + e.CommandArgument);
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            
            //searchOrders();
           
        }


        protected void searchOrders()
        {
            Truck tk = new Truck();
            tk.FK_TeamID = Convert.ToInt32(ddlTruckTeam.SelectedValue);
            tk.Number = txtNumber.Text;
            tk.Type = ddlTruckType.SelectedValue;
            tk.State = Convert.ToInt32(ddlTruckState.SelectedValue);
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int recordCount = 0;
            gv_Truck.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck(tk, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;
            
            gv_Truck.DataBind();

        }


        protected void AspNetPager1_PageChanging1(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            //searchOrders();
            Bindgv_Truck();
        }
    }
}
