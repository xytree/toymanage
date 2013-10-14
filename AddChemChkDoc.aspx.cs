using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;

public partial class AddChemChkDoc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "生成化学检验单>";

            //默认输入人
            TxInputMan.Value = Session["CurrentUser"].ToString();

            //添加报检时间，当前日期+15日
            TxFinishDate.Text = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");

            //添加消息,显示日历控件
            TxFinishDate.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv').style.display = \"block\";"); 
        }
    }

    //保存化学检验任务单
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labvalue.Text = "请输入相关内容!";
            Master.labvalue.ForeColor = System.Drawing.Color.Red;
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [化学检验] (报检号,样品名称,样品数量,输入人,是否接收,
                                            截止日期) VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxnIndex.Value.Trim()).Append("','");
            sql.Append(TxSampleName.Value.Trim()).Append("','");
            sql.Append(TxSampleNum.Value.Trim()).Append("','");
            sql.Append(TxInputMan.Value.Trim()).Append("','");
            sql.Append(bool.Parse("false")).Append("','");
            sql.Append(TxFinishDate.Text.Trim()).Append("')");

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
                Master.labvalue.ForeColor = Color.Red;
            }

            if (NResult > 0)
            {
                Master.labvalue.Text = "成功生成报检号为 " + TxnIndex.Value.Trim() + " 的化学检验单";
                Master.labvalue.ForeColor = Color.RoyalBlue;
            }

        }//using
    }

    //检验输入值
    private bool ChkValid()
    {
        if (TxnIndex.Value.Trim().Length == 0)
            return false;

        if (TxSampleName.Value.Trim().Length == 0)
            return false;

        if (TxSampleNum.Value.Trim().Length == 0)
            return false;

        if (TxInputMan.Value.Trim().Length == 0)
            return false;

        if (TxFinishDate.Text.Trim().Length == 0)
            return false;

        return true;
    }

    //选择不同的日期
    protected void CalendarFinish_SelectionChanged(object sender, EventArgs e)
    {
        TxFinishDate.Text = CalendarFinish.SelectedDate.ToString("yyyy-MM-dd");
        CalendarFinish.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarFinish').style.display=\"none\";");
    }

    protected void CalendarFinish_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv').style.display=\"block\";", true);
    }
}