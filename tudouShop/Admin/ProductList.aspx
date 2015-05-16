<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EShop.ProductList"  %>


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
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center" ShowBorder="true" BodyPadding="5px" Title=" ">
                    <Items>
                        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="商品列表" runat="server" EnableCollapse="false"
                            DataKeyNames="ProID,ProName" PageSize="13" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                            AllowCellEditing="true" ClicksToEdit="2" AllowSorting="true" OnRowCommand="Grid1_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <f:Button ID="btnNew" Text="新增商品" Icon="Add" EnablePostBack="false" runat="server">
                                        </f:Button>
                                        <f:ToolbarFill runat="server"></f:ToolbarFill>
                                        <f:Button ID="btnSave" runat="server" Text="保存数据" OnClick="btnSave_Click">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:RowNumberField />
                                <f:RenderField Width="260px" TextAlign="Center" ColumnID="ProName" DataField="ProName" FieldType="String"
                                    HeaderText="商品名称">
                                    <Editor>
                                        <f:TextBox ID="txtProName" Required="true" runat="server">
                                        </f:TextBox>
                                    </Editor>
                                </f:RenderField>
                                <f:RenderField ColumnID="BraID" DataField="BraID" HeaderText="品牌" FieldType="Int" RendererFunction="renderBrand" TextAlign="Center">
                                    <Editor>
                                        <f:DropDownList runat="server" ID="ddlBrand" Required="true"></f:DropDownList>
                                    </Editor>
                                </f:RenderField>

                                <f:RenderField TextAlign="Center" ColumnID="Price" DataField="Price" RendererFunction="renderMoney" FieldType="Float" HeaderText="价格">
                                    <Editor>
                                        <f:TextBox ID="txtPrice" Required="true" runat="server">
                                        </f:TextBox>
                                    </Editor>
                                </f:RenderField>
                                <f:RenderField TextAlign="Center" ColumnID="SalePoint" DataField="SalePoint" FieldType="Int" HeaderText="销售积分">
                                    <Editor>
                                        <f:TextBox ID="txtSaslePoint" Required="true" runat="server">
                                        </f:TextBox>
                                    </Editor>
                                </f:RenderField>
                                <f:RenderField TextAlign="Center" ColumnID="Stock" DataField="Stock" FieldType="Int" HeaderText="库存">
                                    <Editor>
                                        <f:TextBox ID="txtStrock" Required="true" runat="server">
                                        </f:TextBox>
                                    </Editor>
                                </f:RenderField>
                                <f:RenderField Width="120px" ColumnID="ShelveDate" DataField="ShelveDate" FieldType="Date"
                                    Renderer="Date" RendererArgument="yyyy-MM-dd" HeaderText="上架日期" TextAlign="Center">
                                    <Editor>
                                        <f:DatePicker ID="DatePicker1" Required="true" runat="server">
                                        </f:DatePicker>
                                    </Editor>
                                </f:RenderField>
                               <%-- <f:BoundField DataField="des" DataFormatString="{0}" HeaderText="描述"></f:BoundField>--%>
                                <f:LinkButtonField HeaderText="&nbsp;" TextAlign="Center" Width="60px" ConfirmText="删除选中行？" ConfirmTarget="Top"
                                    CommandName="Del" Icon="Delete" />
                                <f:WindowField ColumnID="ProID" Width="60px" WindowID="InfoWindows" Icon="Pencil" ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ProID"
                                    DataIFrameUrlFormatString="ProductInfo.aspx?id={0}&t=1" DataWindowTitleField="ProName" TextAlign="Center" DataWindowTitleFormatString="编辑 - {0}" />
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
