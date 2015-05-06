<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EShop.Register" %>


<!DOCTYPE HTML>
<html>
<head  runat="server">
    <title>ANRUI International | login</title>
    <link href="../css/zc.css" rel='stylesheet' type='text/css' />
    <meta charset="utf-8">
</head>
<body style="font-size:17px;">


    <div class="header">
        <div class="top-header">
            <div class="wrap">
                <div class="footer-left">
                    <ul>
                        <li><a href="../index.ashx">首页</a> <span></span></li>
                        <li><a href="../Male.ashx">男士</a> <span></span></li>
                        <li><a href="nvshi.html">女士</a> <span></span></li>
                        <li><a href="dzcp.html">电子产品</a> <span></span></li>
                        <li><a href="ssp.html">奢饰品</a> <span></span></li>
                        <li><a href="pinpai.html">品牌</a></li>
                        <div class="clear"></div>
                    </ul>
                </div>

                <div class="top-header-right">
                    <ul>
                        <li><a href="login.ashx">登陆</a><span> </span></li>
                        <li><a href="zc.html">注册</a></li>
                    </ul>
                </div>
                <div class="clear"></div>
            </div>
        </div>

        <div class="mid-header">
            <div class="wrap">
                <div class="mid-grid-right">
                    <a href="index.html"><span>这是LOGO</span></a>
                </div>
                <div class="clear"></div>
            </div>
        </div>

        <div class="header-bottom">
            <div class="wrap">
            </div>
        </div>
    </div>

    <div class="content login-box">
        <div class="login-main">
            <div class="wrap">
                <h1>ANRUI International</h1>
                <div class="register-grids">
                    <form runat="server">
                        <f:PageManager runat="server" ID="pm1"></f:PageManager>
                        <div class="register-top-grid">
                            <h3>ANRUI International注册</h3>
                            <div>
                                <span>Email<label>*</label></span>
                                <f:TextBox ID="txtEmail" Required="true" RegexPattern="EMAIL" RegexMessage="邮箱格式不正确" runat="server" Width="200" Height="40"></f:TextBox>
                            </div>
                            <%--<div class="clear"></div>--%>
                            
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                        <div class="register-bottom-grid">
                            <div>
                                <span>密码<label>*</label></span>
                                <f:TextBox ID="txtPwd1" Required="true" runat="server" Width="200" Height="40" TextMode="Password"></f:TextBox>
                            </div>
                            <div>
                                <span>确认密码<label>*</label></span>
                                <f:TextBox ID="TextBox1" Required="true" runat="server" Width="200" Height="40" CompareControl="txtPwd1"
                                     CompareOperator="Equal" CompareMessage="两次输入密码不一致" TextMode="Password"></f:TextBox>
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                        <f:Button Text="注册" runat="server" ID="btnRegister" CssClass="b_btn" OnClick="btnRegister_Click" ></f:Button>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="footer">
        <div class="wrap">
            <div class="footer-left">
                <ul>
                    <li><a href="#">首页</a> <span></span></li>
                    <li><a href="#">男士</a> <span></span></li>
					<li><a href="#">女生</a> <span></span></li>
                    <li><a href="#">电子产品</a> <span></span></li>
                    <li><a href="#">奢饰品</a> <span></span></li>
                    <li><a href="#">品牌</a></li>
                    <div class="clear"></div>
                </ul>
            </div>
            <div class="clear"></div>
        </div>
    </div>

</body>
</html>


