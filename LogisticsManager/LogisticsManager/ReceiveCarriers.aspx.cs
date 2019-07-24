using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LogisticsManager
{
    public partial class ReceiveCarriers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    int userId = (Session["User"] as List<Users>)[0].UserID;
                    BindCarriers(userId);
                }

            }
        }
        public void BindCarriers(int userId)
        {
            rpt_Carriers.DataSource = LogisticsManagerBLL.CarriersBLL.GetCarriersByUserID(userId);
            rpt_Carriers.DataBind();
        }
        //public string GetUserNameById(int userId)
        //{
        //    return LogisticsManagerBLL.UserInfoBLL.GetUserNameById(userId);
        //}

        protected void rpt_Carriers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ReceiveCarriers")
            {
                int carriersId = Convert.ToInt32(e.CommandArgument);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.CarriersBLL.ReceiveCarriers(carriersId) + "')", true);
                BindCarriers((Session["User"] as List<Users>)[0].UserID);
            }
            if (e.CommandName == "Detils")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("CarriersDetils.aspx?id=" + id);
            }
        }

        protected void rpt_Carriers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableCell cell = null;
                //Carriers cars = (logisticsModel.Carriers)e.Item.DataItem;
                //int id = cars.Fk_UserID;
                cell = e.Item.FindControl("Name") as HtmlTableCell;
                int id = (Session["User"] as List<Users>)[0].UserID;
                string username = LogisticsManagerBLL.UserInfoBLL.GetUserNameById(id);

                cell.InnerText = username;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}