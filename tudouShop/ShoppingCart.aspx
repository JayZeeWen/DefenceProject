<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="EShop.ShoppingCart" %>


<!DOCTYPE HTML>
<html>
<head runat="server">
    <title>ANRUI International | login</title>
    <link href="css/gouwuche.css" rel='stylesheet' type='text/css' />
    <link href="css/grid.css" rel='stylesheet' type='text/css' />
    <script src="js/jquery.js"></script>
    <script src="scripts/Common.js"></script>
    <script src="scripts/jquery-ui.js"></script>

    <meta charset="utf-8">
</head>

<body runat="server">
    <!---start-wrap---->
    <!---start-header---->
    <form id="Form1" runat="server">
        <div class="header">
            <div class="top-header">
                <div class="wrap">
                    <div class="footer-left">
                        <ul>
                            <li><a href="index.ashx">首页</a> <span></span></li>
                            <li><a href="Male.ashx">男士</a> <span></span></li>
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
                            <li><a href="aspx/Register.aspx">注册</a></li>
                            <li><a href="ShoppingCart.aspx">查看购物车</a></li>
                            <li><a href="Orders.aspx">已购买的商品</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>

            <div class="clear"></div>


            <section id="main" class="entire_width">

                <div class="container_12">
                    <f:PageManager runat="server" ID="pgm1"></f:PageManager>
                    <div class="grid_12">
                        <h1 class="page_title">商品购物车</h1>

                        <table class="cart_product">
                            <tr>
                                <th class="images"></th>
                                <th class="bg name">品牌名称</th>

                                <th class="bg price">商品单价(元)</th>
                                <th class="qty">数量</th>
                                <th class="bg subtotal">小计(元)</th>
                                <th class="close"></th>
                                <th class="edit"></th>
                            </tr>
                            <tr>
                                <asp:Repeater runat="server" ID="rptCart">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="images"><a href="sp.html">
                                                <img src="<%# Eval("Img") %>" alt="Product 6"></a></td>
                                            <td class="bg name"><%# Eval("ProName") %><br />
                                                香港, x'x'x</td>

                                            <td class="bg price">$<%#Eval("Price") %></td>
                                            <td class="qty">
                                                <input type="text" id="quantity" name="quantity" value="<%#Eval("Quantity") %>" placeholder="<%#Eval("Quantity") %>" onblur="total(this,<%#Eval("ProID") %>)" onkeyup="onlyNum(this)" /></td>
                                            <td class="bg subtotal">$<%#Convert.ToDecimal( Eval("Price")) * Convert.ToDecimal( Eval("Quantity")) %></td>
                                            <td class="close"><a title="close" class="close" href="#"></a></td>
                                            <td class="edit">
                                                <a title="Edit" href="javascript:void(0);" onclick="DelProduct(<%#Eval("ProID") %>,this);">删除</a>
                                                <td><asp:CheckBox ID="CheckBox1" runat="server" dataID='<%#Eval("ProID")%>' Quantity='<%#Eval("Quantity") %>' checked="true" />操作</td>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>

                                    </FooterTemplate>
                                </asp:Repeater>
                            </tr>
                            <tr>
                                <td colspan="7" class="cart_but">
                                    <div id="Div1" class="pagination" runat="server">
                                        <asp:Literal runat="server" ID="ltlPage"></asp:Literal>
                                    </div>
                                    <button class="update"><span>icon</span>保存购物车</button>
                                </td>
                            </tr>


                        </table>
                    </div>
                    <!-- .grid_12 -->

                    <div id="content_bottom">
                        <!-- .grid_4 -->
                        <!-- .grid_4 -->

                        <div class="grid_4">
                            <div class="bottom_block total">
                                <table class="subtotal">
                                    <tr>
                                        <td>商品价格</td>
                                        <td class="price"><asp:Literal runat="server" ID="ltlPrice"></asp:Literal></td>
                                    </tr>
                                    <tr class="grand_total">
                                        <td>应付价钱</td>
                                        <td class="price"><asp:Literal runat="server" ID="ltlTotal"></asp:Literal></td>
                                    </tr>
                                </table>
                                 <span class="zi8"><asp:Button ID="order" runat="server" OnClick="order_Click" Text="结算" /></span>
                                
                            </div>
                            <!-- .total -->
                        </div>
                        <!-- .grid_4 -->

                        <div class="clear"></div>
                    </div>
                    <!-- #content_bottom -->
                    <div class="clear"></div>

                    <div class="clear"></div>

                    <div class="carousel" id="following">
                        <div class="c_header">
                            <div class="grid_10">
                                <h5>你也许会喜欢:</h5>
                            </div>
                            <!-- .grid_10 -->

                            <div class="grid_2">
                                <a id="next_c1" class="next arows" href="#"><span>上一页</span></a>
                                <a id="prev_c1" class="prev arows" href="#"><span>上一页</span></a>
                            </div>
                            <!-- .grid_2 -->
                        </div>
                        <!-- .c_header -->

                        <div class="list_carousel">

                            <ul id="list_product" class="list_product">
                                <li class="">
                                    <div class="grid_3 product">

                                        <div class="prev">
                                            <a href="sp.html">
                                                <img src="images/nanshi/nanshi/916.jpg" alt="" title="" /></a>
                                        </div>
                                        <!-- .prev -->
                                        <h3 class="title">最新手表</h3>
                                        <div class="cart">
                                            <div class="price">
                                                <div class="vert">
                                                    <div class="price_new">$550.00</div>
                                                    <div class="price_old">$725.00</div>
                                                </div>
                                            </div>
                                            <a href="#" class="obn">收藏</a>
                                            <a href="#" class="like">收藏</a>
                                            <a href="#" class="bay">收藏</a>
                                        </div>
                                        <!-- .cart -->
                                    </div>
                                    <!-- .grid_3 -->
                                </li>

                                <li class="">
                                    <div class="grid_3 product">

                                        <div class="prev">
                                            <a href="sp.html">
                                                <img src="images/nanshi/nanshi/916.jpg" alt="" title="" /></a>
                                        </div>
                                        <!-- .prev -->
                                        <h3 class="title">最新手表</h3>
                                        <div class="cart">
                                            <div class="price">
                                                <div class="vert">
                                                    <div class="price_new">$550.00</div>
                                                    <div class="price_old">$725.00</div>
                                                </div>
                                            </div>
                                            <a href="#" class="obn">收藏</a>
                                            <a href="#" class="like">收藏</a>
                                            <a href="#" class="bay">收藏</a>
                                        </div>
                                        <!-- .cart -->
                                    </div>
                                    <!-- .grid_3 -->
                                </li>

                                <li class="">
                                    <div class="grid_3 product">

                                        <div class="prev">
                                            <a href="sp.html">
                                                <img src="images/nanshi/nanshi/916.jpg" alt="" title="" /></a>
                                        </div>
                                        <!-- .prev -->
                                        <h3 class="title">最新手表</h3>
                                        <div class="cart">
                                            <div class="price">
                                                <div class="vert">
                                                    <div class="price_new">$550.00</div>
                                                    <div class="price_old">$725.00</div>
                                                </div>
                                            </div>
                                            <a href="#" class="obn">收藏</a>
                                            <a href="#" class="like">收藏</a>
                                            <a href="#" class="bay">收藏</a>
                                        </div>
                                        <!-- .cart -->
                                    </div>
                                    <!-- .grid_3 -->
                                </li>

                                <li class="">
                                    <div class="grid_3 product">

                                        <div class="prev">
                                            <a href="sp.html">
                                                <img src="images/nanshi/nanshi/916.jpg" alt="" title="" /></a>
                                        </div>
                                        <!-- .prev -->
                                        <h3 class="title">最新手表</h3>
                                        <div class="cart">
                                            <div class="price">
                                                <div class="vert">
                                                    <div class="price_new">$550.00</div>
                                                    <div class="price_old">$725.00</div>
                                                </div>
                                            </div>
                                            <a href="#" class="obn">收藏</a>
                                            <a href="#" class="like">收藏</a>
                                            <a href="#" class="bay">收藏</a>
                                        </div>
                                        <!-- .cart -->
                                    </div>
                                    <!-- .grid_3 -->
                                </li>



                            </ul>
                            <!-- #list_product -->
                        </div>
                        <!-- .list_carousel -->
                    </div>
                    <!-- .carousel -->

                </div>
                <!-- .container_12 -->

            </section>
            <!-- #main -->


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
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>





                <div class="clear"></div>
            </div>
        </div>
        </div>

		<div class="footer">
            <div class="wrap">
                <div class="footer-left">
                    <ul>
                        <li><a href="index.html">网络文化经营许可证京网文[2011]0168-061号  违法和不良信息举报电话：4006561155  Copyright © 2004-2015  京东JD.com 版权所有</li>

                    </ul>
                </div>
                <div class="clear"></div>
            </div>
        </div>
        <script type="text/javascript">
            //限制数量只能输入数字
            function onlyNum(d) {
                d.value = d.value.replace(/\D/g, '');
            }

            //计算数量与单价的乘积
            function total(d, proid) {
                //alert($("#quantity").val());
                // alert(d.value);
                var str = d.parentElement.parentElement.cells[2].innerHTML.substr(1);
                //alert(str);
                var price = str * d.value;
                d.parentElement.parentElement.cells[4].innerHTML = "$" + fmoney(price, 2);
                submit(d.value, proid);
            }

            function submit(quantity, proid) {
                EShop.ShoppingCart.Edit(proid, quantity);
            }

            //计算所有商品的金额
            function fmoney(s, n) {
                n = n > 0 && n <= 20 ? n : 2;
                s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
                var l = s.split(".")[0].split("").reverse(),
                r = s.split(".")[1];
                t = "";
                for (i = 0; i < l.length; i++) {
                    t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
                }
                return t.split("").reverse().join("") + "." + r;
            }

            function DelProduct(proid, d) {
                if (confirmL("确定将商品移出购物车？", function () {
                    EShop.ShoppingCart.del(proid);
                    var t = d.parentElement.parentElement;
                    t.parentNode.removeChild(t);
                    return true;
                }))
                { }
            }

            function showtips() {
                if (confirm("未发现登陆账户，请先登陆")) {
                    window.navigate("aspx/login.aspx");
                }
            }
    </script>
    </form>
    
</body>
</html>

