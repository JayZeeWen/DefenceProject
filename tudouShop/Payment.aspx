<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="tudouShop.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>ANRUI International | login</title>
        <link href="css/gouwuchexin.css" rel='stylesheet' type='text/css' />
		<link href="css/grid.css" rel='stylesheet' type='text/css' /> 
        <script src="js/jquery.js"></script>
	</head>
	<body style="width:100%;height:100%">
        <form id="form1" runat="server">
		<!---start-wrap---->
			<!---start-header---->
            
			<div class="header">
				<div class="top-header">
					<div class="wrap">
						<div class="footer-left">
				<ul><li><a href="index.ashx">首页</a> <span> </span></li>
						<li><a href="Male.ashx">男士</a> <span> </span></li>
						<li><a href="Female.ashx">女生</a> <span> </span></li>
						<li><a href="Electronic.ashx">电子产品</a> <span> </span></li>
						<li><a href="Luxury.ashx">奢饰品</a> <span> </span></li>
						<li><a href="Brand.ashx">品牌</a></li>
						<div class="clear"> </div>
					</ul>
				</div>
                        
						<div class="top-header-right">
							<ul>
								<li><a href="aspx/login.aspx">登录</a><span> </span></li>
								<li><a href="aspx/register.aspx">注册</a></li>
							</ul>
						</div>
						<div class="clear"> </div>
					</div>
				</div>
				
 <div class="clear"></div>
                </div>
  <section id="main" class="entire_width">
  
<div  class="iconbox-wrap">
    <p>我的收货地址</p>
     <asp:Repeater runat="server" ID="rptAddress">
                        <ItemTemplate>
                <div class="one-fourth">
                    <div class="iconone">
                       <a href="javascript:void(0)" onclick="SelectAddress(this)">
                            <h3 class="iconbox-title"><span class="iconbox-icon"></span><%#Eval("Name") %></h3>
                            <p><%#Eval("Address") %></p>
                        </a>
                    </div>
                </div>                             
                       </ItemTemplate>
                    </asp:Repeater>

            </div>  

    <div class="container_12" runat="server">
      <%-- <div class="grid_12">--%>
       <h1 class="page_title">正在进行交易</h1>

       <table>
	      <tr>
               
           <td>支付金额:</td>
           <td class="price"><asp:Literal runat="server" ID="ltlTotal"></asp:Literal></td>
                                   
          </tr>
	      <tr>
		     <td>账号余额:</td>		    	   		     
		     <td><asp:Literal runat="server" ID="ltlbalance"></asp:Literal><input id="Add" type="button" value="添加" /></td>     
	      </tr>
	      <tr>
          <td>支付密码：</td>
          <td><input type="password" name="PFP" value=""/><span><asp:Label ID="lblerror" runat="server" Text=""  ForeColor="Red"></asp:Label></span></td>
            </tr>                                                               
		    <tr>
             <td><span><asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="确认付款" /></span></td>
                <td><input type="hidden" value=""/></td>
            </tr> 	    			   	     
       </table>
       </div><!-- .grid_12 -->
     <div id="background" style="display:none;width:100%;height:100%;position:absolute; top:0; left:0; filter:alpha(opacity=30);opacity: 0.9;background:#908d8d">
     <div id="recharge" style="width:30%;height:40%;margin: 0 auto;position:absolute; top:180px; left:600px;background:#ffffff;filter:alpha;opacity: 1;">
       <h1 class="page_title">正在进行充值</h1>
      <table>
      <tr>
      <td>账号：</td>
      <td><asp:Literal runat="server" ID="Name"></asp:Literal></td>
      </tr>
      <tr>
      <td>充值金额：</td>
      <td><input type="text" name="money" value=""/></td>
      </tr>
           <tr>
      <td><span><asp:Button ID="submitsec" runat="server" OnClick="submitsec_Click" Text="确认" /></span></td>
      <td></td>
      </tr>
      </table> 
    </div>
         </div>
  

       <div id="content_bottom"><!-- .grid_4 --><!-- .grid_4 -->

        <div class="grid_4">
  
	   
        </div><!-- .grid_4 -->

        <div class="clear"></div>
      </div><!-- #content_bottom -->
      <div class="clear"></div>

      <div class="clear"></div>

      <div class="carousel" id="following"><!-- .c_header --><!-- .list_carousel -->
      </div><!-- .carousel -->

   <!-- .container_12 -->
  </section><!-- #main -->
                    
  
                   <div id="xia">
     <div class="bottom-grids">
		  <div class="bottom-bottom-grids">
			  <div class="wrap">
					<div class="bottom-bottom-grid">
						<h6>购物指南</h6>
						<p>会员介绍</p>
						<a class="learn-more" href="#">团购/机票</a>
					</div>
                    <div class="bottom-bottom-grid">
						<h6>购物指南</h6>
						<p>会员介绍</p>
						<a class="learn-more" href="#">团购/机票</a>
					</div>
                    <div class="bottom-bottom-grid">
						<h6>购物指南</h6>
						<p>会员介绍</p>
						<a class="learn-more" href="#">团购/机票</a>
					</div>
                    
					<div class="bottom-bottom-grid">
						<h6>配送方式</h6>
						<p>配送费收取标准</p>
						<a class="learn-more" href="#">ANRUI International</a>
					</div>
					<div class="bottom-bottom-grid2">
						<h6>售后服务</h6>
						<p>售后政策</p>
						<a class="learn-more" href="#">价格保护</a>
					</div>
					<div class="clear"> </div>
			</div>
		  </div>
          </div>

            
	
                
					
					<div class="clear"> </div>
			</div>
		 
	

		<div class="footer">
			<div class="wrap">
				<div class="footer-left">
				<ul><li><a href="index.html">网络文化经营许可证京网文[2011]0168-061号  违法和不良信息举报电话：4006561155  Copyright © 2004-2015  京东JD.com 版权所有</a></li>
				
					</ul>
				</div>
				<div class="clear"> </div>
			</div>
		</div>
       
              
        </form>
	</body>
</html>
<script type="text/javascript">
    $(document).ready(function () {
        $("#Add").click(function () {
            $("#background").show();

        });
    });
</script>
