using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;


namespace LogisticsMangerUI.SysLog
{
    public partial class SysLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindType();
                BindGvSysLogList();


            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        public void BindType()
        {
            ddlType.DataSource = LogisticsManagerBLL.SysLogBLL.GetTypeName();
            ddlType.DataTextField = "TypeName";
            ddlType.DataValueField = "TypeID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("不限", "-1"));
        }
        public void BindGvSysLogList()
        {
            LogisticsManagerModel.SysLog sys = new LogisticsManagerModel.SysLog();
            sys.FK_TypeID = Convert.ToInt32(ddlType.SelectedValue);
            sys.Account = txtAccount.Text;
            sys.IsException = Convert.ToByte(rdlIsException.SelectedValue);
            sys.ProcName = txtProcName.Text;
            sys.CheckInTimeS = txtBeginTime.Value;
            sys.CheckInTimeE = txtEndTime.Value;
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            int recordCount = 0;
            GvSysLogList.DataSource = LogisticsManagerBLL.SysLogBLL.GetAllSysLog(sys, pageSize, pageIndex, out recordCount);
            AspNetPager1.RecordCount = recordCount;
            GvSysLogList.DataBind();
        }
        public string  ChangeIsException(int id)
        {
            if (id==0)
            {
                return "无异常";
            }
            else
            {
                return "异常";
            }
        }
        private void ExportGridViewForUTF8(GridView GridView, string filename)
        {

            string attachment = "attachment; filename=" + filename;

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", attachment);

            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.ContentType = "application/ms-excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();




        }

        protected void Btn_Click1(object sender, EventArgs e)
        {
            if (GvSysLogList.Rows.Count > 0)
            {
                //调用导出方法
                ExportGridViewForUTF8(GvSysLogList, DateTime.Now.ToShortDateString() + ".xls");
            }
            else
            {

            }

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindGvSysLogList();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindGvSysLogList();
        }
        public static string StringTruncat(string oldStr)
        {
            return Utility.Class1.StringTruncat(oldStr, 10, "...");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtBeginTime.Value = "";
            txtEndTime.Value = "";
            txtProcName.Text = "";
            ddlType.SelectedIndex = 0;
            rdlIsException.SelectedIndex = 2;
        }
    }
}