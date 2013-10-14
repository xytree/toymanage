using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //退出当前登录
    protected void BtnCancel_click(object sender, ImageClickEventArgs e)
    {
        //登录注销
        Session.Abandon();
        this.Response.Write("<script type='text/javascript'>window.parent.location.href='login.aspx';</script>");

        Response.End();
    }
}