<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="staffmanger.aspx.cs" Inherits="Staffmanger" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div style="margin: 15px">
        人员信息:
    </div>

    <div class="leftbox">
        <asp:GridView ID="GdStaffInfo" runat="server" CssClass="datalist" 
            ForeColor="Black" AllowPaging="True" AllowSorting="True" 
            DataSourceID="ObjectDataSource_staff" PageSize="15" 
            onpageindexchanged="GdStaffInfo_PageIndexChanged" onsorted="GdStaffInfo_Sorted" 
            Width="100%" DataKeyNames="登录名" 
            onselectedindexchanged="GdStaffInfo_SelectedIndexChanged" Font-Names="黑体" 
            ondatabound="GdStaffInfo_DataBound">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="选择用户" />
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NumericFirstLast" 
                NextPageText="下一页" PreviousPageText="上一页" />
            <SelectedRowStyle BackColor="#003300" ForeColor="White" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjectDataSource_staff" runat="server" 
            SelectMethod="GetStaffInfo" TypeName="InfoSpace.HandleStaff">
        </asp:ObjectDataSource>
    </div>
    
    <div class="rightbox">
        <asp:DetailsView ID="DetailsView_StaffInfo" runat="server" Height="100%" 
            Width="95%" CssClass="datalist" ForeColor="Black" HorizontalAlign="Left"
            AutoGenerateRows="False"
            DataSourceID="ObjectDataSource_DetailStaff" DataKeyNames="登录名" 
            ondatabound="DetailsView_StaffInfo_DataBound" Font-Names="黑体" 
            onitemupdating="DetailsView_StaffInfo_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="登录名" HeaderText="登录名"/>
                <asp:BoundField DataField="用户名" HeaderText="用户名"/>
                <asp:BoundField DataField="密码" HeaderText="密码"/>
                <asp:TemplateField HeaderText="部门">
                    <EditItemTemplate>
                        <%-- <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("部门") %>'></asp:TextBox>--%>
                        <asp:DropDownList ID="DropListDepart" runat="server" 
                            onselectedindexchanged="DropListDepart_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TxDepartname" runat="server" Text='<%# Bind("部门") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LabDepart" runat="server" Text='<%# Bind("部门") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="岗位" HeaderText="岗位"/>
                <asp:BoundField DataField="管理权限" HeaderText="管理权限"/>
                <asp:BoundField DataField="使用权限" HeaderText="使用权限"/>
                <asp:BoundField DataField="性别" HeaderText="性别"/>
                <asp:BoundField DataField="注册时间" HeaderText="注册时间"/>
                <asp:BoundField DataField="登录时间" HeaderText="登录时间"/>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
        
        <asp:ObjectDataSource ID="ObjectDataSource_DetailStaff" runat="server" 
            TypeName="InfoSpace.HandleStaff" DataObjectTypeName="InfoSpace.Staffpara" 
            DeleteMethod="DelStaff" SelectMethod="GetStaffDetails" 
            UpdateMethod="UpdateStaff" 
            onselecting="ObjectDataSource_DetailStaff_Selecting" 
            ondeleted="ObjectDataSource_DetailStaff_Deleted" 
            onupdating="ObjectDataSource_DetailStaff_Updating" 
            onupdated="ObjectDataSource_DetailStaff_Updated">
            <SelectParameters>
                <asp:ControlParameter ControlID="GdStaffInfo" Name="loginName" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            
        </asp:ObjectDataSource>
    </div>
</asp:Content>

