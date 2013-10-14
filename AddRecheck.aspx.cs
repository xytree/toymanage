using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class AddRecheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "输入复检信息>";
            TxInputdate.Value = DateTime.Now.ToString("yyyy-MM-dd");

            //添加消息,显示日历控件
            TxInputdate.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv').style.display = \"block\";"); 
        }
    }

    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labvalue.Text = "相关输入信息不能为空";
            return;
        }

        if (!IsRecheck())
        {
            Master.labvalue.Text = "没有匹配的报检数据,请检查报检号";
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [复检信息] (报检号,输入时间,输入人,单位名称,样品类型,
                                            样品数量,复检原因)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxRechkIndex.Value.Trim()).Append("','");
            sql.Append(TxInputdate.Value.Trim()).Append("','");
            sql.Append(TxInputman.Value.Trim()).Append("','");
            sql.Append(TxCorpName.Value.Trim()).Append("','");
            sql.Append(TxSampleType.Value.Trim()).Append("','");
            sql.Append(TxSampleNum.Value.Trim()).Append("','");
            if (TxReason.Value.Trim().Length != 0)
            {
                sql.Append(TxReason.Value.Trim()).Append("')");
            }
            else
            {
                sql.Append("未知").Append("')");
            }

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
                Master.labvalue.Text = "成功添加复检号为 " + TxRechkIndex.Value.Trim() + " 的信息";

        }//using

    }

    //检查数据是否合法
    private bool ChkValid()
    {
        if (TxRechkIndex.Value.Trim().Length == 0)
            return false;

        if (TxCorpName.Value.Trim().Length == 0)
            return false;

        if (TxInputdate.Value.Trim().Length == 0)
            return false;

        if (TxInputman.Value.Trim().Length == 0)
            return false;

        if (TxSampleType.Value.Trim().Length == 0)
            return false;

        if (TxSampleNum.Value.Trim().Length == 0)
            return false;

        return true;
    }

    //检查是否有匹配的报检
    private bool IsRecheck()
    {
        bool bRet = false;

        SqlConnection sqlcon = null;
        string sqlcmd = "SELECT * FROM [报检信息] WHERE 报检号=@reportnum";

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

            cmd.Parameters.AddWithValue("@reportnum", TxRechkIndex.Value.Trim());

            SqlDataReader reader = null;

            try
            {
                sqlcon.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    bRet = false;
                }
                else
                {
                    bRet = true;
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('无法连接数据库!')</script>");
                sqlcon.Close();
                return false;
            }

        }//using

        return bRet;
    }

    //选择不同的日期
    protected void CalendarInput_SelectionChanged(object sender, EventArgs e)
    {
        TxInputdate.Value = CalendarInput.SelectedDate.ToString("yyyy-MM-dd");
        CalendarInput.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarInput').style.display=\"none\";");
    }

    protected void CalendarInput_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv').style.display=\"block\";", true);
    }
}