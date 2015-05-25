<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="tudouShop.Admin.OrderList" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
    <style>
        body.f-body {
            padding: 0;
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
                                        <f:Button ID="btnNew" Text="新增订单" Icon="Add" EnablePostBack="false" runat="server">
                                        </f:Button>
                                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                                        <f:Button ID="btnSave" runat="server" Text="保存数据" OnClick="btnSave_Click">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField TextAlign="Center" ColumnID="OrderID" DataField="OrderID"  HeaderText="订单标识"></f:BoundField>
                                
                                
                                
                                
                                <f:LinkButtonField HeaderText="&nbsp;" TextAlign="Center" Width="60px" ConfirmText="删除选中行？" ConfirmTarget="Top"
                                    CommandName="Del" Icon="Delete" />
                                
                            </Columns>
                        </f:Grid>
                        
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelBottomRegion" RegionPosition="Bottom" RegionSplit="true" EnableCollapse="false" Height="20px"
                    Title=" " ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
    <script>
        function renderType(value) {
            var tid = value;
            return EShop.ProductList.getTypeName(tid).value;
        }
        function renderBrand(value) {
            var bid = value;
            return EShop.ProductList.getBrandName(bid).value;
        }

        function renderMoney(value) {
            var money = "$ " + value;
            return money;
        }

    </script>
</body>
</html>
