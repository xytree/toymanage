using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class AddCorp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "添加报检单位>";
        }
    }

    protected void BtnSaveClick(object sender, EventArgs e)
    {
        if (!ChkValid())
        {
            Master.labvalue.Text = "相关输入信息不能为空";
            Master.labvalue.ForeColor = Color.Red;
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [报检单位] (单位编号,单位名称,联系人1,联系人2,联系地址1,
                                            联系地址2,联系电话)
                                            VALUES('");

            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxCorpNum.Value.Trim()).Append("','");
            sql.Append(TxCorpName.Value.Trim()).Append("','");
            sql.Append(TxContactMan1.Value.Trim()).Append("','");
            sql.Append(TxContactMan2.Value.Trim()).Append("','");
            sql.Append(TxAddress1.Value.Trim()).Append("','");
            sql.Append(TxAddress2.Value.Trim()).Append("','");
            sql.Append(TxPhoneNum.Value.Trim()).Append("')");

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
                Master.labvalue.Text = "成功添加名称为 " + TxCorpName.Value.Trim() + " 的用户信息";
                Master.labvalue.ForeColor = Color.RoyalBlue;
            }

        }//using
    }

    private bool ChkValid()
    {
        if (TxCorpNum.Value.Trim().Length == 0)
            return false;

        if (TxCorpName.Value.Trim().Length == 0)
            return false;

        if (TxAddress1.Value.Trim().Length == 0)
            return false;

        if (TxContactMan1.Value.Trim().Length == 0)
            return false;

        if (TxPhoneNum.Value.Trim().Length == 0)
            return false;

        return true;
    }
}