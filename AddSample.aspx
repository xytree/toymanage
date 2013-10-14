<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="AddSample.aspx.cs" Inherits="AddSample" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css">
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="InputDiv">
        <table width="690" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
            <td width=15% class="td1" height="35"> 样品批号* </td>
            <td width=35% class="td2"><input type="text" name="samplenum" id="TxSampleIndex" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 单位名称 </td>
            <td width=35% class="td2">
                <asp:DropDownList ID="DListCorpname" runat="server" CssClass="in">
                </asp:DropDownList>
            </td>
        </tr>
        <tr >
            <td width=15% class="td1" height="35"> 收件人 </td>
            <td width=35% class="td2"><input type="text" name="recvman" id="TxRecvman" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 接件人 </td>
            <td width=35% class="td2"><input type="text" name="getman" id="TxGetman" runat="server" class="in" /></td>
        </tr>
        <tr >
            <td width=15% class="td1" height="35"> 收件单号 </td>
            <td width=35% class="td2"><input type="text" name="sendernum" id="TxSendnum" runat="server" class="in" /></td>
 
            <td width=15% class="td1" height="35"> 快递公司 </td>
            <td width=35% class="td2">
                <asp:DropDownList ID="DListSender" runat="server" CssClass="in">
                    <asp:ListItem>顺丰</asp:ListItem>
                    <asp:ListItem>申通</asp:ListItem>
                    <asp:ListItem>韵达</asp:ListItem>
                    <asp:ListItem>EMS</asp:ListItem>
                    <asp:ListItem>天天</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr >
            <td width=15% class="td1" height="35"> 收件时间 </td>
            <td width=35% class="td2">
                <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="UpdateCal">
                    <ContentTemplate> 
                    <input type="text" name="recvtime" id="TxRecvtime" runat="server" class="in" />
                    <div id="Calendardiv" style="display:none; z-index:2; position:absolute">
                        <asp:Calendar ID="CalendarRecv" runat="server" 
                            onselectionchanged="CalendarRecv_SelectionChanged" 
                            onvisiblemonthchanged="CalendarRecv_VisibleMonthChanged" 
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
 
            <td width=15% class="td1" height="35"> 批次数 </td>
            <td width=35% class="td2"><input type="text" name="batchnum" id="TxBatchnum" runat="server" class="in" /></td>
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

