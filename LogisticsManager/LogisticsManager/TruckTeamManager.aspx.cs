using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LogisticsManagerModel;



namespace LogisticsManager
{
    public partial class TruckTeamManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTruckTeam();
                BindddlTruckTeamName();
            }
        }
        public void BindTruckTeam()
        {
            gvTruckTeam.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckTeam();
            gvTruckTeam.DataBind();
        }
        public void BindddlTruckTeamName()
        {

            ddlTruck.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruck.DataTextField = "TeamName";
            ddlTruck.DataValueField = "TeamID";
            ddlTruck.DataBind();
            ddlTruck.Items.Insert(0,new ListItem("不限","-1"));
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int teamID = Convert.ToInt32(ddlTruck.SelectedValue);
            string leader = txtLeader.Text;
            TruckTeam team = new TruckTeam()
            {
                TeamID = teamID,
                Leader = leader
            };
            gvTruckTeam.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckTeam(team);
            gvTruckTeam.DataBind();
        }

        protected void gvTruckTeam_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTruckTeam.EditIndex =e.NewEditIndex;
            BindTruckTeam();
        }

        protected void gvTruckTeam_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTruckTeam.EditIndex = -1;
            BindTruckTeam();
        }

        protected void gvTruckTeam_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TruckTeam tt = new TruckTeam();
            tt.TeamID = Convert.ToInt32(gvTruckTeam.DataKeys[e.RowIndex].Value);
            tt.TeamName = ((TextBox)(gvTruckTeam.Rows[e.RowIndex].Cells[1].Controls[0])).Text;

            try
            {
                tt.CheckInTime = Convert.ToDateTime(((TextBox)(gvTruckTeam.Rows[e.RowIndex].Cells[3].FindControl("txtBeginTime"))).Text);

            }
            catch (Exception)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入正确的时间！')",true);
                return;
            }
            
            tt.Leader = ((TextBox)(gvTruckTeam.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            tt.Remark = ((TextBox)(gvTruckTeam.Rows[e.RowIndex].Cells[5].FindControl("txtRemark"))).Text;
            if (LogisticsManagerBLL.TruckTeamBLL.UpdateTruckTeam(tt)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
                gvTruckTeam.EditIndex = -1;
                BindTruckTeam();
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败!')", true);
                gvTruckTeam.EditIndex = -1;
                BindTruckTeam();
                return;
            }
        }

        protected void gvTruckTeam_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int teamId = Convert.ToInt32(gvTruckTeam.DataKeys[e.RowIndex].Value); 

                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + LogisticsManagerBLL.TruckTeamBLL.DeleteTruckTeam(teamId)+"')", true);
                BindTruckTeam();
                return;
            
        }
        public static string StringTruncat(string oldStr)
        {
            return Utility.Class1.StringTruncat(oldStr,20,"...");
        }
    }
}