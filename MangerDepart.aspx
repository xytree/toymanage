<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="MangerDepart.aspx.cs" Inherits="MangerDepart" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function ChkValue() {
            var btn = document.getElementById("cPMainContent_BtnDelDepart");
            var btninput = document.getElementById("cPMainContent_BtnSaveDepart");
            var f = function () {
                var txt = document.getElementById('cPMainContent_TxDepartName');
                if (txt.value.length == 0) {
                    alert('部门名不能为空!');
                    return false;
                }
                else {
                    return confirm("您确认要删除当前项目?");
                }
            };

            btn.onclick = f;

            var f1 = function () {
                var txt = document.getElementById('cPMainContent_TxDepartName');
                if (txt.value.length == 0) {
                    alert('部门名不能为空!');
                    return false;
                }
                else {
                    return true;
                }
            };
            btninput.onclick = f1;
        };
       
        window.onload = ChkValue;
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
    <div align="center" style="margin-top: 30px;margin-bottom: 20px;margin-left: 0px;" >
         <table width="390" cellspacing="0" cellpadding="0" class="table" align="center">
            <tr >
                <td width=15% class="td1" height="35"> 部门名称 </td>
                <td width=35% class="td2"><input type="text" name="corpnum" id="TxDepartName" runat="server" class="in" /></td>
            </tr>
            <tr>
            <td height="45" colspan="2" class="td3">
                <input id="BtnSaveDepart" type="submit" runat="server" class="blues" 
                    onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                OnServerClick="BtnSaveClick" style="width: 70px" value="保存"/>
                <input id="BtnDelDepart" type="submit" value="删除" runat="server" class="blues" 
                    onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
                 OnServerClick="BtnDelClick" style="width: 70px"/>
            </td>
            </tr>
         </table>
    </div>

    <div class="ShowInfoDiv" align="center">
        <asp:GridView ID="GdDepartName" runat="server" CssClass="datalist" 
            AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="NIndex" HeaderText="序号" SortExpression="NIndex" />
                <asp:BoundField DataField="name" HeaderText="部门名称" SortExpression="NIndex" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>

