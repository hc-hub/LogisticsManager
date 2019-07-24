<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveCarriers.aspx.cs" Inherits="LogisticsManager.ReceiveCarriers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <style type="text/css">
        .auto-style1 {
            width: 156px;
        }
    </style>
</head>
<body>
    <div class="header">
        <div class="logo">
            <img src="img/logo2.png" />
        </div>

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
                    <a href="#">承运单管理</a> <span class="divider">/</span>
                    接受承运单
                </ul>
                <form id="form1" runat="server">
                    <div class="title_right"><strong>接受承运单</strong></div>
                    <div style="width: 900px; margin: auto;">
                        <table>
                            <tr>
                                <td>承运单号:</td>
                                <td>
                                    <asp:TextBox ID="txtCarriersId" runat="server"></asp:TextBox></td>
                                <td>承运日期:</td>
                                <td>
                                    <input type="text" class="auto-style1" id="txtBeginTime" runat="server" />
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" class="auto-style1" id="txtEndTime" runat="server" /></td>
                            </tr>
                            <tr>
                                <td>收货人:</td>
                                <td>
                                    <asp:TextBox ID="txtSendLinkman" runat="server"></asp:TextBox>
                                </td>
                                <td>发货人:</td>
                                <td>
                                    <asp:TextBox ID="txtReceiveLinkman" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSelect" runat="server" Text="查询" CssClass="button orange" OnClick="btnSelect_Click" /></td>
                            </tr>

                        </table>
                        <table class="bordered">
                            <tr>
                                <th>承运单号</th>
                                <th>业务员</th>
                                <th>发货人</th>
                                <th>发货单位</th>
                                <th>收货人</th>
                                <th>收货单位</th>
                                <th>承运日期</th>
                                <th>合计费用</th>
                                <th>查看</th>
                                <th>签收</th>
                            </tr>
                            <tbody>
                                <asp:Repeater ID="rpt_Carriers" runat="server" OnItemCommand="rpt_Carriers_ItemCommand" OnItemDataBound="rpt_Carriers_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("CarriersID") %></td>
                                            <td id="Name" runat="server"><%# Convert.ToInt32(Eval("FK_UserID")) %></td>
                                            <td><%#Eval("SendLinkman") %></td>
                                            <td><%#Eval("SendCompany") %></td>
                                            <td><%#Eval("ReceiveLinkman") %></td>
                                            <td><%#Eval("ReceiveCompany") %></td>
                                            <td><%#Eval("LeaverDate") %></td>
                                            <td><%#Eval("TotalCost") %></td>
                                            <td>
                                                <asp:LinkButton ID="lbtnDetils" CommandName="Detils" CommandArgument='<%#Eval("CarriersID") %>' CssClass="button orange" runat="server">详情</asp:LinkButton></td>
                                            <td>
                                                <asp:LinkButton ID="lbtnReceive" CommandName="ReceiveCarriers" CommandArgument='<%#Eval("CarriersID") %>' CssClass="button orange" runat="server">接收</asp:LinkButton>                                               
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>
                            </tbody>
                        </table>
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

    </script>



</body>
</html>
