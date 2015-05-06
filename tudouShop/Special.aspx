<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Special.aspx.cs" Inherits="EShop.Special" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ANRUI International | login</title>
    <link href="css/zhuanchang2.css" rel='stylesheet' type='text/css' />
    <link href="css/bootstrap2.css" rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">

        <div class="header">
            <div class="top-header">
                <div class="wrap">
                    <div class="footer-left">
                        <ul>
                            <li><a href="index.ashx">首页</a> <span></span></li>
                            <li><a href="male.ashx">男士</a> <span></span></li>
                            <li><a href="Female.ashx">女生</a> <span></span></li>
                            <li><a href="Electronic.ashx">电子产品</a> <span></span></li>
                            <li><a href="Luxury.ashx">奢饰品</a> <span></span></li>
                            <li><a href="Brand.ashx">品牌</a></li>
                            <div class="clear"></div>
                        </ul>
                    </div>

                    <div class="top-header-right">
                        <ul>
                            <li><a href="aspx/login.aspx">登录</a><span> </span></li>
                            <li><a href="aspx/register.aspx">注册</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>


            <div class="container">


                <div class="form-wrapper cf">
                    <input type="text" placeholder="搜索商品" required>
                    <button type="submit">搜索一下</button>
                </div>

                <div class="products">
                    <div class="product-filter">
                        <h1><a href="#"></a></h1>
                        <div class="product-filter-grids" runat="server">
                            <div class="col-md-3 product-filter-grid1-brands">
                                <h3><asp:Literal ID="ltlTitle" runat="server" Text="男士商品"></asp:Literal></h3>
                                <ul class="col-md-6 unstyled-list b-list1">
                                    <asp:Repeater runat="server" ID="rptType">
                                        <ItemTemplate>
                                            <li><a href="#"><%#Eval("CTName") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                    <div class="clearfix"></div>
                                </ul>
                                <ul class="col-md-6 unstyled-list b-list2">
                                    <div class="clearfix"></div>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <!---->


                        </div>
                        <!---->
                        <div class="product-filter-grid1-brands-col3">
                            <div class="products-colors">
                                <h3>商品</h3>

                                <div class="clearfix"></div>
                            </div>
                        </div>


                        <div class="product-filter-grid1-brands-col3">
                            <div class="products-colors">
                                <h3>商品</h3>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>

        <div class="zhong2">
            <div class="shop_box-top">
                <asp:Repeater runat="server" ID="rptProducts">
                    <ItemTemplate>
                        <div class="col-md-3 shop_box">
                            <a href="detials.aspx?ProID=<%#Eval("ProID") %>">
                                <img src="<%#Eval("Img") %>" alt="" width="500" height="311" class="img-responsive" /></a>

                                <div class="shop_desc">
                                    <h3><a href="#"><%#Eval("ProName") %></h3>
                                    <p>男士最新 </p>
                                    <span class="reducedfrom"><%#Eval("Price") %></span>
                                    <span class="actual"><%#Eval("Price") %></span><br>
                                    <ul class="buttons">
                                        <li class="cart"><a href="#">加关注</li>
                                        <li class="shop_btn"><a href="#">进入商品页面</li>
                                        <div class="clear"></div>
                                    </ul>
                                </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

        <div class="clear">
            <div class="pagination">
                <asp:Literal runat="server" ID="ltlPage"></asp:Literal>
            </div>
        </div>
		<div class="footer">
            <div class="wrap">
                <div class="footer-left">
                    <ul>
                        <li><a href="index.html">版权所有</a> <span></span></li>

                        <div class="clear"></div>
                    </ul>
                </div>

                <div class="clear"></div>
            </div>
        </div>
    </form>
</body>
</html>
