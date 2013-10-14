using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AddUser : System.Web.UI.Page
{
    List<string> listdepart = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //无管理权限
            if (Session["ManagerAuty"] != null)
            {
                //C#中重载了string类的 == 符号，作用相当于Equals()
                if (Session["ManagerAuty"].ToString() == "无")
                    this.Response.Redirect("ErrPage.aspx");
            }

            Master.labelopen.Text += "添加用户>";

            //绑定部门信息
            DListDepart.DataSource = AppGlobe.ListDepartName;
            DListDepart.DataBind();
        }
    }

    //保存人员信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labelopen.Text += "相关信息不能为空";
            return;
        }

        if (TxPasswd.Value.Trim() != TxpasswdAss.Value.Trim())
        {
            Master.labelopen.Text += "两次输入的密码不一致";
            return;
        }

        SqlConnection sqlcon = null;
        
        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [用户信息] (登录名,用户名,密码,部门,管理权限,
                                            使用权限,岗位,注册时间,登录时间)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxLogName.Value.Trim()).Append("','");
            sql.Append(TxName.Value.Trim()).Append("','");
            sql.Append(TxPasswd.Value.Trim()).Append("','");
            sql.Append(DListDepart.Text.Trim()).Append("','");
            sql.Append(DListManageAuthority.Text.Trim()).Append("','");
            sql.Append(DListUseAuthority.Text.Trim()).Append("','");
            sql.Append(TxPosition.Value.Trim()).Append("','");
            sql.Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("','");
            sql.Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("')");

            string sqlcmd = sql.ToString();
            SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

            int NResult = -1;
            try
            {
                sqlcon.Open();
                NResult = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labelopen.Text += ex.Message;
            }

            if (NResult > 0)
                Master.labelopen.Text += "成功添加名称为 " + TxName.Value.Trim() + " 的用户信息";

        }//using
    }

    private bool ChkValid()
    {
        if (TxName.Value.Trim().Length == 0)
            return false;

        if (TxPasswd.Value.Trim().Length == 0)
            return false;

        return true;
    }

}