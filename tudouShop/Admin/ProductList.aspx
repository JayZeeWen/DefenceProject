<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EShop.ProductList" %>

<!DOCTYPE html>

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
        <f:Panel ID="Panel1" runat="server"  Layout="Region" Title=" ">
            <Items>
                <f:Panel runat="server" ID="panelTopRegion" Height="50px" RegionPosition="Top" ShowHeader="false">
                    <Content>
                        <f:Label runat="server" ID="lblTitle" EncodeText="false" Margin="10px" Text="<span style='font-size:30px;'><strong>商城后台管理系统</strong></span>"></f:Label>
                    </Content>
                </f:Panel>
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="false"
                    Width="200px" Title="左侧面板" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:Label ID="Label2" runat="server" Text="左侧面板的内容">
                        </f:Label>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center" ShowBorder="true"  BodyPadding="5px" Title=" " >
                    <Items>
                        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="商品列表"  runat="server" EnableCollapse="false"
                            DataKeyNames="ProName" PageSize="15" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                            AllowCellEditing="true" ClicksToEdit="1" AllowSorting="true">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="200px" DataField="ProName" DataFormatString="{0}" HeaderText="商品名称" TextAlign="Center" />
                                <f:RenderField ColumnID="TID" DataField="TID" HeaderText="大类" FieldType="Int" RendererFunction="renderType" TextAlign="Center">
                                    <Editor>
                                        <f:DropDownList runat="server" id="ddlType" Required="true"></f:DropDownList>
                                    </Editor>
                                </f:RenderField>
                                 <f:RenderField ColumnID="BraID" DataField="BraID" HeaderText="品牌" FieldType="Int" RendererFunction="renderBrand" TextAlign="Center">
                                    <Editor>
                                        <f:DropDownList runat="server" id="ddlBrand" Required="true"></f:DropDownList>
                                    </Editor>
                                </f:RenderField>
                                
                                <f:BoundField DataField="Price" DataFormatString="$ {0}" HeaderText="价格" TextAlign="Center" />
                                <f:BoundField DataField="SalePoint" DataFormatString="{0}" HeaderText="销售积分" TextAlign="Center"></f:BoundField>
                                <f:BoundField DataField="Stock" DataFormatString="{0}" HeaderText="库存" TextAlign="Center"></f:BoundField>
                                <f:RenderField Width="120px" ColumnID="ShelveDate" DataField="ShelveDate" FieldType="Date"
                                    Renderer="Date" RendererArgument="yyyy-MM-dd" HeaderText="上架日期" TextAlign="Center">
                                    <Editor>
                                        <f:DatePicker ID="DatePicker1" Required="true" runat="server">
                                        </f:DatePicker>
                                    </Editor>
                                </f:RenderField>
                                <f:BoundField  DataField="des" DataFormatString="{0}" HeaderText="描述"></f:BoundField>
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
    </script>
</body>
</html>
