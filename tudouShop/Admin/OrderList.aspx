<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="tudouShop.Admin.OrderList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.ui.all.css" rel="stylesheet" />
    <style>
        body.f-body {
            padding: 0;
        }

        #fade {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }

        #light {
            display: none;
            position: absolute;
            top: 25%;
            left: 25%;
            width: 50%;
            height: 50%;
            padding: 16px;
            border: 3px solid orange;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">        
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        
        <f:Panel ID="Panel1" runat="server" Layout="Region" Title=" ">
            <Items>
                <f:Panel runat="server" ID="panelTopRegion" Height="50px" RegionPosition="Top" ShowHeader="false">
                    <Content>
                        <f:Label runat="server" ID="lblTitle" EncodeText="false" Margin="10px" Text="<span style='font-size:30px;'><strong>商城后台管理系统</strong></span>"></f:Label>
                    </Content>
                </f:Panel>
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="false"
                    Width="140px" Title="内容管理" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:HyperLink NavigateUrl="~/admin/ProductList.aspx" runat="server" Text="商品管理"></f:HyperLink>
                        <f:HyperLink NavigateUrl="~/admin/userlist.aspx" runat="server" Text="会员管理"></f:HyperLink>
                        <f:HyperLink NavigateUrl="~/admin/OrderList.aspx" runat="server" Text="订单管理"></f:HyperLink>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center" ShowBorder="true" BodyPadding="5px" Title=" ">
                    <Items>
                        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="订单列表" runat="server" EnableCollapse="false"
                            DataKeyNames="OrderID" PageSize="13" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                            AllowCellEditing="true" ClicksToEdit="2" AllowSorting="true" OnRowCommand="Grid1_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        
                                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                                        <f:Button ID="btnSave" runat="server" Text="保存数据" OnClick="btnSave_Click">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField TextAlign="Center" ColumnID="OrderID" DataField="OrderID"  HeaderText="订单标识"></f:BoundField>                                
                                <f:BoundField TextAlign="Center" ColumnID="Account" DataField="Account"  HeaderText="订单用户" Width="150px"></f:BoundField>
                                <f:BoundField TextAlign="Center" ColumnID="OrderDate" DataField="OrderDate"  HeaderText="订单日期" Width="150px"></f:BoundField>
                                <f:BoundField TextAlign="Center" ColumnID="NAME" DataField="NAME"  HeaderText="收件人"></f:BoundField>
                                <f:BoundField TextAlign="Center" ColumnID="deliverAddress" DataField="deliverAddress"  HeaderText="收件地址"></f:BoundField>
                                <f:BoundField TextAlign="Center" ColumnID="Phone" DataField="Phone"  HeaderText="联系电话"></f:BoundField>
                                <f:RenderField TextAlign="Center" ColumnID="c_state"  DataField="c_state"  HeaderText="订单状态" RendererArgument="OrderID" RendererFunction="renderState"></f:RenderField>                                
                                <f:TemplateField HeaderText=" " TextAlign="Center" ExpandUnusedSpace="true" >
                                    <ItemTemplate>
                                        <a href="javascript:<%# GetEditUrl(Eval("OrderID"), Eval("OrderID")) %>">商品详情</a>
                                    </ItemTemplate>
                                </f:TemplateField>
                            </Columns>
                        </f:Grid>
                        <f:Window ID="InfoWindows" Title="商品详情" Hidden="true" EnableIFrame="true" runat="server"
                            CloseAction="HidePostBack" EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="600px" Height="350px">
                        </f:Window>
                        
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelBottomRegion" RegionPosition="Bottom" RegionSplit="true" EnableCollapse="false" Height="20px"
                    Title=" " ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                </f:Panel>

            </Items>
            
        </f:Panel>
        
    </form>
    <script>


        function renderState(value, metadata, record, rowIndex, colIndex) {
            if (value == "未发货") {
                return "<span><image src='../res/icon/exclamation.png' onclick='Delive(" + record.data.OrderID + ")'></image></span>" + value;
            } else {
                return value;
            }
        }
        function renderBrand(value) {
            var bid = value;
            return EShop.ProductList.getBrandName(bid).value;
        }

        function renderMoney(value) {
            var money = "$ " + value;
            return money;
        }

        function renderDelivery(value) {
            var rowid = value;
            var html = tudouShop.Admin.OrderList.BuildHtml(rowid);
            return html;
        }

        function Delive(id) {
            if (confirmL("确认发货？", function () {
                tudouShop.Admin.OrderList.Delive(id);
                
                location.reload();
            })) {

            }
        }

        function confirmL(msg, callBack) {
            var div = document.createElement("div");
            $(div).html(msg).dialog({
                title: "提醒",
                modal: true,
                resizable: false,
                buttons: {
                    "确定": function (e) {
                        $(this).dialog("close");
                        if (callBack != null) {
                            callBack();
                        }

                    }, "取消": function (e) {
                        $(this).dialog("close");

                    }
                }
            });
        }



    </script>
</body>
</html>
