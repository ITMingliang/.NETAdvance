using Ant.DB.Interface;
using Models;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ant.DB.SQLServer
{
    public class SQLServerHelper : IDBHelper
    {

        private static readonly string connStsring = ConfigurationManager.ConnectionStrings["studentConn"].ConnectionString;
        public SQLServerHelper()
        {
            //Console.WriteLine("{0}被构造", this.GetType().Name);
        }


        public void Query()
        {
            //Console.WriteLine("{0}.Query", this.GetType().Name);
        }

        /// <summary>
        /// 根据ID查询对象
        /// </summary>
        /// <typeparam name="T">查询的对象</typeparam>
        /// <param name="id">对象ID</param>
        /// <returns></returns>
        public Students Find(int id)
        {
            string sql = $"SELECT [StudentId],[StudentName] ,[Gender] ,[Birthday] ,[AttendanceNO] ,[StuImage],[Age] ,[Phone] ,[StudentAddress] FROM [dbo].[Students] where StudentId={id}";

            using (SqlConnection conn=new SqlConnection(connStsring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                Students students=new Students();
                if (dataReader.Read())
                {
                    students.StudentId = Convert.ToInt32(dataReader["StudentId"]);
                    students.StudentName = dataReader["StudentName"].ToString();
                    students.Gender = dataReader["Gender"].ToString();
                    students.Birthday = Convert.ToDateTime(dataReader["Birthday"]);
                    students.AttendanceNO = dataReader["AttendanceNO"].ToString();
                    students.StuImage = dataReader["StuImage"].ToString();
                    students.Age = Convert.ToInt32(dataReader["Age"]);
                    students.Phone = dataReader["Phone"].ToString();
                    students.StudentAddress = dataReader["StudentAddress"].ToString();
                }
                dataReader.Close();
                return students;
            }
        }

        public T Find<T>(int id)
        {
            Type type = typeof(T);
            string sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => p.Name))} from {type.Name} where StudentId={id}";

            using (SqlConnection conn = new SqlConnection(connStsring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                //Students students = new Students();
                object oObject = Activator.CreateInstance(type);
                if (dataReader.Read())
                {

                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oObject, dataReader[prop.Name]);
                    }

                }
                dataReader.Close();
                return (T)oObject;
            }
        }



    }


}
