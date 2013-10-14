using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class ChemElement : System.Web.UI.Page
{
    public class ElementInfo
    {
        public string SIndex { get; set; }
        public string SEleName { get; set; }
        public string SGateUp { get; set; }
        public string SGateDown { get; set; }
    }

    List<ElementInfo> EleList = new List<ElementInfo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowElementInfo();

            Master.labelopen.Text = "管理化检数据>";
        }
    }

    //保存化学元素数据
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!Chkval())
        {
            Master.labelopen.Text = "请输入相关信息!";
            return;
        }

        SqlConnection sqlcon = null;
        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [元素信息] (元素名称,检测门限上限,检测门限下限) VALUES('");
            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxElemName.Value.Trim()).Append("','");

            if (TxGateUp.Value.Trim().Length != 0)
                sql.Append(float.Parse(TxGateUp.Value.Trim())).Append("','");

            if (TxGateDown.Value.Trim().Length != 0)
                sql.Append(float.Parse(TxGateDown.Value.Trim())).Append("')");
            else
                sql.Append("')");

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
                Master.labvalue.Text = "成功添加名称为 " + TxElemName.Value.Trim() + " 的元素";
                //显示所有元素
                ShowElementInfo();
            }

        }//using

    }


    //删除化学元素信息
    protected void BtnDelClick(object sender, EventArgs e)
    {
        string SElement = TxElemName.Value.Trim();

        if (SElement.Length == 0)
        {
            Master.labvalue.Text = "元素名称不能为空!";
            return;
        }

        SqlConnection sqlcon = null;

        string sqlCmd = string.Format("DELETE FROM [元素信息] WHERE 元素名称='{0}'", SElement);

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
                Master.labvalue.Text = ex.Message;
            }

            if (NResult > 0)
            {
                Master.labelopen.Text = "成功删除名称为 " + SElement.Trim() + " 的元素";
                //显示所有元素
                ShowElementInfo();
            }

        }//using
    }


    //显示
    public void ShowElementInfo()
    {
        string sqlcmd = string.Format("SELECT * FROM [元素信息] ORDER BY 序号");

        GdElementInfo.DataSource = null;
        GdElementInfo.DataBind();

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
                    ElementInfo ele = new ElementInfo();

                    ele.SIndex = reader["序号"].ToString();
                    ele.SEleName = reader["元素名称"].ToString();
                    ele.SGateUp = reader["检测门限上限"].ToString();
                    ele.SGateDown = reader["检测门限下限"].ToString();
                    EleList.Add(ele);
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

        }//using

        if (EleList.Count > 0)
        {
            GdElementInfo.DataSource = EleList;
            GdElementInfo.DataBind();

            Master.labelopen.Text = " 共有" + EleList.Count.ToString() + "种元素";
        }
        else
        {
            Master.labelopen.Text = "没有元素信息";
        }

    }


    //检测有效性
    public bool Chkval()
    {
        if (TxElemName.Value.Trim().Length == 0)
            return false;

        if (TxGateDown.Value.Trim().Length == 0 && TxGateUp.Value.Trim().Length == 0)
            return false;

        return true;
    }

}