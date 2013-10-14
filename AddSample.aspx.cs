using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Drawing;

public partial class AddSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "添加样品信息>";

            TxRecvman.Value = Session["CurrentUser"].ToString();
            TxGetman.Value = Session["CurrentUser"].ToString();

            //添加输入时间，当前日期
            TxRecvtime.Value = DateTime.Now.ToString("yyyy-MM-dd");

            TxBatchnum.Value= "1";

            //读取单位信息
            DListCorpname.DataSource = AppGlobe.GetCorpName();
            DListCorpname.DataBind();

            //添加消息,显示日历控件
            TxRecvtime.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv').style.display = \"block\";"); 
        }
    }

    //保存样品信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!IsInputvalid())
        {
            Master.labvalue.Text = "相关输入信息不能为空";
            Master.labvalue.ForeColor = Color.Red;
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [样品信息] (样品批号,单位名称,收件人,接件人,快递公司,
                                            快递单号,收件时间,批次数)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxSampleIndex.Value.Trim()).Append("','");
            sql.Append(DListCorpname.SelectedValue.Trim()).Append("','");
            sql.Append(TxRecvman.Value.Trim()).Append("','");
            sql.Append(TxGetman.Value.Trim()).Append("','");
            sql.Append(DListSender.SelectedValue.Trim()).Append("','");
            sql.Append(TxSendnum.Value.Trim()).Append("','");
            sql.Append(TxRecvtime.Value.Trim()).Append("','");
            sql.Append(TxBatchnum.Value.Trim()).Append("')");

            string sqlcmd = sql.ToString();
            SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);

            int nResult = -1;
            try
            {
                sqlcon.Open();
                nResult = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.ForeColor = Color.Red;
                Master.labvalue.Text = ex.Message;
            }

            if (nResult > 0)
            {
                Master.labvalue.Text = "成功添加号为 " + TxSampleIndex.Value.Trim() + " 的样品信息";
                Master.labvalue.ForeColor = Color.RoyalBlue;
            }

        }//using

    }

    //检验输入是否合法
    private bool IsInputvalid()
    {
        bool bRet = true;

        if (TxSampleIndex.Value.Trim().Length == 0)
            return false;

        if (TxRecvman.Value.Trim().Length == 0)
            return false;

        if (TxGetman.Value.Trim().Length == 0)
            return false;

        if (TxRecvtime.Value.Trim().Length == 0)
            return false;

        if (TxRecvtime.Value.Trim().Length == 0)
            return false;

        return bRet;
    }

    //选择不同的日期
    protected void CalendarRecv_SelectionChanged(object sender, EventArgs e)
    {
        TxRecvtime.Value = CalendarRecv.SelectedDate.ToString("yyyy-MM-dd");
        CalendarRecv.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarRecv').style.display=\"none\";");
    }

    protected void CalendarRecv_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv').style.display=\"block\";", true);
    }
}