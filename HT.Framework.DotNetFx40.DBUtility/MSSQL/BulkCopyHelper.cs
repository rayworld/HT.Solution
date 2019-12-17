using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HT.Framework.DotNetFx4.DBUtility.MSSQL
{
    public static class BulkCopyHelper
    {
        #region SqlBulkCopy批量插入数据
        /// <summary>
        /// 执行SqlBulkCopy批量插入，执行事务。
        /// </summary>
        /// <param name="connectionString">数据连接</param>
        /// <param name="TableName">表名</param>
        /// <param name="dt">要插入的数据</param>
        /// <returns></returns>
        public static int SqlBulkCopy(string connectionString, string TableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.UseInternalTransaction))
                {
                    try
                    {
                        sqlbulkcopy.DestinationTableName = TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                        return 1;
                    }
                    catch (System.Exception ex)
                    {
                        return 0;
                    }
                }
            }
        }
        /// <summary>  
        /// 批量插入  
        /// </summary>  
        /// <typeparam name="T">泛型集合的类型</typeparam>  
        /// <param name="conn">连接对象</param>  
        /// <param name="tableName">将泛型集合插入到本地数据库表的表名</param>  
        /// <param name="list">要插入大泛型集合</param>  
        public static void BulkInsert<T>(SqlConnection conn, string tableName, IList<T> list)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open(); //打开Connection连接  
            }
            using (var bulkCopy = new SqlBulkCopy(conn))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))

                    .Cast<PropertyDescriptor>()
                    .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                    .ToArray();

                foreach (var propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }

                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close(); //关闭Connection连接  
            }
        }
        #endregion
    }
}
