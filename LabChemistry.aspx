<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="LabChemistry.aspx.cs" Inherits="LabChemistry" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div style="margin: 15px">
        <asp:Label ID="Label1" runat="server" Text="开始编号" Font-Names="楷体"></asp:Label>
        <asp:TextBox ID="TxBeignNum" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="结束编号" Font-Names="楷体"></asp:Label>
        <asp:TextBox ID="TxEndNum" runat="server"></asp:TextBox>
        <asp:Button ID="BtnFind" runat="server" Width="80px" Text="查找" Height="21px" 
            onclick="BtnFind_Click" />
    </div>
    <div style="margin: 15px">
        <asp:Label ID="Label3" runat="server" Text="检验结果" Font-Names="楷体"></asp:Label>
        <asp:FileUpload ID="FileUpExcel" CssClass="in_ra" runat="server" />
        <asp:Button ID="BtnUpload" runat="server" Text="提交检验结果" onclick="BtnUpload_Click" />
    </div>
    

    <div class="leftbox" style="width: 28%">
        <asp:GridView ID="GdChemsinfo" runat="server" CssClass="datalist" 
            ForeColor="Black" AllowPaging="True" 
            DataSourceID="ObjectDataSource_chemistry" PageSize="15" 
            AllowSorting="True" Width="100%" 
            onselectedindexchanged="GdChemsinfo_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="选择" />
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页" Mode="NumericFirstLast" 
                NextPageText="下一页" PreviousPageText="上一页" />
            <SelectedRowStyle BackColor="#009933" ForeColor="White" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjectDataSource_chemistry" runat="server" 
            onselected="ObjectDataSource_chemistry_Selected" 
            onselecting="ObjectDataSource_chemistry_Selecting" SelectMethod="GetChemTable" 
            TypeName="InfoSpace.HandleChem">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxBeignNum" Name="nBegin" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="TxEndNum" Name="nEnd" PropertyName="Text" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    
    <div class="rightbox" style="width: 70%" align="left">
        <asp:GridView ID="GridChemInfo" runat="server" CssClass="datalist" Width="98%" HorizontalAlign="Left" 
            ForeColor="Black">
        </asp:GridView>
    </div>

</asp:Content>

