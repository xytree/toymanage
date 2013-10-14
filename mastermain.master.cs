using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mastermain : System.Web.UI.MasterPage
{
    //设置label公共属性
    public Label labelopen
    {
        get { return Label_Status; }
        set { Label_Status = value; }
    }

    public  Label labvalue
    {
        get { return Label_Value; }
        set { Label_Value = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
