using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FindItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //取当前时间
            DateBegin.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            DateEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //添加消息,显示日历控件
            DateBegin.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv1').style.display = \"block\";");
            
            //添加消息,显示日历控件
            DateEnd.Attributes.Add("onfocus", "JavaScript:document.getElementById('Calendardiv2').style.display = \"block\";"); 

        }
    }

    //查找按钮
    protected void BtnFind_Click(object sender, EventArgs e)
    {
        //重新绑定
        ObjDataSource_Find.Select();
        GdProinfo.DataBind();
    }

    //条目选择变化
    protected void GdProinfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailviewProinfo.ChangeMode(DetailsViewMode.ReadOnly);

        DetailviewProinfo.DataBind();
    }

    //执行详细查询前调用
    protected void DetailsDatasource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //如果参数为空则不进行查找
        if (e.InputParameters["nIndex"] == null)
            e.Cancel = true;
    }

    //列表数据控件在查询前进行参数检查
    protected void ObjDataSource_Find_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //参数不为空才进行查找
        if (e.InputParameters["begin"] == null || e.InputParameters["end"] == null)
            e.Cancel = true;
    }

    //选择完成后处理
    protected void DetailsDatasource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Master.labelopen.Text = e.Exception != null ? e.Exception.Message : "查询成功";
    }

    protected void DetailsDatasource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            Master.labelopen.Text += e.Exception.Message;
        }
        else
        {
            if ((int) e.ReturnValue == 0)
            {
                Master.labelopen.Text = "更新失败";
            }
            else
            {
                Master.labelopen.Text = "已成功更新报检号为" + e.ReturnValue.ToString() + "的项目";

                ObjDataSource_Find.Select();
                GdProinfo.DataBind();
            }
        }
    }

    //GridView切换页面时需进行操作
    protected void GdProinfo_PageIndexChanged(object sender, EventArgs e)
    {
        this.GdProinfo.SelectedIndex = 0;

        //转换为只读模式
        this.DetailviewProinfo.ChangeMode(DetailsViewMode.ReadOnly);
    }

    //排序时需进行操作
    protected void GdProinfo_Sorted(object sender, EventArgs e)
    {
        //转换为只读模式
        this.DetailviewProinfo.ChangeMode(DetailsViewMode.ReadOnly);
    }

    //数据绑定时进行操作
    protected void DetailviewProinfo_DataBound(object sender, EventArgs e)
    {
        if (this.DetailviewProinfo.CurrentMode == DetailsViewMode.Edit)
        {
            //当处于编辑模式时,不允许编辑报检号
            TextBox IndexBox = (TextBox) this.DetailviewProinfo.Rows[0].Cells[1].Controls[0];
            IndexBox.Enabled = false;
        }

        if (this.DetailviewProinfo.CurrentMode == DetailsViewMode.Edit)
        {
            DropDownList ddl = (DropDownList)DetailviewProinfo.FindControl("DListCorp");

            ddl.DataSource = ReadCorpInfo();
            ddl.DataBind();

            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.Trim() == this.GdProinfo.SelectedRow.Cells[2].Text.Trim())
                {
                    ddl.Items[i].Selected = true;
                }
            }
        }
    }

    //删除后重新绑定
    protected void DetailsDatasource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        this.GdProinfo.DataBind();
    }

    //绑定GridView后，立刻绑定Detailsview
    protected void GdProinfo_DataBound(object sender, EventArgs e)
    {
        this.GdProinfo.SelectedIndex = 0;

        //转换为只读模式
        this.DetailviewProinfo.ChangeMode(DetailsViewMode.ReadOnly);
        this.DetailviewProinfo.DataBind();
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
                Master.labvalue.Text = ex.Message;
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

    //更新前操作
    protected void DetailsDatasource_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        DropDownList ddl = (DropDownList)DetailviewProinfo.FindControl("DListCorp");

        ((InfoSpace.Itempara)e.InputParameters[0]).报检单位 = ddl.SelectedItem.Text;
    }

    //选择不同的日期
    protected void CalendarBegin_SelectionChanged(object sender, EventArgs e)
    {
        DateBegin.Text = CalendarBegin.SelectedDate.ToString("yyyy-MM-dd");
        CalendarBegin.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarBegin').style.display=\"none\";");
    }

    protected void CalendarBegin_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv1').style.display=\"block\";", true);
    }

    //选择不同的日期
    protected void CalendarEnd_SelectionChanged(object sender, EventArgs e)
    {
        DateEnd.Text = CalendarEnd.SelectedDate.ToString("yyyy-MM-dd");
        CalendarEnd.Attributes.Add("onblur", "javascript:document.getElementById('cPMainContent_CalendarEnd').style.display=\"none\";");
    }

    protected void CalendarEnd_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ScriptManager.RegisterStartupScript(UpdateCal, UpdateCal.GetType(), "key", "document.getElementById('Calendardiv2').style.display=\"block\";", true);
    }
}