using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class AddCarriers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSendCompany.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入发货单位！')",true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReceiveCompany.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入收货单位！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSendAddress.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入发货单位地址！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReceiveAddress.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入收货单位地址！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSendLinkman.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入发货人！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReceiveLinkman.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入收货人！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSendPhone.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入发货人电话！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtReceivePhone.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入收货人电话！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInsuranceCost.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入保险费！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTransportCost.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入运费！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtOtherCost.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入其他费用！')", true);
                return;
            }
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
            this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.CarriersBLL.AddCarriers(carr)+"')",true);
        }

       

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSendCompany.Text="";
            txtSendAddress.Text = "";
            txtSendLinkman.Text = "";
            txtSendPhone.Text = "";
           txtReceiveCompany.Text = "";
             txtReceiveAddress.Text = "";
             txtReceiveLinkman.Text = "";
             txtReceivePhone.Text = "";
            txtInsuranceCost.Text = "";
            txtTransportCost.Text = "";
            txtOtherCost.Text = "";
        }
    }
}