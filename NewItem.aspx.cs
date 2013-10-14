using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InfoSpace;

public partial class NewItem : System.Web.UI.Page
{
    //属性
    public List<string> ListBaseLineName = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "添加报检信息>";

            //添加报检时间，当前日期
            TxInputTime.Value = DateTime.Now.ToString("yyyy-MM-dd");

            //设置单位名称
            DListCorp.DataSource = ReadCorpInfo();
            DListCorp.DataBind();

            //设置检测标准名称
            DListChkStand1.DataSource = AppGlobe.GetBaseLineName();
            DListChkStand1.DataBind();

            DListChkStand2.DataSource = AppGlobe.GetBaseLineName();
            DListChkStand2.DataBind();

            DListChkStand3.DataSource = AppGlobe.GetBaseLineName();
            DListChkStand3.DataBind();

            //获取登录的用户名
            TxInputman.Value = Session["CurrentUser"].ToString();

            //添加消息,显示日历控件
            TxInputTime.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv').style.display = \"block\";"); 
        }
    }

    //保存报检信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labvalue.Text = "相关信息不能为空";
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [报检信息] (报检号,录入人,录入时间,接样人,收样人,报检单位,报检标准,
                                            样品数量,检测标准1,检测标准2,检测标准3,样品类型)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxItemNum.Value.Trim()).Append("','");
            sql.Append(TxInputman.Value.Trim()).Append("','");
            sql.Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("','");
            sql.Append(TxGetMan.Value.Trim()).Append("','");
            sql.Append(TxRecvMan.Value.Trim()).Append("','");
            sql.Append(DListCorp.SelectedItem.Text.Trim()).Append("','");
            sql.Append(TxChkType.Value.Trim()).Append("','");
            sql.Append(TxSampleNum.Value.Trim()).Append("','");
            sql.Append(DListChkStand1.SelectedValue.Trim()).Append("','");
            sql.Append(DListChkStand2.SelectedValue.Trim()).Append("','");
            sql.Append(DListChkStand3.SelectedValue.Trim()).Append("','");
            sql.Append(TxSampleType.Value.Trim()).Append("')");

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
                Master.labvalue.Text = "成功添加报检号为 " + TxItemNum.Value.Trim() + " 的报检信息";

        }//using
    }

    private bool ChkValid()
    {
        if (TxItemNum.Value.Trim().Length == 0)
            return false;

        if (TxInputman.Value.Trim().Length == 0)
            return false;

        if (TxSampleType.Value.Trim().Length == 0)
            return false;

        if (TxInputTime.Value.Trim().Length == 0)
            return false;

        if (TxGetMan.Value.Trim().Length == 0)
            return false;

        if (TxSendType.Value.Trim().Length == 0)
            return false;

        if (TxChkType.Value.Trim().Length == 0)
            return false;

        if (TxSampleNum.Value.Trim().Length == 0)
            return false;

        if (TxCountName.Value.Trim().Length == 0)
            return false;

        if (TxFinishTime.Value.Trim().Length == 0)
            return false;
        
        return true;
    }

    //获取单位名称
    public List<string> ReadCorpInfo()
    {
        List<string> listCorp = new List<string>();

        string sqlcmd = string.Format("SELECT 单位名称 FROM [报检单位] ORDER BY 序号");

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
                    string Name = reader["单位名称"].ToString();
                    listCorp.Add(Name);
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

        if (listCorp.Count == 0)
            return null;
        else
            return listCorp;
    }

    //选择不同的日期
    protected void CalendarInput_SelectionChanged(object sender, EventArgs e)
    {
        TxInputTime.Value = CalendarInput.SelectedDate.ToString("yyyy-MM-dd");
        CalendarInput.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarInput').style.display=\"none\";");
    }

    protected void CalendarInput_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv').style.display=\"block\";", true);
    }
}