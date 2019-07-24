using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;
namespace LogisticsManager
{
    public partial class UpdateTruck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
                Bindddl_Truck_Type();
                Bindddl_Truck_State();
                if (Request.QueryString["id"] != null)
                {
                    int truckId = Convert.ToInt32(Request.QueryString["id"]);
                    BindTruckInfo(truckId);
                }
            }

        }
        public void BindddlTruckTeamName()
        {

            ddlTruck.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruck.DataTextField = "TeamName";
            ddlTruck.DataValueField = "TeamID";
            ddlTruck.DataBind();
        }
        public void Bindddl_Truck_Type()
        {
            ddlTruckType.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck_Type();
            ddlTruckType.DataTextField = "Type";
            ddlTruckType.DataValueField = "Type";
            ddlTruckType.DataBind();
        }
        public void Bindddl_Truck_State()
        {
            ddlTruckState.DataSource = LogisticsManagerBLL.TruckBLL.GetTruck_State();
            ddlTruckState.DataTextField = "StateName";
            ddlTruckState.DataValueField = "State";
            ddlTruckState.DataBind();
        }
        public void BindTruckInfo(int truckId)
        {
            Truck tk = LogisticsManagerBLL.TruckBLL.GetTruckById(truckId);
            txtNumber.Text = tk.Number;
            txtBuyDate.Value = tk.BuyDate.ToString();
            txtLength.Text = tk.Length;
            txtRemark.Text = tk.Remark;
            txtTonnage.Text = tk.Tonnage.ToString();
            ddlTruck.SelectedValue = tk.FK_TeamID.ToString();
            ddlTruckType.SelectedValue = tk.Type;
            ddlTruckState.SelectedValue = tk.State.ToString();

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TruckManager.aspx");
        }

        protected void btnUpdat_Click(object sender, EventArgs e)
        {
            Truck tk = new Truck();
            tk.TruckID= Convert.ToInt32(Request.QueryString["id"]);
            tk.Number = txtNumber.Text;
            tk.Length = txtLength.Text;
            tk.Tonnage = Convert.ToInt16(txtTonnage.Text);
            tk.Remark = txtRemark.Text;
            tk.BuyDate = Convert.ToDateTime(txtBuyDate.Value);
            tk.FK_TeamID = Convert.ToInt32(ddlTruck.SelectedValue);
            tk.Type = ddlTruckType.SelectedValue;
            tk.State = Convert.ToInt32(ddlTruckState.SelectedValue);
            if (LogisticsManagerBLL.TruckBLL.UpdateTruckInfo(tk)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败!')", true);
                return;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("TruckManager.aspx");
        }
    }
}