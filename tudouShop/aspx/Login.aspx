<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EShop.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/login.css" rel='stylesheet' type='text/css' />
    <style>
        .customlabel span {
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <div class="header" style="font-size:17px;">
        <div class="top-header">
            <div class="wrap">
                <div class="footer-left">
                    <ul>
                        <li><a href="index.html">首页</a> <span></span></li>
                        <li><a href="nanshi.html">男士</a> <span></span></li>
                        <li><a href="nvshi.html">女士</a> <span></span></li>
                        <li><a href="dzcp.html">电子产品</a> <span></span></li>
                        <li><a href="ssp.html">奢饰品</a> <span></span></li>
                        <li><a href="pinpai.html">品牌</a></li>
                        <div class="clear"></div>
                    </ul>
                </div>

                <div class="top-header-right">
                    <ul>
                        <li><a href="aspx/login.aspx">登录</a><span> </span></li>
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
                <!-- start header menu -->
            </div>
        </div>
    </div>

    <!--- start-content---->
    		<div class="content login-box" runat="server">
			<div class="login-main">
				<div class="wrap">
				  <p>&nbsp;</p>
				  <p>&nbsp;</p>
				  <p></p>
                  <div class="login-left"><img src="../images/guangao/44.jpg" width="490" height="440"/></div>
				  <div class="login-right" style="font-size:16px">
				    <h3>登陆我们的账号</h3>
						<p>全球最大奢侈品log in.</p>
						<form runat="server">
                            <f:PageManager runat="server" ID="pm1"></f:PageManager>
							<div>
								<span>账号<label>*</label></span>
								<f:TextBox runat="server" ID="txtEmail" Required="true" Height="40" Width="540" Text="ZhangWenJun" ></f:TextBox>
							</div>
							<div>
								<span>密码<label>*</label></span>
								<f:TextBox runat="server" ID="txtPwd" Required="true" Height="40" Width="540" TextMode="Password" Text="123456"></f:TextBox>
							</div>
                            <f:Label ID="lblerror" EncodeText="false" CssClass="customlabel" runat="server"></f:Label>
                            <div>
                                <span>验证码<label>*</label></span>
								<f:TextBox runat="server" ID="tbxCaptcha" Required="true" Height="40" Width="200"></f:TextBox>
                                <f:Image ID="imgCaptcha" CssStyle="float:left;width:160px;" runat="server">
                                </f:Image>
                                <f:LinkButton CssStyle="float:left;margin-top:8px;" ID="btnRefresh" Text="看不清？"
                                    runat="server" OnClick="btnRefresh_Click">
                                </f:LinkButton>
                            </div>
                         
					<a class="forgot" ><input name="" type="checkbox" value=""/>记住密码</a>
						<span><asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Font-Size="Medium" BorderStyle="None"  CssClass="zi8" Text="登陆" /></span>
                       <span class="zc"><a href="zc.html">注册ANRUI会员</a></span>
						</form>
					</div>
					<div class="clear"> </div>
				</div>
			</div>
		</div>

    <div class="bottom-grids">

        <div class="bottom-bottom-grids">
            <div class="wrap">


                <div class="shuoming">
                    <ul>
                        <li><a href="index.html">网络文化经营许可证：文网文[2010]040号|增值电信业务经营许可证：浙B2-20080224-1|信息网络传播视听节目许可证：1109364号</a> <span></span></li>

                    </ul>
                </div>

            </div>

            <div class="clear"></div>
        </div>
    </div>

		<div class="footer">
			<div class="wrap">
				<div class="footer-left">
				<ul><li><a href="index.html">网络文化经营许可证京网文[2011]0168-061号  违法和不良信息举报电话：4006561155  Copyright © 2004-201版权所有</li>
						
						<div class="clear"> </div>
					</ul>
				</div>
				
				<div class="clear"> </div>
			</div>
		</div>
</body>
</html>
