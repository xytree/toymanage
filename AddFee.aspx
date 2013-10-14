<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddFee.aspx.cs" Inherits="AddFee" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
            <td width=15% class="td1" height="35"> 报检号 </td>
            <td width=35% class="td2"><input type="text" name="TxReportNum" id="TxReportNum" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 账户名称 </td>
            <td width=35% class="td2"><input type="text" name="TxCountName" id="TxCountName" runat="server" class="in" /></td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 货币单位 </td>
            <td width=35% class="td2"><input type="text" name="TxCurrency" id="TxCurrency" runat="server" class="in" /></td>
            <td width=15% class="td1"> 原始价格 </td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="TxCostOriginal" id="TxCostOriginal" runat="server" class="in" />
            </td>
        </tr>
        <tr >
            <td width=15% class="td1" height="35"> 优惠价格 </td>
            <td width=35% class="td2">
                <input type="text" name="TxCostPrefer" id="TxCostPrefer" runat="server" class="in" />
            </td>
            <td width=15% class="td1">合计价格</td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="TxCostAll" id="TxCostAll" runat="server" class="in" />
            </td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 是否到账 </td>
            <td width=35% class="td2">
                <asp:DropDownList ID="DListCostRecv" runat="server" CssClass="in">
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
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
