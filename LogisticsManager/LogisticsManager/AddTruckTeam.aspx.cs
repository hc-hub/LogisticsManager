using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class AddTruckTeam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTruckName.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入车队名称！')",true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLeader.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入车队负责人！')", true);
                return;
            }
            TruckTeam tm = new TruckTeam()
            {
                TeamName = txtTruckName.Text,
                Leader = txtLeader.Text,
                Remark=txtRemark.Text
            };
            if (LogisticsManagerBLL.TruckTeamBLL.AddTruckTeam(tm)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！')", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！')", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTruckName.Text = "";
            txtLeader.Text = "";
            txtRemark.Text = "";
        }
    }
}