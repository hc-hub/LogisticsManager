<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriverInfo.aspx.cs" Inherits="LogisticsManager.DriverInfo" %>

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
        .auto-style1 {
            width: 257px;
        }

        .auto-style2 {
            width: 156px;
            margin-left: 0;
        }

        .auto-style3 {
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
                $("a").removeClass();
            });
        </script>

        <div class="right" id="mainFrame">

            <div class="right_cont">
                <ul class="breadcrumb">
                    当前位置：
  <a href="#">首页</a> <span class="divider">/</span>
                    <a href="#">驾驶员管理</a> <span class="divider">/</span>
                    驾驶员信息维护
                </ul>
                <form id="form1" runat="server">
                    <div class="title_right"><strong>驾驶员信息维护</strong></div>
                    <div style="width: 900px; margin: auto;">
                        <table>
                            <tr>
                                <td>姓名:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                <td>性别:</td>
                                <td>
                                    <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal" Width="81px">
                                        <asp:ListItem Selected="True" Value="-1">不限</asp:ListItem>
                                        <asp:ListItem Value="0">男</asp:ListItem>
                                        <asp:ListItem Value="1">女</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>身份证号码:</td>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtIDCard" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>生日:</td>
                                <td>
                                    <input type="text" class="auto-style2" id="txtBeginBirth" runat="server" /></td>
                                <td>至:</td>
                                <td>
                                    <input type="text" class="auto-style3" id="txtEndBirth" runat="server" /></td>

                                <td>车辆绑定状态:</td>
                                <td class="auto-style1">
                                    <asp:RadioButtonList ID="rdlTruckState" runat="server" RepeatDirection="Horizontal" Width="111px">
                                        <asp:ListItem Selected="True" Value="0">不限</asp:ListItem>
                                        <asp:ListItem Value="2">未绑定 </asp:ListItem>
                                        <asp:ListItem Value="1">已绑定</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>电话:</td>
                                <td>
                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                                <td>车队:</td>
                                <td>
                                    <asp:DropDownList ID="ddlTruck" Width="72px" runat="server" Height="25px"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>聘用日期:</td>
                                <td>
                                    <input type="text" class="auto-style3" id="txtBeginInTime" runat="server" /></td>
                                <td>至:</td>
                                <td>
                                    <input type="text" class="auto-style3" id="txtEndInTime" runat="server" /></td>
                                <td></td>
                                <td class="auto-style1">
                                    <asp:Button ID="btnSelect" runat="server" Text="检索" CssClass="button orange" OnClick="btnSelect_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnReset" runat="server" Text="重置" CssClass="button orange" OnClick="btnReset_Click" />
                                </td>
                            </tr>
                        </table>

                        <table class="bordered">
                            <thead>
                                <tr>
                                    <th>姓名</th>
                                    <th>性别</th>
                                    <th>电话</th>
                                    <th>生日</th>
                                    <th>车队</th>
                                    <th>身份证号码</th>
                                    <th>聘用日期</th>
                                    <th>车牌号码</th>
                                    <th>车辆绑定</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rpt_Driver" runat="server" OnItemCommand="rpt_Driver_ItemCommand" OnItemDataBound="rpt_Driver_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Name") %></td>
                                            <td><%#Eval("SexName") %></td>
                                            <td><%#Eval("Phone") %></td>
                                            <td><%#Eval("Birth") %></td>
                                            <td><%# GetTeamNameById(Convert.ToInt32(Eval("FK_TeamID"))) %></td>
                                            <td><%#Eval("IDCard") %></td>
                                            <td><%#Eval("CheckInTime") %></td>
                                            <td><%#Eval("Number") %></td>
                                            <td>
                                                <asp:Button ID="BindTruck" OnClick="BindTruck_Click" CommandName="bindTruck" CommandArgument='<%#Eval("DriverID") %>' Visible='<%# ChangeBind(Convert.ToInt32(Eval("TruckID"))) %>' CssClass="button orange medium" runat="server" Text="车辆绑定" />
                                                <asp:Button ID="LinkButton2" CommandName="delContact" CommandArgument='<%#Eval("TruckID") %>' Visible='<%# CancelBind(Convert.ToInt32(Eval("TruckID"))) %>' OnClientClick='return confirm("您确定要解除绑定吗？")' CssClass="button red medium" runat="server" Text="解除绑定" />
                                               
                                                <%--<asp:Button ID="BindTruck" OnClick="BindTruck_Click" CommandName="bindTruck" CommandArgument='<%#Eval("DriverID") %>' Visible='<%# ChangeBind(Convert.ToInt32(Eval("TruckID"))) %>' CssClass="button orange" runat="server">车辆绑定</asp:Button>
                                                <asp:Button ID="LinkButton2" CommandName="delContact" CommandArgument='<%#Eval("TruckID") %>' Visible='<%# CancelBind(Convert.ToInt32(Eval("TruckID"))) %>' OnClientClick='return confirm("您确定要解除绑定吗？")' CssClass="button orange" runat="server">解除绑定</asp:Button>--%>
                                            </td>
                                            <td>
                                                     <asp:Button ID="LinkButton3" CommandName="Update" CommandArgument='<%#Eval("DriverID") %>' CssClass="button orange medium" runat="server" Text="修改" />
                                                <asp:Button ID="LinkButton4" CommandName="delDriver" CommandArgument='<%#Eval("DriverID") %>' OnClientClick='confirm("您确定要删除吗？")' CssClass="button red medium" runat="server" Text="删除" />
                                                <%--<asp:Button ID="LinkButton3" CommandName="Update" CommandArgument='<%#Eval("DriverID") %>' CssClass="button orange" runat="server">修改</asp:Button>
                                                <asp:Button ID="LinkButton4" CommandName="delDriver" CommandArgument='<%#Eval("DriverID") %>' OnClientClick='confirm("您确定要删除吗？")' CssClass="button red" runat="server">删除</asp:Button>--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>



                                </asp:Repeater>
                            </tbody>
                        </table>
                        <tr>
                            <td>
                                <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                                    Width="99%" PageSize="5" runat="server" AlwaysShow="false" FirstPageText="<<"
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
            laydate({ elem: '#txtBeginBirth' });
        }();
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtEndBirth' });
        }();

        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtBeginInTime' });
        }();

        !function () {
            laydate.skin('molv');
            laydate({ elem: '#txtEndInTime' });
        }();


    </script>



</body>
</html>
