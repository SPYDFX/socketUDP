using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DbHelper
    {
        /// <summary>
        /// 获取数据库连接信息
        /// </summary>
        private static string strcon
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            }
        }

        /// <summary>
        /// 查询数据库获取指定表
        /// </summary>
        /// <param name="tbName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sqlStr)
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlStr, connection);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            connection.Close();
            connection.Dispose();
            return dt;
        }

        public static DataTable GetTableByCondition(string tableName)
        {
            string cmdStr = string.Format("select * from {0} ", tableName);
            return GetTable(cmdStr);
        }
        public static DataTable GetTableByCondition(string tbName, string strWhere)
        {
            string cmdStr = string.Format("select * from {0} where {1}", tbName, strWhere);
            return GetTable(cmdStr);
        }
        public static DataTable GetTableByCondition(string tbName, string strWhere,string strSelect)
        {
            string cmdStr = string.Format("select {2} from {0} where {1}", tbName, strWhere,strSelect);
            return GetTable(cmdStr);
        }

        public static int UpdateTable(string sqlStr)
        {
            int ret = 0;
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = new SqlCommand(sqlStr,connection);
            ret = cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
            connection.Dispose();
            return ret;
        }
        public static int UpdateTableByCondition(string tbName,string strWhere,string strSet)
        {
            string cmdStr = string.Format("update {0} set {1}  where {2}", tbName, strSet ,strWhere);
            return UpdateTable(cmdStr);
        }
    }
}
