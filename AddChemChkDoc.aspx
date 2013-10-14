<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddChemChkDoc.aspx.cs" Inherits="AddChemChkDoc" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css">
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr>
            <td width=15% class="td1" height="35"> 报检号 </td>
            <td width=35% class="td2"><input type="text" name="txindex" id="TxnIndex" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 样品名称 </td>
            <td width=35% class="td2"><input type="text" name="samplename" id="TxSampleName" runat="server" class="in" /></td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 样品数量 </td>
            <td width=35% class="td2">
                <input type="text" name="samplenum" id="TxSampleNum" runat="server" class="in" />
            </td>
            <td width=15% class="td1">输入人 </td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="inputman" id="TxInputMan" runat="server" class="in" />
            </td>
        </tr>
        <tr > 
            <td width=15% class="td1" height="35"> 截止日期 </td>
            <td width=35% class="td2">
                <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="UpdateCal">
                    <ContentTemplate> 
<%--                    <input type="text" name="finishdate" id="TxFinishDate" runat="server" class="in" />--%>
                        <asp:TextBox ID="TxFinishDate" runat="server" CssClass="in"></asp:TextBox>
                    <div id="Calendardiv" style="display:none; z-index:2; position:absolute">
                        <asp:Calendar ID="CalendarFinish" runat="server" 
                            onselectionchanged="CalendarFinish_SelectionChanged" 
                            onvisiblemonthchanged="CalendarFinish_VisibleMonthChanged" 
                            BackColor="#FFFFCC" BorderColor="#FFCC66" ForeColor="#0000C0" ShowGridLines="True">
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True"/>
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                        </asp:Calendar> 
                    </div> 
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td height="45" colspan="5" class="td3">
                <input id="BtnSave" type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnSaveClick"/>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>

