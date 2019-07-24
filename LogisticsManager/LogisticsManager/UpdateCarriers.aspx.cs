using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class UpdateCarriers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    BindCarriers(Convert.ToInt32(Request.QueryString["id"]));
                }
                

            }
        }
        public void BindCarriers(int id)
        {
            Carriers carr = LogisticsManagerBLL.CarriersBLL.GetCarriersDetils(id);
            txtSendCompany.Text = carr.SendCompany;
            txtSendAddress.Text = carr.SendAddress;
            txtSendLinkman.Text = carr.SendLinkman;
            txtSendPhone.Text = carr.SendPhone;
            txtReceiveCompany.Text = carr.ReceiveCompany;
            txtReceiveAddress.Text = carr.ReceiveAddress;
            txtReceiveLinkman.Text = carr.ReceiveLinkman;
            txtReceivePhone.Text = carr.ReceivePhone;
            txtInsuranceCost.Text = carr.InsuranceCost.ToString();
            txtTransportCost.Text = carr.TransportCost.ToString();
            txtOtherCost.Text = carr.OtherCost.ToString();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Carriers carr = new Carriers();
            carr.SendCompany = txtSendCompany.Text;
            carr.SendAddress = txtSendAddress.Text;
            carr.SendLinkman = txtSendLinkman.Text;
            carr.SendPhone = txtSendPhone.Text;
            carr.ReceiveCompany = txtReceiveCompany.Text;
            carr.ReceiveAddress = txtReceiveAddress.Text;
            carr.ReceiveLinkman = txtReceiveLinkman.Text;
            carr.ReceivePhone = txtReceivePhone.Text;
            carr.InsuranceCost = Convert.ToDouble(txtInsuranceCost.Text);
            carr.TransportCost = Convert.ToDouble(txtTransportCost.Text);
            carr.OtherCost = Convert.ToDouble(txtOtherCost.Text);
            carr.FK_UserID = (Session["User"] as List<Users>)[0].UserID;
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.CarriersBLL.UpdateCarriersByCarriers(carr) + "')", true);

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                BindCarriers(Convert.ToInt32(Request.QueryString["id"]));
            }

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarriersManager.aspx");
        }
    }
}