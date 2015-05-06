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
                <f:Panel runat="server" ID="panelTopRegion" Height="50px" RegionPosition="Top">
                    
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
                            DataKeyNames="ProName" PageSize="23" AllowPaging="true" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="200px" DataField="ProName" DataFormatString="{0}" HeaderText="姓名" TextAlign="Center" />
                                <f:BoundField Width="100px" DataField="Price" DataFormatString="$ {0}" HeaderText="价格" />                                
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
</body>
</html>
