using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class ChemBaseline : System.Web.UI.Page
{
    //属性
    public class BaseLineInfo
    {
        public string basename { get; set; }
        public string tablename { get; set; }
    }

    public List<string> listbasename = new List<string>();
    public List<BaseLineInfo> listbaseinfo = new List<BaseLineInfo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Master.labelopen.Text += "管理报检标准>";

            ReadTableInfo();
            DListChkBaseLine.DataSource = listbasename;
            DListChkBaseLine.DataBind();
        }
    }

    //添加元素信息
    protected void BtnSaveClick(object sender, EventArgs e)
    {
        ReadTableInfo();

        string tablename = "";          //当前选择的表名称
        for (int i = 0; i < listbaseinfo.Count; i++)
        {
            if (listbaseinfo[i].basename == this.DListChkBaseLine.SelectedValue)
                tablename = listbaseinfo[i].tablename;
        }

        //添加元素
        if (!Chkval())
        {
            Master.labvalue.Text = "请输入相关信息!";
            return;
        }

        SqlConnection sqlcon = null;
        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"INSERT INTO [{0}] (元素名称,检测上限,检测下限) VALUES('",tablename);

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

                //重新绑定,刷新显示
                ObjDataEle.Select();
                GdShowInfo.DataBind();
            }

        }//using

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

    //添加检验标准数据表
    protected void BtnAddTable_Click(object sender, EventArgs e)
    {
        //创建新的数据表
        //取得数据表名
        int NResult = -1;
        string tableName = TxTableName.Text.Trim();
        if (tableName.Trim().Length == 0)
        {
            Master.labvalue.Text = "请输入数据表名称!";
            return;
        }

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"CREATE TABLE {0} 
                            (序号 int IDENTITY NOT NULL,
                             元素名称  VARCHAR(15) PRIMARY KEY NOT NULL,
                             检测上限  FLOAT NULL,
                             检测下限  FLOAT NULL
                            );",tableName);

            SqlCommand cmd = new SqlCommand(szCom, sqlcon);

            try
            {
                sqlcon.Open();
                NResult = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
                return;                 //失败则退出函数
            }

            //向数据库表名表中添加项目

            szCom = string.Format(@"INSERT INTO [化学检验标准] (标准名称,库名称) VALUES('");
            StringBuilder sql = new StringBuilder(szCom);
            sql.Append(TxBaselinName.Text.Trim()).Append("','");
            sql.Append(tableName).Append("')");

            string sqlcmd = sql.ToString();
            cmd = new SqlCommand(sqlcmd, sqlcon);

            int nRet = -1;
            try
            {
                nRet = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
            }

            if (nRet > 0)
            {
                Master.labvalue.Text += "名称为 " + TxBaselinName.Text.Trim() + "的检验标准已生成";
            }

        }//using

        //重新显示
        ReadTableInfo();
        DListChkBaseLine.DataSource = listbasename;
        DListChkBaseLine.DataBind();
    }

    //删除检验标准数据表
    protected void BtnDelTable_Click(object sender, EventArgs e)
    {
        //删除数据表格
        string basename = DListChkBaseLine.SelectedItem.Text.Trim();
        if (basename.Length == 0)
        {
            Master.labvalue.Text = "需删除的表名不能为空";
            return;
        }

        ReadTableInfo();

        string tablename = "";
        for (int i = 0; i < listbaseinfo.Count; i++)
        {
            if (listbaseinfo[i].basename == basename)
                tablename = listbaseinfo[i].tablename;
        }

        if (tablename.Length == 0)
            return;

        SqlConnection sqlcon = null;

        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"DROP TABLE {0};", tablename);

            SqlCommand cmd = new SqlCommand(szCom, sqlcon);

            try
            {
                sqlcon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
                return;
            }

            //删除对应的表项
            szCom = string.Format(@"DELETE FROM [化学检验标准] WHERE 标准名称='{0}'",basename);

            cmd = new SqlCommand(szCom, sqlcon);

            int nRet = -1;
            try
            {
                nRet = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
            }

            if (nRet > 0)
            {
                Master.labvalue.Text += "已删除名称为 " + basename + "的检验标准";
            }
        }//using

        //重新显示
        ReadTableInfo();
        DListChkBaseLine.DataSource = listbasename;
        DListChkBaseLine.DataBind();
    }

    //读取化学检验数据表名称
    private void ReadTableInfo()
    {
        listbaseinfo.Clear();

        string sqlcmd = string.Format("SELECT * FROM [化学检验标准] ORDER BY 序号");

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
                    BaseLineInfo m_base = new BaseLineInfo();
                    m_base.basename = reader["标准名称"].ToString();
                    m_base.tablename = reader["库名称"].ToString();

                    listbaseinfo.Add(m_base);
                }
            }
            catch (Exception ex)
            {
                Master.labvalue.Text = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            for (int i = 0; i < listbaseinfo.Count; i++)
                listbasename.Add(listbaseinfo[i].basename);

        }//using

    }

    //选择不同的表
    protected void DListChkBaseLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        //根据不同的选择进行绑定
        ObjDataEle.Select();
        GdShowInfo.DataBind();
    }

    //更新之前处理
    protected void ObjDataEle_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        ReadTableInfo();

        string tablename = "";
        for (int i = 0; i < listbaseinfo.Count; i++)
        {
            if (listbaseinfo[i].basename == this.DListChkBaseLine.SelectedValue)
                tablename = listbaseinfo[i].tablename;
        }

        ((InfoSpace.ElementInfo) e.InputParameters[0]).数据表名 = tablename;
    }

    //显示前操作
    protected void ObjDataEle_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (e.InputParameters["basename"] == null)
            e.Cancel = true;
    }

    //删除前操作
    protected void ObjDataEle_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //删除前需要取得需删除数据所在的表名称
        ReadTableInfo();

        string tablename = "";
        for (int i = 0; i < listbaseinfo.Count; i++)
        {
            if (listbaseinfo[i].basename == this.DListChkBaseLine.SelectedValue)
                tablename = listbaseinfo[i].tablename;
        }

        ((InfoSpace.ElementInfo)e.InputParameters[0]).数据表名 = tablename;
    }
}