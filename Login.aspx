<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%"  height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="561" style="background:url(imalog/lbg.gif)"><table width="940" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="238" style="background:url(imalog/login01.png)">&nbsp;</td>
          </tr>
          <tr>
            <td height="190"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="208" height="190" style="background:url(imalog/login02.jpg)">&nbsp;</td>
                <td width="518" style="background:url(imalog/login03.jpg)"><table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="40" height="40"><img src="imalog/user.gif" width="30" height="30"></td>
                    <td width="38" height="40" style="font-family: 黑体">用户</td>
                    <td width="242" height="40"><input type="text" name="TxtUserName" id="TxtUserName" runat="server" style="width:164px; height:32px; line-height:34px; background:url(imalog/inputbg.gif) repeat-x; border:solid 1px #d1d1d1; font-size:9pt; font-family:Verdana, Geneva, sans-serif;"></td>
                    </tr>
                  <tr>
                    <td height="40"><img src="imalog/password.gif" width="28" height="32"></td>
                    <td height="40" style="font-family: 黑体">密码</td>
                    <td height="40"><input type="password" name="Txpassword" id="Txpassword" runat="server" style="width:164px; height:32px; line-height:34px; background:url(imalog/inputbg.gif) repeat-x; border:solid 1px #d1d1d1; font-size:9pt; "></td>
                  </tr>
                  <tr>
                    <td height="40">&nbsp;</td>
                    <td height="40">&nbsp;</td>
                    <td height="40">
                        <asp:ImageButton ID="BtnLogin" runat="server" ImageUrl="~/imalog/login.gif" 
                            onclick="BtnLogin_Click" />
                    </td>
                  </tr>
                  <tr>
                      <td height="40"></td>
                      <td height="40"></td>
                      <td>
                       <asp:CheckBox ID="ChkRember" runat="server" Text="记住用户名" Checked="True" 
                          Width="200px" Font-Names="宋体" Font-Size="Smaller"/>
                      </td>
                  </tr>
                </table>
                </td>
                <td width="214" style="background:url(imalog/login04.jpg)" >&nbsp;</td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td height="133" style="background:url(imalog/login05.png)">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
