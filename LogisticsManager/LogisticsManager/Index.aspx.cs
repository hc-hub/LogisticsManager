using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogisticsManager
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
            
        }
        public void BindUser()
        {
            if (Session["User"]!=null)
            {
                lblName.Text = (Session["User"] as List<Users>)[0].UserName;
                lblSex.Text= (Session["User"] as List<Users>)[0].Sex;
                lblRoleName.Text = LogisticsManagerBLL.RoleInfoBLL.GetRoleNameByRoleID((Session["User"] as List<Users>)[0].FK_RoleID);
                lblPhone.Text= (Session["User"] as List<Users>)[0].Phone;
                lblEmail.Text= (Session["User"] as List<Users>)[0].Email;
            }
        }
    }
}