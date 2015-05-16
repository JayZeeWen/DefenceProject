<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="tudouShop.Admin.ProductInfo"  validateRequest="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body.f-body {
            padding: 0;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" ValidateRequestMode="Disabled"/>
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"  AutoScroll="true" BodyPadding="10px" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        
                        <f:Button ID="btnSaveRefresh" ValidateForms="SimpleForm1" Text="保存" runat="server" Icon="SystemSave"
                            OnClick="btnSaveRefresh_Click">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
 
                        <f:ToolbarText ID="ToolbarText1" Text="提示一" runat="server">
                        </f:ToolbarText>
                        <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText2" Text="提示二&nbsp;&nbsp;" runat="server">
                        </f:ToolbarText>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow >
                    <Items >                        
                        <f:TextBox runat="server" ID="txtProName" Label="商品名称" Required="true" ShowRedStar="true" ></f:TextBox>
                        <f:NumberBox ID="nbxPrice" runat="server" Required="true" Label="售价" ShowRedStar="true" NoNegative="true"></f:NumberBox>
                       
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox ID="nbxSalePoint" runat="server" Required="true" Label="销售积分" ShowRedStar="true" NoNegative="true" NoDecimal="true"></f:NumberBox>
                        <f:DropDownList runat="server" ID="ddlBrand" Label="品牌"></f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox ID="nbxStack" NoNegative="true" Label="库存" Required="true" ShowRedStar="true" runat="server" NoDecimal="true"  />
                        <f:DatePicker ID="dtpShelveDate" Required="True" ShowRedStar="true" runat="server" Label="上架日期" ></f:DatePicker>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea  ID="txtDesc" Label="详细描述" Height="150px" runat="server">
                        </f:TextArea>

                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
