using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staffmanger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //GridView换页时需进行操作
    protected void GdStaffInfo_PageIndexChanged(object sender, EventArgs e)
    {
        this.GdStaffInfo.SelectedIndex = 0;

        //转换为只读模式
        this.DetailsView_StaffInfo.ChangeMode(DetailsViewMode.ReadOnly);
    }

    //排序时需进行操作
    protected void GdStaffInfo_Sorted(object sender, EventArgs e)
    {
        //转换为只读模式
        this.DetailsView_StaffInfo.ChangeMode(DetailsViewMode.ReadOnly);
    }

    //详细信息选择前调用
    protected void ObjectDataSource_DetailStaff_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //如果参数为空则不进行查找
        if (e.InputParameters["loginName"] == null)
            e.Cancel = true;
    }

    //根据选择的不同项目进行详细显示
    protected void GdStaffInfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DetailsView_StaffInfo.ChangeMode(DetailsViewMode.ReadOnly);
        this.DetailsView_StaffInfo.DataBind();
    }

    //数据绑定时调用
    protected void DetailsView_StaffInfo_DataBound(object sender, EventArgs e)
    {
        if (this.DetailsView_StaffInfo.CurrentMode == DetailsViewMode.Edit)
        {
            //当处于编辑模式时,不允许编辑登录名
            TextBox loginnamebox = (TextBox)this.DetailsView_StaffInfo.Rows[0].Cells[1].Controls[0];
            loginnamebox.Enabled = false;
        }

        if (this.DetailsView_StaffInfo.CurrentMode == DetailsViewMode.Edit)
        {
            DropDownList ddl = (DropDownList)DetailsView_StaffInfo.FindControl("DropListDepart");

            ddl.DataSource = AppGlobe.ListDepartName;
            ddl.DataBind();

            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.Trim() == this.GdStaffInfo.SelectedRow.Cells[3].Text.Trim())
                {
                    ddl.Items[i].Selected = true;
                }
            }
        }
    }

    //删除后重新绑定GridView
    protected void ObjectDataSource_DetailStaff_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        this.GdStaffInfo.DataBind();
    }

    //Gridview绑定后立刻显示详细信息
    protected void GdStaffInfo_DataBound(object sender, EventArgs e)
    {
        this.GdStaffInfo.SelectedIndex = 0;

        this.DetailsView_StaffInfo.ChangeMode(DetailsViewMode.ReadOnly);
        this.DetailsView_StaffInfo.DataBind();
    }

    //更新之前发生
    protected void DetailsView_StaffInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

    }
    

    //绑定下拉列表
    protected void DropListDepart_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //在更新前修改输入的内容
    protected void ObjectDataSource_DetailStaff_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        DropDownList ddl = (DropDownList)DetailsView_StaffInfo.FindControl("DropListDepart");

        ((InfoSpace.Staffpara) e.InputParameters[0]).部门 = ddl.SelectedItem.Text;
    }

    protected void ObjectDataSource_DetailStaff_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        ObjectDataSource_staff.Select();
        GdStaffInfo.DataBind();
    }
}