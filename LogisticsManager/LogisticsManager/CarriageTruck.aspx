<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarriageTruck.aspx.cs" Inherits="LogisticsManager.CarriageTruck" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/css.css" />
    <link rel="stylesheet" href="css/GridViewCss.css" />
    <link href="css/Table2.css" rel="stylesheet" />
    <link href="css/StyleButton.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery1.9.0.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/sdmenu.js"></script>
    <script type="text/javascript" src="js/laydate/laydate.js"></script>
    <script src="js/calendar.js" type="text/javascript"></script>
</head>
<body>
    <div class="header">
        <div class="logo">
            <img src="img/logo2.png" /></div>

        <div class="header-right">
            <i class="icon-question-sign icon-white"></i><a href="#">帮助</a> <i class="icon-off icon-white"></i><a id="modal-973558" href="#modal-container-973558" role="button" data-toggle="modal">注销</a> <i class="icon-user icon-white"></i><a href="#">开票员的工作平台</a> <i class="icon-envelope icon-white"></i><a href="#">发送短信</a>
            <div id="modal-container-973558" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="width: 300px; margin-left: -150px; top: 30%">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="myModalLabel">注销系统
                    </h3>
                </div>
                <div class="modal-body">
                    <p>
                        您确定要注销退出系统吗？
                    </p>
                </div>
                <div class="modal-footer">
                    <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
                    <a class="btn btn-primary" style="line-height: 20px;" href="Login.aspx">确定退出</a>
                </div>
            </div>
        </div>
    </div>
    <!-- 顶部 -->

    <div id="middle">
        <div class="left">

            <script type="text/javascript">
                var myMenu;
                window.onload = function () {
                    myMenu = new SDMenu("my_menu");
                    myMenu.init();
                };
            </script>

            <div id="my_menu" class="sdmenu">
                <div >
		<span>车辆管理</span>
		<a href="TruckTeamManager.aspx">车队信息维护</a>
		<a href="TruckManager.aspx">车辆信息维护</a>
		<a href="AddTruckTeam.aspx">添加车队信息</a>
		<a href="AddTruck.aspx">添加车辆信息</a>
	</div>
	<div class="collapsed">
		<span>驾驶员管理</span>
		
                    <a href="DriverInfo.aspx">驾驶员信息维护</a>
                    <a href="AddDriver.aspx">添加驾驶员信息</a>
	</div>
	<div class="collapsed">
		<span>运力查询</span>
		 <a href="CarriageTeam.aspx">查询承运车队</a>
                    <a href="CarriageTruck.aspx">查询承运车辆</a>
        <a href="HistoryCarriage.aspx">查询历史承运单</a>
	</div>
    
 	<div class="collapsed">
		<span>承运单管理</span>
		<a href="CarriersManager.aspx">承运单管理</a>
		<a href="ReceiveCarriers.aspx">接受签收承运单</a>
        <a href="AddCarriers.aspx">添加承运单</a>

	</div>
 	<div class="collapsed">
		<span>车辆调度</span>
		   <a href="SchedulingManager.aspx">车辆调度管理</a>		   
	</div>
 	<div class="collapsed">
		<span>成本核算</span>
		<a href="CostMaintenance.aspx">成本维护</a>
		
	</div>
 	<div class="collapsed">
		<span>系统维护</span>
		   <a href="SysLog.aspx">日志查询</a>
		   <a href="AddUserInfo.aspx">添加用户信息</a>
		   <a href="Index.aspx">系统维护</a>
		   <a href="ChangePossWord.aspx">修改密码</a>
		   <a href="UserInfo.aspx">用户信息维护</a>

	</div>

            </div>

        </div>
        <div class="Switch"></div>
        <script type="text/javascript">
            $(document).ready(function (e) {
                $(".Switch").click(function () {
                    $(".left").toggle();

                });
            });
        </script>

        <div class="right" id="mainFrame">

            <div class="right_cont">
                <ul class="breadcrumb">
                    当前位置：
  <a href="#">首页</a> <span class="divider">/</span>
                    <a href="#">运力查询</a> <span class="divider">/</span>
                    查询承运车辆
                </ul>
                <form id="form1" runat="server">
                    <div class="title_right"><strong>查询承运车辆</strong></div>
                    <div style="width: 900px; margin: auto;">
                        所属车队:<asp:DropDownList ID="ddlTruckTeam" runat="server" Height="25px" Width="114px"></asp:DropDownList>
                        车牌号码:<asp:TextBox ID="txtNumber" runat="server" Height="25px"></asp:TextBox>
                        车辆类型:<asp:DropDownList ID="ddlTruckType" runat="server" Height="25px" Width="120px"></asp:DropDownList>
                        车辆状态<asp:DropDownList ID="ddlTruckState" runat="server" Width="104px"></asp:DropDownList>
                        <asp:Button ID="btnSelect" runat="server" Text="查询" OnClick="btnSelect_Click" CssClass="button orange" />
                       
                            
                                <table class="bordered">
                                    <tr>
                                        <th>车队</th>
                                        <th>车辆编号</th>
                                        <th>车牌号码</th>
                                        <th>购车日期</th>
                                        <th>车辆类型</th>
                                        <th>车身长度</th>
                                        <th>吨位/吨</th>
                                        <th>工作状态</th>
                                        <th>创建时间</th>
                                        <th>修改时间</th>
                                        <th>备注</th>
                                    </tr>
                                    <tbody>
                             <asp:Repeater ID="rptTruck" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("TeamName") %></td>
                                    <td><%#Eval("TruckID") %></td>
                                    <td><%#Eval("Number") %></td>
                                    <td><%#Eval("BuyDate") %></td>
                                    <td><%#Eval("Type") %></td>
                                    <td><%#Eval("Length") %></td>
                                    <td><%#Eval("Tonnage") %></td>
                                    <td><%#Eval("StateName") %></td>
                                    <td><%#Eval("CheckInTime") %></td>
                                    <td><%#Eval("AlterTime") %></td>
                                    <td><%# StringTruncat(Eval("Remark").ToString()) %></td>
                                </tr>
                            </ItemTemplate>
                            
                        </asp:Repeater>
                        </tbody></table>
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                                    Width="99%" PageSize="10" runat="server" AlwaysShow="false" FirstPageText="<<"
                                    LastPageText=">>" NextPageText=">" PrevPageText="<" ShowCustomInfoSection="Left"
                                    ShowInputBox="Never" OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left"
                                    CurrentPageButtonPosition="Beginning" CustomInfoHTML="第 %CurrentPageIndex% 页，共 %PageCount%页,共%RecordCount%条"
                                    ShowPageIndexBox="Always" PageIndexBoxType="DropDownList" TextBeforePageIndexBox="转到第"
                                    TextAfterPageIndexBox="页">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <!-- 底部 -->
    <div id="footer">版权所有：不简单客流 &copy; 2018&nbsp;&nbsp;&nbsp;&nbsp;服务热线：0371-88888888</div>



    <script>
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtBeginTime' });
        }();
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtEndTime' });
        }();
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtUpdateBeginTime' });
        }();
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtUpdateEndTime' });
        }();

    </script>




</body>
</html>
