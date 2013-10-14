<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddRecheck.aspx.cs" Inherits="AddRecheck" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
            <td width=15% class="td1" height="35"> 报检号 </td>
            <td width=35% class="td2"><input type="text" name="RechkIndex" id="TxRechkIndex" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 单位名称 </td>
            <td width=35% class="td2"><input type="text" name="corpname" id="TxCorpName" runat="server" class="in" /></td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 输入人 </td>
            <td width=35% class="td2"><input type="text" name="inputman" id="TxInputman" runat="server" class="in" /></td>
            <td width=15% class="td1"> 输入日期 </td>
            <td width=35% colspan="2" class="td2">
                <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="UpdateCal">
                    <ContentTemplate> 
                    <input type="text" name="inputdate" id="TxInputdate" runat="server" class="in" />
                    <div id="Calendardiv" style="display:none; z-index:2; position:absolute">
                        <asp:Calendar ID="CalendarInput" runat="server" 
                            onselectionchanged="CalendarInput_SelectionChanged" 
                            onvisiblemonthchanged="CalendarInput_VisibleMonthChanged" 
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
        <tr > 
            <td width=15% class="td1" height="35"> 样品类型 </td>
            <td width=35% class="td2">
                <input type="text" name="sampletype" id="TxSampleType" runat="server" class="in" />
            </td>
            <td width=15% class="td1"> 样品数量</td>
            <td width=35% colspan="2" class="td2">
                <input type="text" name="samplenum" id="TxSampleNum" runat="server" class="in" />
            </td>
        </tr>
        <tr>
            <td width=15% class="td1" height="35"> 复检原因 </td>
            <td width=35% class="td2" colspan="3">
                <input type="text" name="rechkReason" id="TxReason" runat="server" class="in" />
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

