<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="ChemBaseline.aspx.cs" Inherits="ChemBaseline" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/buju.css" rel="stylesheet" type="text/css">
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div style="margin: 5px">
        <span>
                <span>
                <asp:DropDownList ID="DListChkBaseLine" runat="server" 
                    onselectedindexchanged="DListChkBaseLine_SelectedIndexChanged" 
                    AutoPostBack="True" Width="150px">
                </asp:DropDownList>
                <asp:Button ID="BtnDelTable" runat="server" Text="删除检验方法" 
                    onclick="BtnDelTable_Click" />
                </span>
                <span style="padding: 0px 0px 0px 20px">
                <asp:Label ID="Lable1" runat="server" Text="数据标准名称:" Font-Names="楷体"></asp:Label>
                <asp:TextBox ID="TxBaselinName" runat="server" CssClass="in_ra"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="数据表名称:" Font-Names="楷体"></asp:Label>
                <asp:TextBox ID="TxTableName" runat="server" CssClass="in_ra"></asp:TextBox>
                <asp:Button ID="BtnAddTable" runat="server" Text="添加检验方法" 
                    onclick="BtnAddTable_Click" />
                </span>
        </span>
        <table width="590" cellspacing="0" cellpadding="0" class="table" align="left" 
            style="margin-bottom: 10px; margin-top: 10px;">
            <tr >
                <td width=15% class="td1" height="35"> 元素名称 </td>
                <td width=35% class="td2" colspan="3"><input type="text" name="corpnum" id="TxElemName" runat="server" class="in" /></td>
            </tr>
            <tr >
                <td width=15% class="td1" height="35"> 检测上限 </td>
                <td width=35% class="td2"><input type="text" name="corpnum" id="TxGateUp" runat="server" class="in" /></td>
                <td width=15% class="td1" height="35"> 检测下限 </td>
                <td width=35% class="td2"><input type="text" name="corpnum" id="TxGateDown" runat="server" class="in" /></td>
            </tr>
            <tr>
                <td height="45" colspan="4" class="td3">
                    <input id="BtnSaveDepart" type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                    OnServerClick="BtnSaveClick"/>
                </td>
            </tr>
         </table>
    </div>

    <div style="margin: 5px" align="center">
        <asp:GridView ID="GdShowInfo" runat="server" CssClass="datalist" Width="100%" 
            AllowPaging="True" DataSourceID="ObjDataEle" DataKeyNames="元素名称">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjDataEle" runat="server" 
            DataObjectTypeName="InfoSpace.ElementInfo" DeleteMethod="DelEleInfo" 
            SelectMethod="GetElementInfo" TypeName="InfoSpace.HandleChemElement" 
            UpdateMethod="UpdateEleInfo" onselecting="ObjDataEle_Selecting" 
            onupdating="ObjDataEle_Updating" ondeleting="ObjDataEle_Deleting">
            <SelectParameters>
                <asp:ControlParameter ControlID="DListChkBaseLine" Name="basename" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
            
        </asp:ObjectDataSource>
    </div>

</asp:Content>

