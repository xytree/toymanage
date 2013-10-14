using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace InfoSpace
{
    public class HandleStaff
    {
        public string SRet = "";

        public HandleStaff()
        {
        }

        public DataSet GetStaffInfo()
        {
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT 登录名,用户名,部门 FROM [用户信息] ORDER BY 部门");

            DataSet dsstaff = new DataSet();

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

                    dsstaff.Load(reader, LoadOption.OverwriteChanges, "人员信息");
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

            return dsstaff;
        }


        //得到详细信息
        public DataSet GetStaffDetails(string loginName)
        {
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT 登录名,用户名,密码,部门,岗位,管理权限,使用权限,
                                        性别,年龄,注册时间,登录时间 FROM [用户信息] WHERE 登录名=@logname");


            //创建dataset对象
            DataSet dsdetails = new DataSet();

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.Add("@logname", SqlDbType.VarChar).Value = loginName;

                //
                SqlDataReader reader = null;

                try
                {
                    sqlcon.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    dsdetails.Load(reader, LoadOption.OverwriteChanges, "人员信息");
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

            return dsdetails;
        }


        //详细内容更新
        public int UpdateStaff(Staffpara staffinfo)
        {
            int nRet = 0;

            if (staffinfo.登录名 == null || string.IsNullOrEmpty(staffinfo.登录名.Trim()))
                return 0;

            if (staffinfo.用户名 == null) staffinfo.用户名 = string.Empty;
            if (staffinfo.使用权限 == null) staffinfo.使用权限 = string.Empty;
            if (staffinfo.密码 == null) staffinfo.密码 = string.Empty;
            if (staffinfo.岗位 == null) staffinfo.岗位 = string.Empty;
            if (staffinfo.年龄 == null) staffinfo.年龄 = string.Empty;
            if (staffinfo.性别 == null) staffinfo.性别 = string.Empty;
            if (staffinfo.注册时间 == null) staffinfo.注册时间 = string.Empty;
            if (staffinfo.登录名 == null) staffinfo.登录名 = string.Empty;
            if (staffinfo.登录时间 == null) staffinfo.登录时间 = string.Empty;
            if (staffinfo.管理权限 == null) staffinfo.管理权限 = string.Empty;
            if (staffinfo.部门 == null) staffinfo.部门 = string.Empty;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"UPDATE [用户信息] SET 用户名=@用户名,使用权限=@使用权限,密码=@密码,
                        岗位=@岗位,年龄=@年龄,性别=@性别,注册时间=@注册时间,
                        登录时间=@登录时间,管理权限=@管理权限,部门=@部门 
                        WHERE 登录名=@登录名");

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@用户名", staffinfo.用户名);
                cmd.Parameters.AddWithValue("@使用权限", staffinfo.使用权限);
                cmd.Parameters.AddWithValue("@密码", staffinfo.密码);
                cmd.Parameters.AddWithValue("@岗位", staffinfo.岗位);
                cmd.Parameters.AddWithValue("@年龄", staffinfo.年龄);
                cmd.Parameters.AddWithValue("@性别", staffinfo.性别);
                cmd.Parameters.AddWithValue("@注册时间", staffinfo.注册时间);
                cmd.Parameters.AddWithValue("@登录时间", staffinfo.登录时间);
                cmd.Parameters.AddWithValue("@管理权限", staffinfo.管理权限);
                cmd.Parameters.AddWithValue("@部门", staffinfo.部门);
                cmd.Parameters.AddWithValue("@登录名", staffinfo.登录名);

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


        //删除选定信息
        public int DelStaff(Staffpara delstaff)
        {
            int nRet = 0;

            if (delstaff.登录名 == null || string.IsNullOrEmpty(delstaff.登录名))
                return 0;

            //建立连接
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"DELETE FROM [用户信息] WHERE 登录名=@登录名");

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.AddWithValue("@登录名", delstaff.登录名);

                sqlcon.Open();

                nRet = cmd.ExecuteNonQuery();
            }//using

            return nRet;
        }
    }
}