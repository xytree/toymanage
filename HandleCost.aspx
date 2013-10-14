<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="HandleCost.aspx.cs" Inherits="HandleCost" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/4.css" rel="stylesheet" type="text/css" />
    <link href="CSS/gridview.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="jquery-ui-1.10.2/themes/cupertino/jquery.ui.all.css" />
    <script src="JQuery/jquery-1.9.1.js"></script>
	<script src="jquery-ui-1.10.2/ui/jquery.ui.core.js" type="text/javascript"></script>
	<script src="jquery-ui-1.10.2/ui/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="jquery-ui-1.10.2/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
    <link rel="stylesheet" href="jquery-ui-1.10.2/demos/demos.css" />
    <style type="text/css">
        .style1
        {
            border: 1px solid #d6d5d5;
            padding: 0;
            margin: 0;
            background-color: #ffffff;
            text-align: center;
            font-family: 宋体;
            font-weight: bold;
            font-size: 10pt;
            vertical-align: middle;
            height: 36px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#datepicker1,#datepicker2,#datepicker3,#datepicker4").datepicker({
                showOtherMonths: true,
                selectOtherMonths: true
            });
            $("#datepicker1,#datepicker2,#datepicker3,#datepicker4").datepicker("option", "dateFormat", "yy-mm-dd");
        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" class="ConDiv">
        <table cellspacing="0" cellpadding="0" class="table" align="center">
            <tr>
                <td width="304" height="36"class="td1">报验日期:
<%--                  <input type="text" name="datepicker1" id="datepicker1" class="date" />--%> 
                 <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server" ID="UpdateCal1" RenderMode="Inline">
                        <ContentTemplate> 
                        <input type="text" name="Begindate" id="TxBeginDate" runat="server" class="date" />
                        <div id="Calendardiv1" style="display:none; z-index:2; position:absolute">
                            <asp:Calendar ID="CalendarBegin" runat="server" 
                                onselectionchanged="CalendarBegin_SelectionChanged" 
                                onvisiblemonthchanged="CalendarBegin_VisibleMonthChanged" 
                                BackColor="#FFFFCC" BorderColor="#FFCC66" ForeColor="#0000C0" ShowGridLines="True">
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True"/>
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                            </asp:Calendar>
                        </div> 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  至
<%--                  <input type="text" name="datepicker2" id="datepicker2" class="date"/></td>--%> 
                   <asp:UpdatePanel runat="server" ID="UpdateCal2" RenderMode="Inline">
                        <ContentTemplate> 
                        <input type="text" name="Enddate" id="TxEndDate" runat="server" class="date" />
                        <div id="Calendardiv2" 
                                style="display:none; z-index:3; position:absolute; left: 45%">
                            <asp:Calendar ID="CalendarEnd" runat="server" 
                                onselectionchanged="CalendarEnd_SelectionChanged" 
                                onvisiblemonthchanged="CalendarEnd_VisibleMonthChanged" 
                                BackColor="#FFFFCC" BorderColor="#FFCC66" ForeColor="#0000C0" ShowGridLines="True">
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True"/>
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                            </asp:Calendar>
                        </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <td width="183" height="36" class="td1"> 是否到账
                    <asp:DropDownList ID="DListBRecv" runat="server">
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style1">
                    <asp:Button ID="BtnFind" runat="server" Text="搜索" onclick="BtnFind_Click" 
                        CssClass="blues" />
                </td>
            </tr>
        </table>
    </div>
    <div align="center" >
        <asp:Panel ID="Panel1" runat="server" Height=400px 
            Width=90%>
        <asp:GridView ID="GridCostInfo" runat="server"
            AutoGenerateColumns="False" Width="100%" CssClass="datalist" 
                onrowcreated="GridCostInfo_RowCreated" 
                onrowdatabound="GridCostInfo_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="报验号" DataField="SSerial"/>
                <asp:BoundField HeaderText="报检单位" DataField="SCorpRep"/>
                <asp:BoundField HeaderText="送样单位" DataField="SCorpSend"/>
                <asp:BoundField HeaderText="合计价格" DataField="FCostAll"/>
                <asp:CheckBoxField HeaderText="是否到账" DataField="BPay"/>
                <asp:TemplateField HeaderText="完成付款">
                    <ItemTemplate>
                        <asp:Button ID="BtnPay" runat="server" Text="到账确认" onclick="BtnPay_Click" CssClass="blues" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </asp:Panel>
    </div>
    
</asp:Content>

