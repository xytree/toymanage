<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
            <td width=15% class="td1" height="35"> 登录名 </td>
            <td width=35% class="td2"><input type="text" name="logname" id="TxLogName" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 姓名 </td>
            <td width=35% class="td2"><input type="text" name="name" id="TxName" runat="server" class="in" /></td>

        </tr>
        <tr > 
            <td width=15% class="td1" height="35"> 密码 </td>
            <td width=35% class="td2"><input type="text" name="password" id="TxPasswd" runat="server" class="in" /></td>
            <td width=15% class="td1">确认密码</td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="passwordassert" id="TxpasswdAss" runat="server" class="in" />
            </td>
        </tr>
        <tr > 
            <td width=15% class="td1" height="35"> 管理权限 </td>
            <td width=35% class="td2">
                <asp:DropDownList ID="DListManageAuthority" runat="server" CssClass="in">
                    <asp:ListItem>无</asp:ListItem>
                    <asp:ListItem>有</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width=15% class="td1">应用权限</td>
            <td width=35% colspan="2" class="td2">
                <asp:DropDownList ID="DListUseAuthority" runat="server" CssClass="in">
                    <asp:ListItem>一级</asp:ListItem>
                    <asp:ListItem>二级</asp:ListItem>
                    <asp:ListItem>三级</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 部门 </td>
            <td width=35% class="td2">
                <asp:DropDownList ID="DListDepart" runat="server" CssClass="in">
                </asp:DropDownList>
            </td>
            <td width=15% class="td1">岗位</td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="position" id="TxPosition" runat="server" class="in" />
            </td>
        </tr>
        <tr>
            <td height="45" colspan="5" class="td3">
                <input type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnSaveClick"/>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>