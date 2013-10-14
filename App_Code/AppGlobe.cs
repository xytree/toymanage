using System;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using InfoSpace;
using Microsoft.Office.Interop.Excel;

/// <summary>
///AppGlobe 定义全局使用的变量
/// </summary>
public class AppGlobe
{
    public static string ErrCode { get; set; }

	public AppGlobe()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //数据库连接字符串
    public readonly static String SSqlConnetString =
        WebConfigurationManager.AppSettings["SQLConnString"].ToString();

    public static List<string> ListDepartName = new List<string>();

    //操作

    //读取部门信息
    public static void ReadDepartName()
    {
        //清空原有的信息,重新读取内容
        ListDepartName.Clear();

        string sqlcmd = string.Format("SELECT * FROM [部门名称] ORDER BY 序号");

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
                    string Name = reader["部门名称"].ToString();
                    ListDepartName.Add(Name);
                }
            }
            catch (Exception ex)
            {
                ErrCode = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }//using
    }

    //获取检验规则
    static public List<string> GetBaseLineName()
    {
        List<string> m_list = new List<string>();

        m_list.Add("无");

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
                    string Name = reader["标准名称"].ToString();
                    m_list.Add(Name);
                }
            }
            catch (Exception ex)
            {
                ErrCode = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }//using

        if (m_list.Count == 0)
            return null;
        else
            return m_list;
    }

    //获取人员名单
    static public List<UserInfo> GetUserList()
    {
        List<UserInfo> m_list = new List<UserInfo>();

        string sqlcmd = string.Format("SELECT 登录名,用户名 FROM [用户信息 ] ORDER BY 序号");

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
                    UserInfo info = new UserInfo();
                    info.SLoginName = reader["登录名"].ToString();
                    info.SUserName = reader["用户名"].ToString();

                    m_list.Add(info);
                }
            }
            catch (Exception ex)
            {
                ErrCode = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }//using

        return m_list;
    }

    
    //获取单位名称
    static public List<string> GetCorpName()
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
               ErrCode = ex.Message;
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

        return listCorp;
    }

}