<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="ChemElement.aspx.cs" Inherits="ChemElement" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="left" style="margin-top: 30px;margin-bottom: 20px;margin-left: 0px;" >
         <table width="590" cellspacing="0" cellpadding="0" class="table" align="center">
            <tr >
                <td width=15% class="td1" height="35"> 元素名称 </td>
                <td width=35% class="td2" colspan="3"><input type="text" name="corpnum" id="TxElemName" runat="server" class="in" /></td>
            </tr>
            <tr >
                <td width=15% class="td1" height="35"> 检测上限 </td>
                <td width=35% class="td2"><input type="text" name="corpnum" id="TxGateUp" runat="server" class="in" /></td>
                <td width=15% class="td1" height="35"> 门限下限 </td>
                <td width=35% class="td2"><input type="text" name="corpnum" id="TxGateDown" runat="server" class="in" /></td>
            </tr>
            <tr>
            <td height="45" colspan="4" class="td3">
                <input id="BtnSaveDepart" type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnSaveClick"/>
                <input id="BtnDelDepart" type="button" runat="server" class="btn2" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnDelClick"/>
            </td>
            </tr>
         </table>
    </div>
    
    <div class="ShowInfoDiv" align="center">
        <asp:GridView ID="GdElementInfo" runat="server" CssClass="datalist" 
            AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="SIndex" HeaderText="序号" SortExpression="SIndex" />
                <asp:BoundField DataField="SEleName" HeaderText="元素名称" SortExpression="SIndex" />
                <asp:BoundField DataField="SGateUp" HeaderText="检测上限" SortExpression="SIndex" />
                <asp:BoundField DataField="SGateDown" HeaderText="检测下限" SortExpression="SIndex" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

