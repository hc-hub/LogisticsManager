using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace LogisticsManager
{
    public partial class CarriageTruck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddl_TruckTeam_Name();
                Bindddl_Truck_Type();
                Bindddl_Truck_State();
                Bindgv_Truck();
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
            rptTruck.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck(tk, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;

            rptTruck.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Bindgv_Truck();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bindgv_Truck();
        }
        public static string StringTruncat(string oldStr)
        {
            return Utility.Class1.StringTruncat(oldStr,10,"...");
        }
    }
}