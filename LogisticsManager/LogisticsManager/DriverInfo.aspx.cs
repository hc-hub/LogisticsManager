using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class DriverInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
                Bindgv_Driver();
            }
        }
        public void BindddlTruckTeamName()
        {

            ddlTruck.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruck.DataTextField = "TeamName";
            ddlTruck.DataValueField = "TeamID";
            ddlTruck.DataBind();
            ddlTruck.Items.Insert(0, new ListItem("不限", "-1"));
        }
        public void Bindgv_Driver()
        {
            Driver dri = new Driver()
            {
                Name = txtName.Text,
                Sex = Convert.ToInt32(rdlSex.SelectedValue),
                BeginBirth = txtBeginBirth.Value,
                EndBirth = txtEndBirth.Value,
                Phone = txtPhone.Text,
                FK_TeamID = Convert.ToInt32(ddlTruck.SelectedValue),
                BeginInTime = txtBeginInTime.Value,
                EndInTime = txtEndInTime.Value,
                IDCard = txtIDCard.Text,
                State = Convert.ToByte(rdlTruckState.SelectedValue)
            };
            int recordCount = 0;
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            rpt_Driver.DataSource = LogisticsManagerBLL.DriverBLL.GetDriverInfo(dri, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;
            rpt_Driver.DataBind();
        }
        public string GetTeamNameById(int teamId)
        {
            return LogisticsManagerBLL.TruckTeamBLL.GetTruckNameById(teamId);
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Bindgv_Driver();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtIDCard.Text = "";
            txtEndInTime.Value = "";
            txtEndBirth.Value = "";
            txtBeginInTime.Value = "";
            txtBeginBirth.Value = "";
            ddlTruck.SelectedIndex = 0;
            rdlSex.SelectedIndex = 0;
            rdlTruckState.SelectedIndex = 0;
        }

        protected void rpt_Driver_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="delContact")
            {
                int truckId = Convert.ToInt32(e.CommandArgument);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.ContactBLL.DeleteContrctBytruckId(truckId) + "')", true);
                Bindgv_Driver();
            }
            if (e.CommandName== "delDriver")
            {
                int truckId = Convert.ToInt32(e.CommandArgument);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.DriverBLL.DeleteDriver(truckId) + "')", true);
                Bindgv_Driver();
            }
            if (e.CommandName == "bindTruck")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DriverBindTruck.aspx?id=" + id);
            }
            if (e.CommandName=="Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("UpdateDriver.aspx?id=" + id);
            }
        }
        public bool ChangeBind(int id)
        {
            return LogisticsManagerBLL.ContactBLL.ChangeBind(id);
        }
        public bool CancelBind(int id)
        {
            return LogisticsManagerBLL.ContactBLL.CancelBind(id);
        }

        protected void BindTruck_Click(object sender, EventArgs e)
        {
            
        }

        protected void rpt_Driver_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Bindgv_Driver();
        }
    }
}