using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class CarriersManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarriers();
            }
            
        }
        public string ChangeState(int id)
        {
            if (id==0)
            {
                return "待调度";
            }
            else if(id==1)
            {
                return "已调度";
            }
            else if(id==2)
            {
                return "已签收";
            }
            else if (id==3)
            {
                return "已结算";
            }
            else
            {
                return "不详";
            }
        }
        public void BindCarriers()
        {          
            rpt_Carriers.DataSource=LogisticsManagerBLL.CarriersBLL.GetCarriers();
            rpt_Carriers.DataBind();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Carriers carr = new Carriers();
            try
            {
                carr.CarriersID = Convert.ToInt32(txtCarriersId.Text);
            }
            catch (Exception)
            {

                carr.CarriersID = 0;
            }
            try
            {
                DateTime dt = Convert.ToDateTime(txtBeginTime.Value);
                carr.LeaverDateS = txtBeginTime.Value;
            }
            catch (Exception)
            {

                carr.LeaverDateS = "";
            }
            try
            {
                DateTime dt = Convert.ToDateTime(txtEndTime.Value);
                carr.LeaverDateE = txtEndTime.Value;
            }
            catch (Exception)
            {

                carr.LeaverDateE = "";
            }
            carr.SendLinkman = txtSendLinkman.Text;
            carr.ReceiveLinkman = txtReceiveLinkman.Text;
            rpt_Carriers.DataSource = LogisticsManagerBLL.CarriersBLL.GetCarriersWhere(carr);
            rpt_Carriers.DataBind();
        }

        protected void rpt_Carriers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void rpt_Carriers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.CarriersBLL.DeleteCarriers(id)+"')",true);
                BindCarriers();
                return;
            }
            if (e.CommandName=="Detils")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("CarriersDetils.aspx?id="+id);
            }
            if (e.CommandName=="AddGoods")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("AddGoods.aspx?id=" + id);
            }
            if (e.CommandName=="Update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("UpdateCarriers.aspx?id=" + id);
            }
        }

    }
}