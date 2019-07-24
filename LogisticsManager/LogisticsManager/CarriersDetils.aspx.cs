using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class CarriersDetils : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarriersInfo(Convert.ToInt32(Request.QueryString["id"]));
                BindrptGoods(Convert.ToInt32(Request.QueryString["id"]));
            }
            
        }
        public void BindCarriersInfo(int carriersID)
        {
            //绑定承运单信息
            Carriers carriers = LogisticsManagerBLL.CarriersBLL.GetOneCarriers(carriersID);
            lblStartTime.Text = carriers.StartTime;
            lblSendCompany.Text = carriers.SendCompany;
            lblSendAddress.Text = carriers.SendAddress;
            lblSendPhone.Text = carriers.SendPhone;
            lblReceiveLinkman.Text = carriers.ReceiveLinkman;
            lblReceiveCompany.Text = carriers.ReceiveCompany;
            lblReceivePhone.Text = carriers.ReceivePhone;
            //if (carriers.ReceiveDate.ToString() == "0001/1/1 0:00:00")
            //{
                lblReceiveDate.Text = carriers.ReceiveDate.ToString();
            //}
            //else
            //{
                //lblReceiveDate.Text = "";
            //}
            lblTransportCost.Text = carriers.TransportCost.ToString();
            lblInsuranceCost.Text = carriers.InsuranceCost.ToString();
            lblOtherCost.Text = carriers.OtherCost.ToString();
            lblTotalCost.Text = carriers.TotalCost.ToString();
           // if (carriers.LeaverDate.ToString() == "0001/1/1 0:00:00")
            //{
                lblLeaverDate.Text = carriers.LeaverDate.ToString();
           // }
           // else
            //{
               // lblLeaverDate.Text = "";
            //}
            lblSendLinkman.Text = carriers.SendLinkman;
            lblFinishedState.Text = carriers.FinishedState.ToString();
            txtRemark.Text = carriers.Remark;
            if (lblFinishedState.Text == "0")
            {
                lblFinishedState.Text = "待调度";
            }
            else if (lblFinishedState.Text == "1")
            {
                lblFinishedState.Text = "已调度";
            }
            else if(lblFinishedState.Text == "2")
            {
                lblFinishedState.Text = "已签收";
            }
            else
            {
                lblFinishedState.Text = "已结算";
            }
            lblStartTime.Text = carriers.LeaverDate.ToString();
            lblFK_UserID.Text = LogisticsManagerBLL.UserInfoBLL.GetUserNameById(carriers.FK_UserID);
        }
        public void BindrptGoods(int carriersId)
        {
            rpt_Goods.DataSource = LogisticsManagerBLL.GoodsBLL.GetGoodsByCarriersId(carriersId);
            rpt_Goods.DataBind();
        }
    }
}