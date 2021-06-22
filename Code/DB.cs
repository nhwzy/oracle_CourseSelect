using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

namespace 小型管理信息系统.Code
{
    public class DB
    {
        public DB()
        {
        }

        public static OracleConnection Open()
        {
            try
            {
                String sql = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=wangziyao;Password=wzysgdbd52;";
                OracleConnection cnt = new OracleConnection(sql);
                cnt.Open();
                return cnt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //关闭数据库
        public static void Close(OracleConnection cnt)
        {
            if (cnt != null)
            {
                try
                {
                    cnt.Close();
                    cnt.Dispose();
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
        }
        // 搜索数据库
        public static OracleDataReader Search(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //检查数据
        public static bool IsExist(string tablename, string key, string keyvalue)
        {
            OracleConnection cnt = Open();
            string sql = "select * from [dbo].[" + tablename + "] where " + key + "='" + keyvalue + " ' ";
            OracleCommand cmd = new OracleCommand(sql, cnt);
            OracleDataReader reader = cmd.ExecuteReader();
            bool res = reader.Read();
            reader.Close();
            if (res)
                return true;
            else
                return false;
        }
        //插入数据
        public static bool Insert(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }
        //从数据库中获得数据
        public static DataTable getData(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }
        //从DataTable内容筛数据
        public static DataTable getData(DataTable dt, string exp)
        {
            DataRow[] dataRows;
            DataTable subdt = dt.Clone();
            try
            {
                dataRows = dt.Select(exp);
                int len = dataRows.Length;
                for (int i = 0; i < len; i++)
                {
                    subdt.ImportRow(dataRows[i]);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return subdt;
        }


        //删除
        public static bool Delete(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }
        //清空表
        public static bool Truncate(string tablename)
        {
            string sql = "truncate  table [dbo].[" + tablename + "]";
            int count = 0;
            DataTable dt = new DataTable();
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                count = adapter.Fill(dt);
                if (count == 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }
        }
        //更新
        public static bool Update(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}