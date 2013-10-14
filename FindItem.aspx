<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="FindItem.aspx.cs" Inherits="FindItem" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css">
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div style="margin: 15px; width: 100%;">
        <asp:Label ID="Label1" runat="server" Text="开始日期" Font-Names="楷体"></asp:Label>
            <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdateCal" RenderMode="Inline">
                <ContentTemplate> 
                <asp:TextBox ID="DateBegin" runat="server"></asp:TextBox>
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
        <asp:Label ID="Label2" runat="server" Text="结束日期" Font-Names="楷体"></asp:Label>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" RenderMode="inline">
                <ContentTemplate> 
                <asp:TextBox ID="DateEnd" runat="server"></asp:TextBox>
                <div id="Calendardiv2" 
                        style="display:none; z-index:3; position:absolute; left: 30%;">
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
        <asp:Button ID="BtnFind" runat="server" Text="查找" Width="80px" CssClass="blues" 
            onclick="BtnFind_Click" />
    </div>

    <div class="leftbox">
        <asp:GridView ID="GdProinfo" runat="server" Width="100%" CssClass="datalist" 
            DataSourceID="ObjDataSource_Find" ForeColor="Black" DataKeyNames="报检号" 
            onselectedindexchanged="GdProinfo_SelectedIndexChanged" AllowPaging="True" 
            PageSize="15" AllowSorting="True" 
            onpageindexchanged="GdProinfo_PageIndexChanged" 
            onsorted="GdProinfo_Sorted" ondatabound="GdProinfo_DataBound">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="选择项目" />
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NumericFirstLast" 
                NextPageText="后一页" PreviousPageText="前一页" />
            <SelectedRowStyle BackColor="#006600" ForeColor="White" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjDataSource_Find" runat="server" 
        TypeName="InfoSpace.HandleItem" 
        SelectMethod="GetProinfo" onselecting="ObjDataSource_Find_Selecting" EnableCaching="True">
            <SelectParameters>
                <asp:ControlParameter ControlID="DateBegin" 
                    Name="begin" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DateEnd" Name="end" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>

    <div class="rightbox">
        <asp:DetailsView ID="DetailviewProinfo" runat="server" Height="100%" 
            Width="95%" AutoGenerateRows="False"
            HorizontalAlign="Left" DataSourceID="DetailsDatasource" 
            CssClass="datalist"  
            ForeColor="Black" ondatabound="DetailviewProinfo_DataBound" DataKeyNames="报检号">
            <Fields>
                <asp:BoundField DataField="报检号" HeaderText="报检号" />
                <asp:BoundField DataField="录入人" HeaderText="录入人" />
                <asp:BoundField DataField="录入时间" HeaderText="录入时间" />
                <asp:BoundField DataField="报检类型" HeaderText="报检类型" />
                <asp:TemplateField HeaderText="报检单位">
                    <EditItemTemplate>
<%--                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("报检单位") %>'></asp:TextBox>--%>
                            <asp:DropDownList ID="DListCorp" runat="server">
                            </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("报检单位") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("报检单位") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="收样人" HeaderText="收样人" />
                <asp:BoundField DataField="样品类型" HeaderText="样品类型" />
                <asp:BoundField DataField="规格型号" HeaderText="规格型号" />
                <asp:BoundField DataField="样品数量" HeaderText="样品数量" />
                <asp:BoundField DataField="检测标准1" HeaderText="检测标准1" />
                <asp:BoundField DataField="检测标准2" HeaderText="检测标准2" />
                <asp:BoundField DataField="检测标准3" HeaderText="检测标准3" />
                <asp:BoundField DataField="备注信息" HeaderText="备注信息" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"/>
            </Fields>
        </asp:DetailsView>
        
        <asp:ObjectDataSource ID="DetailsDatasource" runat="server"
                TypeName="InfoSpace.HandleItem" 
                SelectMethod="GetDetails" UpdateMethod="UpdateItem"
                onselecting="DetailsDatasource_Selecting" 
                onselected="DetailsDatasource_Selected" 
            DataObjectTypeName="InfoSpace.Itempara" 
            onupdated="DetailsDatasource_Updated" DeleteMethod="DeleteItem" 
            ondeleted="DetailsDatasource_Deleted" 
            onupdating="DetailsDatasource_Updating">
            <SelectParameters>
                <asp:ControlParameter ControlID="GdProinfo" Name="nIndex" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

