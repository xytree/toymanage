using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/*取得化学实验数据*/
namespace InfoSpace
{
    public class HandleChem
    {
        public HandleChem()
        {
        }

        public DataSet GetChemTable(string nBegin,string nEnd)
        {
            SqlConnection sqlcon = null;

            string szCmd = string.Format(@"SELECT 报检号,接收时间,检验结果文件 FROM [化学检验] WHERE 
                        报检号>=@beginnum AND 报检号<=@endnum");

            DataSet dschem = new DataSet();

            using (sqlcon = new SqlConnection(AppGlobe.SSqlConnetString))
            {
                //创建命令对象
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = szCmd;

                cmd.Parameters.Add("@beginnum", SqlDbType.NVarChar).Value = nBegin;
                cmd.Parameters.Add("@endnum", SqlDbType.NVarChar).Value = nEnd;

                SqlDataReader reader = null;

                try
                {
                    sqlcon.Open();
                    reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    dschem.Load(reader, LoadOption.OverwriteChanges, "化学检验");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

            }//using

            return dschem;

        }//函数
    }
}