using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace InfoSpace
{
    public class HandleChemElement
    {
        public string SRet { get; set; }
        public string TableName;
        public List<EleTableInfo> m_listtableinfo = new List<EleTableInfo>();

	    public HandleChemElement()
	    {
	        
	    }

        //Select 函数
        public DataSet GetElementInfo(string basename)
        {
            ReadTableInfo();

            string tablename = "";
            for (int i = 0; i < m_listtableinfo.Count; i++)
            {
                if (m_listtableinfo[i].SBaseLinName == basename)
                    tablename = m_listtableinfo[i].STableName;
            }

            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT * FROM [{0}]",tablename);

            //创建dataset对象
            DataSet dsEleInfo = new DataSet();

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                SqlDataReader reader = null;
                try
                {
                    sqlcon.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    dsEleInfo.Load(reader, LoadOption.OverwriteChanges, "元素信息");

                    SRet = string.Format("共查询到" + "条信息");
                }
                catch (Exception ex)
                {
                    SRet = ex.Message;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

            }//using

            return dsEleInfo;
        }

        //更新相应的记录
        public int UpdateEleInfo(ElementInfo eleinfo)
        {
            int nRet = 0;

            if (eleinfo.元素名称 == null || string.IsNullOrEmpty(eleinfo.元素名称.Trim()))
                return 0;

            if (eleinfo.检测上限 == null) eleinfo.检测上限 = string.Empty;
            if (eleinfo.检测下限 == null) eleinfo.检测下限 = string.Empty;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"UPDATE [{0}] SET 检测上限=@检测上限,检测下限=@检测下限
                        WHERE 元素名称=@元素名称",eleinfo.数据表名);

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@检测上限", eleinfo.检测上限);
                cmd.Parameters.AddWithValue("@检测下限", eleinfo.检测下限);
                cmd.Parameters.AddWithValue("@元素名称", eleinfo.元素名称);

                try
                {
                    sqlcon.Open();
                    nRet = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    SRet = ex.Message;
                }
            }//using

            return nRet;
        }

        //删除相应的记录
        public int DelEleInfo(ElementInfo eleinfo)
        {
            int nResult = 0;

            if (eleinfo.元素名称 == null || string.IsNullOrEmpty(eleinfo.元素名称.Trim()))
                return 0;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"DELETE FROM [{0}] WHERE 元素名称=@元素名称",eleinfo.数据表名);

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@元素名称", eleinfo.元素名称);

                sqlcon.Open();

                nResult = cmd.ExecuteNonQuery();
            }//using

            return nResult;
        }

        //读取化学检验数据表名称
        private void ReadTableInfo()
        {
            m_listtableinfo.Clear();

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
                        EleTableInfo m_base = new EleTableInfo();
                        m_base.SBaseLinName = reader["标准名称"].ToString();
                        m_base.STableName = reader["库名称"].ToString();

                        m_listtableinfo.Add(m_base);
                    }
                }
                catch (Exception ex)
                {
                    SRet = ex.Message;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

            }//using
        }

    }
}