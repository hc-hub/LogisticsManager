using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class HistoryCarriage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarrisesH();
            }
        }
        public void BindCarrisesH()
        {
            
            Carriers carr = new Carriers();
            if (string.IsNullOrWhiteSpace(txtCarriersID.Text))
            {
                carr.CarriersID = 0;
            }
            else
            {
                try
                {
                    carr.CarriersID = Convert.ToInt32(txtCarriersID.Text);
                }
                catch (Exception)
                {

                    this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('输入承运单编号格式不正确！')",true);
                    return;
                }
            }           
            carr.LeaverDateS = txtLeaverDateS.Value;
            carr.LeaverDateE = txtLeaverDateE.Value;
            carr.ReceiveDateS = txtReceiveDateS.Value;
            carr.ReceiveDateE = txtReceiveDateE.Value;
            carr.ReceiveLinkman = txtReceiveLinkman.Text;
            carr.SendLinkman = txtSendLinkMan.Text;
            carr.UserName = txtUserName.Text;
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int recordCount = 0;
            rptCarriersH.DataSource = LogisticsManagerBLL.CarriersBLL.GetCarriersH(carr, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;
            rptCarriersH.DataBind();
        }
        public string ChangeName(int id)
        {
            return LogisticsManagerBLL.UserInfoBLL.GetUserNameById(id);
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindCarrisesH();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindCarrisesH();
        }

        protected void rptCarriersH_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Detils")
            {
                Response.Redirect($"CarriersDetils.aspx?id={e.CommandArgument}");
            }
        }
    }
}