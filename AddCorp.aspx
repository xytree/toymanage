<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddCorp.aspx.cs" Inherits="AddCorp" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
            <td width=15% class="td1" height="35"> 单位编号 </td>
            <td width=35% class="td2"><input type="text" name="corpnum" id="TxCorpNum" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 单位名称 </td>
            <td width=35% class="td2"><input type="text" name="corpname" id="TxCorpName" runat="server" class="in" /></td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 联系人1 </td>
            <td width=35% class="td2"><input type="text" name="contactman" id="TxContactMan1" runat="server" class="in" /></td>
            <td width=15% class="td1"> 联系人2 </td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="contactman" id="TxContactMan2" runat="server" class="in" />
            </td>
        </tr>
        <tr > 
            <td width=15% class="td1" height="35"> 联系地址1 </td>
            <td width=35% class="td2">
                <input type="text" name="address1" id="TxAddress1" runat="server" class="in" />
            </td>
            <td width=15% class="td1">联系地址2</td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="address2" id="TxAddress2" runat="server" class="in" />
            </td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 联系电话 </td>
            <td width=35% class="td2">
                <input type="text" name="phonenum" id="TxPhoneNum" runat="server" class="in" />
            </td>
        </tr>
        <tr>
            <td height="45" colspan="5" class="td3">
                <input id="Button1" type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnSaveClick"/>
            </td>
        </tr>
        </table>
    </div>

</asp:Content>

