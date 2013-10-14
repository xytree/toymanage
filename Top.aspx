<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页</title>
    <link href="CSS/skin.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="admin_topbg">
            <tr>
                <td width="356">
                    <img src="images/logo1_wanju.png" align="absmiddle" />
                </td>
                <td class="admin_txt">
                    您好：<b><%=Session["CurrentUser"]%></b>，感谢登录使用！
                </td>
                <td width="87" headers="42">
                    <asp:ImageButton ID="BtnCancel" runat="server" ImageUrl="~/images/anniu.png" Width="87"
                        Height="42" OnClick="BtnCancel_click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
