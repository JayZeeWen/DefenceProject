<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="tudouShop.Admin.UserList" %>

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
                    Width="140px" Title="左侧面板" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:HyperLink NavigateUrl="~/admin/ProductList.aspx" runat="server" Text="商品管理"></f:HyperLink>
                        <f:HyperLink NavigateUrl="~/admin/userlist.aspx" runat="server" Text="会员管理"></f:HyperLink>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center" ShowBorder="true" BodyPadding="5px" Title=" ">
                    <Items>
                        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="商品列表" runat="server" EnableCollapse="false"
                            DataKeyNames="UserID,Account" PageSize="13" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                            AllowCellEditing="true" ClicksToEdit="2" AllowSorting="true" OnRowCommand="Grid1_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <f:Button ID="btnNew" Text="新增会员" Icon="Add" EnablePostBack="false" runat="server">
                                        </f:Button>
                                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                                        <f:Button ID="btnSave" runat="server" Text="保存数据" OnClick="btnSave_Click">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:RenderField Width="200px" TextAlign="Center" ColumnID="Account" DataField="Account" FieldType="String"
                                    HeaderText="用户名">
                                    <Editor>
                                        <f:TextBox ID="txtProName" Required="true" runat="server">
                                        </f:TextBox>
                                    </Editor>
                                </f:RenderField>
                               <f:BoundField DataField="Pwd" HeaderText="登陆密码" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="PFP" HeaderText="支付密码" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="Points" HeaderText="积分" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="Name" HeaderText="姓名" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="Sex" Width="60" HeaderText="性别" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="Phone" HeaderText="电话"  TextAlign="Center"></f:BoundField>
                               <%-- <f:BoundField DataField="des" DataFormatString="{0}" HeaderText="描述"></f:BoundField>--%>
                            </Columns>
                        </f:Grid>
                        <f:Window ID="InfoWindows" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
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
