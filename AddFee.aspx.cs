using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddFee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "费用情况输入>";
        }
    }

    //保存费用信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labvalue.Text = "相关信息不能为空";
            return;
        }

        bool bRecv = false;
        if (DListCostRecv.Text == "是")
            bRecv = true;
        else
            bRecv = false;

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [费用信息] (报检号,账户名称,货币单位,原始价格,优惠价格,
                                            合计价格,是否到账)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxReportNum.Value.Trim()).Append("','");
            sql.Append(TxCountName.Value.Trim()).Append("','");
            sql.Append(TxCurrency.Value.Trim()).Append("','");
            sql.Append(float.Parse(TxCostOriginal.Value.Trim())).Append("','");
            sql.Append(float.Parse(TxCostPrefer.Value.Trim())).Append("','");
            sql.Append(float.Parse(TxCostAll.Value.Trim())).Append("','");
            sql.Append(bRecv).Append("')");

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
                Master.labvalue.Text = "成功添加名称为 " + TxCountName.Value.Trim() + " 的账户信息";

        }//using
    }

    private bool ChkValid()
    {
        if (TxReportNum.Value.Trim().Length == 0)
            return false;

        if (TxCountName.Value.Trim().Length == 0)
            return false;

        if (TxCurrency.Value.Trim().Length == 0)
            return false;

        if (TxCostOriginal.Value.Trim().Length == 0)
            return false;

        if (TxCostPrefer.Value.Trim().Length == 0)
            return false;

        if (TxCostAll.Value.Trim().Length == 0)
            return false;

        return true;
    }
}