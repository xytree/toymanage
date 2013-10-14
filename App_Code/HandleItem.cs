using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using InfoSpace;

namespace InfoSpace
{
    public class HandleItem
    {
        public string sRet = "";

        public HandleItem()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet GetProinfo(string begin,string end)
        {
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT 报检号,报检单位,录入时间 FROM [报检信息] WHERE 
                        录入时间>=@begindate AND 录入时间<=@enddate");

            //创建dataset对象
            DataSet dsProinfo = new DataSet();

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.Add("@begindate", SqlDbType.Date).Value = begin;
                cmd.Parameters.Add("@enddate", SqlDbType.Date).Value = end;

                //
                SqlDataReader reader = null;

                try
                {
                    sqlcon.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    dsProinfo.Load(reader, LoadOption.OverwriteChanges, "报检信息");

                    sRet = string.Format("共查询到" + "条信息");
                }
                catch (Exception ex)
                {
                    sRet = ex.Message;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

            }//using

            return dsProinfo;
        }


        //详细信息
        public DataSet GetDetails(string nIndex)
        {
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT 报检号,录入人,录入时间,报检类型,报检单位,收样人,样品类型,
                        规格型号,样品数量,检测标准1,检测标准2,检测标准3,备注信息 FROM [报检信息] WHERE 报检号=@index");

            //创建dataset对象
            DataSet dsdetails = new DataSet();

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.Add("@index", SqlDbType.VarChar).Value = nIndex;

                //
                SqlDataReader reader = null;

                try
                {
                    sqlcon.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    dsdetails.Load(reader, LoadOption.OverwriteChanges, "详细信息");
                }
                catch (Exception ex)
                {
                    sRet = ex.Message;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

            }//using

            return dsdetails;
        }

        
        //详细内容更新
        public int UpdateItem(Itempara miteminfo)
        {
            int nRet = 0;

            if (miteminfo.报检号 == null || string.IsNullOrEmpty(miteminfo.报检号.Trim()))
                return 0;

            if (miteminfo.备注信息 == null) miteminfo.备注信息 = string.Empty;

            if (miteminfo.录入人 == null) miteminfo.录入人 = string.Empty;

            if (miteminfo.录入时间 == null) miteminfo.录入时间 = DateTime.Now.ToString("yyyy-MM-dd");

            if (miteminfo.报检单位 == null) miteminfo.报检单位 = string.Empty;

            if (miteminfo.报检类型 == null) miteminfo.报检类型 = string.Empty;

            if (miteminfo.收样人 == null) miteminfo.收样人 = string.Empty;

            if (miteminfo.样品类型 == null) miteminfo.样品类型 = string.Empty;

            if (miteminfo.检测标准1 == null) miteminfo.检测标准1 = string.Empty;

            if (miteminfo.规格型号 == null) miteminfo.规格型号 = string.Empty;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"UPDATE [报检信息] SET 录入人=@录入人,录入时间=@录入时间,报检类型=@报检类型,
                        报检单位=@报检单位,收样人=@收样人,样品类型=@样品类型,规格型号=@规格型号,
                        样品数量=@样品数量,检测标准1=@检测标准1,检测标准2=@检测标准2,检测标准3=@检测标准3,备注信息=@备注信息 
                        WHERE 报检号=@报检号");

            //新建参数

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@报检号", miteminfo.报检号);
                cmd.Parameters.AddWithValue("@录入人", miteminfo.录入人);
                cmd.Parameters.AddWithValue("@录入时间", miteminfo.录入时间);
                cmd.Parameters.AddWithValue("@报检类型", miteminfo.报检类型);
                cmd.Parameters.AddWithValue("@报检单位", miteminfo.报检单位);
                cmd.Parameters.AddWithValue("@收样人", miteminfo.收样人);
                cmd.Parameters.AddWithValue("@样品类型", miteminfo.样品类型);
                cmd.Parameters.AddWithValue("@规格型号", miteminfo.规格型号);
                cmd.Parameters.AddWithValue("@样品数量", miteminfo.样品数量);
                cmd.Parameters.AddWithValue("@检测标准1", miteminfo.检测标准1);
                cmd.Parameters.AddWithValue("@检测标准2", miteminfo.检测标准2);
                cmd.Parameters.AddWithValue("@检测标准3", miteminfo.检测标准3);
                cmd.Parameters.AddWithValue("@备注信息", miteminfo.备注信息);

                try
                {
                    sqlcon.Open();
                    nRet = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }//using

            return nRet;
        }

        //删除当前的项目,删除项目时必须指定主键
        public int DeleteItem(Itempara miteminfodel)
        {
            int result = 0;

            if (miteminfodel.报检号 == null || string.IsNullOrEmpty(miteminfodel.报检号.Trim()))
                return 0;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"DELETE FROM [报检信息] WHERE 报检号=@报检号");

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@报检号", miteminfodel.报检号);

                sqlcon.Open();

                result = cmd.ExecuteNonQuery();

            }//using

            return result;
        }

    }
}