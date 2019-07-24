using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class UpdateDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
                if (Request.QueryString["id"]!=null)
                {
                    int driverId = Convert.ToInt32(Request.QueryString["id"]);
                    BindDriver(driverId);
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
        public void BindDriver(int driverId)
        {
            Driver dri = LogisticsManagerBLL.DriverBLL.GetDriverDetils(driverId);
            txtName.Text = dri.Name;
            txtPhone.Text = dri.Phone;
            txtIDCard.Text = dri.IDCard;
            txtRemark.Text = dri.Remark;
            txtBeginTime.Value = dri.Birth.ToString();
            ddlTruck.SelectedValue = dri.FK_TeamID.ToString();
            rdlSex.SelectedValue = dri.Sex.ToString();
            rdlState.SelectedValue = dri.State.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Driver dri = new Driver();
            dri.DriverID = Convert.ToInt32(Request.QueryString["id"]);
            dri.Name = txtName.Text;
            dri.Phone = txtPhone.Text;
            dri.IDCard = txtIDCard.Text;
            dri.Remark = txtRemark.Text;
            dri.Birth = Convert.ToDateTime(txtBeginTime.Value);
            dri.FK_TeamID = Convert.ToInt32(ddlTruck.SelectedValue);
            dri.Sex = Convert.ToInt32(rdlSex.SelectedValue);
            dri.State = Convert.ToByte(rdlState.SelectedValue);
            this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.DriverBLL.UpdateDriver(dri)+"')",true);
            return;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}