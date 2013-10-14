using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using officecon;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.IO;


public partial class LabChemistry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ObjectDataSource_chemistry_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //参数不为空才进行查找
        if (e.InputParameters["nBegin"] == null || e.InputParameters["nEnd"] == null)
        {
            e.Cancel = true;
        }
    }


    protected void ObjectDataSource_chemistry_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            Master.labelopen.Text += e.Exception.Message;
        }
    }

    //加载相应的excel文件
    public DataTable LoadExcel(string strName)
    {
        #region 载入名为strname的Excel文件，并返回DataTable

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        OleDbConnection  objcon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            strName+";Extended Properties=\"Excel 8.0;HDR=YES\"");

        objcon.Open();

        DataTable schemaTable = objcon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,null);
        string tablename = schemaTable.Rows[1][2].ToString().Trim();    //获取表名
        tablename = "问题(question)$";

        string szSql = "SELECT * FROM[" + tablename.Replace('.','#') + "]";
        OleDbCommand objcmd = new OleDbCommand(szSql,objcon);
        OleDbDataAdapter objdata = new OleDbDataAdapter(szSql,objcon);

        objdata.Fill(ds, tablename);

        dt = ds.Tables[tablename];

        return dt;

        #endregion
    }


    /*上传相应的excel文件到服务器文件夹*/
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        int nRet = 0;
        string filename;

        try
        {
            if (FileUpExcel.PostedFile.FileName == "")
            {
                Master.labelopen.Text = "文件名不能为空!";
                return;
            }
            else
            {
                string filepath = FileUpExcel.PostedFile.FileName;
                //string filename = filepath.Substring(filepath.LastIndexOf("\\" + 1));
                string serverpath = Server.MapPath("Excel/") + filepath;

                //判断文件是否存在
                FileInfo fileinfo = new FileInfo(serverpath);
                try
                {
                    if (fileinfo.Exists)
                    {
                        Master.labelopen.Text = "文件已经存在";
                    }
                }
                catch (Exception ex)
                {
                    Master.labelopen.Text = ex.Message;
                    return;
                }

                FileUpExcel.PostedFile.SaveAs(serverpath);
                Master.labelopen.Text = "上传成功";
                filename = filepath;
            }
        }
        catch (Exception err)
        {
            Master.labelopen.Text = "发送错误!原因:" + err.ToString();
            return;
        }

        //将文件名记录到数据库
        string nIndex = GdChemsinfo.SelectedRow.Cells[1].Text;

        SqlConnection sqlcon = null;
        using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
        {
            string szCom = string.Format(@"UPDATE [化学检验] SET 检验结果文件=@文件名 WHERE 报检号=@报检号");
            //创建命令对象
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = szCom;

            cmd.Parameters.AddWithValue("@报检号",nIndex);
            cmd.Parameters.AddWithValue("@文件名",filename);

            try
            {
                sqlcon.Open();
                nRet = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Master.labelopen.Text = ex.Message;
            }

        }//using

    }

    /*选中项后显示对应的excel文件*/
    protected void GdChemsinfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //取得当前项目对应的文件名称
        string filename = GdChemsinfo.SelectedRow.Cells[3].Text;

        if (string.IsNullOrWhiteSpace(filename) || string.IsNullOrEmpty(filename)
            || filename == "&nbsp;")
        {
            //清空显示
            GridChemInfo.DataSource = null;
            GridChemInfo.DataBind();

            Master.labelopen.Text = "没有对应的检验结果!";
        }
        else
        {
            //ConWord mWord = new ConWord("LED任务单.doc");
            //mWord.Review();

            conExcel mExcel = new conExcel(filename);
            GridChemInfo.DataSource = LoadExcel(mExcel.FileName);
            GridChemInfo.DataBind();
        }
    }

    //搜索按钮
    protected void BtnFind_Click(object sender, EventArgs e)
    {
        //重新绑定
        this.ObjectDataSource_chemistry.Select();
        GdChemsinfo.DataBind();

        //清空显示
        GridChemInfo.DataSource = null;
        GridChemInfo.DataBind();
    }
}