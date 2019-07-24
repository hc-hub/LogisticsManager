<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LogisticsManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>GPS监控平台</title>
<link rel="stylesheet" href="css/bootstrap.css" />

    <script src="js/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        
     $(document).ready(function () {
         console.log("qwe");

              $("#btnLogin").click(function () {
                var account = $("#txtAccount").val();
                var passwrd = $("#txtPwd").val();
                    $.ajax({
                        type: "POST",
                        url: "Login1.ashx",
                        datatype:"text",
                        data: { Account: account, Password: passwrd },
                        async:false,
                        success: function (getMsg) {
                           
                          
                            if (getMsg == "登陆成功") {
                                alert('nihao');
                               // window.location.href = "Index.aspx";
                                $(location).attr('href', 'Index.aspx');
                               
                            }
                            else {

                                alert(getMsg);


                            }
                        },
                        alert(errorThrown);
                        //}//error: function (XMLHttpRequest, textStatus, errorThrown) {  //重点  这里可以查看报错信息
                        //    alert(XMLHttpRequest.status);
                        //    alert(XMLHttpRequest.readyState);
                        //    alert(textStatus);
                        //    

                    })

                
              })
              $("#btnLogin").click(function () {
                  console.log("click");
                  window.location.href = "Index.aspx";
              })
        })
    </script>
<style type="text/css">
body{ background:#0066A8 url(img/login_bg.png) no-repeat center 0px;}
.tit{ margin:auto; margin-top:170px; text-align:center; width:350px; padding-bottom:20px;}
.login-wrap{ width:220px; padding:30px 50px 0 330px; height:220px; background:#fff url(img/20150212154319.jpg) no-repeat 30px 40px; margin:auto; overflow: hidden;}
.login_input{ display:block;width:210px;}
.login_user{ background: url(img/input_icon_1.png) no-repeat 200px center; font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif}
.login_password{ background: url(img/input_icon_2.png) no-repeat 200px center; font-family:"Courier New", Courier, monospace}
.btn-login{ background:#40454B; box-shadow:none; text-shadow:none; color:#fff; border:none;height:35px; line-height:26px; font-size:14px; font-family:"microsoft yahei";}
.btn-login:hover{ background:#333; color:#fff;}
.copyright{ margin:auto; margin-top:10px; text-align:center; width:370px; color:#CCC}
@media (max-height: 700px) {.tit{ margin:auto; margin-top:100px; }}
@media (max-height: 500px) {.tit{ margin:auto; margin-top:50px; }}
    .auto-style1 {
        border-style: none;
        border-color: inherit;
        border-width: medium;
        background: #40454B;
        box-shadow: none;
        text-shadow: none;
        color: #fff;
        line-height: 26px;
        font-size: 14px;
        font-family: "microsoft yahei";
        margin-top: 0;
    }
    .auto-style2 {
        width: 371px;
        margin-left: 0px;
    }
</style>

</head>
<body>
<div class="tit"><img src="img/tit1.png" alt="" class="auto-style2" /></div>
<div class="login-wrap">
    <form id="form1" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td height="25" valign="bottom">用户名：</td>
    </tr>
    <tr>
      <td><input type="text" id="txtAccount" class="login_input login_user"  runat="server"/></td>
    </tr>
    <tr>
      <td height="35" valign="bottom">密  码：</td>
    </tr>
    <tr>
      <td><input type="password" id="txtPwd" class="login_input login_password" runat="server" /></td>
    </tr>
    <tr>
      <td height="60" valign="bottom">
          <asp:Button ID="btnLogin" runat="server" CssClass="auto-style1" OnClick="btnLogin_Click" Text="登录"  Width="220px" /></td>
    </tr>
   
  </table>

        </form>
</div>
<div class="copyright">建议使用IE8以上版本或谷歌浏览器</div>
</body>
</html>
