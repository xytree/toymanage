using System;
using System.Data.SqlClient;
using System.Text;
using InfoSpace;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HandleCost : System.Web.UI.Page
{
    protected List<ProInfo> ListProInfo = new List<ProInfo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "费用查询>";

            //添加消息,显示日历控件
            TxBeginDate.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv1').style.display = \"block\";");

            //添加消息,显示日历控件
            TxEndDate.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv2').style.display = \"block\";"); 
        }
    }

    //统计信息
    protected void BtnFind_Click(object sender, EventArgs e)
    {
        bool bRecv = false;
        bRecv = DListBRecv.Text.Trim() == "是";

        //string BTime = datepicker1.Value.Trim();    //起始时间
        //string FTime = datepicker2.Value.Trim();    //终止时间

        //string BTime = Request.Form.Get("datepicker1").Trim();
        //string FTime = Request.Form.Get("datepicker2").Trim();

        string BTime = TxBeginDate.Value.Trim();
        string FTime = TxEndDate.Value.Trim();

        GridCostInfo.DataSource = null;
        GridCostInfo.DataBind();

        SqlConnection sqlcon = null;
        SqlDataReader reader = null;

        string szCom = string.Format(@"SELECT 报检信息.报检号,报检单位,送样单位,是否到账,合计价格 FROM [报检信息] JOIN [费用信息]
            ON 报检信息.报检号=费用信息.报检号  
            WHERE 是否到账='{0}'", bRecv.ToString());

        StringBuilder sql = new StringBuilder(szCom);

        //根据时间查找
        if (BTime.Length != 0 && FTime.Length != 0)
        {
            sql.Append(" AND 录入时间 BETWEEN'").Append(BTime).Append("' AND '").Append(FTime).Append("'");
        }

        sql.Append("ORDER BY 报检信息.报检号");

        string szSql = sql.ToString();

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            SqlCommand cmd = new SqlCommand(szSql, sqlcon);

            try
            {
                sqlcon.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProInfo mProInfo = new ProInfo();

                    mProInfo.SSerial = reader["报检号"].ToString();
                    mProInfo.SCorpRep = reader["报检单位"].ToString();
                    mProInfo.SCorpSend = reader["送样单位"].ToString();
                    mProInfo.BPay = bool.Parse(reader["是否到账"].ToString());
                    mProInfo.FCostAll = float.Parse(reader["合计价格"].ToString());

                    ListProInfo.Add(mProInfo);
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

            if (ListProInfo.Count > 0)
            {
                GridCostInfo.DataSource = ListProInfo;
                GridCostInfo.DataBind();

                Master.labvalue.Text = "共有符合条件的条目" + ListProInfo.Count.ToString() + "批";

                float FPriceSum = 0.0F;
                for (int i = 0; i < ListProInfo.Count; i++)
                {
                    FPriceSum += ListProInfo[i].FCostAll;
                }

                Master.labvalue.Text += " 价格共计:" + FPriceSum.ToString() + "元";
            }
            else
            {
                Master.labvalue.Text = "没有找到匹配项";
            }

        }//using
    }

    //数据绑定后激发
    protected void GridCostInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    //创建行之前调用
    protected void GridCostInfo_RowCreated(object sender, GridViewRowEventArgs e)
    {
        Button btn = null;

        if (this.DListBRecv.SelectedValue == "是")
        {
            btn = (Button)e.Row.Cells[5].FindControl("BtnPay");
            if (btn != null)
                btn.Text = "取消收费";
        }
    }

    //响应到账按钮
    protected void BtnPay_Click(object sender, EventArgs e)
    {
        //取得当前选中的行
        int nRet = -1;
        Button btn = (Button) sender;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        string nIndex = row.Cells[0].Text;

        SqlConnection sqlcon = null;

        string szCmd = string.Format(@"UPDATE [费用信息] SET 是否到账=@是否到账
                        WHERE 报检号=@报检号");

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            //创建命令对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = szCmd;

            cmd.Parameters.AddWithValue("@报检号", nIndex);
            if (btn.Text == "到账确认")
                cmd.Parameters.AddWithValue("@是否到账", true);
            else
                cmd.Parameters.AddWithValue("@是否到账", false);

            try
            {
                sqlcon.Open();
                nRet = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
            }

        }//using

        //按键无效
        if (btn.Text == "到账确认")
            btn.Text = "取消收费";
        else
            btn.Text = "到账确认";
    }

    //选择不同的日期
    protected void CalendarBegin_SelectionChanged(object sender, EventArgs e)
    {
        TxBeginDate.Value = CalendarBegin.SelectedDate.ToString("yyyy-MM-dd");
        CalendarBegin.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarBegin').style.display=\"none\";");
    }

    protected void CalendarBegin_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal1, UpdateCal1.GetType(), "key", "document.getElementById('Calendardiv1').style.display=\"block\";", true);
    }


    //选择不同的日期
    protected void CalendarEnd_SelectionChanged(object sender, EventArgs e)
    {
        TxEndDate.Value = CalendarEnd.SelectedDate.ToString("yyyy-MM-dd");
        CalendarEnd.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarEnd').style.display=\"none\";");
    }

    protected void CalendarEnd_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal2, UpdateCal2.GetType(), "key", "document.getElementById('Calendardiv2').style.display=\"block\";", true);
    }
}