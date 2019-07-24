using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class AddTruck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
                Bindddl_Truck_Type();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入车队号码！')",true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtBuyDate.Value))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入购买时间！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLength.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入车身长度！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTonnage.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入车辆吨位！')", true);
                return;
            }
            Truck tk = new Truck()
            {
                Number=txtNumber.Text,
                FK_TeamID=int.Parse(ddlTruck.SelectedValue),
                Type=ddlTruckType.SelectedValue,
                BuyDate=Convert.ToDateTime(txtBuyDate.Value),
                Length=txtLength.Text,
                Tonnage=int.Parse(txtTonnage.Text),
                Remark=txtRemark.Text
            };
            if (LogisticsManagerBLL.TruckBLL.AddTruck(tk)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！')", true);
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！')", true);
                return;
            }           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtBuyDate.Value = "";
            txtLength.Text = "";
            txtNumber.Text = "";
            txtRemark.Text = "";
            txtTonnage.Text = "";
            ddlTruck.SelectedIndex = 0;
            ddlTruckType.SelectedIndex = 0;            
        }
    }
}