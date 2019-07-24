using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class TruckInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    int truckId = Convert.ToInt32(Request.QueryString["id"]);
                    BindTruckInfo(truckId);
                }
            }
        }
        public void BindTruckInfo(int truckId)
        {
            Truck tk = LogisticsManagerBLL.TruckBLL.GetTruckById(truckId);
            lblNumber.Text = tk.Number;
            lblTeamName.Text = tk.TeamName;
            lblLength.Text = tk.Length;
            lblBuyDate.Text = tk.BuyDate.ToString();
            lblTonnage.Text = tk.Tonnage.ToString();
            lblType.Text = tk.Type;
            lblState.Text = tk.State.ToString();
            txtRemark.Text = tk.Remark;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TruckManager.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateTruck.aspx?id="+ Request.QueryString["id"]);
        }
    }
}