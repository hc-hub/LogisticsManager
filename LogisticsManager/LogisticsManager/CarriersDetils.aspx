<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarriersDetils.aspx.cs" Inherits="LogisticsManager.CarriersDetils" %>

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
                    承运单详情
                </ul>
                <form id="form1" runat="server">
                    <div class="title_right"><strong>承运单详情</strong></div>
                    <div style="width: 900px; margin: auto;">
                        <table width="750px" border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>发货单位：
                                </td>
                                <td>
                                    <asp:Label ID="lblSendCompany" runat="server" Text=""></asp:Label>
                                </td>
                                <td>单位地址：
                                </td>
                                <td>
                                    <asp:Label ID="lblSendAddress" runat="server" Text=""></asp:Label>
                                </td>
                                <td>发货人电话：
                                </td>
                                <td>
                                    <asp:Label ID="lblSendPhone" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>收货人：
                                </td>
                                <td>
                                    <asp:Label ID="lblReceiveLinkman" runat="server" Text=""></asp:Label>
                                </td>
                                <td>单位地址：
                                </td>
                                <td>
                                    <asp:Label ID="lblReceiveCompany" runat="server" Text=""></asp:Label>
                                </td>
                                <td>收货人电话：
                                </td>
                                <td>
                                    <asp:Label ID="lblReceivePhone" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>发货时间：
                                </td>
                                <td>
                                    <asp:Label ID="lblStartTime" runat="server" Text=""></asp:Label>
                                </td>
                                <td>收货时间：
                                </td>
                                <td>
                                    <asp:Label ID="lblReceiveDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td>运 费：
                                </td>
                                <td>
                                    <asp:Label ID="lblTransportCost" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>保险费：
                                </td>
                                <td>
                                    <asp:Label ID="lblInsuranceCost" runat="server" Text=""></asp:Label>
                                </td>
                                <td>其他费用：
                                </td>
                                <td>
                                    <asp:Label ID="lblOtherCost" runat="server" Text=""></asp:Label>
                                </td>
                                <td>合计费用：
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalCost" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>承运时间：
                                </td>
                                <td>
                                    <asp:Label ID="lblLeaverDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td>发货人：
                                </td>
                                <td>
                                    <asp:Label ID="lblSendLinkman" runat="server" Text=""></asp:Label>
                                </td>
                                <td>业务员：
                                </td>
                                <td>
                                    <asp:Label ID="lblFK_UserID" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>货单情况：
                                </td>
                                <td>
                                    <asp:Label ID="lblFinishedState" runat="server" Text=""></asp:Label>
                                </td>
                                <td></td>
                                <td colspan="3" rowspan="4">
                                    <table class="bordered">
                                        <tr>
                                            <th>承运单编号</th>
                                            <th>货物单</th>
                                            <th>货物名称</th>
                                            <th>货物数量</th>
                                            <th>货物重量</th>
                                            <th>货物体积</th>
                                        </tr>
                                        <tbody>
                                            <asp:Repeater ID="rpt_Goods" runat="server">
                                                <ItemTemplate>
                                                    <tr>	
                                                        <td><%#Eval("FK_CarriersID") %></td>
                                                        <td><%#Eval("GoodsID") %></td>
                                                        <td><%#Eval("GoodsName") %></td>
                                                        <td><%#Eval("Amount") %></td>
                                                        <td><%#Eval("Weight") %></td>
                                                        <td><%#Eval("Volume") %></td>
                                                    </tr>
                                                </ItemTemplate>

                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2" rowspan="3">
                                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Height="100px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>备 注 ：
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <hr />
                                    <input id="Button1" type="button" value="返回" class="button gray" onclick="history.go(-1)" />
                                </td>

                            </tr>
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
            laydate({ elem: '#txtCheckInTime' });
        }();

    </script>



</body>
</html>
