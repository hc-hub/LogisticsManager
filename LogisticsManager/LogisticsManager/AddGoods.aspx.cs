using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class AddGoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Goods goods = new Goods();
            goods.GoodsName = txtGoodsName.Text;
            goods.Amount = Convert.ToInt32(txtAmount.Text);
            goods.Weight = Convert.ToDouble(txtWeight.Text);
            goods.Volume = Convert.ToDouble(txtVolume.Text);
            goods.FK_CarriersID = Convert.ToInt32(Request.QueryString["id"]);
            this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.GoodsBLL.AddGoods(goods)+"')",true);
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarriersManager.aspx");
        }
    }
}