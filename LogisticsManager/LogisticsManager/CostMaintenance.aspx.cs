using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class CostMaintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"]!=null)
                {
                    int userId = (Session["User"] as List<Users>)[0].UserID;
                    BindCost(userId);
                }
            }
        }
        public string GetUserNameById(int id)
        {
            return LogisticsManagerBLL.UserInfoBLL.GetUserNameById(id);
        }
        public void BindCost(int userId)
        {
            Carriers carr = new Carriers();
            carr.FinishedState = Convert.ToByte(rdlState.SelectedValue);
            carr.ReceiveDateS = txtBeginTime.Value;
            carr.ReceiveDateE = txtEndTime.Value;
            if (!string.IsNullOrWhiteSpace(carr.ReceiveDateS) && !string.IsNullOrWhiteSpace(carr.ReceiveDateE))
            {
                if (Convert.ToDateTime(carr.ReceiveDateS) > Convert.ToDateTime(carr.ReceiveDateE))
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('开始时间不能大于结束时间！')",true);
                    return;
                }
            }
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int recordCount = 0;            
            rpt_Cost.DataSource = LogisticsManagerBLL.CarriersBLL.GetCostByUserId(userId,carr,pageSize,pageIndex,out recordCount);
            AspNetPager1.RecordCount = recordCount;
            rpt_Cost.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                int userId = (Session["User"] as List<Users>)[0].UserID;
                BindCost(userId);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                int userId = (Session["User"] as List<Users>)[0].UserID;
                BindCost(userId);
            }
        }

        protected void rpt_Cost_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Update"||e.CommandName=="Close")
            {
                if (e.CommandName=="Update")
                {
                    btnUpdate.Text = "修改";
                }
                else
                {
                    btnUpdate.Text = "结算";
                }
                update.Attributes.Add("style","display:block");
                Carriers carr = LogisticsManagerBLL.SchedulingBLL.GetFourCostById(Convert.ToInt32(e.CommandArgument));
                txtToll.Text = carr.Toll.ToString();
                txtFine.Text = carr.Fine.ToString();
                txtOilCost.Text = carr.OilCost.ToString();
                txtOtherCost.Text = carr.OtherCost.ToString();
                Session["CarriersID"] = e.CommandArgument;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            update.Attributes.Add("style", "display:none");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Scheduling sche = new Scheduling();
            sche.FK_CarriersID = Convert.ToInt32(Session["CarriersID"]);
            sche.Toll = Convert.ToDouble(txtToll.Text);
            sche.OilCost = Convert.ToDouble(txtOilCost.Text);
            sche.Fine = Convert.ToDouble(txtFine.Text);
            sche.OtherCost = Convert.ToDouble(txtOtherCost.Text);
            if (LogisticsManagerBLL.SchedulingBLL.UpdateFourCostById(sche)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+btnUpdate.Text+"成功！')",true);
                if (Session["User"] != null)
                {
                    int userId = (Session["User"] as List<Users>)[0].UserID;
                    BindCost(userId);
                }
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + btnUpdate.Text + "失败！')", true);
                return;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            rdlState.SelectedIndex = 0;
            txtBeginTime.Value = "";
            txtEndTime.Value = "";
        }
    }
}