using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["pasword"] != null)
            {
                TxtUserName.Attributes["value"] = Request.Cookies["username"].Value;
                Txpassword.Attributes["value"] = Request.Cookies["pasword"].Value;
            }
        }

    }
    

    //登录按钮
    protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (TxtUserName.Value.Length == 0)
        {
            return;
        }

        if (IsLogValid())
        {
            //记录登录名和密码
            if (Request.Cookies["username"] == null)
            {
                if (ChkRember.Checked)
                {
                    //cookie 存储时间30天
                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["pasword"].Expires = DateTime.Now.AddDays(30);

                    Response.Cookies["username"].Value = TxtUserName.Value.Trim();
                    Response.Cookies["pasword"].Value = Txpassword.Value.Trim();
                }
            }

            //如果不勾选记录cookie 则删除
            if (!ChkRember.Checked)
            {
                HttpCookie aCookie;
                string cookiename;
                int count = Request.Cookies.Count;
                for (int i = 0; i < count; i++)
                {
                    cookiename = Request.Cookies[i].Name;
                    aCookie = new HttpCookie(cookiename);
                    aCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(aCookie);
                }
            }

            this.Response.Redirect("MainPage.aspx");
        }
    }


    //登录是否合法
    protected bool IsLogValid()
    {
        bool BValue = false;
        SqlConnection sqlcon = null;

        string sqlcmd = "SELECT * FROM [用户信息] WHERE 登录名=@username AND 密码=@password";

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 20);
            cmd.Parameters[0].Value = this.TxtUserName.Value.Trim();
            cmd.Parameters[1].Value = this.Txpassword.Value.Trim();

            SqlDataReader reader = null;

            try
            {
                sqlcon.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //没有符合的项
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('错误的用户名或密码!')</script>");
                    reader.Close();
                    return false;
                }
                else
                {
                    //登录成功,创建会话状态
                    reader.Read();                  //读取数据库

                    if (Session["CurrentUser"] != null)
                        Session.Clear();

                    Session["LoginName"] = TxtUserName.Value.Trim();
                    Session["CurrentUser"] = reader["用户名"].ToString();
                    Session["Department"] = reader["部门"].ToString();
                    Session["ManagerAuty"] = reader["管理权限"].ToString();
                    Session["UseManagerAuty"] = reader["使用权限"].ToString();
                }
            }
            catch (Exception e)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('无法连接数据库!')</script>");
                sqlcon.Close();
                return false;
            }

            BValue = true;
            reader.Close();
        }

        return BValue;
    }
}