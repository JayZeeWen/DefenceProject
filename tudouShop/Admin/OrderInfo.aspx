<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="tudouShop.Admin.OrderInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <f:PageManager runat="server" ID="pagemanager"></f:PageManager>
        <f:Grid runat="server" ID="gridDetails" OnPageIndexChange="gridDetails_PageIndexChange" PageSize="5">
            <Columns>
                <f:BoundField TextAlign="Center" ColumnID="ProName" DataField="ProName"  HeaderText="商品名称" ExpandUnusedSpace="true"></f:BoundField>
                <f:BoundField TextAlign="Center" DataField="Price" HeaderText="价格"></f:BoundField>
                <f:BoundField TextAlign="Center" DataField ="quantity" HeaderText="数量"></f:BoundField>
            </Columns>
        </f:Grid>
    
    </div>
    </form>
</body>
</html>
