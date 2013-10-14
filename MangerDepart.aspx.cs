using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class MangerDepart : System.Web.UI.Page
{
    public class Departinfo
    {
        public string NIndex { get; set; }
        public string Name { get; set; }
    }

    public List<Departinfo> listdepart = new List<Departinfo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowDepartInfo();
        }
    }

    //添加部门信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (TxDepartName.Value.Trim().Length == 0)
        {
            Master.labvalue.Text = "部门名称不能为空";
            return;
        }

        SqlConnection sqlcon = null;
        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [部门名称] (部门名称) VALUES('");
            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxDepartName.Value.Trim()).Append("')");

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
                Master.labvalue.Text = ex.Message;
            }

            if (NResult > 0)
            {
                Master.labvalue.Text = "成功添加名称为 " + TxDepartName.Value.Trim() + " 的部门";

                //更新全局信息
                AppGlobe.ListDepartName.Add(TxDepartName.Value.Trim());
            }

        }//using

        ShowDepartInfo();
    }

    //删除部门信息
    protected void BtnDelClick(object sender, EventArgs e)
    {
        string departname = TxDepartName.Value.Trim();

        if (TxDepartName.Value.Trim().Length == 0)
        {
            Master.labvalue.Text = "部门名称不能为空";
            return;
        }

        SqlConnection sqlcon = null;

        string sqlCmd = string.Format("DELETE FROM [部门名称] WHERE 部门名称='{0}'", departname);

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            int NResult = -1;
            SqlCommand cmd = new SqlCommand(sqlCmd, sqlcon);

            try
            {
                sqlcon.Open();
                NResult = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labelopen.Text = ex.Message;
            }

            if (NResult > 0)
            {
                Master.labelopen.Text = "成功删除名称为 " + departname.Trim() + " 的部门";
                ShowDepartInfo();
                //更新全局数据
                AppGlobe.ListDepartName.Remove(departname.Trim());
            }
        }//using
    }

    //显示部门名称
    protected void ShowDepartInfo()
    {
        string sqlcmd = string.Format("SELECT * FROM [部门名称] ORDER BY 序号");

        GdDepartName.DataSource = null;
        GdDepartName.DataBind();

        SqlConnection sqlcon = null;
        SqlDataReader reader = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

            try
            {
                sqlcon.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Departinfo dep = new Departinfo();

                    dep.NIndex = reader["序号"].ToString();
                    dep.Name = reader["部门名称"].ToString();
                    listdepart.Add(dep);
                }
            }
            catch (Exception ex)
            {
                Master.labelopen.Text = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            if (listdepart.Count > 0)
            {
                GdDepartName.DataSource = listdepart;
                GdDepartName.DataBind();

                Master.labelopen.Text = " 共有" + listdepart.Count.ToString() + "部门";
            }
            else
            {
                Master.labelopen.Text = "没有部门信息";
            }
        }
    }
}