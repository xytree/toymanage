<%@ Page Title="" Language="C#" MasterPageFile="~/mastermain.master" AutoEventWireup="true" CodeFile="newitem.aspx.cs" Inherits="NewItem" %>
<%@ MasterType VirtualPath="~/mastermain.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Gridview.css" rel="stylesheet" type="text/css"/>
    <link href="CSS/3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cPMainContent" Runat="Server">
        
    <script type="text/javascript">
        function IsValidInput() {
            var ob = document.getElementById("TxItemNum");
            if (ob.text.length == 0) {
                alert("请输入有效信息");
                return true;
            }
            return false;
        }

    </script>

    <div class="InputDiv">
        <table width="750" cellspacing="0" cellpadding="0" class="table" align="center">
        <tr >
        <td width="10%" class="td1" height="35"> 报检号*</td>
        <td width="23%" class="td2"><input type="text" name="TxItemNumBox"  id="TxItemNum" runat="server" class="in" /></td>
        <td width="10%" class="td1" height="35">录入人* </td>
        <td width="23%" class="td2"><input type="text" name="TxInputmanBox" id="TxInputman" runat="server" class="in" /></td>
        <td width="10%" class="td1" height="35"> 报验日期* </td>
        <td width="23%" class="td2">
            <asp:ScriptManager runat="server" ID="CalScripmanager"></asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="UpdateCal">
                <ContentTemplate> 
                <input type="text" name="TxInputTimeBox" id="TxInputTime" runat="server" class="in" />
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

        <tr>
        <td width="10%" class="td1" height="35"> 委托单位 </td>
        <td width="23%" class="td2" ><input type="text" name="TxGetManBox" id="TxGetMan" runat="server" class="in" /></td>
        <td width="10%" class="td1" height="35">联系人</td>
        <td width="23%" class="td2"><input type="text" name="TxContactManBox" id="TxContactMan" runat="server" class="in"/></td>
        </tr>

        <tr>
        <td width="10%" class="td1" height="35"> 送样单位 </td>
        <td width="23%" class="td2">
            <asp:DropDownList ID="DListCorp" runat="server" CssClass="in">
            </asp:DropDownList>
        </td>
        <td width="10%" class="td1">送样类型</td>
        <td width="23%" class="td2"><input type="text" name="TxSendTypeBox" id="TxSendType" runat="server" class="in"/></td>
        <td width="10%" class="td1">报检类型</td>
        <td width="23%" class="td2"><input type="text" name="TxChkTypeBox" id="TxChkType" runat="server" class="in"/></td>
        </tr>

        <tr>
        <td width="10%" class="td1" height="35"> 样品数量 </td>
        <td width="23%" class="td2"><input type="text" name="TxSampleNumBox" id="TxSampleNum" runat="server" class="in"/></td>
        <td width="10%" class="td1">样品类型</td>
        <td width="23%" class="td2"><input type="text" name="TxSampleTypeBox" id="TxSampleType" runat="server" class="in"/></td>            
        <td width="10%" class="td1">检测标准1</td>
        <td width="23%" class="td2">
            <asp:DropDownList ID="DListChkStand1" runat="server" CssClass="in">
            </asp:DropDownList>
        </td>
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">检测标准2</td>
        <td width="23%" class="td2">
            <asp:DropDownList ID="DListChkStand2" runat="server" CssClass="in">
            </asp:DropDownList>        
        </td>
        <td width="10%" class="td1" height="35">检测标准3</td>
        <td width="23%" class="td2">
            <asp:DropDownList ID="DListChkStand3" runat="server" CssClass="in">
            </asp:DropDownList>
        </td>        
        <td width="10%" class="td1" height="35">账户名称</td>
        <td width="23%" class="td2"><input type="text" name="TxCountNameBox" id="TxCountName" runat="server" class="in"/></td>            
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">样品名称</td>
        <td width="23%" class="td2"><input type="text" name="TxSampleNameBox" id="TxSampleName" runat="server" class="in"/></td>
        <td width="10%" class="td1" height="35">样品货号</td>
        <td width="23%" class="td2"><input type="text" name="TxSampleSerialBox" id="TxSampleSerial" runat="server" class="in"/></td>        
        <td width="10%" class="td1" height="35">样品描述</td>
        <td width="23%" class="td2"><input type="text" name="TxSampleInfoBox" id="TxSampleInfo" runat="server" class="in"/></td>            
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">证书类型</td>
        <td width="23%" class="td2"><input type="text" name="TxCertificateTypeBox" id="TxCertificateType" runat="server" class="in"/></td>
        <td width="10%" class="td1" height="35">要证日期</td>
        <td width="23%" class="td2"><input type="text" name="TxFinishTimeBox" id="TxFinishTime" runat="server" class="in"/></td>        
        <td width="10%" class="td1" height="35">接样人</td>
        <td width="23%" class="td2"><input type="text" name="TxRecvManBox" id="TxRecvMan" runat="server" class="in"/></td>            
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">费用原价</td>
        <td width="23%" class="td2"><input type="text" name="TxOriginalFeeBox" id="TxOriginalFee" runat="server" class="in"/></td>
        <td width="10%" class="td1" height="35">检验要求</td>
        <td width="23%" class="td2"><input type="text" name="TxChkDemandBox" id="TxChkDemand" runat="server" class="in"/></td>        
        <td width="10%" class="td1" height="35">加急费用</td>
        <td width="23%" class="td2"><input type="text" name="TxAcceleFeeBox" id="TxAcceleFee" runat="server" class="in"/></td>            
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">优惠费用</td>
        <td width="23%" class="td2"><input type="text" name="TxPreferFeeBox" id="TxPreferFee" runat="server" class="in"/></td>
        <td width="10%" class="td1" height="35">检验费(元)</td>
        <td width="23%" class="td2"><input type="text" name="TxChkFeeBox" id="TxChkFee" runat="server" class="in"/></td>        
        <td width="10%" class="td1" height="35">营销负责人</td>
        <td width="23%" class="td2"><input type="text" name="TxSellManBox" id="TxSellMan" runat="server" class="in"/></td>            
        </tr>
        
        <tr>
        <td width="10%" class="td1" height="35">外包机构</td>
        <td width="23%" class="td2"><input type="text" name="TxEpiboleBox" id="TxEpibole" runat="server" class="in"/></td>
        <td width="10%" class="td1" height="35">进口国</td>
        <td width="23%" class="td2"><input type="text" name="TxImportBox" id="TxImport" runat="server" class="in"/></td>        
        <td width="10%" class="td1" height="35">报价单编号</td>
        <td width="23%" class="td2"><input type="text" name="TxCostlistNumBox" id="TxCostlistNum" runat="server" class="in"/></td>            
        </tr>

        <tr>
        <td height="45" colspan="7" class="td3">
            <input type="button" runat="server" class="btn1" onmouseover="this.style.backgroundPosition='left -32px'" onmouseout="this.style.backgroundPosition='left top'"
            OnServerClick="BtnSaveClick"/>
        </td>
        </tr>
        </table>
    </div>
</asp:Content>