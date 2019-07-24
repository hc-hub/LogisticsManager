using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;
using System.Text.RegularExpressions;
using System.Text;

namespace LogisticsManager
{
    public partial class AddDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlTruckTeamName();
            }
        }
        public void BindddlTruckTeamName()
        {

            ddlTruck.DataSource = LogisticsManagerBLL.TruckTeamBLL.GetTruckName();
            ddlTruck.DataTextField = "TeamName";
            ddlTruck.DataValueField = "TeamID";
            ddlTruck.DataBind();          
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtIDCard.Text = "";
            txtPhone.Text = "";
            txtRemark.Text = "";
            txtBeginTime.Value = "";
            ddlTruck.SelectedIndex = 0;
            rdlSex.SelectedIndex = 0;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入驾驶员姓名！')",true);
                return;
            }
            if (Encoding.Default.GetByteCount(txtName.Text) < 4)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('不能用单个字符命名！')", true);
                return;
            }
            if (Encoding.Default.GetByteCount(txtName.Text) > 14)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('姓名超过字符长度！')", true);
                return;
            }
            string pa = @"[\u4e00-\u9fa5]{1,20}|[a-zA-Z\.\s]{1,20}";
            bool isphon = Regex.IsMatch(txtName.Text, pa);
            if (!isphon)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('姓名格式不符合要求！')", true);
                return;
            }
            if (LogisticsManagerBLL.UserInfoBLL.GetUserName(txtName.Text)!=null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('姓名已存在，请更换其他姓名！')", true);
                return;
            }
            try
            {
                DateTime dt = Convert.ToDateTime(txtBeginTime.Value);
            }
            catch (Exception)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入生日！')",true);
                return;
            }
            string path = @"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";

            if (txtPhone.Text.Length == 11)
            {
                //public static bool IsMatch(string input, string pattern);bool类型
                bool isphone = Regex.IsMatch(txtPhone.Text, path);
                Console.WriteLine("电话:" + isphone);
                if (!isphone)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('手机号不符合要求！')", true);
                    return;
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('手机号长度不够11位！')", true);
                return;
            }
            //if (string.IsNullOrWhiteSpace(txtPhone.Text))
            //{
            //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入电话！')",true);
            //    return;
            //}
            if ((!Regex.IsMatch(txtIDCard.Text, @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入身份证号！')", true);
                return;
               
            }

            Driver driver = new Driver();
            driver.Name = txtName.Text;
            driver.Sex = Convert.ToInt32(rdlSex.SelectedValue);
            driver.Birth = Convert.ToDateTime(txtBeginTime.Value);
            driver.Phone = txtPhone.Text;
            driver.IDCard = txtIDCard.Text;
            driver.FK_TeamID = Convert.ToInt32(ddlTruck.SelectedValue);
            driver.Remark = txtRemark.Text;
            this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+LogisticsManagerBLL.DriverBLL.AddDriver(driver)+"')",true);
        }
    }
}