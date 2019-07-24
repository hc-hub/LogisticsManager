<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostMaintenance.aspx.cs" Inherits="LogisticsManager.CostMaintenance" %>

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
    <style type="text/css">
        
        #update {
            position: absolute;
            margin-left: 200px;
            margin-top: 100px;
            z-index: 5555;
            width:550px;
            height:150px;
            display:none;
            background-color:#11eecb;
        }

        .show {
            display: block;
        }

        .close {
            display: none;
        }
        .auto-style1 {
            width: 103px;
        }
        .auto-style2 {
            width: 20px;
        }
        .auto-style3 {
            width: 87%;
        }
    </style>
    <script type="text/javascript">

        ;
    </script>
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
                <%--var btnUpdate = document.getElementByIdx_x("<%=btnUpdate.ClientID %>");
                var btnClose = document.getElementByIdx_x("<%=btnClose.ClientID %>");
                btnUpdate.click(function (e) {
                    $("#update").addClass("show");
                });
                btnClose.click(function (e) {
                    $("#update").addClass("close");
                })--%>
            });
        </script>

        <div class="right" id="mainFrame">

            <div class="right_cont">
                <ul class="breadcrumb">
                    当前位置：
  <a href="#">首页</a> <span class="divider">/</span>
                    <a href="#">成本核算</a> <span class="divider">/</span>
                    成本维护
                </ul>
                <form id="form1" runat="server">
                    <div class="title_right"><strong>成本维护</strong></div>
                    <div style="width: 900px; margin: auto;">
                        <div id="update" runat="server">
                            <table style="margin-left:30px;margin-top:30px" class="auto-style3">
                                <tr>
                                    <td>油费：</td>
                                    <td>
                                        <asp:TextBox ID="txtOilCost" runat="server" Width="156px"></asp:TextBox></td>
                                    <td>过桥费：</td>
                                    <td>
                                        <asp:TextBox ID="txtToll" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>罚款：</td>
                                    <td>
                                        <asp:TextBox ID="txtFine" runat="server"></asp:TextBox></td>
                                    <td>其他费用：</td>
                                    <td>
                                        <asp:TextBox ID="txtOtherCost" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="button orange medium" Text="修改" /></td>
                                    <td>
                                        <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" CssClass="button gray medium" Text="返回" /></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <table>
                            <tr>
                                <td>结算状态:</td>
                                <td>
                                    <asp:RadioButtonList ID="rdlState" runat="server" RepeatDirection="Horizontal" Width="121px">
                                        <asp:ListItem Selected="True" Value="0">不限</asp:ListItem>
                                        <asp:ListItem Value="3">已结算</asp:ListItem>
                                        <asp:ListItem Value="1">未结算</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>接收时间:<input type="text" class="laydate-icon span1-1" id="txtBeginTime" runat="server" />至<input type="text" class="laydate-icon span1-1" id="txtEndTime" runat="server" /></td>
                                <td class="auto-style1">
                                    <asp:Button ID="btnSelect" runat="server" Text="搜索" CssClass="button orange" OnClick="btnSelect_Click" />
                                </td>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="span1-2">
                                    <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="button orange" OnClick="btnReset_Click" />
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td class="auto-style1"></td>

                                <td class="auto-style2">
                                    &nbsp;</td>
                                <td class="span1-2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table class="bordered">
                            <tr>
                                <th>编号</th>
                                <th>业务员</th>
                                <th>发货单位</th>
                                <th>接收时间</th>
                                <th>运费合计</th>
                                <th>运输成本</th>
                                <th>成本核算</th>
                            </tr>
                            <tbody>
                                <asp:Repeater ID="rpt_Cost" runat="server" OnItemCommand="rpt_Cost_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("CarriersID") %></td>
                                            <td><%# GetUserNameById(Convert.ToInt32(Eval("FK_UserID"))) %></td>
                                            <td><%#Eval("SendCompany") %></td>
                                            <td><%#Eval("ReceiveDate") %></td>
                                            <td><%#Eval("TotalCost") %></td>
                                            <td><%#Eval("TotalCostS") %></td>
                                            <td>
                                                <asp:LinkButton ID="lbtnClose" CommandName="Close" Visible='<%#Convert.ToInt32(Eval("FinishedState"))<3?true:false %>' CommandArgument='<%#Eval("CarriersID") %>' CssClass="button red" runat="server">结算成本</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnUpdate" CommandName="Update" Visible='<%#Convert.ToInt32(Eval("FinishedState"))==3?true:false %>' CommandArgument='<%#Eval("CarriersID") %>' CssClass="button orange" runat="server">成本修改</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                                    Width="99%" PageSize="3" runat="server" AlwaysShow="false" FirstPageText="<<"
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
        
    </script>



</body>
</html>
